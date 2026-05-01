using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class TracesInclusionIter2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "apikey_traces",
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
                    table.PrimaryKey("PK_apikey_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_apikey_traces_apikeys_TargetId",
                        column: x => x.TargetId,
                        principalTable: "apikeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "classification_traces",
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
                    table.PrimaryKey("PK_classification_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_classification_traces_classifications_TargetId",
                        column: x => x.TargetId,
                        principalTable: "classifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "feature_traces",
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
                    table.PrimaryKey("PK_feature_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_feature_traces_features_TargetId",
                        column: x => x.TargetId,
                        principalTable: "features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "featurekind_traces",
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
                    table.PrimaryKey("PK_featurekind_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_featurekind_traces_featurekinds_TargetId",
                        column: x => x.TargetId,
                        principalTable: "featurekinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "interestarea_traces",
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
                    table.PrimaryKey("PK_interestarea_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_interestarea_traces_interestareas_TargetId",
                        column: x => x.TargetId,
                        principalTable: "interestareas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "keyvariable_traces",
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
                    table.PrimaryKey("PK_keyvariable_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_keyvariable_traces_keyvariables_TargetId",
                        column: x => x.TargetId,
                        principalTable: "keyvariables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "macroprogram_traces",
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
                    table.PrimaryKey("PK_macroprogram_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_macroprogram_traces_macroprograms_TargetId",
                        column: x => x.TargetId,
                        principalTable: "macroprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "objective_traces",
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
                    table.PrimaryKey("PK_objective_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_objective_traces_objectives_TargetId",
                        column: x => x.TargetId,
                        principalTable: "objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "organizationkind_traces",
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
                    table.PrimaryKey("PK_organizationkind_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_organizationkind_traces_organizationkinds_TargetId",
                        column: x => x.TargetId,
                        principalTable: "organizationkinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "publicpolicy_traces",
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
                    table.PrimaryKey("PK_publicpolicy_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_publicpolicy_traces_publicpolicies_TargetId",
                        column: x => x.TargetId,
                        principalTable: "publicpolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "strategicaxe_traces",
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
                    table.PrimaryKey("PK_strategicaxe_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_strategicaxe_traces_strategicaxes_TargetId",
                        column: x => x.TargetId,
                        principalTable: "strategicaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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

            migrationBuilder.CreateTable(
                name: "territorialbarrier_traces",
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
                    table.PrimaryKey("PK_territorialbarrier_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_territorialbarrier_traces_territorialbarriers_TargetId",
                        column: x => x.TargetId,
                        principalTable: "territorialbarriers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "territorypotential_traces",
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
                    table.PrimaryKey("PK_territorypotential_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_territorypotential_traces_territorypotentials_TargetId",
                        column: x => x.TargetId,
                        principalTable: "territorypotentials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "unitmeasurement_traces",
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
                    table.PrimaryKey("PK_unitmeasurement_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_unitmeasurement_traces_unitmeasurements_TargetId",
                        column: x => x.TargetId,
                        principalTable: "unitmeasurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_apikey_traces_TargetId",
                table: "apikey_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_classification_traces_TargetId",
                table: "classification_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_feature_traces_TargetId",
                table: "feature_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_featurekind_traces_TargetId",
                table: "featurekind_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_interestarea_traces_TargetId",
                table: "interestarea_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_keyvariable_traces_TargetId",
                table: "keyvariable_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_macroprogram_traces_TargetId",
                table: "macroprogram_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_objective_traces_TargetId",
                table: "objective_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_organizationkind_traces_TargetId",
                table: "organizationkind_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_publicpolicy_traces_TargetId",
                table: "publicpolicy_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_traces_TargetId",
                table: "strategicaxe_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_traces_TargetId",
                table: "strategicprogram_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicproject_traces_TargetId",
                table: "strategicproject_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_territorialbarrier_traces_TargetId",
                table: "territorialbarrier_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_territorypotential_traces_TargetId",
                table: "territorypotential_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_unitmeasurement_traces_TargetId",
                table: "unitmeasurement_traces",
                column: "TargetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "apikey_traces");

            migrationBuilder.DropTable(
                name: "classification_traces");

            migrationBuilder.DropTable(
                name: "feature_traces");

            migrationBuilder.DropTable(
                name: "featurekind_traces");

            migrationBuilder.DropTable(
                name: "interestarea_traces");

            migrationBuilder.DropTable(
                name: "keyvariable_traces");

            migrationBuilder.DropTable(
                name: "macroprogram_traces");

            migrationBuilder.DropTable(
                name: "objective_traces");

            migrationBuilder.DropTable(
                name: "organizationkind_traces");

            migrationBuilder.DropTable(
                name: "publicpolicy_traces");

            migrationBuilder.DropTable(
                name: "strategicaxe_traces");

            migrationBuilder.DropTable(
                name: "strategicprogram_traces");

            migrationBuilder.DropTable(
                name: "strategicproject_traces");

            migrationBuilder.DropTable(
                name: "territorialbarrier_traces");

            migrationBuilder.DropTable(
                name: "territorypotential_traces");

            migrationBuilder.DropTable(
                name: "unitmeasurement_traces");
        }
    }
}
