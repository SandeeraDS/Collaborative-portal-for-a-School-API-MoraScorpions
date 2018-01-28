using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestFullDatabase.Migrations
{
    public partial class Twelve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteDetails_Teachers_TeachersUserId",
                table: "NoteDetails");

            migrationBuilder.DropIndex(
                name: "IX_NoteDetails_TeachersUserId",
                table: "NoteDetails");

            migrationBuilder.DropColumn(
                name: "TeachersUserId",
                table: "NoteDetails");

            migrationBuilder.RenameColumn(
                name: "UploadedTime",
                table: "NoteDetails",
                newName: "UploadedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "NoteDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "NoteDetails");

            migrationBuilder.RenameColumn(
                name: "UploadedDate",
                table: "NoteDetails",
                newName: "UploadedTime");

            migrationBuilder.AddColumn<string>(
                name: "TeachersUserId",
                table: "NoteDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NoteDetails_TeachersUserId",
                table: "NoteDetails",
                column: "TeachersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteDetails_Teachers_TeachersUserId",
                table: "NoteDetails",
                column: "TeachersUserId",
                principalTable: "Teachers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
