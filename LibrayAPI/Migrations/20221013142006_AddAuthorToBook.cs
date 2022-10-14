using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrayAPI.Migrations
{
    public partial class AddAuthorToBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorModelId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullnameAuthor",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorModelId",
                table: "Books",
                column: "AuthorModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorModelId",
                table: "Books",
                column: "AuthorModelId",
                principalTable: "Authors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorModelId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorModelId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorModelId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "FullnameAuthor",
                table: "Books");
        }
    }
}
