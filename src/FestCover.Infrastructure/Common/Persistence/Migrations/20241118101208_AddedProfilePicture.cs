using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedProfilePicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PictureUrl", "SecurityStamp" },
                values: new object[] { "f5896f22-d5b1-4259-8ce2-cad79be382dc", "AQAAAAIAAYagAAAAELIf93ynblSRsqaGOJ40HgniuZzWjAnZmlekENT0XDVY/gWIPMyBtJ14Eyi393eG1Q==", null, "fb3d9018-b815-426f-b58d-84ec75cb8d68" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PictureUrl", "SecurityStamp" },
                values: new object[] { "57f4c572-b597-41e2-96a4-5fffdb653ca7", "AQAAAAIAAYagAAAAELasnWWXrEDti8dO/MeBBEdySTowuAkd1QAjB/gdpPRcjG1aFkJq5jtF2xHWDZKqIA==", null, "868573b5-0dc4-4829-8301-7f9c4a449e08" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PictureUrl", "SecurityStamp" },
                values: new object[] { "f20bd4ab-ce78-4fee-bcd8-905b717aa9e0", "AQAAAAIAAYagAAAAEK91Trw51R+Loq6xO6SDAmFf/6D8fUtgAeVNLno7dxaY387IF80L0yGaABwjnexcjg==", null, "f270ab22-d52f-4f21-825d-9c9e09196f26" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Users");

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
    }
}
