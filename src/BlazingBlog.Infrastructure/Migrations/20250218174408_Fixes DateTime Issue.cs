using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazingBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixesDateTimeIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Id",
                table: "AspNetUsers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Id",
                table: "Articles",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Articles_Id",
                table: "Articles");
        }
    }
}
