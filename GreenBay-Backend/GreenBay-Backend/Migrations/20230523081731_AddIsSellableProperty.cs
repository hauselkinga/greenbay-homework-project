using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenBay_Backend.Migrations
{
    public partial class AddIsSellableProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSellable",
                table: "Items",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSellable",
                table: "Items");
        }
    }
}
