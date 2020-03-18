using Microsoft.EntityFrameworkCore.Migrations;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Identity",
                table: "Users",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Identity",
                table: "Users",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c5342858-edea-4dd0-a405-cf12efe58ecd");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d7f2d805-1a47-44c9-84cc-e69f31173fc9");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Identity",
                table: "Users");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "61b9d910-1503-458a-b695-ea885aedf141");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "34a1cedc-6607-4796-9f33-3fb9f59ac63d");
        }
    }
}
