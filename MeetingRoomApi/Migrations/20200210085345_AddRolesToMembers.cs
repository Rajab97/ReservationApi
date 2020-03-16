using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingRoomApi.Migrations
{
    public partial class AddRolesToMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "MemberId", "RoleId" },
                values: new object[,]
                {
                    { 1, (short)1, (byte)2 },
                    { 2, (short)2, (byte)3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_Id",
                keyValue: (short)1,
                column: "Password",
                value: "$2b$10$zVMV5z1yTiQuX.RQ98HDVuw3DsCmmqw5K3s/RygkjwZThdlJE7ubC");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "Member_Id",
                keyValue: (short)2,
                column: "Password",
                value: "$2b$10$DXUSAzKZ2eEheVOzM5/a2OuCFMT7XKFQMZ37EdYzIBoPEfTlX.Gqu");
        }
    }
}
