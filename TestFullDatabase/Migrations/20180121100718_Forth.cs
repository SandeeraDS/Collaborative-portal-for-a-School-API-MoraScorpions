using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestFullDatabase.Migrations
{
    public partial class Forth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarkDetails_Subject_SubId",
                table: "MarkDetails");

            migrationBuilder.DropTable(
                name: "OutlineSyllabus");

            migrationBuilder.RenameColumn(
                name: "SubId",
                table: "MarkDetails",
                newName: "TernaryId");

            migrationBuilder.RenameIndex(
                name: "IX_MarkDetails_SubId",
                table: "MarkDetails",
                newName: "IX_MarkDetails_TernaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarkDetails_Ternary_TernaryId",
                table: "MarkDetails",
                column: "TernaryId",
                principalTable: "Ternary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarkDetails_Ternary_TernaryId",
                table: "MarkDetails");

            migrationBuilder.RenameColumn(
                name: "TernaryId",
                table: "MarkDetails",
                newName: "SubId");

            migrationBuilder.RenameIndex(
                name: "IX_MarkDetails_TernaryId",
                table: "MarkDetails",
                newName: "IX_MarkDetails_SubId");

            migrationBuilder.CreateTable(
                name: "OutlineSyllabus",
                columns: table => new
                {
                    OutlineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassRoomId = table.Column<int>(nullable: false),
                    DoneOrNot = table.Column<bool>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    Topic = table.Column<string>(nullable: false),
                    Week = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutlineSyllabus", x => x.OutlineId);
                    table.ForeignKey(
                        name: "FK_OutlineSyllabus_ClassRoom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRoom",
                        principalColumn: "ClassRoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutlineSyllabus_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OutlineSyllabus_ClassRoomId",
                table: "OutlineSyllabus",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_OutlineSyllabus_SubjectId",
                table: "OutlineSyllabus",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarkDetails_Subject_SubId",
                table: "MarkDetails",
                column: "SubId",
                principalTable: "Subject",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
