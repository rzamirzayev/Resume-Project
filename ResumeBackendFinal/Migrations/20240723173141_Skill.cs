using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumeBackendFinal.Migrations
{
    /// <inheritdoc />
    public partial class Skill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_SkillGroup_GroupId",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                table: "Skill");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skills");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_GroupId",
                table: "Skills",
                newName: "IX_Skills_GroupId");

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "Services",
                type: "varchar(64)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Services",
                type: "varchar(64)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Services",
                type: "varchar(64)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skills",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedAt",
                table: "Skills",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Skills",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Skills",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillGroup_GroupId",
                table: "Skills",
                column: "GroupId",
                principalTable: "SkillGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillGroup_GroupId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "Skill");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_GroupId",
                table: "Skill",
                newName: "IX_Skill_GroupId");

            migrationBuilder.AlterColumn<string>(
                name: "LastModifiedBy",
                table: "Services",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "Services",
                type: "varchar",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Services",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(64)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skill",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedAt",
                table: "Skill",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "Skill",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Skill",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                table: "Skill",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_SkillGroup_GroupId",
                table: "Skill",
                column: "GroupId",
                principalTable: "SkillGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
