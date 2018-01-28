using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestFullDatabase.Migrations
{
    public partial class Eighteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionDetails_Teachers_TeachersUserId",
                table: "ActionDetails");

            migrationBuilder.DropIndex(
                name: "IX_ActionDetails_TeachersUserId",
                table: "ActionDetails");

            migrationBuilder.DropColumn(
                name: "TeachersUserId",
                table: "ActionDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeachersUserId",
                table: "ActionDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActionDetails_TeachersUserId",
                table: "ActionDetails",
                column: "TeachersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionDetails_Teachers_TeachersUserId",
                table: "ActionDetails",
                column: "TeachersUserId",
                principalTable: "Teachers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
