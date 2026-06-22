using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainRevision1Step4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "strategiclines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    AxeId = table.Column<int>(type: "integer", nullable: true),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Objective = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CoordinatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategiclines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_strategiclines_people_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_strategiclines_strategicaxes_AxeId",
                        column: x => x.AxeId,
                        principalTable: "strategicaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "strategicline_organization_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicline_organization_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_strategicline_organization_bridges_organizations_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_strategicline_organization_bridges_strategiclines_MainId",
                        column: x => x.MainId,
                        principalTable: "strategiclines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicline_strategicactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicLineId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicline_strategicactions", x => new { x.Id, x.StrategicLineId });
                    table.ForeignKey(
                        name: "FK_strategicline_strategicactions_strategiclines_StrategicLine~",
                        column: x => x.StrategicLineId,
                        principalTable: "strategiclines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicline_traces",
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
                    table.PrimaryKey("PK_strategicline_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_strategicline_traces_strategiclines_TargetId",
                        column: x => x.TargetId,
                        principalTable: "strategiclines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "strategicprograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LineId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    CoordinatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_strategicprograms_people_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_strategicprograms_strategiclines_LineId",
                        column: x => x.LineId,
                        principalTable: "strategiclines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "strategicprogram_actions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprogram_actions", x => new { x.Id, x.StrategicProgramId });
                    table.ForeignKey(
                        name: "FK_strategicprogram_actions_strategicprograms_StrategicProgram~",
                        column: x => x.StrategicProgramId,
                        principalTable: "strategicprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicprogram_impacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprogram_impacts", x => new { x.Id, x.StrategicProgramId });
                    table.ForeignKey(
                        name: "FK_strategicprogram_impacts_strategicprograms_StrategicProgram~",
                        column: x => x.StrategicProgramId,
                        principalTable: "strategicprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicprogram_objetives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    StrategicProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprogram_objetives", x => new { x.Id, x.StrategicProgramId });
                    table.ForeignKey(
                        name: "FK_strategicprogram_objetives_strategicprograms_StrategicProgr~",
                        column: x => x.StrategicProgramId,
                        principalTable: "strategicprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicprogram_organization_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprogram_organization_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_strategicprogram_organization_bridges_organizations_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_strategicprogram_organization_bridges_strategicprograms_Mai~",
                        column: x => x.MainId,
                        principalTable: "strategicprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicprogram_projectideas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprogram_projectideas", x => new { x.Id, x.StrategicProgramId });
                    table.ForeignKey(
                        name: "FK_strategicprogram_projectideas_strategicprograms_StrategicPr~",
                        column: x => x.StrategicProgramId,
                        principalTable: "strategicprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicprogram_traces",
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
                    table.PrimaryKey("PK_strategicprogram_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_strategicprogram_traces_strategicprograms_TargetId",
                        column: x => x.TargetId,
                        principalTable: "strategicprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "strategicprojects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    KindId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Objective = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprojects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_strategicprojects_strategicprograms_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "strategicprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_strategicprojects_strategicprojectkinds_KindId",
                        column: x => x.KindId,
                        principalTable: "strategicprojectkinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "strategicprogram_action_interestarea_bridges",
                columns: table => new
                {
                    ProgramActionId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprogram_action_interestarea_bridges", x => new { x.ProgramActionId, x.StrategicProgramId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_strategicprogram_action_interestarea_bridges_interestareas_~",
                        column: x => x.LinkedId,
                        principalTable: "interestareas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_strategicprogram_action_interestarea_bridges_strategicprogr~",
                        columns: x => new { x.ProgramActionId, x.StrategicProgramId },
                        principalTable: "strategicprogram_actions",
                        principalColumns: new[] { "Id", "StrategicProgramId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicprogram_impactindicators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProgramImpactId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Alias = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Meta = table.Column<float>(type: "real", nullable: false),
                    UnitMeasurementId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprogram_impactindicators", x => new { x.Id, x.ProgramImpactId, x.StrategicProgramId });
                    table.ForeignKey(
                        name: "FK_strategicprogram_impactindicators_strategicprogram_impacts_~",
                        columns: x => new { x.ProgramImpactId, x.StrategicProgramId },
                        principalTable: "strategicprogram_impacts",
                        principalColumns: new[] { "Id", "StrategicProgramId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_strategicprogram_impactindicators_unitmeasurements_UnitMeas~",
                        column: x => x.UnitMeasurementId,
                        principalTable: "unitmeasurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "strategicprogram_objective_strategicproject_bridges",
                columns: table => new
                {
                    ProgramObjectiveId = table.Column<int>(type: "integer", nullable: false),
                    StrategicProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprogram_objective_strategicproject_bridges", x => new { x.ProgramObjectiveId, x.StrategicProgramId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_strategicprogram_objective_strategicproject_bridges_strateg~",
                        column: x => x.LinkedId,
                        principalTable: "strategicprojects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_strategicprogram_objective_strategicproject_bridges_strate~1",
                        columns: x => new { x.ProgramObjectiveId, x.StrategicProgramId },
                        principalTable: "strategicprogram_objetives",
                        principalColumns: new[] { "Id", "StrategicProgramId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicproject_traces",
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
                    table.PrimaryKey("PK_strategicproject_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_strategicproject_traces_strategicprojects_TargetId",
                        column: x => x.TargetId,
                        principalTable: "strategicprojects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_strategicline_organization_bridges_LinkedId",
                table: "strategicline_organization_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicline_strategicactions_StrategicLineId",
                table: "strategicline_strategicactions",
                column: "StrategicLineId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicline_traces_TargetId",
                table: "strategicline_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_strategiclines_AxeId",
                table: "strategiclines",
                column: "AxeId");

            migrationBuilder.CreateIndex(
                name: "IX_strategiclines_CoordinatorId",
                table: "strategiclines",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_strategiclines_Index_AxeId",
                table: "strategiclines",
                columns: new[] { "Index", "AxeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_action_interestarea_bridges_LinkedId",
                table: "strategicprogram_action_interestarea_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_actions_StrategicProgramId",
                table: "strategicprogram_actions",
                column: "StrategicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_impactindicators_Name_Id_ProgramImpactId_S~",
                table: "strategicprogram_impactindicators",
                columns: new[] { "Name", "Id", "ProgramImpactId", "StrategicProgramId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_impactindicators_ProgramImpactId_Strategic~",
                table: "strategicprogram_impactindicators",
                columns: new[] { "ProgramImpactId", "StrategicProgramId" });

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_impactindicators_UnitMeasurementId",
                table: "strategicprogram_impactindicators",
                column: "UnitMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_impacts_Name_Id_StrategicProgramId",
                table: "strategicprogram_impacts",
                columns: new[] { "Name", "Id", "StrategicProgramId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_impacts_StrategicProgramId",
                table: "strategicprogram_impacts",
                column: "StrategicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_objective_strategicproject_bridges_LinkedId",
                table: "strategicprogram_objective_strategicproject_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_objetives_StrategicProgramId",
                table: "strategicprogram_objetives",
                column: "StrategicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_organization_bridges_LinkedId",
                table: "strategicprogram_organization_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_projectideas_Name_Id_StrategicProgramId",
                table: "strategicprogram_projectideas",
                columns: new[] { "Name", "Id", "StrategicProgramId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_projectideas_StrategicProgramId",
                table: "strategicprogram_projectideas",
                column: "StrategicProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_traces_TargetId",
                table: "strategicprogram_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprograms_CoordinatorId",
                table: "strategicprograms",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprograms_LineId",
                table: "strategicprograms",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicproject_traces_TargetId",
                table: "strategicproject_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprojects_KindId",
                table: "strategicprojects",
                column: "KindId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprojects_Name_Id_ProgramId",
                table: "strategicprojects",
                columns: new[] { "Name", "Id", "ProgramId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicprojects_ProgramId",
                table: "strategicprojects",
                column: "ProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "strategicline_organization_bridges");

            migrationBuilder.DropTable(
                name: "strategicline_strategicactions");

            migrationBuilder.DropTable(
                name: "strategicline_traces");

            migrationBuilder.DropTable(
                name: "strategicprogram_action_interestarea_bridges");

            migrationBuilder.DropTable(
                name: "strategicprogram_impactindicators");

            migrationBuilder.DropTable(
                name: "strategicprogram_objective_strategicproject_bridges");

            migrationBuilder.DropTable(
                name: "strategicprogram_organization_bridges");

            migrationBuilder.DropTable(
                name: "strategicprogram_projectideas");

            migrationBuilder.DropTable(
                name: "strategicprogram_traces");

            migrationBuilder.DropTable(
                name: "strategicproject_traces");

            migrationBuilder.DropTable(
                name: "strategicprogram_actions");

            migrationBuilder.DropTable(
                name: "strategicprogram_impacts");

            migrationBuilder.DropTable(
                name: "strategicprogram_objetives");

            migrationBuilder.DropTable(
                name: "strategicprojects");

            migrationBuilder.DropTable(
                name: "strategicprograms");

            migrationBuilder.DropTable(
                name: "strategiclines");
        }
    }
}
