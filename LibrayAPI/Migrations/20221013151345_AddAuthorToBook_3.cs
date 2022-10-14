using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrayAPI.Migrations
{
    public partial class AddAuthorToBook_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorModelId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorModelId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorModelId",
                table: "Books",
                column: "AuthorModelId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorModelId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorModelId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorModelId",
                table: "Books",
                column: "AuthorModelId",
                principalTable: "Authors",
                principalColumn: "Id");
        }
    }
}
