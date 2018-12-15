using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScanner.Migrations
{
    public partial class AlterResponsesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Responses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Responses");
        }
    }
}
