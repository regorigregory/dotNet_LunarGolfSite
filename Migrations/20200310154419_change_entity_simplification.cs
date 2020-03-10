using Microsoft.EntityFrameworkCore.Migrations;

namespace LunarSports.Migrations
{
    public partial class change_entity_simplification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactDetailID",
                table: "LaunchSites");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LaunchSites");

            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "LaunchSites");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactDetailID",
                table: "LaunchSites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LaunchSites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "LaunchSites",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
