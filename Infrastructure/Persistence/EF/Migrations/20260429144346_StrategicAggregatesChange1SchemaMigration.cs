using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class StrategicAggregatesChange1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_strategiclines_strategicaxes_StrategicAxeId",
                table: "strategiclines");

            migrationBuilder.DropIndex(
                name: "IX_strategicprograms_Index_Id_StrategicLineId_StrategicAxeId",
                table: "strategicprograms");

            migrationBuilder.RenameColumn(
                name: "Index",
                table: "strategicprograms",
                newName: "Priority");

            migrationBuilder.RenameColumn(
                name: "StrategicAxeId",
                table: "strategiclines",
                newName: "SecoundId");

            migrationBuilder.RenameColumn(
                name: "StrategicLineId",
                table: "strategiclines",
                newName: "FirstId");

            migrationBuilder.RenameIndex(
                name: "IX_strategiclines_StrategicAxeId",
                table: "strategiclines",
                newName: "IX_strategiclines_SecoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_strategiclines_strategicaxes_SecoundId",
                table: "strategiclines",
                column: "SecoundId",
                principalTable: "strategicaxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_strategiclines_strategicaxes_SecoundId",
                table: "strategiclines");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "strategicprograms",
                newName: "Index");

            migrationBuilder.RenameColumn(
                name: "SecoundId",
                table: "strategiclines",
                newName: "StrategicAxeId");

            migrationBuilder.RenameColumn(
                name: "FirstId",
                table: "strategiclines",
                newName: "StrategicLineId");

            migrationBuilder.RenameIndex(
                name: "IX_strategiclines_SecoundId",
                table: "strategiclines",
                newName: "IX_strategiclines_StrategicAxeId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprograms_Index_Id_StrategicLineId_StrategicAxeId",
                table: "strategicprograms",
                columns: new[] { "Index", "Id", "StrategicLineId", "StrategicAxeId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_strategiclines_strategicaxes_StrategicAxeId",
                table: "strategiclines",
                column: "StrategicAxeId",
                principalTable: "strategicaxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
