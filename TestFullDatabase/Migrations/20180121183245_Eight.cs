using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestFullDatabase.Migrations
{
    public partial class Eight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplainDetails_AspNetUsers_UsersId",
                table: "ComplainDetails");

            migrationBuilder.DropIndex(
                name: "IX_ComplainDetails_UsersId",
                table: "ComplainDetails");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "ComplainDetails");

            migrationBuilder.AlterColumn<string>(
                name: "ComplaineeId",
                table: "ComplainDetails",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<bool>(
                name: "Satisfaction",
                table: "ActionDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComplainDetails_ComplaineeId",
                table: "ComplainDetails",
                column: "ComplaineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplainDetails_AspNetUsers_ComplaineeId",
                table: "ComplainDetails",
                column: "ComplaineeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplainDetails_AspNetUsers_ComplaineeId",
                table: "ComplainDetails");

            migrationBuilder.DropIndex(
                name: "IX_ComplainDetails_ComplaineeId",
                table: "ComplainDetails");

            migrationBuilder.AlterColumn<string>(
                name: "ComplaineeId",
                table: "ComplainDetails",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "ComplainDetails",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Satisfaction",
                table: "ActionDetails",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.CreateIndex(
                name: "IX_ComplainDetails_UsersId",
                table: "ComplainDetails",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplainDetails_AspNetUsers_UsersId",
                table: "ComplainDetails",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
