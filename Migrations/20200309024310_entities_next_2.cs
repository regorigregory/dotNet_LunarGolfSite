using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LunarSports.Migrations
{
    public partial class entities_next_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    ContactDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactDetailType = table.Column<int>(nullable: false),
                    Mobile = table.Column<string>(nullable: true),
                    Landline = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    User = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.ContactDetailID);
                });

            migrationBuilder.CreateTable(
                name: "EventScheduleEntries",
                columns: table => new
                {
                    EventScheduleEntryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventScheduleEntries", x => x.EventScheduleEntryID);
                });

            migrationBuilder.CreateTable(
                name: "LaunchSites",
                columns: table => new
                {
                    LaunchSiteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactDetailID = table.Column<int>(nullable: false),
                    Location = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PhotoURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaunchSites", x => x.LaunchSiteID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(nullable: true),
                    BuildingNO = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    Locality = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    Lat = table.Column<double>(nullable: false),
                    Long = table.Column<double>(nullable: false),
                    IsLunarLocation = table.Column<bool>(nullable: false),
                    ContactDetail = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "EventScheduleEntries");

            migrationBuilder.DropTable(
                name: "LaunchSites");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
