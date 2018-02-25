using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tendy.DAL.Migrations
{
    public partial class Removed_Attachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Attachments_AttachmentId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Attachments_AttachmentId",
                table: "Links");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.RenameColumn(
                name: "AttachmentId",
                table: "Links",
                newName: "IdeaId");

            migrationBuilder.RenameIndex(
                name: "IX_Links_AttachmentId",
                table: "Links",
                newName: "IX_Links_IdeaId");

            migrationBuilder.RenameColumn(
                name: "AttachmentId",
                table: "Files",
                newName: "IdeaId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_AttachmentId",
                table: "Files",
                newName: "IX_Files_IdeaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Ideas_IdeaId",
                table: "Files",
                column: "IdeaId",
                principalTable: "Ideas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Ideas_IdeaId",
                table: "Links",
                column: "IdeaId",
                principalTable: "Ideas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Ideas_IdeaId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Ideas_IdeaId",
                table: "Links");

            migrationBuilder.RenameColumn(
                name: "IdeaId",
                table: "Links",
                newName: "AttachmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Links_IdeaId",
                table: "Links",
                newName: "IX_Links_AttachmentId");

            migrationBuilder.RenameColumn(
                name: "IdeaId",
                table: "Files",
                newName: "AttachmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_IdeaId",
                table: "Files",
                newName: "IX_Files_AttachmentId");

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdeaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_IdeaId",
                table: "Attachments",
                column: "IdeaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Attachments_AttachmentId",
                table: "Files",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Attachments_AttachmentId",
                table: "Links",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
