using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace costcollector.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderTable",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<Guid>(type: "uniqueidentifier", unicode: false, maxLength: 45, nullable: false),
                    erpOrderId = table.Column<int>(type: "int", nullable: true),
                    invoiceId = table.Column<int>(type: "int", nullable: true),
                    storeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_panel_lista", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OrderPositions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    offerId = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPositions", x => x.id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_OrderPositions_OrderTable_orderId",
                        column: x => x.orderId,
                        principalTable: "OrderTable",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OrderTable",
                columns: new[] { "id", "erpOrderId", "invoiceId", "orderId", "storeId" },
                values: new object[,]
                {
                    { 1, 1, 12, new Guid("024ac720-3857-11ef-ac0a-e5fcc384aba0"), 21 },
                    { 2, 2, 13, new Guid("64f97c00-3847-11ef-ac0a-e5fcc384aba0"), 21 }
                });

            migrationBuilder.InsertData(
                table: "OrderPositions",
                columns: new[] { "id", "offerId", "orderId" },
                values: new object[,]
                {
                    { 1, "7770594916", 1 },
                    { 2, "7770594916", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderPositions_orderId",
                table: "OrderPositions",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "si",
                table: "OrderTable",
                columns: new[] { "orderId", "storeId" },
                unique: true,
                filter: "[storeId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPositions");

            migrationBuilder.DropTable(
                name: "OrderTable");
        }
    }
}
