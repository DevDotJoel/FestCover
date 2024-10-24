using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewUser3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
