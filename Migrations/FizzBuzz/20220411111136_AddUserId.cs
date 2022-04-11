using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotNet2.Migrations.FizzBuzz
{
    public partial class AddUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UId",
                table: "FizzBuzz",
                type: "NVARCHAR(450)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UId",
                table: "FizzBuzz");
        }
    }
}
