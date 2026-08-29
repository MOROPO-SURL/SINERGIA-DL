using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpgrade19SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pdloperationreport_document_bridges",
                columns: table => new
                {
                    MainId = table.Column<long>(type: "bigint", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdloperationreport_document_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_pdloperationreport_document_bridges_documents_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pdloperationreport_document_bridges_pdloperationreports_Mai~",
                        column: x => x.MainId,
                        principalTable: "pdloperationreports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "srloperationreport_document_bridges",
                columns: table => new
                {
                    MainId = table.Column<long>(type: "bigint", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_srloperationreport_document_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_srloperationreport_document_bridges_documents_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_srloperationreport_document_bridges_srloperationreports_Mai~",
                        column: x => x.MainId,
                        principalTable: "srloperationreports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pdloperationreport_document_bridges_LinkedId",
                table: "pdloperationreport_document_bridges",
                column: "LinkedId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_srloperationreport_document_bridges_LinkedId",
                table: "srloperationreport_document_bridges",
                column: "LinkedId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pdloperationreport_document_bridges");

            migrationBuilder.DropTable(
                name: "srloperationreport_document_bridges");
        }
    }
}
