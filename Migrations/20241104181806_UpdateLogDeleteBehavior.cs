using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse_Manager.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLogDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logi_Produkty_ProduktId",
                table: "Logi");

            migrationBuilder.AddForeignKey(
                name: "FK_Logi_Produkty_ProduktId",
                table: "Logi",
                column: "ProduktId",
                principalTable: "Produkty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logi_Produkty_ProduktId",
                table: "Logi");

            migrationBuilder.AddForeignKey(
                name: "FK_Logi_Produkty_ProduktId",
                table: "Logi",
                column: "ProduktId",
                principalTable: "Produkty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
