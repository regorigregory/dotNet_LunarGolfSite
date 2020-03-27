using Microsoft.EntityFrameworkCore.Migrations;

namespace LunarSports.Migrations
{
    public partial class fixedInhertanceeventContacts2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactDetailType",
                table: "UserContactDetails");

            migrationBuilder.DropColumn(
                name: "ContactDetailType",
                table: "EventLocationContactDetails");

            migrationBuilder.AddColumn<int>(
                name: "IsPrimary",
                table: "UserContactDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsPrimary",
                table: "EventLocationContactDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "UserContactDetails");

            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "EventLocationContactDetails");

            migrationBuilder.AddColumn<int>(
                name: "ContactDetailType",
                table: "UserContactDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContactDetailType",
                table: "EventLocationContactDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
