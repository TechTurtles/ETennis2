using Microsoft.EntityFrameworkCore.Migrations;

namespace ETennis2.Data.Migrations
{
    public partial class CoachEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Coach",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Coach");
        }
    }
}
