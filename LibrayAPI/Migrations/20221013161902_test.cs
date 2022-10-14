using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrayAPI.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "AuthorModelId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
