using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class TracesInclusionIter3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "strategicline_traces",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Author = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TargetPrimaryId = table.Column<int>(type: "integer", nullable: true),
                    TargetSecoundaryId = table.Column<int>(type: "integer", nullable: true),
                    BeforeData = table.Column<string>(type: "text", nullable: true),
                    AfterData = table.Column<string>(type: "text", nullable: true),
                    Signature = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicline_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_strategicline_traces_strategiclines_TargetPrimaryId_TargetS~",
                        columns: x => new { x.TargetPrimaryId, x.TargetSecoundaryId },
                        principalTable: "strategiclines",
                        principalColumns: new[] { "FirstId", "SecoundId" },
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "strategicprojectkind_traces",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Author = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TargetId = table.Column<Guid>(type: "uuid", nullable: true),
                    BeforeData = table.Column<string>(type: "text", nullable: true),
                    AfterData = table.Column<string>(type: "text", nullable: true),
                    Signature = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprojectkind_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_strategicprojectkind_traces_strategicprojectkinds_TargetId",
                        column: x => x.TargetId,
                        principalTable: "strategicprojectkinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_strategicline_traces_TargetPrimaryId_TargetSecoundaryId",
                table: "strategicline_traces",
                columns: new[] { "TargetPrimaryId", "TargetSecoundaryId" });

            migrationBuilder.CreateIndex(
                name: "IX_strategicprojectkind_traces_TargetId",
                table: "strategicprojectkind_traces",
                column: "TargetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "strategicline_traces");

            migrationBuilder.DropTable(
                name: "strategicprojectkind_traces");
        }
    }
}
