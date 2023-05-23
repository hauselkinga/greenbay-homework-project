using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenBay_Backend.Migrations
{
    public partial class AddBuyerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_BuyerId",
                table: "Items",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_BuyerId",
                table: "Items",
                column: "BuyerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_BuyerId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_BuyerId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Items");
        }
    }
}
