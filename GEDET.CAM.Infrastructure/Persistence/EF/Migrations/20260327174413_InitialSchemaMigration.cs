using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "keyvariables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Alias = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    Description = table.Column<string>(type: "character varying(480)", maxLength: 480, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_keyvariables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "objectives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objectives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Family = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    Description = table.Column<string>(type: "character varying(240)", maxLength: 240, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "objective_actions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectiveId = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objective_actions", x => new { x.Id, x.ObjectiveId });
                    table.ForeignKey(
                        name: "FK_objective_actions_objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "objective_challanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectiveId = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objective_challanges", x => new { x.Id, x.ObjectiveId });
                    table.ForeignKey(
                        name: "FK_objective_challanges_objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "objective_keyvariable_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objective_keyvariable_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_objective_keyvariable_bridges_keyvariables_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "keyvariables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_objective_keyvariable_bridges_objectives_MainId",
                        column: x => x.MainId,
                        principalTable: "objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "objective_projections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ObjectiveId = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objective_projections", x => new { x.Id, x.ObjectiveId });
                    table.ForeignKey(
                        name: "FK_objective_projections_objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_permission_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_permission_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_role_permission_bridges_permissions_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_role_permission_bridges_roles_MainId",
                        column: x => x.MainId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_keyvariables_Alias",
                table: "keyvariables",
                column: "Alias");

            migrationBuilder.CreateIndex(
                name: "IX_keyvariables_Name",
                table: "keyvariables",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_objective_actions_Index_Id_ObjectiveId",
                table: "objective_actions",
                columns: new[] { "Index", "Id", "ObjectiveId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_objective_actions_ObjectiveId",
                table: "objective_actions",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_objective_challanges_Index_Id_ObjectiveId",
                table: "objective_challanges",
                columns: new[] { "Index", "Id", "ObjectiveId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_objective_challanges_ObjectiveId",
                table: "objective_challanges",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_objective_keyvariable_bridges_LinkedId",
                table: "objective_keyvariable_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_objective_projections_Index_Id_ObjectiveId",
                table: "objective_projections",
                columns: new[] { "Index", "Id", "ObjectiveId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_objective_projections_ObjectiveId",
                table: "objective_projections",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_objectives_Index",
                table: "objectives",
                column: "Index",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_role_permission_bridges_LinkedId",
                table: "role_permission_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_roles_Name",
                table: "roles",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "objective_actions");

            migrationBuilder.DropTable(
                name: "objective_challanges");

            migrationBuilder.DropTable(
                name: "objective_keyvariable_bridges");

            migrationBuilder.DropTable(
                name: "objective_projections");

            migrationBuilder.DropTable(
                name: "role_permission_bridges");

            migrationBuilder.DropTable(
                name: "keyvariables");

            migrationBuilder.DropTable(
                name: "objectives");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
