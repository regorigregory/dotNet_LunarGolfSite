using Microsoft.EntityFrameworkCore.Migrations;

namespace LunarSports.Migrations
{
    public partial class change_in_user_and_next_of_kin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextOfKinID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "NextOfKins",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "NextOfKins");

            migrationBuilder.AddColumn<int>(
                name: "NextOfKinID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
