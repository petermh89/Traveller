using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Traveller.Data.Migrations
{
    public partial class user_img : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ProfilePhotos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePhotos_UserId",
                table: "ProfilePhotos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilePhotos_AspNetUsers_UserId",
                table: "ProfilePhotos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfilePhotos_AspNetUsers_UserId",
                table: "ProfilePhotos");

            migrationBuilder.DropIndex(
                name: "IX_ProfilePhotos_UserId",
                table: "ProfilePhotos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProfilePhotos");
        }
    }
}
