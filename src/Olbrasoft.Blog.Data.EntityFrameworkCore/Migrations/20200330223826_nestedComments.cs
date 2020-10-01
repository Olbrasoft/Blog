using Microsoft.EntityFrameworkCore.Migrations;

namespace Olbrasoft.Blog.Data.EntityFrameworkCore.Migrations
{
    public partial class nestedComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NestedComment_Comments_CommentId",
                table: "NestedComment");

            migrationBuilder.DropForeignKey(
                name: "FK_NestedComment_Users_CreatorId",
                table: "NestedComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NestedComment",
                table: "NestedComment");

            migrationBuilder.RenameTable(
                name: "NestedComment",
                newName: "NestedComments");

            migrationBuilder.RenameIndex(
                name: "IX_NestedComment_CreatorId",
                table: "NestedComments",
                newName: "IX_NestedComments_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_NestedComment_CommentId",
                table: "NestedComments",
                newName: "IX_NestedComments_CommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NestedComments",
                table: "NestedComments",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "392415e3-3a60-4b9e-ae01-01d8afe24360");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9aab9c86-7a12-4417-ab79-37667cfa112c");

            migrationBuilder.AddForeignKey(
                name: "FK_NestedComments_Comments_CommentId",
                table: "NestedComments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NestedComments_Users_CreatorId",
                table: "NestedComments",
                column: "CreatorId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NestedComments_Comments_CommentId",
                table: "NestedComments");

            migrationBuilder.DropForeignKey(
                name: "FK_NestedComments_Users_CreatorId",
                table: "NestedComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NestedComments",
                table: "NestedComments");

            migrationBuilder.RenameTable(
                name: "NestedComments",
                newName: "NestedComment");

            migrationBuilder.RenameIndex(
                name: "IX_NestedComments_CreatorId",
                table: "NestedComment",
                newName: "IX_NestedComment_CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_NestedComments_CommentId",
                table: "NestedComment",
                newName: "IX_NestedComment_CommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NestedComment",
                table: "NestedComment",
                column: "Id");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "661b2935-8f54-401a-978a-5ab8653930c1");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "84240c51-1b73-418b-a221-88fcf31f4624");

            migrationBuilder.AddForeignKey(
                name: "FK_NestedComment_Comments_CommentId",
                table: "NestedComment",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NestedComment_Users_CreatorId",
                table: "NestedComment",
                column: "CreatorId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
