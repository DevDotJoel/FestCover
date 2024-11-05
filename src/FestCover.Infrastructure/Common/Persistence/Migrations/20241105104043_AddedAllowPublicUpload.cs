using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAllowPublicUpload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowPublicUpload",
                table: "Albums",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Pending",
                table: "AlbumContents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cb28543-2306-4c85-b375-cde945f45316", "AQAAAAIAAYagAAAAELdFAeXILNzXPrgfPulQDv538Kl9CK6F6mqyS5x4Y42nnD9C1tp3KVvt3wWhCtWffg==", "88c4568a-83bd-4c00-97f6-58c51c00696b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68ed53b5-46d4-44f5-92a5-708814b07cdd", "AQAAAAIAAYagAAAAECLTxrk7qJhJEnPgTWG3yMfQ6VQI7NaBWJNIZVWRDg9GxtqQpGENyhLH5AGyY3PIYw==", "b67620be-d679-41d7-88e2-22f729e7d9f6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "201bb950-f345-447c-bb2a-0b9bba687320", "AQAAAAIAAYagAAAAEAlpLhMBHSq1Z/SHylAGnJOfbVTo9bBrKTV4/45NWsAKGLb1r68UcmxdQUdk0MOO6Q==", "b909ffab-63dd-46ae-8e70-01b48f7f8256" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowPublicUpload",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "Pending",
                table: "AlbumContents");

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
    }
}
