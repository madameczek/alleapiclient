using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace costcollector.Migrations
{
    /// <inheritdoc />
    public partial class AddSampleCategoriesAndTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PaymentCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Koszty stałe" },
                    { 2, "Koszty zmienne" }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { "PB2", "Wpłata" },
                    { "RES", "Opłata za cenę minimalną" },
                    { "RIC", "Korekta salda" },
                    { "ST4", "Abonament za statystyki - 12 miesięcy" },
                    { "SUC", "Prowizja od sprzedaży" },
                    { "SUM", "Podsumowanie miesiąca" },
                    { "USF", "Jednostkowa opłata transakcyjna" },
                    { "VEP", "Naliczenie VAT e-commerce" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "PB2");

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "RES");

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "RIC");

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "ST4");

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "SUC");

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "SUM");

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "USF");

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: "VEP");
        }
    }
}
