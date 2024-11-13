using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AlbumContents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f4edda8-8057-4fe8-acda-74c6273380e4", "AQAAAAIAAYagAAAAEAVnHkPDT3lNKtA0qmthDecHo6aKiG68DDdww7e+LwfawCGqxfWsYgvdue1bxLYyBw==", "bcae5051-51e6-4b30-a4f7-4a0a7c4dad41" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee3003be-8aaf-4f6b-809b-b1490125fc1e", "AQAAAAIAAYagAAAAEFzu9Ij/b6ofgZ0MvTU+oJpkrjNJvnRfpD4/+g6QUhBGLMh/V04dTqjWz+HHB7l0Jw==", "03f26adf-b77e-4763-bb9d-9e1bd34f5c91" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da0472e2-c5df-4405-96a5-3561e00aab87", "AQAAAAIAAYagAAAAEEwnrWcoBoAZ89nBnbuET53uPksrVWFn3X6Du82Cgv0tB46MfdHcaOGo1yGxK5vq7g==", "1da052e4-adf4-46e7-a1df-18a42652de3c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AlbumContents");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ccf14a6b-7647-49ef-a328-327d83c2e04e", "AQAAAAIAAYagAAAAEF1h/UqYIL/pbGV3diD7e8tjAWscpaxgGoehyzcXpIVV5sEOZg4pHRcCGNvOp1lDUg==", "1a5b2f1e-9e95-44ca-8bf3-6c8274209acb" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f147414-ac6d-4820-be48-88e42d3b19d8", "AQAAAAIAAYagAAAAEOhdA7pShQjzbVG0Sua73pfQds8t9IfjAxzql0bjcpk51QzmCH2KJk9LhxDcZqkF+A==", "45175fb4-cd4c-420e-87ba-ae6cb61a036d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c23f038c-759d-48cb-aea2-55f21914dd84", "AQAAAAIAAYagAAAAEFgi68C9fi54i+F6PO2ik3Cyb1Me3/v/dyFqr043AGBlnTDMMZcFwVg5aXpuqmdBcQ==", "5470799c-b989-4fe7-ad0a-1d233899a730" });
        }
    }
}
