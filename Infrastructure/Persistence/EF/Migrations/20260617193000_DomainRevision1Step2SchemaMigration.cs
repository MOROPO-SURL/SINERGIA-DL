using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainRevision1Step2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_strategicaxes_people_CoordinadorId",
                table: "strategicaxes");

            migrationBuilder.DropForeignKey(
                name: "FK_strategiclines_people_CoordinadorId",
                table: "strategiclines");

            migrationBuilder.RenameColumn(
                name: "CoordinadorId",
                table: "strategiclines",
                newName: "CoordinatorId");

            migrationBuilder.RenameIndex(
                name: "IX_strategiclines_CoordinadorId",
                table: "strategiclines",
                newName: "IX_strategiclines_CoordinatorId");

            migrationBuilder.RenameColumn(
                name: "CoordinadorId",
                table: "strategicaxes",
                newName: "CoordinatorId");

            migrationBuilder.RenameIndex(
                name: "IX_strategicaxes_CoordinadorId",
                table: "strategicaxes",
                newName: "IX_strategicaxes_CoordinatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_strategicaxes_people_CoordinatorId",
                table: "strategicaxes",
                column: "CoordinatorId",
                principalTable: "people",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_strategiclines_people_CoordinatorId",
                table: "strategiclines",
                column: "CoordinatorId",
                principalTable: "people",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_strategicaxes_people_CoordinatorId",
                table: "strategicaxes");

            migrationBuilder.DropForeignKey(
                name: "FK_strategiclines_people_CoordinatorId",
                table: "strategiclines");

            migrationBuilder.RenameColumn(
                name: "CoordinatorId",
                table: "strategiclines",
                newName: "CoordinadorId");

            migrationBuilder.RenameIndex(
                name: "IX_strategiclines_CoordinatorId",
                table: "strategiclines",
                newName: "IX_strategiclines_CoordinadorId");

            migrationBuilder.RenameColumn(
                name: "CoordinatorId",
                table: "strategicaxes",
                newName: "CoordinadorId");

            migrationBuilder.RenameIndex(
                name: "IX_strategicaxes_CoordinatorId",
                table: "strategicaxes",
                newName: "IX_strategicaxes_CoordinadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_strategicaxes_people_CoordinadorId",
                table: "strategicaxes",
                column: "CoordinadorId",
                principalTable: "people",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_strategiclines_people_CoordinadorId",
                table: "strategiclines",
                column: "CoordinadorId",
                principalTable: "people",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
