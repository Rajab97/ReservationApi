using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingRoomApi.Migrations
{
    public partial class SeedingDefaultMeetingRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MeetingRooms",
                columns: new[] { "MeetingRoom_Id", "RoomName" },
                values: new object[] { (byte)1, "Main Room" });
            migrationBuilder.DropColumn("IsActive","RoomReservations");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_Id",
                keyValue: (short)1,
                column: "Password",
                value: "$2b$10$fxkFn/Qmc0Dt84qh6B4JxuyxaYkwFxb7vQWjeSX4b9gmv8bGe32ua");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_Id",
                keyValue: (short)2,
                column: "Password",
                value: "$2b$10$gG5XTCds01Rwwr7kt7wk3ObTVOYhA3sdKmC1jttgtKI.YEdfcB8Si");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MeetingRooms",
                keyColumn: "MeetingRoom_Id",
                keyValue: (byte)1);

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_Id",
                keyValue: (short)1,
                column: "Password",
                value: "$2b$10$8UWP6ahVvtQnHZP56V1WNOz/wdoWzdjFqju67wjEI.w04A/YpDl2.");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_Id",
                keyValue: (short)2,
                column: "Password",
                value: "$2b$10$.bZxiJRrA2Q3XeJowNgxIuHx/iGMs/HVR6UUHCUmIcyFKDF.thlKK");
        }
    }
}
