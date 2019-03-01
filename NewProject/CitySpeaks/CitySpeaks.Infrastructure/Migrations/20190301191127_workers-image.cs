using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CitySpeaks.Infrastructure.Migrations
{
    public partial class workersimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Images_ImageId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ImageId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "BigImageData",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "BigImageMimeType",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "Workers");

            migrationBuilder.AddColumn<int>(
                name: "BigImageId",
                table: "Workers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SmallImageId",
                table: "Workers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Reviews",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Workers_BigImageId",
                table: "Workers",
                column: "BigImageId",
                unique: true,
                filter: "[BigImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_SmallImageId",
                table: "Workers",
                column: "SmallImageId",
                unique: true,
                filter: "[SmallImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ImageId",
                table: "Reviews",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Images_ImageId",
                table: "Reviews",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Images_BigImageId",
                table: "Workers",
                column: "BigImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Images_SmallImageId",
                table: "Workers",
                column: "SmallImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Images_ImageId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Images_BigImageId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Images_SmallImageId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_BigImageId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_SmallImageId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ImageId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "BigImageId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "SmallImageId",
                table: "Workers");

            migrationBuilder.AddColumn<byte[]>(
                name: "BigImageData",
                table: "Workers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BigImageMimeType",
                table: "Workers",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Workers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "Workers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ImageId",
                table: "Reviews",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Images_ImageId",
                table: "Reviews",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
