using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class ProgramMinorFix1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_strategicprograms_people_CoordinatorId",
                table: "strategicprograms");

            migrationBuilder.DropForeignKey(
                name: "FK_strategicprograms_strategiclines_StrategicLineId1_Strategic~",
                table: "strategicprograms");

            migrationBuilder.DropIndex(
                name: "IX_strategicprograms_StrategicLineId1_StrategicLineStrategicAx~",
                table: "strategicprograms");

            migrationBuilder.DropColumn(
                name: "StrategicLineId1",
                table: "strategicprograms");

            migrationBuilder.DropColumn(
                name: "StrategicLineStrategicAxeId",
                table: "strategicprograms");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprograms_StrategicLineId_StrategicAxeId",
                table: "strategicprograms",
                columns: new[] { "StrategicLineId", "StrategicAxeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_strategicprograms_people_CoordinatorId",
                table: "strategicprograms",
                column: "CoordinatorId",
                principalTable: "people",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_strategicprograms_strategiclines_StrategicLineId_StrategicA~",
                table: "strategicprograms",
                columns: new[] { "StrategicLineId", "StrategicAxeId" },
                principalTable: "strategiclines",
                principalColumns: new[] { "StrategicLineId", "StrategicAxeId" },
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_strategicprograms_people_CoordinatorId",
                table: "strategicprograms");

            migrationBuilder.DropForeignKey(
                name: "FK_strategicprograms_strategiclines_StrategicLineId_StrategicA~",
                table: "strategicprograms");

            migrationBuilder.DropIndex(
                name: "IX_strategicprograms_StrategicLineId_StrategicAxeId",
                table: "strategicprograms");

            migrationBuilder.AddColumn<int>(
                name: "StrategicLineId1",
                table: "strategicprograms",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrategicLineStrategicAxeId",
                table: "strategicprograms",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicprograms_StrategicLineId1_StrategicLineStrategicAx~",
                table: "strategicprograms",
                columns: new[] { "StrategicLineId1", "StrategicLineStrategicAxeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_strategicprograms_people_CoordinatorId",
                table: "strategicprograms",
                column: "CoordinatorId",
                principalTable: "people",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_strategicprograms_strategiclines_StrategicLineId1_Strategic~",
                table: "strategicprograms",
                columns: new[] { "StrategicLineId1", "StrategicLineStrategicAxeId" },
                principalTable: "strategiclines",
                principalColumns: new[] { "StrategicLineId", "StrategicAxeId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
