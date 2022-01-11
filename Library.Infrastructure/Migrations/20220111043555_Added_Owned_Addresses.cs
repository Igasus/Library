using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    public partial class Added_Owned_Addresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreationAddress_City",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreationAddress_Country",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Authors",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "BirthAddress_City",
                table: "Authors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BirthAddress_Country",
                table: "Authors",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationAddress_City",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CreationAddress_Country",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BirthAddress_City",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "BirthAddress_Country",
                table: "Authors");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Authors",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
