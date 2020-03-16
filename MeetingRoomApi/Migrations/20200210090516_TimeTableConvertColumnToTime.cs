using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingRoomApi.Migrations
{
    public partial class TimeTableConvertColumnToTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ValidRoomTimes_StartTime_EndTime",
                table: "ValidRoomTimes"
                );
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "ValidRoomTimes",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "ValidRoomTimes",
                nullable: false,
                oldClrType: typeof(DateTime));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
       
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "ValidRoomTimes",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "ValidRoomTimes",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_Id",
                keyValue: (short)1,
                column: "Password",
                value: "$2b$10$jTemwN6w1KbCQDDEmTOmL.nxkbV8zE31ZT9/J5pkamI7Lhn52G6KK");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_Id",
                keyValue: (short)2,
                column: "Password",
                value: "$2b$10$SQj/SOCJmsLzT3A8/ieDzeVERHsfDWYizWEahZ3CuVAXThgN.drDW");
 
        }
    }
}
