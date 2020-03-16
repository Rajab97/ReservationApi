using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingRoomApi.Migrations
{
    public partial class ColorProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReservationColorCode",
                table: "Members",
                maxLength: 15,
                nullable: true,
                defaultValue: "#2196F2");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationColorCode",
                table: "Members");


        }
    }
}
