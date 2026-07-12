using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpgrade8SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_strategicline_macroprogram_bridges_macroprograms_LinkedId",
                table: "strategicline_macroprogram_bridges");

            migrationBuilder.DropForeignKey(
                name: "FK_strategicline_publicpolicy_bridges_publicpolicies_LinkedId",
                table: "strategicline_publicpolicy_bridges");

            migrationBuilder.DropForeignKey(
                name: "FK_strategicprogram_organization_bridges_organizations_LinkedId",
                table: "strategicprogram_organization_bridges");

            migrationBuilder.CreateTable(
                name: "strategicprogram_macroprogram_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprogram_macroprogram_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_strategicprogram_macroprogram_bridges_macroprograms_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "macroprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_strategicprogram_macroprogram_bridges_strategicprograms_Mai~",
                        column: x => x.MainId,
                        principalTable: "strategicprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_macroprogram_bridges_LinkedId",
                table: "strategicprogram_macroprogram_bridges",
                column: "LinkedId");

            migrationBuilder.AddForeignKey(
                name: "FK_strategicline_macroprogram_bridges_macroprograms_LinkedId",
                table: "strategicline_macroprogram_bridges",
                column: "LinkedId",
                principalTable: "macroprograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_strategicline_publicpolicy_bridges_publicpolicies_LinkedId",
                table: "strategicline_publicpolicy_bridges",
                column: "LinkedId",
                principalTable: "publicpolicies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_strategicprogram_organization_bridges_organizations_LinkedId",
                table: "strategicprogram_organization_bridges",
                column: "LinkedId",
                principalTable: "organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_strategicline_macroprogram_bridges_macroprograms_LinkedId",
                table: "strategicline_macroprogram_bridges");

            migrationBuilder.DropForeignKey(
                name: "FK_strategicline_publicpolicy_bridges_publicpolicies_LinkedId",
                table: "strategicline_publicpolicy_bridges");

            migrationBuilder.DropForeignKey(
                name: "FK_strategicprogram_organization_bridges_organizations_LinkedId",
                table: "strategicprogram_organization_bridges");

            migrationBuilder.DropTable(
                name: "strategicprogram_macroprogram_bridges");

            migrationBuilder.AddForeignKey(
                name: "FK_strategicline_macroprogram_bridges_macroprograms_LinkedId",
                table: "strategicline_macroprogram_bridges",
                column: "LinkedId",
                principalTable: "macroprograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_strategicline_publicpolicy_bridges_publicpolicies_LinkedId",
                table: "strategicline_publicpolicy_bridges",
                column: "LinkedId",
                principalTable: "publicpolicies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_strategicprogram_organization_bridges_organizations_LinkedId",
                table: "strategicprogram_organization_bridges",
                column: "LinkedId",
                principalTable: "organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
