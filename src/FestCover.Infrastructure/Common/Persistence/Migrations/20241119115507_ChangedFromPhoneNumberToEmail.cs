using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedFromPhoneNumberToEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "AlbumContents",
                newName: "Email");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "268ceaf6-af8b-47e0-8499-956e69ec5670", "AQAAAAIAAYagAAAAEOfpOIqbhRRGplQOM3+AIeNPSzvl3P3+2l/oHUBjgz+xoPem0+/7YP3cH+NVpItQvw==", "3f60f5af-cd5d-42e3-aa21-3b9e54e237a6" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c8d0093-668d-4ed8-9928-864d5c807ea5", "AQAAAAIAAYagAAAAEI24UsVKSgFKAtx10Fk5Q4Zq4K+bZwD3HP0+jC8TBXnqfrHVo58latIaXwsX5W0EbQ==", "340f66b0-c82c-48d7-a358-380430148f19" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "603a65a1-d9c8-4b76-b8e3-cfa80a6ce2e4", "AQAAAAIAAYagAAAAEPT+KPaaxkVjcQ9Mnu93QlnYypzY/Ss3kOV5/xgShARxHwYC+9G/5gVaEsurDmz9Rw==", "19ff4a33-85a7-4513-99da-989f0a8c08ba" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "AlbumContents",
                newName: "PhoneNumber");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5896f22-d5b1-4259-8ce2-cad79be382dc", "AQAAAAIAAYagAAAAELIf93ynblSRsqaGOJ40HgniuZzWjAnZmlekENT0XDVY/gWIPMyBtJ14Eyi393eG1Q==", "fb3d9018-b815-426f-b58d-84ec75cb8d68" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57f4c572-b597-41e2-96a4-5fffdb653ca7", "AQAAAAIAAYagAAAAELasnWWXrEDti8dO/MeBBEdySTowuAkd1QAjB/gdpPRcjG1aFkJq5jtF2xHWDZKqIA==", "868573b5-0dc4-4829-8301-7f9c4a449e08" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f20bd4ab-ce78-4fee-bcd8-905b717aa9e0", "AQAAAAIAAYagAAAAEK91Trw51R+Loq6xO6SDAmFf/6D8fUtgAeVNLno7dxaY387IF80L0yGaABwjnexcjg==", "f270ab22-d52f-4f21-825d-9c9e09196f26" });
        }
    }
}
