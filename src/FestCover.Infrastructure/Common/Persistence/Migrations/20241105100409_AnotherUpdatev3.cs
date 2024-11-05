using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AnotherUpdatev3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b78221ea-e6ca-407a-8cc3-e50f0bd8e33f", "AQAAAAIAAYagAAAAEKc4DSOiBwbj42Q6quiln2wGOoSE0QuFGB3Y7YoGV1nFGjetEMoc/9clxEGGRyBQxQ==", "0e014ea6-6650-4eb2-ace0-282413808f72" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f335d534-c063-497d-b860-a72fc7237960", "AQAAAAIAAYagAAAAEINGth4DpNs4Vbf4YsUX5EzYB6j87+AWQRh8GHNIdQaWrjXq3oIQTDi4BuqAYeQBfw==", "d1fac02d-c3e8-4ad0-a2be-16afd4d6d557" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d34d0564-ef91-416d-87dc-f64cb39418af", "AQAAAAIAAYagAAAAEEMYIFKaW9x0yOxGZHvGM5WvRTlyl+/2LAIqJHJXN5ErPI4VriCXxiO1t/LupZxiIQ==", "68ce8eda-be70-43fd-8feb-c1e1405be9c2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f407ce7-cf23-4e8b-b62e-082781393581", "AQAAAAIAAYagAAAAEKtjGznDn9wO/s5PHZfDng8ho62NXsPIZbU++KbwevCuZi4SxniaXDbsEmdaCfvUmw==", "e1f14ce3-0923-46cd-9cb2-2f970387900e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7c0c8bd-aaa8-4239-9ebb-0912250c9823", "AQAAAAIAAYagAAAAELYG23AAUocPyIHiAHcQTflD/l5laXAjD19fAsXBSsGwesnspowqpbe1u3MHnHllIg==", "8f8fc909-866d-4b7b-aa50-bbb7ab9e8077" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "706ef391-50ba-4d03-809d-2d5230151f33", "AQAAAAIAAYagAAAAEOgTfuNu+LtAX+d7sQS3OePpKGNLOZ3W5rDmSAYq4+FB4R5vI55PIuOti3w9e1t63Q==", "285b1489-a4f6-4a53-b8c5-12bb59638455" });
        }
    }
}
