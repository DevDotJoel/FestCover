using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedMirandaUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90750a0a-a0c1-4e4a-9cbb-def864d51eb1", "AQAAAAIAAYagAAAAED2WFD8w8QOhfC4istp1QhaEWRSikDTIO1GDbPGHiZr+tUSgrZ/w/UAGpWQiVqf0hw==", "f9058ad7-ce9f-4c4e-b5eb-3b962e1f0fcd" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("613de40e-809c-47c2-8f8b-005efffff05e"), 0, "545602ee-939b-4e8d-ad9c-7160554901b1", "mirandajp@gmail.com", true, false, null, "MIRANDAJP@GMAIL.COM", "JOAOMIRANDA", "AQAAAAIAAYagAAAAEGzbyt6KAr1CVBcVt8vHeeT54hSsBEyqTkjefRfjbNaPLLOxJM8PoIEQrjQCA0Werg==", "+351960180464", false, null, null, "dd997f96-0f5a-49c0-a125-e2666713415f", false, "JoaoMiranda" });

            migrationBuilder.InsertData(
                table: "UsersRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("d67c7fbd-69bb-4926-acb6-f393143c16b3"), new Guid("613de40e-809c-47c2-8f8b-005efffff05e") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d67c7fbd-69bb-4926-acb6-f393143c16b3"), new Guid("613de40e-809c-47c2-8f8b-005efffff05e") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bb675ee-01da-4f36-8d84-8c57064f6a63", "AQAAAAIAAYagAAAAEM09LAclJrutSNwbgvQNjwrciMc1UvqybmIk0L3VaoP943Pz6zWbGozWbnk78UtrRQ==", "f3530b50-e613-484a-81c9-0b37b5ceb213" });
        }
    }
}
