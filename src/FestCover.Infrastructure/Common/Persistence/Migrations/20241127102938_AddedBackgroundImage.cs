using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedBackgroundImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackgroundUrl",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a125930-205c-4428-8792-79d0a28410ab", "AQAAAAIAAYagAAAAELkc3xYWbzXHnQBFtJ++4JxfwBaifVMc43OD2+9fmDUoyoSAqqHjOb7BYljMbQXANQ==", "f2d036d1-87b6-4384-96e6-5ea6cdf27c42" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b5c3022-d536-4ab0-8e15-744cc3cfb6a0", "AQAAAAIAAYagAAAAEE23mFYnXGVUsqLk/vbSs+u/hTJXIT4BfyXAXtmCQEfMH7kpRkueSTOg/xYyrRsjcw==", "1103cc0d-2d8f-4e4e-9e3d-e7cded91316d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7652f31e-1367-458a-97dc-3429bd28f2c8", "AQAAAAIAAYagAAAAEP6pQuveOoqs0Tj9hdn6HVKG3QSg88lhwae9UyzxRdbvlXJyIgftLuzEBBQ0L6VNFg==", "2685f2b8-ceaa-4b49-ac2f-d6c026a24e58" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundUrl",
                table: "Albums");

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
    }
}
