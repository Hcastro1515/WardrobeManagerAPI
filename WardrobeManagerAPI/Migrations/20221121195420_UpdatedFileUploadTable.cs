using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedFileUploadTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFiles",
                table: "WardrobeItemImageFile");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "WardrobeItemImageFile");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "WardrobeItemImageFile");

            migrationBuilder.DropColumn(
                name: "uploadedOn",
                table: "WardrobeItemImageFile");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "WardrobeItemImageFile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "WardrobeItemImageFile",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoredFileName",
                table: "WardrobeItemImageFile",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "WardrobeItemImageFile");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "WardrobeItemImageFile");

            migrationBuilder.DropColumn(
                name: "StoredFileName",
                table: "WardrobeItemImageFile");

            migrationBuilder.AddColumn<byte[]>(
                name: "DataFiles",
                table: "WardrobeItemImageFile",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "WardrobeItemImageFile",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "WardrobeItemImageFile",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "uploadedOn",
                table: "WardrobeItemImageFile",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
