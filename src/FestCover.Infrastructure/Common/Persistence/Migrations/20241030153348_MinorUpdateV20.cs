using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MinorUpdateV20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "AlbumContents",
                newName: "SmallAlbumContentUrlImage");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "SmallAlbumContentUrlImage",
                table: "AlbumContents",
                newName: "Url");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbf3d579-3273-4cb6-9eb2-39fc16fa477b", "AQAAAAIAAYagAAAAEIhpu/NEY6idjKMhwbj0QwB1JClYO49KgPxCujWSNdMhrQJIBbkRehlSmgABvhW58g==", "077fe7d6-3d7f-47e2-a692-bc8d2002741a" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98a0daeb-2e59-4e4e-8e68-d54832220b12", "AQAAAAIAAYagAAAAEP0vylne89vbXZS5kExF5Yvsm62a0UZ+mLKDKC+YJM+6KhYqe5t2+7jSRSiUUHcddA==", "4cb53199-9578-4d73-bd6e-48371a44fb3d" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7edf22d2-302e-4b72-bb47-1886bf79b6f8", "AQAAAAIAAYagAAAAEBLBWCkByc8aNm3lkTXdM56LmIVOp3XQFUgQOEo0hLm88uw5/L8G4JQODk6KPnBuiw==", "2df6e633-af52-4101-b2e8-d8a641b1a786" });
        }
    }
}
