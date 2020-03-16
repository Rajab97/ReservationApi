using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingRoomApi.Migrations
{
    public partial class validTimesSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
      

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_Id",
                keyValue: (short)1,
                column: "Password",
                value: "$2b$10$SdT01AXDDwwoCziD1HLVD.Eng4rvAWTw6ScCaus3ks5VWVIJ1yJ.m");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_Id",
                keyValue: (short)2,
                column: "Password",
                value: "$2b$10$wX63IcePaEsC4dsybJOBouFIGIXbJTlH1CZVyXTXpjr4tJa11NP9u");

            migrationBuilder.InsertData(
                table: "ValidRoomTimes",
                columns: new[] { "ValidRoomTime_Id", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { (short)14, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 16, 30, 0, 0) },
                    { (short)13, new TimeSpan(0, 16, 30, 0, 0), new TimeSpan(0, 16, 0, 0, 0) },
                    { (short)12, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 15, 30, 0, 0) },
                    { (short)11, new TimeSpan(0, 15, 30, 0, 0), new TimeSpan(0, 15, 0, 0, 0) },
                    { (short)10, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 14, 30, 0, 0) },
                    { (short)9, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 14, 0, 0, 0) },
                    { (short)8, new TimeSpan(0, 13, 0, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { (short)7, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 12, 0, 0, 0) },
                    { (short)6, new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { (short)5, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 11, 0, 0, 0) },
                    { (short)4, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { (short)3, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { (short)2, new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { (short)1, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { (short)15, new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 17, 0, 0, 0) },
                    { (short)16, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 17, 30, 0, 0) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ValidRoomTimes",
                keyColumn: "ValidRoomTime_Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "ValidRoomTimes",
                keyColumn: "ValidRoomTime_Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "ValidRoomTimes",
                keyColumn: "ValidRoomTime_Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "ValidRoomTimes",
                keyColumn: "ValidRoomTime_Id",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                table: "ValidRoomTimes",
                keyColumn: "ValidRoomTime_Id",
                keyValue: (short)5);

            migrationBuilder.DeleteData(
                table: "ValidRoomTimes",
                keyColumn: "ValidRoomTime_Id",
                keyValue: (short)6);

            migrationBuilder.DeleteData(
                table: "ValidRoomTimes",
                keyColumn: "ValidRoomTime_Id",
                keyValue: (short)7);

            migrationBuilder.DeleteData(
                table: "ValidRoomTimes",
                keyColumn: "ValidRoomTime_Id",
                keyValue: (short)8);

            migrationBuilder.DeleteData(
                table: "ValidRoomTimes",
                keyColumn: "ValidRoomTime_Id",
                keyValue: (short)9);

            migrationBuilder.DeleteData(
                table: "ValidRoomTimes",
                keyColumn: "ValidRoomTime_Id",
                keyValue: (short)10);

            migrationBuilder.DeleteData(
                table: "ValidRoomTimes",
                keyColumn: "ValidRoomTime_Id",
                keyValue: (short)11);

            migrationBuilder.DeleteData(
                table: "ValidRoomTimes",
                keyColumn: "ValidRoomTime_Id",
                keyValue: (short)12);

            migrationBuilder.DeleteData(
                table: "ValidRoomTimes",
                keyColumn: "ValidRoomTime_Id",
                keyValue: (short)13);

            migrationBuilder.DeleteData(
                table: "ValidRoomTimes",
                keyColumn: "ValidRoomTime_Id",
                keyValue: (short)14);

            migrationBuilder.DeleteData(
                table: "ValidRoomTimes",
                keyColumn: "ValidRoomTime_Id",
                keyValue: (short)15);

            migrationBuilder.DeleteData(
                table: "ValidRoomTimes",
                keyColumn: "ValidRoomTime_Id",
                keyValue: (short)16);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "RoomReservations",
                nullable: false,
                defaultValue: false);

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
    }
}
