using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class TracesInclusionIter1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organization_traces",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Author = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TargetId = table.Column<Guid>(type: "uuid", nullable: true),
                    BeforeData = table.Column<string>(type: "text", nullable: true),
                    AfterData = table.Column<string>(type: "text", nullable: true),
                    Signature = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_organization_traces_organizations_TargetId",
                        column: x => x.TargetId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "person_traces",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Author = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TargetId = table.Column<Guid>(type: "uuid", nullable: true),
                    BeforeData = table.Column<string>(type: "text", nullable: true),
                    AfterData = table.Column<string>(type: "text", nullable: true),
                    Signature = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_person_traces_people_TargetId",
                        column: x => x.TargetId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "role_traces",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Author = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TargetId = table.Column<Guid>(type: "uuid", nullable: true),
                    BeforeData = table.Column<string>(type: "text", nullable: true),
                    AfterData = table.Column<string>(type: "text", nullable: true),
                    Signature = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_role_traces_roles_TargetId",
                        column: x => x.TargetId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_organization_traces_TargetId",
                table: "organization_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_person_traces_TargetId",
                table: "person_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_role_traces_TargetId",
                table: "role_traces",
                column: "TargetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "organization_traces");

            migrationBuilder.DropTable(
                name: "person_traces");

            migrationBuilder.DropTable(
                name: "role_traces");
        }
    }
}
