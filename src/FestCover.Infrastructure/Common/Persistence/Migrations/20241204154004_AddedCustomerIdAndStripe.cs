using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCustomerIdAndStripe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "CustomerId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "385a81bd-9f00-4db5-9f96-87094c446c63", null, "AQAAAAIAAYagAAAAEFy2KN9Rk+YZvpCwfPh9w0cPnUvElRzKKnBofuAdIsXnqOgOHkVnkNyqeUllS5XLEA==", "5dea7a8e-3c0d-40e2-a6e9-3676340471c8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "CustomerId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2479089-6abc-42f4-b562-1246ab5bef7d", null, "AQAAAAIAAYagAAAAEG3+mCVO8DdVcfdu0PfqEbTH9mqBmueMpAMjgfVYGoJm63Gb9RaPiKftNJXvxekPSA==", "9027e35f-4ad1-46cc-a499-925f19c1423c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "CustomerId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52766096-2b98-496d-8865-76cda60e4c2a", null, "AQAAAAIAAYagAAAAEAv3OtpX+XTwaeWZwt5iqCN/NYMjSi7L5byThn7gq67X6TrrCIr6uQEb4EDYFU/fKw==", "38c1947d-2c26-44cc-87f4-f9a01cbf92b0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Users");

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
    }
}
