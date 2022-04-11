using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotNet2.Migrations.FizzBuzz
{
    public partial class nullableUId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UId",
                table: "FizzBuzz",
                type: "NVARCHAR(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UId",
                table: "FizzBuzz",
                type: "NVARCHAR(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(450)",
                oldNullable: true);
        }
    }
}
