using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProducts_Products_ProductId",
                table: "UserProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProducts_Users_UserId",
                table: "UserProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProducts",
                table: "UserProducts");

            migrationBuilder.RenameTable(
                name: "UserProducts",
                newName: "UsersProducts");

            migrationBuilder.RenameIndex(
                name: "IX_UserProducts_UserId",
                table: "UsersProducts",
                newName: "IX_UsersProducts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProducts_ProductId",
                table: "UsersProducts",
                newName: "IX_UsersProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersProducts",
                table: "UsersProducts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1099df0-3a12-4d3f-af5f-3b12ca133519", "AQAAAAIAAYagAAAAEElWc5L88XWQv7yq75DsdLuNWK3kNiNxC6Z/vVHvvQQkUH24UyrAI+OrKTC54z+VQg==", "e7bbdc4d-8660-4485-9f0e-18b834df76c2" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12e64e82-f009-449a-a565-c1a9969b1a40", "AQAAAAIAAYagAAAAEOkG2EtItyJqvD6rYtfd3P42zEXrVs5W3/jvgkBYwHSJqYbY4bIIxhvHbbXROHvUIw==", "5e52a307-746b-4907-964a-d707d2304e2a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35bfb9b6-35de-4212-a363-e8d009d864e0", "AQAAAAIAAYagAAAAEGdglK2FQTI/yTbdQQch9T0yh7TFGGgt2SpnXMf529WcoNACQcstUUIOik+PveEmsA==", "974ffddd-84e5-4e8e-80ee-f551dc8f63cd" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProducts_Products_ProductId",
                table: "UsersProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersProducts_Users_UserId",
                table: "UsersProducts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersProducts_Products_ProductId",
                table: "UsersProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersProducts_Users_UserId",
                table: "UsersProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersProducts",
                table: "UsersProducts");

            migrationBuilder.RenameTable(
                name: "UsersProducts",
                newName: "UserProducts");

            migrationBuilder.RenameIndex(
                name: "IX_UsersProducts_UserId",
                table: "UserProducts",
                newName: "IX_UserProducts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersProducts_ProductId",
                table: "UserProducts",
                newName: "IX_UserProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProducts",
                table: "UserProducts",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "013e7249-5edd-4bb7-9175-842915af3f77", "AQAAAAIAAYagAAAAEPTPePSE/rOTByJuu4k+iys/dA0BmG41XjAxZciEqkhS1Rx5o54s0bm3zP5Q48oxhQ==", "0a79fc37-18e1-4ac2-b1e7-79151ef55747" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18ac899c-88e1-40c2-9cdb-546b6a8d00ae", "AQAAAAIAAYagAAAAENBWwy2HOsT6iX2uA0KBzRL8ghWnmVk2NUJhpUpZGpGN3FpFdYrI6ebS2nYMPMlOJA==", "27e823d6-bc43-4320-a941-b1041c71b3d7" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d708dfcd-12fa-44b7-9dfa-0b865efa40fb", "AQAAAAIAAYagAAAAEOVCg7O5PG6X6Cch1RJ25HZpfxtaBwHj0W8F2BalmErFbQ/fg0Nf1LG9vK4GusYK2A==", "f23c1388-6cd4-4cde-a8f9-380abe64113c" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserProducts_Products_ProductId",
                table: "UserProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProducts_Users_UserId",
                table: "UserProducts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
