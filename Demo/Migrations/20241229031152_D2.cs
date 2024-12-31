using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    public partial class D2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Products_ProductModelId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ProductModelId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ProductModelId",
                table: "Reservations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductModelId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ProductModelId",
                table: "Reservations",
                column: "ProductModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Products_ProductModelId",
                table: "Reservations",
                column: "ProductModelId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
