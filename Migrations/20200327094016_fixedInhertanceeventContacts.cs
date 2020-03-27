using Microsoft.EntityFrameworkCore.Migrations;

namespace LunarSports.Migrations
{
    public partial class fixedInhertanceeventContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingNO",
                table: "EventLocationContactDetails");

            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "EventLocationContactDetails");

            migrationBuilder.DropColumn(
                name: "Locality",
                table: "EventLocationContactDetails");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "EventLocationContactDetails");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "EventLocationContactDetails");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "EventLocationContactDetails");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "EventLocationContactDetails");

            migrationBuilder.AddColumn<int>(
                name: "ContactDetailType",
                table: "EventLocationContactDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "EventLocationContactDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Landline",
                table: "EventLocationContactDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "EventLocationContactDetails",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactDetailType",
                table: "EventLocationContactDetails");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "EventLocationContactDetails");

            migrationBuilder.DropColumn(
                name: "Landline",
                table: "EventLocationContactDetails");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "EventLocationContactDetails");

            migrationBuilder.AddColumn<string>(
                name: "BuildingNO",
                table: "EventLocationContactDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "EventLocationContactDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Locality",
                table: "EventLocationContactDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "EventLocationContactDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "EventLocationContactDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "EventLocationContactDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "EventLocationContactDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
