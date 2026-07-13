using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainRevision1Step8SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "strategicaxe_macroprogram_bridges",
                columns: table => new
                {
                    MainId = table.Column<int>(type: "integer", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicaxe_macroprogram_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_strategicaxe_macroprogram_bridges_macroprograms_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "macroprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_strategicaxe_macroprogram_bridges_strategicaxes_MainId",
                        column: x => x.MainId,
                        principalTable: "strategicaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_macroprogram_bridges_LinkedId",
                table: "strategicaxe_macroprogram_bridges",
                column: "LinkedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "strategicaxe_macroprogram_bridges");
        }
    }
}
