using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpgrade17SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "objective_action_indicators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectiveId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Alias = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: true),
                    UnitMeasurementId = table.Column<Guid>(type: "uuid", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objective_action_indicators", x => new { x.Id, x.ActionId, x.ObjectiveId });
                    table.ForeignKey(
                        name: "FK_objective_action_indicators_objective_actions_ActionId_Obje~",
                        columns: x => new { x.ActionId, x.ObjectiveId },
                        principalTable: "objective_actions",
                        principalColumns: new[] { "Id", "ObjectiveId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_objective_action_indicators_unitmeasurements_UnitMeasuremen~",
                        column: x => x.UnitMeasurementId,
                        principalTable: "unitmeasurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "strategicproject_indicators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Alias = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: true),
                    UnitMeasurementId = table.Column<Guid>(type: "uuid", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicproject_indicators", x => new { x.Id, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_strategicproject_indicators_strategicprojects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "strategicprojects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_strategicproject_indicators_unitmeasurements_UnitMeasuremen~",
                        column: x => x.UnitMeasurementId,
                        principalTable: "unitmeasurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "strategicproject_macroprogram_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicproject_macroprogram_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_strategicproject_macroprogram_bridges_macroprograms_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "macroprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_strategicproject_macroprogram_bridges_strategicprojects_Mai~",
                        column: x => x.MainId,
                        principalTable: "strategicprojects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicproject_specificobjetives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicproject_specificobjetives", x => new { x.Id, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_strategicproject_specificobjetives_strategicprojects_Projec~",
                        column: x => x.ProjectId,
                        principalTable: "strategicprojects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "objective_action_indicator_changes",
                columns: table => new
                {
                    Id = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ObjectiveId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionId = table.Column<Guid>(type: "uuid", nullable: false),
                    IndicatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Context = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objective_action_indicator_changes", x => new { x.Id, x.IndicatorId, x.ActionId, x.ObjectiveId });
                    table.ForeignKey(
                        name: "FK_objective_action_indicator_changes_objective_action_indicat~",
                        columns: x => new { x.IndicatorId, x.ActionId, x.ObjectiveId },
                        principalTable: "objective_action_indicators",
                        principalColumns: new[] { "Id", "ActionId", "ObjectiveId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "objective_action_indicator_milestones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectiveId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionId = table.Column<Guid>(type: "uuid", nullable: false),
                    IndicatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    At = table.Column<DateOnly>(type: "date", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objective_action_indicator_milestones", x => new { x.Id, x.IndicatorId, x.ActionId, x.ObjectiveId });
                    table.ForeignKey(
                        name: "FK_objective_action_indicator_milestones_objective_action_indi~",
                        columns: x => new { x.IndicatorId, x.ActionId, x.ObjectiveId },
                        principalTable: "objective_action_indicators",
                        principalColumns: new[] { "Id", "ActionId", "ObjectiveId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicproject_indicator_changes",
                columns: table => new
                {
                    Id = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    IndicatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Context = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicproject_indicator_changes", x => new { x.Id, x.IndicatorId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_strategicproject_indicator_changes_strategicproject_indicat~",
                        columns: x => new { x.IndicatorId, x.ProjectId },
                        principalTable: "strategicproject_indicators",
                        principalColumns: new[] { "Id", "ProjectId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicproject_indicator_milestones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    IndicatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    At = table.Column<DateOnly>(type: "date", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicproject_indicator_milestones", x => new { x.Id, x.IndicatorId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_strategicproject_indicator_milestones_strategicproject_indi~",
                        columns: x => new { x.IndicatorId, x.ProjectId },
                        principalTable: "strategicproject_indicators",
                        principalColumns: new[] { "Id", "ProjectId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_objective_action_indicator_changes_IndicatorId_ActionId_Obj~",
                table: "objective_action_indicator_changes",
                columns: new[] { "IndicatorId", "ActionId", "ObjectiveId" });

            migrationBuilder.CreateIndex(
                name: "IX_objective_action_indicator_milestones_Id_IndicatorId_Action~",
                table: "objective_action_indicator_milestones",
                columns: new[] { "Id", "IndicatorId", "ActionId", "ObjectiveId", "At" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_objective_action_indicator_milestones_IndicatorId_ActionId_~",
                table: "objective_action_indicator_milestones",
                columns: new[] { "IndicatorId", "ActionId", "ObjectiveId" });

            migrationBuilder.CreateIndex(
                name: "IX_objective_action_indicators_ActionId_ObjectiveId",
                table: "objective_action_indicators",
                columns: new[] { "ActionId", "ObjectiveId" });

            migrationBuilder.CreateIndex(
                name: "IX_objective_action_indicators_Name_Id_ActionId_ObjectiveId",
                table: "objective_action_indicators",
                columns: new[] { "Name", "Id", "ActionId", "ObjectiveId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_objective_action_indicators_UnitMeasurementId",
                table: "objective_action_indicators",
                column: "UnitMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicproject_indicator_changes_IndicatorId_ProjectId",
                table: "strategicproject_indicator_changes",
                columns: new[] { "IndicatorId", "ProjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_strategicproject_indicator_milestones_Id_IndicatorId_Projec~",
                table: "strategicproject_indicator_milestones",
                columns: new[] { "Id", "IndicatorId", "ProjectId", "At" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicproject_indicator_milestones_IndicatorId_ProjectId",
                table: "strategicproject_indicator_milestones",
                columns: new[] { "IndicatorId", "ProjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_strategicproject_indicators_Name_Id_ProjectId",
                table: "strategicproject_indicators",
                columns: new[] { "Name", "Id", "ProjectId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicproject_indicators_ProjectId",
                table: "strategicproject_indicators",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicproject_indicators_UnitMeasurementId",
                table: "strategicproject_indicators",
                column: "UnitMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicproject_macroprogram_bridges_LinkedId",
                table: "strategicproject_macroprogram_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicproject_specificobjetives_Index_Id_ProjectId",
                table: "strategicproject_specificobjetives",
                columns: new[] { "Index", "Id", "ProjectId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicproject_specificobjetives_ProjectId",
                table: "strategicproject_specificobjetives",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "objective_action_indicator_changes");

            migrationBuilder.DropTable(
                name: "objective_action_indicator_milestones");

            migrationBuilder.DropTable(
                name: "strategicproject_indicator_changes");

            migrationBuilder.DropTable(
                name: "strategicproject_indicator_milestones");

            migrationBuilder.DropTable(
                name: "strategicproject_macroprogram_bridges");

            migrationBuilder.DropTable(
                name: "strategicproject_specificobjetives");

            migrationBuilder.DropTable(
                name: "objective_action_indicators");

            migrationBuilder.DropTable(
                name: "strategicproject_indicators");
        }
    }
}
