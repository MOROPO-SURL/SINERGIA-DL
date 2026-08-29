using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "apikeys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(240)", maxLength: 240, nullable: false),
                    Token = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Host = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
                    Description = table.Column<string>(type: "character varying(480)", maxLength: 480, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apikeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "classifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "economicactivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_economicactivities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "featurekinds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_featurekinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContentType = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Length = table.Column<long>(type: "bigint", nullable: false),
                    About = table.Column<string>(type: "character varying(240)", maxLength: 240, nullable: true),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "interestareas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interestareas", x => x.Id);
                });

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
                name: "macroprograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Title = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_macroprograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "objectives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objectives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "organizationkinds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    DevelopmentActorProfileKind = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "character varying(480)", maxLength: 480, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizationkinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pdlmodalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdlmodalities", x => x.Id);
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
                name: "publicpolicies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Title = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publicpolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "character varying(480)", maxLength: 480, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "strategicprojectkinds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "character varying(480)", maxLength: 480, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprojectkinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "territorialbarriers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Title = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_territorialbarriers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "territorypotentials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Title = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_territorypotentials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "unitmeasurements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Symbol = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Prefixed = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unitmeasurements", x => x.Id);
                });

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
                name: "features",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    KindId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(51200)", maxLength: 51200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_features_featurekinds_KindId",
                        column: x => x.KindId,
                        principalTable: "featurekinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_services_images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    IsPasswordChangeRequired = table.Column<bool>(type: "boolean", nullable: false),
                    HasFullAccess = table.Column<bool>(type: "boolean", nullable: false),
                    LastSessionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FailAuthenticationCount = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    LastName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    Signature = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
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
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
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
                name: "organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    About = table.Column<string>(type: "text", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    KindId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_organizations_images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_organizations_organizationkinds_KindId",
                        column: x => x.KindId,
                        principalTable: "organizationkinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_organizations_organizations_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "apikey_permission_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<string>(type: "text", nullable: false),
                    Signature = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apikey_permission_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_apikey_permission_bridges_apikeys_MainId",
                        column: x => x.MainId,
                        principalTable: "apikeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_apikey_permission_bridges_permissions_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "role_traces",
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
                    table.PrimaryKey("PK_role_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_role_traces_roles_TargetId",
                        column: x => x.TargetId,
                        principalTable: "roles",
                        principalColumn: "Id",
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
                name: "people",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Alias = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: true),
                    BornDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    About = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    LastName = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: true),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    CivilStatus = table.Column<int>(type: "integer", nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<string>(type: "character varying(64)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.Id);
                    table.ForeignKey(
                        name: "FK_people_images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_people_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "user_role_bridges",
                columns: table => new
                {
                    MainId = table.Column<string>(type: "character varying(64)", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false),
                    Signature = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_user_role_bridges_roles_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_role_bridges_users_MainId",
                        column: x => x.MainId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_traces",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Author = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TargetId = table.Column<string>(type: "character varying(64)", nullable: true),
                    BeforeData = table.Column<string>(type: "text", nullable: true),
                    AfterData = table.Column<string>(type: "text", nullable: true),
                    Signature = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_traces_users_TargetId",
                        column: x => x.TargetId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "organization_classification_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization_classification_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_organization_classification_bridges_classifications_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "classifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_organization_classification_bridges_organizations_MainId",
                        column: x => x.MainId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organization_traces",
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
                    table.PrimaryKey("PK_organization_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_organization_traces_organizations_TargetId",
                        column: x => x.TargetId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "organizations_EmailAddresses",
                columns: table => new
                {
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations_EmailAddresses", x => new { x.OrganizationId, x.Id });
                    table.ForeignKey(
                        name: "FK_organizations_EmailAddresses_organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organizations_PhoneNumbers",
                columns: table => new
                {
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations_PhoneNumbers", x => new { x.OrganizationId, x.Id });
                    table.ForeignKey(
                        name: "FK_organizations_PhoneNumbers_organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organizations_PostalAddresses",
                columns: table => new
                {
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: true),
                    Context = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations_PostalAddresses", x => new { x.OrganizationId, x.Id });
                    table.ForeignKey(
                        name: "FK_organizations_PostalAddresses_organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "organizations_WebSiteAddresses",
                columns: table => new
                {
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations_WebSiteAddresses", x => new { x.OrganizationId, x.Id });
                    table.ForeignKey(
                        name: "FK_organizations_WebSiteAddresses_organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "srldevelopmentactorprofiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    FiscalIdentificationCode = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    MainEconomicActivityId = table.Column<int>(type: "integer", nullable: false),
                    About = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_srldevelopmentactorprofiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_srldevelopmentactorprofiles_economicactivities_MainEconomic~",
                        column: x => x.MainEconomicActivityId,
                        principalTable: "economicactivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_srldevelopmentactorprofiles_organizations_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pdldevelopmentactorprofiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModalityId = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    HolderOrganizationId = table.Column<Guid>(type: "uuid", nullable: true),
                    HolderPersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    FiscalIdentificationCode = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    MainEconomicActivityId = table.Column<int>(type: "integer", nullable: false),
                    About = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdldevelopmentactorprofiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pdldevelopmentactorprofiles_economicactivities_MainEconomic~",
                        column: x => x.MainEconomicActivityId,
                        principalTable: "economicactivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pdldevelopmentactorprofiles_organizations_HolderOrganizatio~",
                        column: x => x.HolderOrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pdldevelopmentactorprofiles_organizations_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pdldevelopmentactorprofiles_pdlmodalities_ModalityId",
                        column: x => x.ModalityId,
                        principalTable: "pdlmodalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pdldevelopmentactorprofiles_people_HolderPersonId",
                        column: x => x.HolderPersonId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "people_EmailAddresses",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people_EmailAddresses", x => new { x.PersonId, x.Id });
                    table.ForeignKey(
                        name: "FK_people_EmailAddresses_people_PersonId",
                        column: x => x.PersonId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "people_PhoneNumbers",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people_PhoneNumbers", x => new { x.PersonId, x.Id });
                    table.ForeignKey(
                        name: "FK_people_PhoneNumbers_people_PersonId",
                        column: x => x.PersonId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "people_PostalAddresses",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: true),
                    Context = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people_PostalAddresses", x => new { x.PersonId, x.Id });
                    table.ForeignKey(
                        name: "FK_people_PostalAddresses_people_PersonId",
                        column: x => x.PersonId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "people_WebSiteAddresses",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people_WebSiteAddresses", x => new { x.PersonId, x.Id });
                    table.ForeignKey(
                        name: "FK_people_WebSiteAddresses_people_PersonId",
                        column: x => x.PersonId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "person_organization_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsRepresentative = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person_organization_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_person_organization_bridges_organizations_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_organization_bridges_people_MainId",
                        column: x => x.MainId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "person_traces",
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
                    table.PrimaryKey("PK_person_traces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_person_traces_people_TargetId",
                        column: x => x.TargetId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "strategicaxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    CoordinatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicaxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_strategicaxes_people_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "srldevelopmentactorprofile_commercialactivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DevelopmentActorProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_srldevelopmentactorprofile_commercialactivities", x => new { x.Id, x.DevelopmentActorProfileId });
                    table.ForeignKey(
                        name: "FK_srldevelopmentactorprofile_commercialactivities_products_Pr~",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_srldevelopmentactorprofile_commercialactivities_srldevelopm~",
                        column: x => x.DevelopmentActorProfileId,
                        principalTable: "srldevelopmentactorprofiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "srldevelopmentactorprofile_economicactivity_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_srldevelopmentactorprofile_economicactivity_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_srldevelopmentactorprofile_economicactivity_bridges_economi~",
                        column: x => x.LinkedId,
                        principalTable: "economicactivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_srldevelopmentactorprofile_economicactivity_bridges_srldeve~",
                        column: x => x.MainId,
                        principalTable: "srldevelopmentactorprofiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "srldevelopmentactorprofile_organization_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_srldevelopmentactorprofile_organization_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_srldevelopmentactorprofile_organization_bridges_organizatio~",
                        column: x => x.LinkedId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_srldevelopmentactorprofile_organization_bridges_srldevelopm~",
                        column: x => x.MainId,
                        principalTable: "srldevelopmentactorprofiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "srldevelopmentactorprofile_person_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_srldevelopmentactorprofile_person_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_srldevelopmentactorprofile_person_bridges_people_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_srldevelopmentactorprofile_person_bridges_srldevelopmentact~",
                        column: x => x.MainId,
                        principalTable: "srldevelopmentactorprofiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "srldevelopmentactorprofile_productionactivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DevelopmentActorProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_srldevelopmentactorprofile_productionactivities", x => new { x.Id, x.DevelopmentActorProfileId });
                    table.ForeignKey(
                        name: "FK_srldevelopmentactorprofile_productionactivities_products_Pr~",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_srldevelopmentactorprofile_productionactivities_srldevelopm~",
                        column: x => x.DevelopmentActorProfileId,
                        principalTable: "srldevelopmentactorprofiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "srldevelopmentactorprofile_servicingactivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DevelopmentActorProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_srldevelopmentactorprofile_servicingactivities", x => new { x.Id, x.DevelopmentActorProfileId });
                    table.ForeignKey(
                        name: "FK_srldevelopmentactorprofile_servicingactivities_services_Ser~",
                        column: x => x.ServiceId,
                        principalTable: "services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_srldevelopmentactorprofile_servicingactivities_srldevelopme~",
                        column: x => x.DevelopmentActorProfileId,
                        principalTable: "srldevelopmentactorprofiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pdldevelopmentactorprofile_commercialactivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DevelopmentActorProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdldevelopmentactorprofile_commercialactivities", x => new { x.Id, x.DevelopmentActorProfileId });
                    table.ForeignKey(
                        name: "FK_pdldevelopmentactorprofile_commercialactivities_pdldevelopm~",
                        column: x => x.DevelopmentActorProfileId,
                        principalTable: "pdldevelopmentactorprofiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pdldevelopmentactorprofile_commercialactivities_products_Pr~",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pdldevelopmentactorprofile_economicactivity_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdldevelopmentactorprofile_economicactivity_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_pdldevelopmentactorprofile_economicactivity_bridges_economi~",
                        column: x => x.LinkedId,
                        principalTable: "economicactivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pdldevelopmentactorprofile_economicactivity_bridges_pdldeve~",
                        column: x => x.MainId,
                        principalTable: "pdldevelopmentactorprofiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pdldevelopmentactorprofile_productionactivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DevelopmentActorProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdldevelopmentactorprofile_productionactivities", x => new { x.Id, x.DevelopmentActorProfileId });
                    table.ForeignKey(
                        name: "FK_pdldevelopmentactorprofile_productionactivities_pdldevelopm~",
                        column: x => x.DevelopmentActorProfileId,
                        principalTable: "pdldevelopmentactorprofiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pdldevelopmentactorprofile_productionactivities_products_Pr~",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pdldevelopmentactorprofile_servicingactivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DevelopmentActorProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdldevelopmentactorprofile_servicingactivities", x => new { x.Id, x.DevelopmentActorProfileId });
                    table.ForeignKey(
                        name: "FK_pdldevelopmentactorprofile_servicingactivities_pdldevelopme~",
                        column: x => x.DevelopmentActorProfileId,
                        principalTable: "pdldevelopmentactorprofiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pdldevelopmentactorprofile_servicingactivities_services_Ser~",
                        column: x => x.ServiceId,
                        principalTable: "services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "strategicline_macroprogram_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicline_macroprogram_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_strategicline_macroprogram_bridges_macroprograms_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "macroprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_strategicline_macroprogram_bridges_strategiclines_MainId",
                        column: x => x.MainId,
                        principalTable: "strategiclines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Restrict);
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
                    Objective = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
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
                    ProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprogram_actions", x => new { x.Id, x.ProgramId });
                    table.ForeignKey(
                        name: "FK_strategicprogram_actions_strategicprograms_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "strategicprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicprogram_impacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprogram_impacts", x => new { x.Id, x.ProgramId });
                    table.ForeignKey(
                        name: "FK_strategicprogram_impacts_strategicprograms_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "strategicprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicprogram_macroprogram_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprogram_macroprogram_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_strategicprogram_macroprogram_bridges_macroprograms_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "macroprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_strategicprogram_macroprogram_bridges_strategicprograms_Mai~",
                        column: x => x.MainId,
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_strategicprogram_organization_bridges_strategicprograms_Mai~",
                        column: x => x.MainId,
                        principalTable: "strategicprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicprogram_specificobjetives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprogram_specificobjetives", x => new { x.Id, x.ProgramId });
                    table.ForeignKey(
                        name: "FK_strategicprogram_specificobjetives_strategicprograms_Progra~",
                        column: x => x.ProgramId,
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
                name: "strategicprojectideas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProgramId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_strategicprojectideas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_strategicprojectideas_strategicprograms_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "strategicprograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "strategicprogram_action_indicators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProgramId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_strategicprogram_action_indicators", x => new { x.Id, x.ActionId, x.ProgramId });
                    table.ForeignKey(
                        name: "FK_strategicprogram_action_indicators_strategicprogram_actions~",
                        columns: x => new { x.ActionId, x.ProgramId },
                        principalTable: "strategicprogram_actions",
                        principalColumns: new[] { "Id", "ProgramId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_strategicprogram_action_indicators_unitmeasurements_UnitMea~",
                        column: x => x.UnitMeasurementId,
                        principalTable: "unitmeasurements",
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
                        principalColumns: new[] { "Id", "ProgramId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicprogram_specificobjective_strategicproject_bridges",
                columns: table => new
                {
                    ProgramObjectiveId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprogram_specificobjective_strategicproject_bridges", x => new { x.ProgramObjectiveId, x.StrategicProgramId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_strategicprogram_specificobjective_strategicproject_bridges~",
                        column: x => x.LinkedId,
                        principalTable: "strategicprojects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_strategicprogram_specificobjective_strategicproject_bridge~1",
                        columns: x => new { x.ProgramObjectiveId, x.StrategicProgramId },
                        principalTable: "strategicprogram_specificobjetives",
                        principalColumns: new[] { "Id", "ProgramId" },
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

            migrationBuilder.CreateTable(
                name: "strategicprogram_action_indicator_changes",
                columns: table => new
                {
                    Id = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionId = table.Column<Guid>(type: "uuid", nullable: false),
                    IndicatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Context = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprogram_action_indicator_changes", x => new { x.Id, x.IndicatorId, x.ActionId, x.ProgramId });
                    table.ForeignKey(
                        name: "FK_strategicprogram_action_indicator_changes_strategicprogram_~",
                        columns: x => new { x.IndicatorId, x.ActionId, x.ProgramId },
                        principalTable: "strategicprogram_action_indicators",
                        principalColumns: new[] { "Id", "ActionId", "ProgramId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicprogram_action_indicator_milestones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActionId = table.Column<Guid>(type: "uuid", nullable: false),
                    IndicatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    At = table.Column<DateOnly>(type: "date", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprogram_action_indicator_milestones", x => new { x.Id, x.IndicatorId, x.ActionId, x.ProgramId });
                    table.ForeignKey(
                        name: "FK_strategicprogram_action_indicator_milestones_strategicprogr~",
                        columns: x => new { x.IndicatorId, x.ActionId, x.ProgramId },
                        principalTable: "strategicprogram_action_indicators",
                        principalColumns: new[] { "Id", "ActionId", "ProgramId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_apikey_permission_bridges_LinkedId",
                table: "apikey_permission_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_apikey_traces_TargetId",
                table: "apikey_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_apikeys_Name",
                table: "apikeys",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_classification_traces_TargetId",
                table: "classification_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_classifications_Name",
                table: "classifications",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_feature_traces_TargetId",
                table: "feature_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_featurekind_traces_TargetId",
                table: "featurekind_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_features_KindId",
                table: "features",
                column: "KindId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_interestarea_traces_TargetId",
                table: "interestarea_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_interestareas_Name",
                table: "interestareas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_keyvariable_traces_TargetId",
                table: "keyvariable_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_keyvariables_Alias",
                table: "keyvariables",
                column: "Alias");

            migrationBuilder.CreateIndex(
                name: "IX_keyvariables_Name",
                table: "keyvariables",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_macroprogram_traces_TargetId",
                table: "macroprogram_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_macroprograms_Index",
                table: "macroprograms",
                column: "Index",
                unique: true);

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
                name: "IX_objective_traces_TargetId",
                table: "objective_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_objectives_Index",
                table: "objectives",
                column: "Index",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_organization_classification_bridges_LinkedId",
                table: "organization_classification_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_organization_traces_TargetId",
                table: "organization_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_organizationkind_traces_TargetId",
                table: "organizationkind_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_organizationkinds_Name",
                table: "organizationkinds",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_organizations_ImageId",
                table: "organizations",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_organizations_KindId",
                table: "organizations",
                column: "KindId");

            migrationBuilder.CreateIndex(
                name: "IX_organizations_OwnerId",
                table: "organizations",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofile_commercialactivities_Development~",
                table: "pdldevelopmentactorprofile_commercialactivities",
                column: "DevelopmentActorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofile_commercialactivities_ProductId",
                table: "pdldevelopmentactorprofile_commercialactivities",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofile_economicactivity_bridges_LinkedId",
                table: "pdldevelopmentactorprofile_economicactivity_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofile_productionactivities_Development~",
                table: "pdldevelopmentactorprofile_productionactivities",
                column: "DevelopmentActorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofile_productionactivities_ProductId",
                table: "pdldevelopmentactorprofile_productionactivities",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofile_servicingactivities_DevelopmentA~",
                table: "pdldevelopmentactorprofile_servicingactivities",
                column: "DevelopmentActorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofile_servicingactivities_ServiceId",
                table: "pdldevelopmentactorprofile_servicingactivities",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofiles_HolderOrganizationId",
                table: "pdldevelopmentactorprofiles",
                column: "HolderOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofiles_HolderPersonId",
                table: "pdldevelopmentactorprofiles",
                column: "HolderPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofiles_MainEconomicActivityId",
                table: "pdldevelopmentactorprofiles",
                column: "MainEconomicActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofiles_ModalityId",
                table: "pdldevelopmentactorprofiles",
                column: "ModalityId");

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofiles_OwnerId",
                table: "pdldevelopmentactorprofiles",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_pdlmodalities_Name",
                table: "pdlmodalities",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_people_ImageId",
                table: "people",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_people_UserId",
                table: "people",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_person_organization_bridges_LinkedId",
                table: "person_organization_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_person_traces_TargetId",
                table: "person_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_products_ImageId",
                table: "products",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_publicpolicies_Title",
                table: "publicpolicies",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_publicpolicy_traces_TargetId",
                table: "publicpolicy_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_role_permission_bridges_LinkedId",
                table: "role_permission_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_role_traces_TargetId",
                table: "role_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_roles_Name",
                table: "roles",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_services_ImageId",
                table: "services",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_srldevelopmentactorprofile_commercialactivities_Development~",
                table: "srldevelopmentactorprofile_commercialactivities",
                column: "DevelopmentActorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_srldevelopmentactorprofile_commercialactivities_ProductId",
                table: "srldevelopmentactorprofile_commercialactivities",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_srldevelopmentactorprofile_economicactivity_bridges_LinkedId",
                table: "srldevelopmentactorprofile_economicactivity_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_srldevelopmentactorprofile_organization_bridges_LinkedId",
                table: "srldevelopmentactorprofile_organization_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_srldevelopmentactorprofile_person_bridges_LinkedId",
                table: "srldevelopmentactorprofile_person_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_srldevelopmentactorprofile_productionactivities_Development~",
                table: "srldevelopmentactorprofile_productionactivities",
                column: "DevelopmentActorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_srldevelopmentactorprofile_productionactivities_ProductId",
                table: "srldevelopmentactorprofile_productionactivities",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_srldevelopmentactorprofile_servicingactivities_DevelopmentA~",
                table: "srldevelopmentactorprofile_servicingactivities",
                column: "DevelopmentActorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_srldevelopmentactorprofile_servicingactivities_ServiceId",
                table: "srldevelopmentactorprofile_servicingactivities",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_srldevelopmentactorprofiles_MainEconomicActivityId",
                table: "srldevelopmentactorprofiles",
                column: "MainEconomicActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_srldevelopmentactorprofiles_OwnerId",
                table: "srldevelopmentactorprofiles",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_macroprogram_bridges_LinkedId",
                table: "strategicaxe_macroprogram_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_traces_TargetId",
                table: "strategicaxe_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxes_CoordinatorId",
                table: "strategicaxes",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicline_macroprogram_bridges_LinkedId",
                table: "strategicline_macroprogram_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicline_organization_bridges_LinkedId",
                table: "strategicline_organization_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicline_publicpolicy_bridges_LinkedId",
                table: "strategicline_publicpolicy_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicline_specificobjectives_Index_Id_StrategicLineId",
                table: "strategicline_specificobjectives",
                columns: new[] { "Index", "Id", "StrategicLineId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicline_specificobjectives_StrategicLineId",
                table: "strategicline_specificobjectives",
                column: "StrategicLineId");

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
                name: "IX_strategicprogram_action_indicator_changes_IndicatorId_Actio~",
                table: "strategicprogram_action_indicator_changes",
                columns: new[] { "IndicatorId", "ActionId", "ProgramId" });

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_action_indicator_milestones_Id_IndicatorId~",
                table: "strategicprogram_action_indicator_milestones",
                columns: new[] { "Id", "IndicatorId", "ActionId", "ProgramId", "At" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_action_indicator_milestones_IndicatorId_Ac~",
                table: "strategicprogram_action_indicator_milestones",
                columns: new[] { "IndicatorId", "ActionId", "ProgramId" });

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_action_indicators_ActionId_ProgramId",
                table: "strategicprogram_action_indicators",
                columns: new[] { "ActionId", "ProgramId" });

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_action_indicators_Name_Id_ActionId_Program~",
                table: "strategicprogram_action_indicators",
                columns: new[] { "Name", "Id", "ActionId", "ProgramId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_action_indicators_UnitMeasurementId",
                table: "strategicprogram_action_indicators",
                column: "UnitMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_action_interestarea_bridges_LinkedId",
                table: "strategicprogram_action_interestarea_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_actions_ProgramId",
                table: "strategicprogram_actions",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_impacts_Name_Id_ProgramId",
                table: "strategicprogram_impacts",
                columns: new[] { "Name", "Id", "ProgramId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_impacts_ProgramId",
                table: "strategicprogram_impacts",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_macroprogram_bridges_LinkedId",
                table: "strategicprogram_macroprogram_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_organization_bridges_LinkedId",
                table: "strategicprogram_organization_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_specificobjective_strategicproject_bridges~",
                table: "strategicprogram_specificobjective_strategicproject_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_specificobjetives_Index_Id_ProgramId",
                table: "strategicprogram_specificobjetives",
                columns: new[] { "Index", "Id", "ProgramId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicprogram_specificobjetives_ProgramId",
                table: "strategicprogram_specificobjetives",
                column: "ProgramId");

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
                name: "IX_strategicprojectideas_Name",
                table: "strategicprojectideas",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprojectideas_ProgramId",
                table: "strategicprojectideas",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprojectkind_traces_TargetId",
                table: "strategicprojectkind_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprojectkinds_Name",
                table: "strategicprojectkinds",
                column: "Name",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_territorialbarrier_traces_TargetId",
                table: "territorialbarrier_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_territorialbarriers_Title",
                table: "territorialbarriers",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_territorypotential_traces_TargetId",
                table: "territorypotential_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_territorypotentials_Title",
                table: "territorypotentials",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_unitmeasurement_traces_TargetId",
                table: "unitmeasurement_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_unitmeasurements_Name",
                table: "unitmeasurements",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_bridges_LinkedId",
                table: "user_role_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_user_traces_TargetId",
                table: "user_traces",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_users_ImageId",
                table: "users",
                column: "ImageId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "apikey_permission_bridges");

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
                name: "objective_actions");

            migrationBuilder.DropTable(
                name: "objective_challanges");

            migrationBuilder.DropTable(
                name: "objective_keyvariable_bridges");

            migrationBuilder.DropTable(
                name: "objective_projections");

            migrationBuilder.DropTable(
                name: "objective_traces");

            migrationBuilder.DropTable(
                name: "organization_classification_bridges");

            migrationBuilder.DropTable(
                name: "organization_traces");

            migrationBuilder.DropTable(
                name: "organizationkind_traces");

            migrationBuilder.DropTable(
                name: "organizations_EmailAddresses");

            migrationBuilder.DropTable(
                name: "organizations_PhoneNumbers");

            migrationBuilder.DropTable(
                name: "organizations_PostalAddresses");

            migrationBuilder.DropTable(
                name: "organizations_WebSiteAddresses");

            migrationBuilder.DropTable(
                name: "pdldevelopmentactorprofile_commercialactivities");

            migrationBuilder.DropTable(
                name: "pdldevelopmentactorprofile_economicactivity_bridges");

            migrationBuilder.DropTable(
                name: "pdldevelopmentactorprofile_productionactivities");

            migrationBuilder.DropTable(
                name: "pdldevelopmentactorprofile_servicingactivities");

            migrationBuilder.DropTable(
                name: "people_EmailAddresses");

            migrationBuilder.DropTable(
                name: "people_PhoneNumbers");

            migrationBuilder.DropTable(
                name: "people_PostalAddresses");

            migrationBuilder.DropTable(
                name: "people_WebSiteAddresses");

            migrationBuilder.DropTable(
                name: "person_organization_bridges");

            migrationBuilder.DropTable(
                name: "person_traces");

            migrationBuilder.DropTable(
                name: "publicpolicy_traces");

            migrationBuilder.DropTable(
                name: "role_permission_bridges");

            migrationBuilder.DropTable(
                name: "role_traces");

            migrationBuilder.DropTable(
                name: "srldevelopmentactorprofile_commercialactivities");

            migrationBuilder.DropTable(
                name: "srldevelopmentactorprofile_economicactivity_bridges");

            migrationBuilder.DropTable(
                name: "srldevelopmentactorprofile_organization_bridges");

            migrationBuilder.DropTable(
                name: "srldevelopmentactorprofile_person_bridges");

            migrationBuilder.DropTable(
                name: "srldevelopmentactorprofile_productionactivities");

            migrationBuilder.DropTable(
                name: "srldevelopmentactorprofile_servicingactivities");

            migrationBuilder.DropTable(
                name: "strategicaxe_macroprogram_bridges");

            migrationBuilder.DropTable(
                name: "strategicaxe_traces");

            migrationBuilder.DropTable(
                name: "strategicline_macroprogram_bridges");

            migrationBuilder.DropTable(
                name: "strategicline_organization_bridges");

            migrationBuilder.DropTable(
                name: "strategicline_publicpolicy_bridges");

            migrationBuilder.DropTable(
                name: "strategicline_specificobjectives");

            migrationBuilder.DropTable(
                name: "strategicline_strategicactions");

            migrationBuilder.DropTable(
                name: "strategicline_traces");

            migrationBuilder.DropTable(
                name: "strategicprogram_action_indicator_changes");

            migrationBuilder.DropTable(
                name: "strategicprogram_action_indicator_milestones");

            migrationBuilder.DropTable(
                name: "strategicprogram_action_interestarea_bridges");

            migrationBuilder.DropTable(
                name: "strategicprogram_impacts");

            migrationBuilder.DropTable(
                name: "strategicprogram_macroprogram_bridges");

            migrationBuilder.DropTable(
                name: "strategicprogram_organization_bridges");

            migrationBuilder.DropTable(
                name: "strategicprogram_specificobjective_strategicproject_bridges");

            migrationBuilder.DropTable(
                name: "strategicprogram_traces");

            migrationBuilder.DropTable(
                name: "strategicproject_traces");

            migrationBuilder.DropTable(
                name: "strategicprojectideas");

            migrationBuilder.DropTable(
                name: "strategicprojectkind_traces");

            migrationBuilder.DropTable(
                name: "territorialbarrier_traces");

            migrationBuilder.DropTable(
                name: "territorypotential_traces");

            migrationBuilder.DropTable(
                name: "unitmeasurement_traces");

            migrationBuilder.DropTable(
                name: "user_role_bridges");

            migrationBuilder.DropTable(
                name: "user_traces");

            migrationBuilder.DropTable(
                name: "apikeys");

            migrationBuilder.DropTable(
                name: "features");

            migrationBuilder.DropTable(
                name: "keyvariables");

            migrationBuilder.DropTable(
                name: "objectives");

            migrationBuilder.DropTable(
                name: "classifications");

            migrationBuilder.DropTable(
                name: "pdldevelopmentactorprofiles");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "srldevelopmentactorprofiles");

            migrationBuilder.DropTable(
                name: "publicpolicies");

            migrationBuilder.DropTable(
                name: "strategicprogram_action_indicators");

            migrationBuilder.DropTable(
                name: "interestareas");

            migrationBuilder.DropTable(
                name: "macroprograms");

            migrationBuilder.DropTable(
                name: "strategicprogram_specificobjetives");

            migrationBuilder.DropTable(
                name: "strategicprojects");

            migrationBuilder.DropTable(
                name: "territorialbarriers");

            migrationBuilder.DropTable(
                name: "territorypotentials");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "featurekinds");

            migrationBuilder.DropTable(
                name: "pdlmodalities");

            migrationBuilder.DropTable(
                name: "economicactivities");

            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.DropTable(
                name: "strategicprogram_actions");

            migrationBuilder.DropTable(
                name: "unitmeasurements");

            migrationBuilder.DropTable(
                name: "strategicprojectkinds");

            migrationBuilder.DropTable(
                name: "organizationkinds");

            migrationBuilder.DropTable(
                name: "strategicprograms");

            migrationBuilder.DropTable(
                name: "strategiclines");

            migrationBuilder.DropTable(
                name: "strategicaxes");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "images");
        }
    }
}
