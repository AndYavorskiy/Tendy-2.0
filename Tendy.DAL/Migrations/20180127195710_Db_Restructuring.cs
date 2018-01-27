using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Tendy.DAL.Migrations
{
    public partial class Db_Restructuring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_AttachmentGroups_AttachmentGroupId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_AttachmentGroups_AttachmentGroupId",
                table: "Ideas");

            migrationBuilder.DropTable(
                name: "IdeaImages");

            migrationBuilder.DropTable(
                name: "PublicationImages");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "AttachmentGroups");

            migrationBuilder.DropIndex(
                name: "IX_Ideas_AttachmentGroupId",
                table: "Ideas");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_AttachmentGroupId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "AttachmentGroupId",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "AttachmentGroupId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "SourceUrl",
                table: "Attachments");

            migrationBuilder.AddColumn<int>(
                name: "IdeaId",
                table: "Attachments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttachmentId = table.Column<int>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    IsPrivate = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(nullable: true),
                    SourceUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttachmentId = table.Column<int>(nullable: false),
                    DateOfCreation = table.Column<DateTime>(nullable: true),
                    IsPrivate = table.Column<bool>(nullable: false, defaultValue: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_Attachments_AttachmentId",
                        column: x => x.AttachmentId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_IdeaId",
                table: "Attachments",
                column: "IdeaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_AttachmentId",
                table: "Files",
                column: "AttachmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_AttachmentId",
                table: "Links",
                column: "AttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Ideas_IdeaId",
                table: "Attachments",
                column: "IdeaId",
                principalTable: "Ideas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Ideas_IdeaId",
                table: "Attachments");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_IdeaId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "IdeaId",
                table: "Attachments");

            migrationBuilder.AddColumn<int>(
                name: "AttachmentGroupId",
                table: "Ideas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttachmentGroupId",
                table: "Attachments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "Attachments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrivate",
                table: "Attachments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceUrl",
                table: "Attachments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AttachmentGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachmentGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsMain = table.Column<bool>(nullable: true),
                    SorceUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttachmentGroupId = table.Column<int>(nullable: true),
                    DateOfCreation = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IdeaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publications_AttachmentGroups_AttachmentGroupId",
                        column: x => x.AttachmentGroupId,
                        principalTable: "AttachmentGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Publications_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdeaImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdeaId = table.Column<int>(nullable: true),
                    ImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdeaImages_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdeaImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicationImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageId = table.Column<int>(nullable: true),
                    PublicationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicationImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PublicationImages_Publications_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_AttachmentGroupId",
                table: "Ideas",
                column: "AttachmentGroupId",
                unique: true,
                filter: "[AttachmentGroupId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_AttachmentGroupId",
                table: "Attachments",
                column: "AttachmentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaImages_IdeaId",
                table: "IdeaImages",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaImages_ImageId",
                table: "IdeaImages",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationImages_ImageId",
                table: "PublicationImages",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationImages_PublicationId",
                table: "PublicationImages",
                column: "PublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_AttachmentGroupId",
                table: "Publications",
                column: "AttachmentGroupId",
                unique: true,
                filter: "[AttachmentGroupId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_IdeaId",
                table: "Publications",
                column: "IdeaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_AttachmentGroups_AttachmentGroupId",
                table: "Attachments",
                column: "AttachmentGroupId",
                principalTable: "AttachmentGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_AttachmentGroups_AttachmentGroupId",
                table: "Ideas",
                column: "AttachmentGroupId",
                principalTable: "AttachmentGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
