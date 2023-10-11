using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookieStandApi.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hourlySale_CookieStands_cookieStandId",
                table: "hourlySale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hourlySale",
                table: "hourlySale");

            migrationBuilder.DropColumn(
                name: "salesvalue",
                table: "hourlySale");

            migrationBuilder.RenameTable(
                name: "hourlySale",
                newName: "HourlySale");

            migrationBuilder.RenameColumn(
                name: "cookieStandId",
                table: "HourlySale",
                newName: "CookieStandId");

            migrationBuilder.RenameColumn(
                name: "StandCookieId",
                table: "HourlySale",
                newName: "SaleValue");

            migrationBuilder.RenameIndex(
                name: "IX_hourlySale_cookieStandId",
                table: "HourlySale",
                newName: "IX_HourlySale_CookieStandId");

            migrationBuilder.AlterColumn<int>(
                name: "CookieStandId",
                table: "HourlySale",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HourlySale",
                table: "HourlySale",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HourlySale_CookieStands_CookieStandId",
                table: "HourlySale",
                column: "CookieStandId",
                principalTable: "CookieStands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HourlySale_CookieStands_CookieStandId",
                table: "HourlySale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HourlySale",
                table: "HourlySale");

            migrationBuilder.RenameTable(
                name: "HourlySale",
                newName: "hourlySale");

            migrationBuilder.RenameColumn(
                name: "CookieStandId",
                table: "hourlySale",
                newName: "cookieStandId");

            migrationBuilder.RenameColumn(
                name: "SaleValue",
                table: "hourlySale",
                newName: "StandCookieId");

            migrationBuilder.RenameIndex(
                name: "IX_HourlySale_CookieStandId",
                table: "hourlySale",
                newName: "IX_hourlySale_cookieStandId");

            migrationBuilder.AlterColumn<int>(
                name: "cookieStandId",
                table: "hourlySale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "salesvalue",
                table: "hourlySale",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_hourlySale",
                table: "hourlySale",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_hourlySale_CookieStands_cookieStandId",
                table: "hourlySale",
                column: "cookieStandId",
                principalTable: "CookieStands",
                principalColumn: "Id");
        }
    }
}
