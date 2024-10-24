using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d42d80d6-a2c4-4c30-9fc9-d56f0a51d47f", "AQAAAAIAAYagAAAAENMPUlV1aYB1Ck+WRLJF1P5mkDUvaPyyiuk+4SidIZI5HHpN4t6j7kmlIOrVxwwhRg==", "def8e4cf-d97d-462f-bcd1-254271ab736e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "859c71f4-7fa0-430b-b5c1-9adafb7e203d", "AQAAAAIAAYagAAAAEDNddH3c18rODULCGmpZzFl0Q4+vMwJ3VAslmy5qcYLDi+n7e2Cl9xKsqQbQuJlzkA==", "6f549a77-9eb2-4b77-879c-28315a3bf1d5" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"), 0, "0ab8493d-00bf-4974-8dca-4bc455487123", "isabelkiala@gmail.com", true, false, null, "ISABELKIALA@GMAIL.COM", "ISABELKIALA", "AQAAAAIAAYagAAAAEBnf2LwGqm8ntqb85fgm2KwDG5gURxZyZPdDCAPbLRz9fXj3lldh0dzfrpO1Lm5Uog==", "+351960180464", false, null, null, "efadf505-a2d8-40fd-ae2d-666e0ceec018", false, "IsabelKiala" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "545602ee-939b-4e8d-ad9c-7160554901b1", "AQAAAAIAAYagAAAAEGzbyt6KAr1CVBcVt8vHeeT54hSsBEyqTkjefRfjbNaPLLOxJM8PoIEQrjQCA0Werg==", "dd997f96-0f5a-49c0-a125-e2666713415f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90750a0a-a0c1-4e4a-9cbb-def864d51eb1", "AQAAAAIAAYagAAAAED2WFD8w8QOhfC4istp1QhaEWRSikDTIO1GDbPGHiZr+tUSgrZ/w/UAGpWQiVqf0hw==", "f9058ad7-ce9f-4c4e-b5eb-3b962e1f0fcd" });
        }
    }
}
