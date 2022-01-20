using Microsoft.EntityFrameworkCore.Migrations;

namespace MotelListingApi.Migrations
{
    public partial class IncreasedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e131cc3-59c2-4802-8419-d3af243e9721");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce88cb7a-199d-4e27-a389-521db013cd30");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "329bf8b1-b580-44ca-bfdf-624d586d9dea", "59793c88-ea47-4303-9803-700b169b84e7", "User", "USER" },
                    { "556514e4-2292-4e38-a640-052be1cc04e4", "234bffa3-ebf7-4c4f-b8a4-c5156ab06366", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 4, "Cayman Island", "CI" },
                    { 5, "Bahamas", "BS" },
                    { 6, "Canada", "CD" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[,]
                {
                    { 5, "George Town", 3, "Comfort Suites", 4.2999999999999998 },
                    { 6, "Nassua", 2, "Grand Palldium", 4.0 }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[] { 4, "Negril", 4, "Sandals Resort and Spa", 4.5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "329bf8b1-b580-44ca-bfdf-624d586d9dea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "556514e4-2292-4e38-a640-052be1cc04e4");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ce88cb7a-199d-4e27-a389-521db013cd30", "ac0ff9f8-ee63-46b0-96ad-d84cd9aeb1bf", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9e131cc3-59c2-4802-8419-d3af243e9721", "2b0287cd-8f0b-4a45-be35-dfb2c79ab48c", "Administrator", "ADMINISTRATOR" });
        }
    }
}
