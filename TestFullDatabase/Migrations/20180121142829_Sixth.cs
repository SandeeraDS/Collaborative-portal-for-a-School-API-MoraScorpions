using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestFullDatabase.Migrations
{
    public partial class Sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "ComplainDetails",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "ComplainDetails",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplainDetails_AspNetUsers_UsersId",
                table: "ComplainDetails");

            migrationBuilder.DropIndex(
                name: "IX_ComplainDetails_UsersId",
                table: "ComplainDetails");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "ComplainDetails");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "ComplainDetails");
        }
    }
}
