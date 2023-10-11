using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookieStandApi.Migrations
{
    /// <inheritdoc />
    public partial class Fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HourlySale_CookieStands_CookieStandId",
                table: "HourlySale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HourlySale",
                table: "HourlySale");

            migrationBuilder.RenameTable(
                name: "HourlySale",
                newName: "hourlySales");

            migrationBuilder.RenameIndex(
                name: "IX_HourlySale_CookieStandId",
                table: "hourlySales",
                newName: "IX_hourlySales_CookieStandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hourlySales",
                table: "hourlySales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_hourlySales_CookieStands_CookieStandId",
                table: "hourlySales",
                column: "CookieStandId",
                principalTable: "CookieStands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hourlySales_CookieStands_CookieStandId",
                table: "hourlySales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hourlySales",
                table: "hourlySales");

            migrationBuilder.RenameTable(
                name: "hourlySales",
                newName: "HourlySale");

            migrationBuilder.RenameIndex(
                name: "IX_hourlySales_CookieStandId",
                table: "HourlySale",
                newName: "IX_HourlySale_CookieStandId");

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
    }
}
