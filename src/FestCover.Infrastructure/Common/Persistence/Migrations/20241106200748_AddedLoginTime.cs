using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedLoginTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginTime",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "LastLoginTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ccf14a6b-7647-49ef-a328-327d83c2e04e", null, "AQAAAAIAAYagAAAAEF1h/UqYIL/pbGV3diD7e8tjAWscpaxgGoehyzcXpIVV5sEOZg4pHRcCGNvOp1lDUg==", "1a5b2f1e-9e95-44ca-8bf3-6c8274209acb" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "LastLoginTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f147414-ac6d-4820-be48-88e42d3b19d8", null, "AQAAAAIAAYagAAAAEOhdA7pShQjzbVG0Sua73pfQds8t9IfjAxzql0bjcpk51QzmCH2KJk9LhxDcZqkF+A==", "45175fb4-cd4c-420e-87ba-ae6cb61a036d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "LastLoginTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c23f038c-759d-48cb-aea2-55f21914dd84", null, "AQAAAAIAAYagAAAAEFgi68C9fi54i+F6PO2ik3Cyb1Me3/v/dyFqr043AGBlnTDMMZcFwVg5aXpuqmdBcQ==", "5470799c-b989-4fe7-ad0a-1d233899a730" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLoginTime",
                table: "Users");

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
    }
}
