using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedReviewUploadedContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReviewUploadedContent",
                table: "Albums",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4338570d-17f5-4fd9-8dde-9c50fea4bca2", "AQAAAAIAAYagAAAAEGRFQzmdV/Mmuvzq0g7iCSyfUafaZ2gGBm6F7Vgr8Q7hc+YSGdarZyamH/xyvfnWOQ==", "9c9fad11-a50d-4f66-8b00-298c3033e656" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91e23de8-dc89-4aa8-bdd2-6fd2546e8edf", "AQAAAAIAAYagAAAAECTULqJ4eviQrg9pmtk6JrIg/qI69LmMU6SmKoCLVH5F8xAd29NOBTd8rquB5CLwZg==", "197e4adb-ba08-44bf-a60f-6dd4625db76c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "483e41c8-9179-4ad8-8041-ff7bf9fdae53", "AQAAAAIAAYagAAAAENZKa4hC2xSQXLZVTFyUrXGsWFwmo6N/z1RcgEHN2CS37Ue+cbmZl9c/dSNqHOrerg==", "eb6f6c9e-d941-4d42-a20d-314d5d45acaa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReviewUploadedContent",
                table: "Albums");

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
    }
}
