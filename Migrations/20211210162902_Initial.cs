using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFEBackend.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Place = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Seller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountReport = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Media_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, "Maison et Jardin", null },
                    { 7, "Famille", null },
                    { 12, "Vêtements et accessoires", null },
                    { 17, "Loisirs - hobbys", null },
                    { 26, "Electronique", null },
                    { 29, "Autres", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 2, "Outils", 1 },
                    { 3, "Meubles", 1 },
                    { 4, "Pour la maison", 1 },
                    { 5, "Jardin", 1 },
                    { 6, "Electroménager", 1 },
                    { 8, "Santé et beauté", 7 },
                    { 9, "Fournitures pour animaux", 7 },
                    { 10, "Puériculture et enfants", 7 },
                    { 11, "Jouets et jeux", 7 },
                    { 13, "Sacs et bagages", 12 },
                    { 14, "Vêtements et chaussures femmes", 12 },
                    { 15, "Vêtements et chaussures hommes", 12 },
                    { 16, "Bijoux et accessoires", 12 },
                    { 18, "Vélos", 17 },
                    { 19, "Loisirs créatifs", 17 },
                    { 20, "Pièces auto", 17 },
                    { 21, "Sports et activités d’extérieures", 17 },
                    { 22, "Jeux vidéo", 17 },
                    { 23, "Livres, films et musique", 17 },
                    { 24, "Instruments de musique", 17 },
                    { 25, "Antiquité et objets de collection", 17 },
                    { 27, "Electronique et ordinateurs", 26 },
                    { 28, "Téléphones mobiles", 26 }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "CategoryId", "CountReport", "Deleted", "Description", "Place", "Price", "Seller", "State", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 5, 0, false, "Tondeuse de luxe automatique", 0, 100.01000000000001, "vendeur@pfegrp5.onmicrosoft.com", 0, "Tondeuse", 1 },
                    { 2, 5, 0, true, "Tondeuse de luxe automatique", 0, 100.01000000000001, "vendeur@pfegrp5.onmicrosoft.com", 0, "TondeuseDeleted", 1 },
                    { 3, 5, 0, false, "Tondeuse de luxe automatique", 1, 99.989999999999995, "vendeur@pfegrp5.onmicrosoft.com", 0, "TondeuseIxelles", 1 },
                    { 4, 6, 0, false, "Tondeuse de luxe automatique", 1, 99.989999999999995, "vendeur@pfegrp5.onmicrosoft.com", 0, "TondeuseCheveux", 1 },
                    { 5, 6, 0, false, "Tondeuse de luxe automatique", 2, 99.989999999999995, "vendeur@pfegrp5.onmicrosoft.com", 0, "TondeuseCheveux", 1 },
                    { 6, 5, 0, false, "Tondeuse de luxe automatique", 1, 99.989999999999995, "vendeur@pfegrp5.onmicrosoft.com", 1, "TondeuseVendue", 1 },
                    { 7, 5, 0, false, "Tondeuse de luxe automatique", 1, 99.989999999999995, "vendeur@pfegrp5.onmicrosoft.com", 2, "TondeuseInvisible", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_OfferId",
                table: "Media",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CategoryId",
                table: "Offers",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
