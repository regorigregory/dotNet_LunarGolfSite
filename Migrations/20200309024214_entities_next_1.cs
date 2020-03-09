using Microsoft.EntityFrameworkCore.Migrations;

namespace LunarSports.Migrations
{
    public partial class entities_next_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_EventType_EventTypeID",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameIndex(
                name: "IX_Event_EventTypeID",
                table: "Events",
                newName: "IX_Events_EventTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "EventID");

            migrationBuilder.CreateTable(
                name: "NextOfKins",
                columns: table => new
                {
                    NextOfKinID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    RelationShip = table.Column<string>(nullable: true),
                    ContactDetailID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextOfKins", x => x.NextOfKinID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventType_EventTypeID",
                table: "Events",
                column: "EventTypeID",
                principalTable: "EventType",
                principalColumn: "EventTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventType_EventTypeID",
                table: "Events");

            migrationBuilder.DropTable(
                name: "NextOfKins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameIndex(
                name: "IX_Events_EventTypeID",
                table: "Event",
                newName: "IX_Event_EventTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_EventType_EventTypeID",
                table: "Event",
                column: "EventTypeID",
                principalTable: "EventType",
                principalColumn: "EventTypeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
