using Microsoft.EntityFrameworkCore.Migrations;

namespace MotelListingApi.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ce88cb7a-199d-4e27-a389-521db013cd30", "ac0ff9f8-ee63-46b0-96ad-d84cd9aeb1bf", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9e131cc3-59c2-4802-8419-d3af243e9721", "2b0287cd-8f0b-4a45-be35-dfb2c79ab48c", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e131cc3-59c2-4802-8419-d3af243e9721");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce88cb7a-199d-4e27-a389-521db013cd30");
        }
    }
}
