using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tendy.DAL.Migrations
{
    public partial class updatedIdeaJoinRequst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_PeopleGroups_AcceptedPeopleGroupId",
                table: "Ideas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_PeopleGroups_RequestedPeopleGroupId",
                table: "Ideas");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_PeopleGroups_PeopleGroupId",
                table: "Requests");

            migrationBuilder.DropTable(
                name: "PeopleGroups");

            migrationBuilder.DropIndex(
                name: "IX_Requests_PeopleGroupId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Ideas_AcceptedPeopleGroupId",
                table: "Ideas");

            migrationBuilder.DropIndex(
                name: "IX_Ideas_RequestedPeopleGroupId",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "PeopleGroupId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "AcceptedPeopleGroupId",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "RequestedPeopleGroupId",
                table: "Ideas");

            migrationBuilder.AddColumn<int>(
                name: "IdeaId",
                table: "Requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Requests",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Requests",
                nullable: true,
                defaultValue: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_IdeaId",
                table: "Requests",
                column: "IdeaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Ideas_IdeaId",
                table: "Requests",
                column: "IdeaId",
                principalTable: "Ideas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Ideas_IdeaId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_IdeaId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IdeaId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "PeopleGroupId",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AcceptedPeopleGroupId",
                table: "Ideas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestedPeopleGroupId",
                table: "Ideas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PeopleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_PeopleGroupId",
                table: "Requests",
                column: "PeopleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_AcceptedPeopleGroupId",
                table: "Ideas",
                column: "AcceptedPeopleGroupId",
                unique: true,
                filter: "[AcceptedPeopleGroupId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_RequestedPeopleGroupId",
                table: "Ideas",
                column: "RequestedPeopleGroupId",
                unique: true,
                filter: "[RequestedPeopleGroupId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_PeopleGroups_AcceptedPeopleGroupId",
                table: "Ideas",
                column: "AcceptedPeopleGroupId",
                principalTable: "PeopleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_PeopleGroups_RequestedPeopleGroupId",
                table: "Ideas",
                column: "RequestedPeopleGroupId",
                principalTable: "PeopleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_PeopleGroups_PeopleGroupId",
                table: "Requests",
                column: "PeopleGroupId",
                principalTable: "PeopleGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
