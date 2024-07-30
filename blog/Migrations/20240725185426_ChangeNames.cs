using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blog.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "post",
                newName: "PostTitle");

            migrationBuilder.RenameColumn(
                name: "Likes",
                table: "post",
                newName: "PostLikes");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "post",
                newName: "PostContent");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "post",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "Likes",
                table: "comments",
                newName: "CommentLikes");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "comments",
                newName: "CommentContent");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "comments",
                newName: "CommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostTitle",
                table: "post",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "PostLikes",
                table: "post",
                newName: "Likes");

            migrationBuilder.RenameColumn(
                name: "PostContent",
                table: "post",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "post",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CommentLikes",
                table: "comments",
                newName: "Likes");

            migrationBuilder.RenameColumn(
                name: "CommentContent",
                table: "comments",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "comments",
                newName: "Id");
        }
    }
}
