using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AnotherUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LargeAlbumUrlImage",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "MediumAlbumUrlImage",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "OriginalAlbumUrlImage",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "LargeAlbumContentUrlImage",
                table: "AlbumContents");

            migrationBuilder.DropColumn(
                name: "MediumAlbumContentUrlImage",
                table: "AlbumContents");

            migrationBuilder.DropColumn(
                name: "OriginalAlbumContentUrlImage",
                table: "AlbumContents");

            migrationBuilder.RenameColumn(
                name: "SmallAlbumUrlImage",
                table: "Albums",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "SmallAlbumContentUrlImage",
                table: "AlbumContents",
                newName: "Url");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f407ce7-cf23-4e8b-b62e-082781393581", "AQAAAAIAAYagAAAAEKtjGznDn9wO/s5PHZfDng8ho62NXsPIZbU++KbwevCuZi4SxniaXDbsEmdaCfvUmw==", "e1f14ce3-0923-46cd-9cb2-2f970387900e" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7c0c8bd-aaa8-4239-9ebb-0912250c9823", "AQAAAAIAAYagAAAAELYG23AAUocPyIHiAHcQTflD/l5laXAjD19fAsXBSsGwesnspowqpbe1u3MHnHllIg==", "8f8fc909-866d-4b7b-aa50-bbb7ab9e8077" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "706ef391-50ba-4d03-809d-2d5230151f33", "AQAAAAIAAYagAAAAEOgTfuNu+LtAX+d7sQS3OePpKGNLOZ3W5rDmSAYq4+FB4R5vI55PIuOti3w9e1t63Q==", "285b1489-a4f6-4a53-b8c5-12bb59638455" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Albums",
                newName: "SmallAlbumUrlImage");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "AlbumContents",
                newName: "SmallAlbumContentUrlImage");

            migrationBuilder.AddColumn<string>(
                name: "LargeAlbumUrlImage",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MediumAlbumUrlImage",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginalAlbumUrlImage",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LargeAlbumContentUrlImage",
                table: "AlbumContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MediumAlbumContentUrlImage",
                table: "AlbumContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginalAlbumContentUrlImage",
                table: "AlbumContents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16c1c36a-8113-46f9-a59c-36623eac2589", "AQAAAAIAAYagAAAAEHaonDtxG/w47aE5nZnWu9OlgyQYGlM4r5PWvgEZJi6Tyn4Bg322zb6DITlkUhPhyg==", "de3fc915-36ca-4fe1-b9b4-e589f73b78db" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8ef2293-1d15-41a4-9fdf-f7a0d028bc95", "AQAAAAIAAYagAAAAEEbsRdZRyn0riCGA4FlKrA55ht4JfD2tO5wTDAiPxfNHOiDygiT+nweFv7CFXNqlYw==", "f50963d4-d2b7-4589-ad8d-b13d87cf3282" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a7da342-0356-4b5b-a482-c7b640c23080", "AQAAAAIAAYagAAAAEDDeW5tCiIILzKoBy9COHSDVAqhCh7M+Awy6+xC3UBuPtKRzBIaXYNk53S1JYVYjdw==", "5f6a207a-db34-48bb-864a-b433351db501" });
        }
    }
}
