using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookieStandApi.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hourlySale_CookieStands_cookieStandId",
                table: "hourlySale");

            migrationBuilder.AlterColumn<double>(
                name: "salesvalue",
                table: "hourlySale",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "cookieStandId",
                table: "hourlySale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "CookieStands",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CookieStands",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_hourlySale_CookieStands_cookieStandId",
                table: "hourlySale",
                column: "cookieStandId",
                principalTable: "CookieStands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hourlySale_CookieStands_cookieStandId",
                table: "hourlySale");

            migrationBuilder.AlterColumn<int>(
                name: "salesvalue",
                table: "hourlySale",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "cookieStandId",
                table: "hourlySale",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "CookieStands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CookieStands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_hourlySale_CookieStands_cookieStandId",
                table: "hourlySale",
                column: "cookieStandId",
                principalTable: "CookieStands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
