using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestFullDatabase.Migrations
{
    public partial class Fourteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReplierId",
                table: "NoteCommentReply",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_NoteCommentReply_ReplierId",
                table: "NoteCommentReply",
                column: "ReplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteCommentReply_AspNetUsers_ReplierId",
                table: "NoteCommentReply",
                column: "ReplierId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteCommentReply_AspNetUsers_ReplierId",
                table: "NoteCommentReply");

            migrationBuilder.DropIndex(
                name: "IX_NoteCommentReply_ReplierId",
                table: "NoteCommentReply");

            migrationBuilder.DropColumn(
                name: "ReplierId",
                table: "NoteCommentReply");
        }
    }
}
