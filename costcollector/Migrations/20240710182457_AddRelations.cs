using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace costcollector.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PaymentTypeCategory",
                columns: new[] { "IdPaymentCategory", "IdPaymentType" },
                values: new object[,]
                {
                    { 1, "USF" },
                    { 2, "SUC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentTypeCategory",
                keyColumns: new[] { "IdPaymentCategory", "IdPaymentType" },
                keyValues: new object[] { 1, "USF" });

            migrationBuilder.DeleteData(
                table: "PaymentTypeCategory",
                keyColumns: new[] { "IdPaymentCategory", "IdPaymentType" },
                keyValues: new object[] { 2, "SUC" });
        }
    }
}
