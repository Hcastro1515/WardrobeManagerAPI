using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WardrobeManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WardrobeItems_Wardrobes_WardrobeId",
                table: "WardrobeItems");

            migrationBuilder.AlterColumn<int>(
                name: "WardrobeId",
                table: "WardrobeItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "WardrobeItemImageFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataFiles = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    uploadedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WardrobeItemImageFile", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WardrobeItems_Wardrobes_WardrobeId",
                table: "WardrobeItems",
                column: "WardrobeId",
                principalTable: "Wardrobes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WardrobeItems_Wardrobes_WardrobeId",
                table: "WardrobeItems");

            migrationBuilder.DropTable(
                name: "WardrobeItemImageFile");

            migrationBuilder.AlterColumn<int>(
                name: "WardrobeId",
                table: "WardrobeItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_WardrobeItems_Wardrobes_WardrobeId",
                table: "WardrobeItems",
                column: "WardrobeId",
                principalTable: "Wardrobes",
                principalColumn: "Id");
        }
    }
}
