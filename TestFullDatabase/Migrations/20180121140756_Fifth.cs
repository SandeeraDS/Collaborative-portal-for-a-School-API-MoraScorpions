using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestFullDatabase.Migrations
{
    public partial class Fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionDetails_Principals_PrincipalId",
                table: "ActionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionDetails_Teachers_TeacherId",
                table: "ActionDetails");

            migrationBuilder.DropIndex(
                name: "IX_ActionDetails_PrincipalId",
                table: "ActionDetails");

            migrationBuilder.DropColumn(
                name: "PrincipalId",
                table: "ActionDetails");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "ActionDetails",
                newName: "TeachersUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ActionDetails_TeacherId",
                table: "ActionDetails",
                newName: "IX_ActionDetails_TeachersUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Satisfaction",
                table: "ActionDetails",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "ActionDetails",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<bool>(
                name: "ActionTaken",
                table: "ActionDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionDetails_Teachers_TeachersUserId",
                table: "ActionDetails",
                column: "TeachersUserId",
                principalTable: "Teachers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionDetails_Teachers_TeachersUserId",
                table: "ActionDetails");

            migrationBuilder.DropColumn(
                name: "ActionTaken",
                table: "ActionDetails");

            migrationBuilder.RenameColumn(
                name: "TeachersUserId",
                table: "ActionDetails",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_ActionDetails_TeachersUserId",
                table: "ActionDetails",
                newName: "IX_ActionDetails_TeacherId");

            migrationBuilder.AlterColumn<string>(
                name: "Satisfaction",
                table: "ActionDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "ActionDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrincipalId",
                table: "ActionDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActionDetails_PrincipalId",
                table: "ActionDetails",
                column: "PrincipalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionDetails_Principals_PrincipalId",
                table: "ActionDetails",
                column: "PrincipalId",
                principalTable: "Principals",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionDetails_Teachers_TeacherId",
                table: "ActionDetails",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
