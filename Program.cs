using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using PFEBackend.Models;
using PFEBackend.Repository;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using PFEBackend;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add AzureAD authentication with a Bearer Token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

// Nécéssaire d'être connecté + d'avoir un rôle user ou administrator pour accéder à l'app.
builder.Services.AddControllers(
    options =>
    {
        var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
        .RequireRole("user", "administrator").RequireAssertion(handler => { return true; }).Build();
        options.Filters.Add(new AuthorizeFilter(policy));
        options.Filters.Add(new HttpResponseExceptionFilter());
    }).AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Connection à la DB
builder.Services.AddDbContext<VinciMarketContext>(options => 
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DB")
    )
);

// Ajout de CORS (sinon erreur frontend)
builder.Services.AddCors(opt =>

{

    opt.AddPolicy(name: "cors", builder =>

    {

        builder.AllowAnyOrigin()

        .AllowAnyHeader()

        .AllowAnyMethod();

    });

});

// Ajout du bind d'interface des repository
builder.Services.AddScoped<IRepositoryCategory, RepositoryCategory>();
builder.Services.AddScoped<IRepositoryOffer, RepositoryOffer>();
builder.Services.AddScoped<IRepositoryMedia, RepositoryMedia>();

var app = builder.Build();

app.UseHttpLogging();

// Configuration des CORS
app.UseCors("cors");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
    RequestPath = new PathString("/StaticFiles")
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
