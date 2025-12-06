using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class ChangesPostRemveExtensionAddImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageExtension",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Posts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "ImageExtension",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
