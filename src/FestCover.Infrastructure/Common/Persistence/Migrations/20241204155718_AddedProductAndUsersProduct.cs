using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedProductAndUsersProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProducts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_ProductId",
                table: "UserProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_UserId",
                table: "UserProducts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProducts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "385a81bd-9f00-4db5-9f96-87094c446c63", "AQAAAAIAAYagAAAAEFy2KN9Rk+YZvpCwfPh9w0cPnUvElRzKKnBofuAdIsXnqOgOHkVnkNyqeUllS5XLEA==", "5dea7a8e-3c0d-40e2-a6e9-3676340471c8" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2479089-6abc-42f4-b562-1246ab5bef7d", "AQAAAAIAAYagAAAAEG3+mCVO8DdVcfdu0PfqEbTH9mqBmueMpAMjgfVYGoJm63Gb9RaPiKftNJXvxekPSA==", "9027e35f-4ad1-46cc-a499-925f19c1423c" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52766096-2b98-496d-8865-76cda60e4c2a", "AQAAAAIAAYagAAAAEAv3OtpX+XTwaeWZwt5iqCN/NYMjSi7L5byThn7gq67X6TrrCIr6uQEb4EDYFU/fKw==", "38c1947d-2c26-44cc-87f4-f9a01cbf92b0" });
        }
    }
}
