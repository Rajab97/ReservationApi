using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingRoomApi.Migrations
{
    public partial class AddValuesToMembersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddUniqueConstraint(
                name: "AK_ValidRoomTimes_StartTime_EndTime",
                table: "ValidRoomTimes",
                columns: new[] { "StartTime", "EndTime" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_RoomReservations_ReservationDate_Time_Id_MeetingRoom_Id",
                table: "RoomReservations",
                columns: new[] { "ReservationDate", "Time_Id", "MeetingRoom_Id" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Member_Id", "Name", "Password", "Surname", "UserName" },
                values: new object[,]
                {
                    { (short)1, "Receb", "$2b$10$zVMV5z1yTiQuX.RQ98HDVuw3DsCmmqw5K3s/RygkjwZThdlJE7ubC", "Qarayev", "Rajab97" },
                    { (short)2, "Test", "$2b$10$DXUSAzKZ2eEheVOzM5/a2OuCFMT7XKFQMZ37EdYzIBoPEfTlX.Gqu", "Test", "Test123" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)2, "Administrator" },
                    { (byte)3, "User" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ValidRoomTimes_StartTime_EndTime",
                table: "ValidRoomTimes");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_RoomReservations_ReservationDate_Time_Id_MeetingRoom_Id",
                table: "RoomReservations");

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Member_Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Member_Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: (byte)3);

        }
    }
}
