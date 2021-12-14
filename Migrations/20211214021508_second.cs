using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFEBackend.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Categories_CategoryId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_CategoryId",
                table: "Offers");

            migrationBuilder.AlterColumn<string>(
                name: "Seller",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SellerEMail",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Seller", "SellerEMail" },
                values: new object[] { "60038da5-5166-40c7-a6f8-8988e4c3cb9f", "vendeur@pfegrp5.onmicrosoft.com" });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Seller", "SellerEMail" },
                values: new object[] { "60038da5-5166-40c7-a6f8-8988e4c3cb9f", "vendeur@pfegrp5.onmicrosoft.com" });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Seller", "SellerEMail" },
                values: new object[] { "60038da5-5166-40c7-a6f8-8988e4c3cb9f", "vendeur@pfegrp5.onmicrosoft.com" });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Seller", "SellerEMail" },
                values: new object[] { "60038da5-5166-40c7-a6f8-8988e4c3cb9f", "vendeur@pfegrp5.onmicrosoft.com" });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Seller", "SellerEMail" },
                values: new object[] { "60038da5-5166-40c7-a6f8-8988e4c3cb9f", "vendeur@pfegrp5.onmicrosoft.com" });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Seller", "SellerEMail" },
                values: new object[] { "60038da5-5166-40c7-a6f8-8988e4c3cb9f", "vendeur@pfegrp5.onmicrosoft.com" });

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Seller", "SellerEMail" },
                values: new object[] { "60038da5-5166-40c7-a6f8-8988e4c3cb9f", "vendeur@pfegrp5.onmicrosoft.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellerEMail",
                table: "Offers");

            migrationBuilder.AlterColumn<string>(
                name: "Seller",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Seller",
                value: "vendeur@pfegrp5.onmicrosoft.com");

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Seller",
                value: "vendeur@pfegrp5.onmicrosoft.com");

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Seller",
                value: "vendeur@pfegrp5.onmicrosoft.com");

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Seller",
                value: "vendeur@pfegrp5.onmicrosoft.com");

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Seller",
                value: "vendeur@pfegrp5.onmicrosoft.com");

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Seller",
                value: "vendeur@pfegrp5.onmicrosoft.com");

            migrationBuilder.UpdateData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 7,
                column: "Seller",
                value: "vendeur@pfegrp5.onmicrosoft.com");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CategoryId",
                table: "Offers",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Categories_CategoryId",
                table: "Offers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
