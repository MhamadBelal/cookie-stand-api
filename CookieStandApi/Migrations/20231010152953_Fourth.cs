using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CookieStandApi.Migrations
{
    /// <inheritdoc />
    public partial class Fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CookieStands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CookieStands",
                keyColumn: "Id",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CookieStands",
                columns: new[] { "Id", "AverageCookiesPerSale", "Description", "Location", "MaximumCustomersPerHour", "MinimumCustomersPerHour", "Owner" },
                values: new object[,]
                {
                    { 1, 2.5, "description1", "Amman", 7, 3, "Person1" },
                    { 2, 2.5, "description2", "Irbid", 7, 3, "Person2" }
                });
        }
    }
}
