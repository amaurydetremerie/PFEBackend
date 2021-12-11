using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFEBackend.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SellerEMail",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
