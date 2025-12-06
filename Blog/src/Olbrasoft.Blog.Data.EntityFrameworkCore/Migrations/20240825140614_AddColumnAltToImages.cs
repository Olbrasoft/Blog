using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnAltToImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alt",
                table: "Images",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alt",
                table: "Images");
        }
    }
}
