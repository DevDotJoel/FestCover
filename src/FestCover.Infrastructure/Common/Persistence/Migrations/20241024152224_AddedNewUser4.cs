using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewUser4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d66fe8c-e3ad-4746-9a8b-26e154321280", "AQAAAAIAAYagAAAAEIpO28zVZGJYbeOcc3HBeMFx2FaA77n78aFEStXRObdG7QJoMrKjTh5khh2sXYuSIw==", "c6a9af71-ad5e-4fcc-b0d7-ca0ddc858df1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4b12fbb-6ba1-44fe-8efc-e057f4015414", "AQAAAAIAAYagAAAAEDxKLv2ODlk2dygxTn9xvUZLh4khH1Zhn0r48/ByviVNoo7thYxsiv26/FUF3VkTJQ==", "83c3d73b-6556-4de5-9707-28672df1996b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed6c08c8-1bcb-4c98-8665-4128a14cabaf", "AQAAAAIAAYagAAAAECa+V3eeYKQ6Lr+DpUQIoXLE+UYSTvDswf07Aq0WKdFQtzU5KZ69ZLTmZe4NYlupwQ==", "93638284-fa22-4e10-a515-8f7ad58ea883" });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("d67c7fbd-69bb-4926-acb6-f393143c16b3"), new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d67c7fbd-69bb-4926-acb6-f393143c16b3"), new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6496d0b3-1197-4725-81ed-cde6c8d054ce", "AQAAAAIAAYagAAAAEEtuPumU6//WcIGmzb2r1crfrSMzu7+R2k5NoQyC7IbIce4IuHY6KMLf1YI1Xh3YNQ==", "23f5185a-bd53-42b3-98b8-bc7e8e83b3c3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec63cfef-ea21-4196-a101-6c22d29c5d28", "AQAAAAIAAYagAAAAEAB7TuUP4TzxCi9VzQD8GKGONji83rqE6M5/K9d0bnanT2y2ud24rE8d1lK370yi4g==", "b0169f02-e90c-4a5c-ba47-e106339e0c94" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56abb71b-cfc9-40fc-a655-0aac35fb1f79", "AQAAAAIAAYagAAAAEKwQBu67kctLBlsG0J0R7kWf8h0R8vvBWIngU982XHGs3C383eYS7XJ5ars1aqw7YA==", "009721be-625f-45bc-af0b-6b564f7de482" });
        }
    }
}
