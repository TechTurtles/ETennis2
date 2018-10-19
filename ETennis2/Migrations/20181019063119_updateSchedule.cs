using Microsoft.EntityFrameworkCore.Migrations;

namespace ETennis2.Migrations
{
    public partial class updateSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Event_EventId",
                table: "Schedule");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Schedule",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Schedule",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Event_EventId",
                table: "Schedule",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Event_EventId",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Schedule");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Schedule",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Event_EventId",
                table: "Schedule",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
