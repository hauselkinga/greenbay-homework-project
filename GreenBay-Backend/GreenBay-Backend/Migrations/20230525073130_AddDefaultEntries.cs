using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenBay_Backend.Migrations
{
    public partial class AddDefaultEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Balance", "Password", "UserName" },
                values: new object[] { 1, 10000, "15E2B0D3C33891EBB0F1EF609EC419420C20E320CE94C65FBC8C3312448EB225", "Test_User" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BuyerId", "Description", "IsSellable", "Name", "PhotoURL", "Price", "UserId" },
                values: new object[] { 1, null, "Test item description", true, "Test Item 1", "https://images.pexels.com/photos/4464484/pexels-photo-4464484.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", 100, 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BuyerId", "Description", "IsSellable", "Name", "PhotoURL", "Price", "UserId" },
                values: new object[] { 2, null, "Test item description", true, "Test Item 2", "https://images.pexels.com/photos/4464484/pexels-photo-4464484.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", 200, 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BuyerId", "Description", "IsSellable", "Name", "PhotoURL", "Price", "UserId" },
                values: new object[] { 3, null, "Test item description", true, "Test Item 3", "https://images.pexels.com/photos/4464484/pexels-photo-4464484.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", 100, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
