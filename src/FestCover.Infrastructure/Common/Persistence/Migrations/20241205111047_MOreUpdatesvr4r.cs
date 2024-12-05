using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MOreUpdatesvr4r : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersProducts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionType",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "SubscriptionType" },
                values: new object[] { "014086d1-75e1-4fc8-b9c2-5b9b42e36b8b", "AQAAAAIAAYagAAAAEDKbZ8TnoeBg17YnupZDimyUbCJ+Bu5N69H9bMQ1/uKug3H4NSdlR4UV8zJHhf0RrQ==", "e3ae06e0-85d9-4edb-a7ba-5ca6dd5a703b", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "SubscriptionType" },
                values: new object[] { "172573ef-278d-4819-abcf-6c378a526837", "AQAAAAIAAYagAAAAEM0L8ikHeeR6KxwmrU5v80n6l05vi2WZQ568Fdwta4ad3XO+ZNHCOlJ4FCWyLLUyVw==", "8882410c-52b5-41fa-a745-e133a87fc2e3", 0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "SubscriptionType" },
                values: new object[] { "f77eee60-9d78-43f9-8498-3236cd05684e", "AQAAAAIAAYagAAAAEMSQUN4CMX0yw9TmdEylwR9QE75tzJmtMTZ/JrxhP3j3zSBiKzdNp8AOlBWBcOrt5w==", "076b91f6-f15d-499b-8137-3f48d3506c7d", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscriptionType",
                table: "Users");

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
                name: "UsersProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersProducts_Users_UserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_UsersProducts_ProductId",
                table: "UsersProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProducts_UserId",
                table: "UsersProducts",
                column: "UserId");
        }
    }
}
