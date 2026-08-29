using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpgrade21SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "economicactivity_traces",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Author = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TargetId = table.Column<int>(type: "integer", nullable: true),
                    BeforeData = table.Column<string>(type: "text", nullable: true),
                    AfterData = table.Column<string>(type: "text", nullable: true),
                    Signature = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_economicactivity_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_economicactivity_traces_economicactivities_TargetId",
                        column: x => x.TargetId,
                        principalTable: "economicactivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "socialsupportdemand_traces",
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
                    table.PrimaryKey("PK_socialsupportdemand_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_socialsupportdemand_traces_socialsupportdemands_TargetId",
                        column: x => x.TargetId,
                        principalTable: "socialsupportdemands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "strategicprojectidea_traces",
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
                    table.PrimaryKey("PK_strategicprojectidea_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_strategicprojectidea_traces_strategicprojectideas_TargetId",
                        column: x => x.TargetId,
                        principalTable: "strategicprojectideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_economicactivity_traces_TargetId",
                table: "economicactivity_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_socialsupportdemand_traces_TargetId",
                table: "socialsupportdemand_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprojectidea_traces_TargetId",
                table: "strategicprojectidea_traces",
                column: "TargetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "economicactivity_traces");

            migrationBuilder.DropTable(
                name: "socialsupportdemand_traces");

            migrationBuilder.DropTable(
                name: "strategicprojectidea_traces");
        }
    }
}
