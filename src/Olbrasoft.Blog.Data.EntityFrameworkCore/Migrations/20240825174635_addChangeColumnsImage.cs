using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class addChangeColumnsImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Images",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MimeType",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extension",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "MimeType",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Images",
                newName: "FileName");
        }
    }
}
