using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CitySpeaks.Infrastructure.Migrations
{
    public partial class newsimages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BigImageData",
                table: "News");

            migrationBuilder.DropColumn(
                name: "BigImageMimeType",
                table: "News");

            migrationBuilder.DropColumn(
                name: "SmallImageData",
                table: "News");

            migrationBuilder.DropColumn(
                name: "SmallImageMimeType",
                table: "News");

            migrationBuilder.AddColumn<int>(
                name: "BigImageId",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SmallImageId",
                table: "News",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_BigImageId",
                table: "News",
                column: "BigImageId",
                unique: true,
                filter: "[BigImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_News_SmallImageId",
                table: "News",
                column: "SmallImageId",
                unique: true,
                filter: "[SmallImageId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Images_BigImageId",
                table: "News",
                column: "BigImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Images_SmallImageId",
                table: "News",
                column: "SmallImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Images_BigImageId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Images_SmallImageId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_BigImageId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_SmallImageId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "BigImageId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "SmallImageId",
                table: "News");

            migrationBuilder.AddColumn<byte[]>(
                name: "BigImageData",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BigImageMimeType",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SmallImageData",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmallImageMimeType",
                table: "News",
                nullable: true);
        }
    }
}
