using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainRevision1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Objective",
                table: "strategicprojects",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "StrategicAxeId",
                table: "strategicprograms",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Objective",
                table: "strategiclines",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CoordinadorId",
                table: "strategicaxes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxes_CoordinadorId",
                table: "strategicaxes",
                column: "CoordinadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_strategicaxes_people_CoordinadorId",
                table: "strategicaxes",
                column: "CoordinadorId",
                principalTable: "people",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_strategicaxes_people_CoordinadorId",
                table: "strategicaxes");

            migrationBuilder.DropIndex(
                name: "IX_strategicaxes_CoordinadorId",
                table: "strategicaxes");

            migrationBuilder.DropColumn(
                name: "Objective",
                table: "strategicprojects");

            migrationBuilder.DropColumn(
                name: "Objective",
                table: "strategiclines");

            migrationBuilder.DropColumn(
                name: "CoordinadorId",
                table: "strategicaxes");

            migrationBuilder.AlterColumn<int>(
                name: "StrategicAxeId",
                table: "strategicprograms",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
