using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FestCover.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MinorUpdatev5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AlbumUrlImage",
                table: "Albums",
                newName: "SmallAlbumUrlImage");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "SmallAlbumUrlImage",
                table: "Albums",
                newName: "AlbumUrlImage");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("613de40e-809c-47c2-8f8b-005efffff05e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d66fe8c-e3ad-4746-9a8b-26e154321280", "AQAAAAIAAYagAAAAEIpO28zVZGJYbeOcc3HBeMFx2FaA77n78aFEStXRObdG7QJoMrKjTh5khh2sXYuSIw==", "c6a9af71-ad5e-4fcc-b0d7-ca0ddc858df1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa14ed43-7698-408e-8b35-3e556e79bd18"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4b12fbb-6ba1-44fe-8efc-e057f4015414", "AQAAAAIAAYagAAAAEDxKLv2ODlk2dygxTn9xvUZLh4khH1Zhn0r48/ByviVNoo7thYxsiv26/FUF3VkTJQ==", "83c3d73b-6556-4de5-9707-28672df1996b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f69b50aa-de02-423b-abc4-0ba2fb3eb64d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed6c08c8-1bcb-4c98-8665-4128a14cabaf", "AQAAAAIAAYagAAAAECa+V3eeYKQ6Lr+DpUQIoXLE+UYSTvDswf07Aq0WKdFQtzU5KZ69ZLTmZe4NYlupwQ==", "93638284-fa22-4e10-a515-8f7ad58ea883" });
        }
    }
}
