using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScanner.Migrations
{
    public partial class RepairedColumnNameinOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TargetAdress",
                table: "ServerOrders",
                newName: "TargetAddress");

            migrationBuilder.RenameColumn(
                name: "TargetAdress",
                table: "HtmlOrders",
                newName: "TargetAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TargetAddress",
                table: "ServerOrders",
                newName: "TargetAdress");

            migrationBuilder.RenameColumn(
                name: "TargetAddress",
                table: "HtmlOrders",
                newName: "TargetAdress");
        }
    }
}
