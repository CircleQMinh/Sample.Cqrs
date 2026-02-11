using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sample.Cqrs.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "StockQuantity", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "seed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Latest Apple smartphone with A16 chip.", "https://example.com/iphone15.jpg", "iPhone 15", 999.99m, 50, "", null },
                    { 2, "seed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flagship Samsung device with premium display.", "https://example.com/galaxys24.jpg", "Samsung Galaxy S24", 899.99m, 40, "", null },
                    { 3, "seed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Industry-leading noise cancelling headphones.", "https://example.com/sony.jpg", "Sony WH-1000XM5", 349.99m, 25, "", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "PasswordHash", "Role", "UpdatedBy", "UpdatedDate", "Username" },
                values: new object[,]
                {
                    { 1, "seed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@demo.com", "AQAAAAIAAYagAAAAELpprLkSumrqI7gS16nm0jm1rzNbR6mFkWHQUb+G442Fk4UIV66Q85VtGya1r3602g==", "Admin", "", null, "admin@demo.com" },
                    { 2, "seed", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@demo.com", "AQAAAAIAAYagAAAAELpprLkSumrqI7gS16nm0jm1rzNbR6mFkWHQUb+G442Fk4UIV66Q85VtGya1r3602g==", "User", "", null, "user@demo.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
