using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c772a892-1768-4d94-b14d-d970af8f8c22", "AQAAAAIAAYagAAAAENNepTWqKH2X5lJXNIk+02IB0zkfONJc85F/OBZi9zy/1h2vNPFfUQ8cIHsRQJeCPg==", "c683386d-014d-47d1-a9ed-95ca16c45de9" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd839bd8-2be9-4731-9a04-f46c6a1ec04c", "AQAAAAIAAYagAAAAEEu8BKTniVCJaM1HC/Qpv8rtJc97AVKNF9shHS+2LfjVOToUz/VHeMx0LYwQS7oA4w==", "68ff4c87-9c45-43ca-bfb9-173265629ccf" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f13f9058-7ebf-4a7d-9074-99a234ef9e41", "AQAAAAIAAYagAAAAEOvSBCI/YPzFtBxQAQ0ZR8gmW8wxyihHkOukCSVAxC0IfnPxrR2WFZgyAOhxNd/yyQ==", "db9361b9-2a3f-4d2d-bc10-92ea2e53b9aa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ab8493d-00bf-4974-8dca-4bc455487123", "AQAAAAIAAYagAAAAEBnf2LwGqm8ntqb85fgm2KwDG5gURxZyZPdDCAPbLRz9fXj3lldh0dzfrpO1Lm5Uog==", "efadf505-a2d8-40fd-ae2d-666e0ceec018" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "859c71f4-7fa0-430b-b5c1-9adafb7e203d", "AQAAAAIAAYagAAAAEDNddH3c18rODULCGmpZzFl0Q4+vMwJ3VAslmy5qcYLDi+n7e2Cl9xKsqQbQuJlzkA==", "6f549a77-9eb2-4b77-879c-28315a3bf1d5" });
        }
    }
}
