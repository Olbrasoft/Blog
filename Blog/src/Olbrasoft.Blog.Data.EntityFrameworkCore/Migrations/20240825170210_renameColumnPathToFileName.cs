using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class renameColumnPathToFileName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Images",
                newName: "FileName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Images",
                newName: "Path");
        }
    }
}
