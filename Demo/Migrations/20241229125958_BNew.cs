using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    public partial class BNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Bonus",
                table: "Salaries",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Salaries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Absents_StaffId",
                table: "Absents",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absents_Staffs_StaffId",
                table: "Absents",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absents_Staffs_StaffId",
                table: "Absents");

            migrationBuilder.DropIndex(
                name: "IX_Absents_StaffId",
                table: "Absents");

            migrationBuilder.DropColumn(
                name: "Bonus",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Salaries");
        }
    }
}
