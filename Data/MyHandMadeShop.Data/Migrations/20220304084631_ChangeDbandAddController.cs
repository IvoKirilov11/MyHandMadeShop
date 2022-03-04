using Microsoft.EntityFrameworkCore.Migrations;

namespace MyHandMadeShop.Data.Migrations
{
    public partial class ChangeDbandAddController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ItemTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ItemTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ItemTypes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
