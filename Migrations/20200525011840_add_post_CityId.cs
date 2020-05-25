using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularDotnetCore.Migrations
{
    public partial class add_post_CityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Posts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Posts");
        }
    }
}
