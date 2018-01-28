using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestFullDatabase.Migrations
{
    public partial class Eleven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteCommentDetails_Students_StudentId",
                table: "NoteCommentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteCommentDetails_Teachers_TeacherId",
                table: "NoteCommentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteDetails_Teachers_TeacherId",
                table: "NoteDetails");

            migrationBuilder.DropIndex(
                name: "IX_NoteDetails_TeacherId",
                table: "NoteDetails");

            migrationBuilder.DropIndex(
                name: "IX_NoteCommentDetails_StudentId",
                table: "NoteCommentDetails");

            migrationBuilder.DropIndex(
                name: "IX_NoteCommentDetails_TeacherId",
                table: "NoteCommentDetails");

            migrationBuilder.DropColumn(
                name: "Discription",
                table: "NoteDetails");

            migrationBuilder.DropColumn(
                name: "NoteFileName",
                table: "NoteDetails");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "NoteCommentDetails");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "NoteCommentDetails");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "NoteDetails",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "NoteDetails",
                newName: "TernaryId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "NoteDetails",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "TeachersUserId",
                table: "NoteDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "NoteCommentDetails",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "NoteCommentReply",
                columns: table => new
                {
                    ReplyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    RepliedTime = table.Column<DateTime>(nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_NoteDetails_TeachersUserId",
                table: "NoteDetails",
                column: "TeachersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteDetails_TernaryId",
                table: "NoteDetails",
                column: "TernaryId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteCommentDetails_UserId",
                table: "NoteCommentDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteCommentReply_CommentId",
                table: "NoteCommentReply",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteCommentDetails_AspNetUsers_UserId",
                table: "NoteCommentDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteDetails_Teachers_TeachersUserId",
                table: "NoteDetails",
                column: "TeachersUserId",
                principalTable: "Teachers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteDetails_Ternary_TernaryId",
                table: "NoteDetails",
                column: "TernaryId",
                principalTable: "Ternary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteCommentDetails_AspNetUsers_UserId",
                table: "NoteCommentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteDetails_Teachers_TeachersUserId",
                table: "NoteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_NoteDetails_Ternary_TernaryId",
                table: "NoteDetails");

            migrationBuilder.DropTable(
                name: "NoteCommentReply");

            migrationBuilder.DropIndex(
                name: "IX_NoteDetails_TeachersUserId",
                table: "NoteDetails");

            migrationBuilder.DropIndex(
                name: "IX_NoteDetails_TernaryId",
                table: "NoteDetails");

            migrationBuilder.DropIndex(
                name: "IX_NoteCommentDetails_UserId",
                table: "NoteCommentDetails");

            migrationBuilder.DropColumn(
                name: "TeachersUserId",
                table: "NoteDetails");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NoteCommentDetails");

            migrationBuilder.RenameColumn(
                name: "TernaryId",
                table: "NoteDetails",
                newName: "ClassId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "NoteDetails",
                newName: "TeacherId");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "NoteDetails",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "NoteDetails",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NoteFileName",
                table: "NoteDetails",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "NoteCommentDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "NoteCommentDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoteDetails_TeacherId",
                table: "NoteDetails",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteCommentDetails_StudentId",
                table: "NoteCommentDetails",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteCommentDetails_TeacherId",
                table: "NoteCommentDetails",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteCommentDetails_Students_StudentId",
                table: "NoteCommentDetails",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteCommentDetails_Teachers_TeacherId",
                table: "NoteCommentDetails",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NoteDetails_Teachers_TeacherId",
                table: "NoteDetails",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
