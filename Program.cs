using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using PFEBackend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add AzureAD authentication with a Bearer Token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

// Nécéssaire d'être connecté + d'avoir un rôle user ou administrator pour accéder à l'app.
builder.Services.AddControllers(
    options =>
    {
        var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
        .RequireRole("user", "administrator")
        .Build();
        options.Filters.Add(new AuthorizeFilter(policy));
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection à la DB
builder.Services.AddDbContext<VinciMarketContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DB"))
        );

// Ajout de CORS (sinon erreur frontend)
builder.Services.AddCors();

var app = builder.Build();

// Configuration des CORS
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
