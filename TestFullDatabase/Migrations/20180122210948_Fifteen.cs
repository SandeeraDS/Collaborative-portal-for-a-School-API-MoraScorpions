using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestFullDatabase.Migrations
{
    public partial class Fifteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteCommentReply");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoteCommentReply",
                columns: table => new
                {
                    ReplyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    RepliedTime = table.Column<DateTime>(nullable: false),
                    ReplierId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteCommentReply", x => x.ReplyId);
                    table.ForeignKey(
                        name: "FK_NoteCommentReply_NoteCommentDetails_CommentId",
                        column: x => x.CommentId,
                        principalTable: "NoteCommentDetails",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteCommentReply_AspNetUsers_ReplierId",
                        column: x => x.ReplierId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteCommentReply_CommentId",
                table: "NoteCommentReply",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteCommentReply_ReplierId",
                table: "NoteCommentReply",
                column: "ReplierId");
        }
    }
}
