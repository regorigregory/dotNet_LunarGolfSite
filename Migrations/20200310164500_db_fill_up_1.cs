using Microsoft.EntityFrameworkCore.Migrations;

namespace LunarSports.Migrations
{
    public partial class db_fill_up_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventTypes_EventTypeID",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventTypeID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventTypeID",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "EventType",
                table: "Events",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventType",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "EventTypeID",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeID",
                table: "Events",
                column: "EventTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventTypes_EventTypeID",
                table: "Events",
                column: "EventTypeID",
                principalTable: "EventTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
