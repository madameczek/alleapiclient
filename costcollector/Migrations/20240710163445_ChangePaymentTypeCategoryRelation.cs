using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace costcollector.Migrations
{
    /// <inheritdoc />
    public partial class ChangePaymentTypeCategoryRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTypes_PaymentCategories_PaymentCategoryId",
                table: "PaymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTypes_PaymentCategoryId",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "PaymentCategoryId",
                table: "PaymentTypes");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PaymentCategories",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "PaymentTypeCategory",
                columns: table => new
                {
                    IdPaymentCategory = table.Column<int>(type: "int", nullable: false),
                    IdPaymentType = table.Column<string>(type: "nvarchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypeCategory", x => new { x.IdPaymentCategory, x.IdPaymentType });
                    table.ForeignKey(
                        name: "FK_PaymentTypeCategory_PaymentCategories_IdPaymentCategory",
                        column: x => x.IdPaymentCategory,
                        principalTable: "PaymentCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentTypeCategory_PaymentTypes_IdPaymentType",
                        column: x => x.IdPaymentType,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypeCategory_IdPaymentType",
                table: "PaymentTypeCategory",
                column: "IdPaymentType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentTypeCategory");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PaymentCategories",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "PaymentCategoryId",
                table: "PaymentTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_PaymentCategoryId",
                table: "PaymentTypes",
                column: "PaymentCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTypes_PaymentCategories_PaymentCategoryId",
                table: "PaymentTypes",
                column: "PaymentCategoryId",
                principalTable: "PaymentCategories",
                principalColumn: "id");
        }
    }
}
