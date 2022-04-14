using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManagement.Infrastructure.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHashtMvc",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSaltMvc",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHashtMvc",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PasswordSaltMvc",
                table: "AspNetUsers");
        }
    }
}
