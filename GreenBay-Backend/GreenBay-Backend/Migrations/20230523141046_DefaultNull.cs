using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenBay_Backend.Migrations
{
    public partial class DefaultNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_BuyerId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_BuyerId",
                table: "Items",
                column: "BuyerId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_BuyerId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_BuyerId",
                table: "Items",
                column: "BuyerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
