using Microsoft.EntityFrameworkCore.Migrations;

namespace WebScanner.Migrations
{
    public partial class SnakeCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Responses",
                table: "Responses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServerOrders",
                table: "ServerOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HtmlOrders",
                table: "HtmlOrders");

            migrationBuilder.RenameTable(
                name: "Responses",
                newName: "responses");

            migrationBuilder.RenameTable(
                name: "ServerOrders",
                newName: "server_orders");

            migrationBuilder.RenameTable(
                name: "HtmlOrders",
                newName: "html_orders");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "responses",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "responses",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "responses",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "responses",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "responses",
                newName: "order_id");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "server_orders",
                newName: "question");

            migrationBuilder.RenameColumn(
                name: "Frequency",
                table: "server_orders",
                newName: "frequency");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "server_orders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TargetAddress",
                table: "server_orders",
                newName: "target_address");

            migrationBuilder.RenameColumn(
                name: "Frequency",
                table: "html_orders",
                newName: "frequency");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "html_orders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TargetAddress",
                table: "html_orders",
                newName: "target_address");

            migrationBuilder.RenameColumn(
                name: "SubjectOfQuestion",
                table: "html_orders",
                newName: "subject_of_question");

            migrationBuilder.AddPrimaryKey(
                name: "pk_responses",
                table: "responses",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_server_orders",
                table: "server_orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_html_orders",
                table: "html_orders",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_responses",
                table: "responses");

            migrationBuilder.DropPrimaryKey(
                name: "pk_server_orders",
                table: "server_orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_html_orders",
                table: "html_orders");

            migrationBuilder.RenameTable(
                name: "responses",
                newName: "Responses");

            migrationBuilder.RenameTable(
                name: "server_orders",
                newName: "ServerOrders");

            migrationBuilder.RenameTable(
                name: "html_orders",
                newName: "HtmlOrders");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Responses",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Responses",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Responses",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Responses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "Responses",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "question",
                table: "ServerOrders",
                newName: "Question");

            migrationBuilder.RenameColumn(
                name: "frequency",
                table: "ServerOrders",
                newName: "Frequency");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ServerOrders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "target_address",
                table: "ServerOrders",
                newName: "TargetAddress");

            migrationBuilder.RenameColumn(
                name: "frequency",
                table: "HtmlOrders",
                newName: "Frequency");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "HtmlOrders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "target_address",
                table: "HtmlOrders",
                newName: "TargetAddress");

            migrationBuilder.RenameColumn(
                name: "subject_of_question",
                table: "HtmlOrders",
                newName: "SubjectOfQuestion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responses",
                table: "Responses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServerOrders",
                table: "ServerOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HtmlOrders",
                table: "HtmlOrders",
                column: "Id");
        }
    }
}
