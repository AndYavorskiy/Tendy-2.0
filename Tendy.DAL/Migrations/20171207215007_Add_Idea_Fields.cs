using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tendy.DAL.Migrations
{
    public partial class Add_Idea_Fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_AspNetUsers_ApplicationUserId",
                table: "Ideas");

            migrationBuilder.DropIndex(
                name: "IX_Ideas_ApplicationUserId",
                table: "Ideas");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Ideas",
                newName: "Title");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Ideas",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Ideas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "Ideas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_AuthorId",
                table: "Ideas",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_AspNetUsers_AuthorId",
                table: "Ideas",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_AspNetUsers_AuthorId",
                table: "Ideas");

            migrationBuilder.DropIndex(
                name: "IX_Ideas_AuthorId",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "SubTitle",
                table: "Ideas");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Ideas",
                newName: "ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Ideas",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_ApplicationUserId",
                table: "Ideas",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_AspNetUsers_ApplicationUserId",
                table: "Ideas",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
