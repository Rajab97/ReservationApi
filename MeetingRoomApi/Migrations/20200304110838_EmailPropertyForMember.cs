using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingRoomApi.Migrations
{
    public partial class EmailPropertyForMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Members",
                maxLength: 25,
                nullable: true);

    
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Members");


        }
    }
}
