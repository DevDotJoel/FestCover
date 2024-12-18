using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedLastSubscriptionDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastSubscriptionPayment",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "LastSubscriptionPayment", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ab94984-69aa-4483-ab1c-bde7cef652d9", null, "AQAAAAIAAYagAAAAEK39IFgoapHutVH6HLOiTCl1rhiIv5fBJmjwkMeJqgHcqNDYuwHSRS2ue7Oj5alsIg==", "a6031431-98db-4bc1-9e13-702af5b24064" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "LastSubscriptionPayment", "PasswordHash", "SecurityStamp" },
                values: new object[] { "634014c5-b5ac-4207-85ca-4020406371bc", null, "AQAAAAIAAYagAAAAEOYOuudUAMtDZrsrGW35okYfmwHmFX6McAEov7LWcJsi3IfTSNLHcwHIyNqFDO7e+w==", "b9081cab-0e72-443d-9895-93b4447ecfa1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "LastSubscriptionPayment", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd5c89ac-5cf6-4f56-890c-1b986265e075", null, "AQAAAAIAAYagAAAAECL13IXZGZ5phRd5H2y1CoKZ00FN4lyjPfm7pt3vtIiX0RbFqMl7tV64NayauxvC/A==", "d571ace5-d4bf-41cb-8323-a83508b139ac" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastSubscriptionPayment",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "014086d1-75e1-4fc8-b9c2-5b9b42e36b8b", "AQAAAAIAAYagAAAAEDKbZ8TnoeBg17YnupZDimyUbCJ+Bu5N69H9bMQ1/uKug3H4NSdlR4UV8zJHhf0RrQ==", "e3ae06e0-85d9-4edb-a7ba-5ca6dd5a703b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "172573ef-278d-4819-abcf-6c378a526837", "AQAAAAIAAYagAAAAEM0L8ikHeeR6KxwmrU5v80n6l05vi2WZQ568Fdwta4ad3XO+ZNHCOlJ4FCWyLLUyVw==", "8882410c-52b5-41fa-a745-e133a87fc2e3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f77eee60-9d78-43f9-8498-3236cd05684e", "AQAAAAIAAYagAAAAEMSQUN4CMX0yw9TmdEylwR9QE75tzJmtMTZ/JrxhP3j3zSBiKzdNp8AOlBWBcOrt5w==", "076b91f6-f15d-499b-8137-3f48d3506c7d" });
        }
    }
}
