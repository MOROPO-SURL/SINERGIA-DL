using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainRevision1Step6SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "strategicline_publicpolicy_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicline_publicpolicy_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_strategicline_publicpolicy_bridges_publicpolicies_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "publicpolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_strategicline_publicpolicy_bridges_strategiclines_MainId",
                        column: x => x.MainId,
                        principalTable: "strategiclines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicline_specificobjectives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicLineId = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicline_specificobjectives", x => new { x.Id, x.StrategicLineId });
                    table.ForeignKey(
                        name: "FK_strategicline_specificobjectives_strategiclines_StrategicLi~",
                        column: x => x.StrategicLineId,
                        principalTable: "strategiclines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_strategicline_publicpolicy_bridges_LinkedId",
                table: "strategicline_publicpolicy_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicline_specificobjectives_Index_Id",
                table: "strategicline_specificobjectives",
                columns: new[] { "Index", "Id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicline_specificobjectives_StrategicLineId",
                table: "strategicline_specificobjectives",
                column: "StrategicLineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "strategicline_publicpolicy_bridges");

            migrationBuilder.DropTable(
                name: "strategicline_specificobjectives");
        }
    }
}
