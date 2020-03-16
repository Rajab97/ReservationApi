using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingRoomApi.Migrations
{
    public partial class TimeTableConvertColumnToTime0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "ValidRoomTimes",
                type: "time(0)",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "ValidRoomTimes",
                type: "time(0)",
                nullable: false,
                oldClrType: typeof(TimeSpan));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "ValidRoomTimes",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "ValidRoomTimes",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(0)");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_Id",
                keyValue: (short)1,
                column: "Password",
                value: "$2b$10$IfeEDCb/S9oFLTH1jQAY1uS3rBwnkYK3ndh6Dar9EhOG5L1jLHAxe");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_Id",
                keyValue: (short)2,
                column: "Password",
                value: "$2b$10$1KHAxfxD/BGc8RjEFPCTZOQxhijWBklQMjsmsBLi5TKDlppBBv.KC");
        }
    }
}
