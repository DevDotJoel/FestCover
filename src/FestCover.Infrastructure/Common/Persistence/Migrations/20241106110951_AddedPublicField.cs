using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedPublicField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Albums",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11511feb-2d58-4c52-b2b5-64baa5a3476a", "AQAAAAIAAYagAAAAEPTJceqa2v65M1GIMOp8iy+Bon39nQDkLfutv86b3tl50woFUZTbZfZ/v/NrYBpSXA==", "ccec22aa-211d-4dc0-a4ab-259fc1bf6ee5" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2898e414-f583-453b-b1a9-d40a6c4a0272", "AQAAAAIAAYagAAAAEN7jtqgOVW0Pp4I3Mp1xk2bk8IQMyGLDXypKh0frjl86W54S3I6xcJcYVjl58QH1Hw==", "ff1f68bb-4f92-48b4-885c-53bae9866d4f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1c98f72-5f23-4396-a03b-ac80316ca3d3", "AQAAAAIAAYagAAAAELIfqxZebGYOfONDt7SBZbeeeWdySMNS7IToxR9nf7w64d5eHO9HoLbBZVeX/dyUpA==", "ffd083b2-b540-487e-bf62-8ec1ebf8dbb3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Albums");

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
    }
}
