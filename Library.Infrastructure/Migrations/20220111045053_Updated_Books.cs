using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    public partial class Updated_Books : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Books",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PagesAmount",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PagesAmount",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Books",
                newName: "Name");
        }
    }
}
