using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularDotnetCore.Migrations
{
    public partial class category_icon_postcount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Categories",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostCount",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PostCount",
                table: "Categories");
        }
    }
}
