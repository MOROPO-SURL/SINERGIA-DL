using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clasifications",
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
                    table.PrimaryKey("PK_clasifications", x => x.Id);
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
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "character varying(480)", maxLength: 480, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizationkinds", x => x.Id);
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
                    PublisheAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                name: "strategicaxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicaxes", x => x.Id);
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
                name: "organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: true),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrganizationKindId = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "FK_organizations_organizationkinds_OrganizationKindId",
                        column: x => x.OrganizationKindId,
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<int>(type: "integer", nullable: true)
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
                name: "people_WebSites",
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
                    table.PrimaryKey("PK_people_WebSites", x => new { x.PersonId, x.Id });
                    table.ForeignKey(
                        name: "FK_people_WebSites_people_PersonId",
                        column: x => x.PersonId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategiclines",
                columns: table => new
                {
                    StrategicLineId = table.Column<int>(type: "integer", nullable: false),
                    StrategicAxeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CoordinadorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategiclines", x => new { x.StrategicLineId, x.StrategicAxeId });
                    table.ForeignKey(
                        name: "FK_strategiclines_people_CoordinadorId",
                        column: x => x.CoordinadorId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_strategiclines_strategicaxes_StrategicAxeId",
                        column: x => x.StrategicAxeId,
                        principalTable: "strategicaxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "organization_clasification_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization_clasification_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_organization_clasification_bridges_clasifications_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "clasifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_organization_clasification_bridges_organizations_MainId",
                        column: x => x.MainId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Name = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<int>(type: "integer", nullable: true)
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
                name: "organizations_WebSites",
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
                    table.PrimaryKey("PK_organizations_WebSites", x => new { x.OrganizationId, x.Id });
                    table.ForeignKey(
                        name: "FK_organizations_WebSites_organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "person_organization_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "strategicline_organization_bridges",
                columns: table => new
                {
                    StrategicLineId = table.Column<int>(type: "integer", nullable: false),
                    StrategicAxesId = table.Column<int>(type: "integer", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicline_organization_bridges", x => new { x.StrategicLineId, x.StrategicAxesId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_strategicline_organization_bridges_organizations_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_strategicline_organization_bridges_strategiclines_Strategic~",
                        columns: x => new { x.StrategicLineId, x.StrategicAxesId },
                        principalTable: "strategiclines",
                        principalColumns: new[] { "StrategicLineId", "StrategicAxeId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicline_strategicactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicLineId = table.Column<int>(type: "integer", nullable: false),
                    StrategicAxeId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicline_strategicactions", x => new { x.Id, x.StrategicLineId, x.StrategicAxeId });
                    table.ForeignKey(
                        name: "FK_strategicline_strategicactions_strategiclines_StrategicLine~",
                        columns: x => new { x.StrategicLineId, x.StrategicAxeId },
                        principalTable: "strategiclines",
                        principalColumns: new[] { "StrategicLineId", "StrategicAxeId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicprograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicAxeId = table.Column<int>(type: "integer", nullable: false),
                    StrategicLineId = table.Column<int>(type: "integer", nullable: false),
                    StrategicLineId1 = table.Column<int>(type: "integer", nullable: true),
                    StrategicLineStrategicAxeId = table.Column<int>(type: "integer", nullable: true),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    Index = table.Column<int>(type: "integer", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_strategicprograms_strategiclines_StrategicLineId1_Strategic~",
                        columns: x => new { x.StrategicLineId1, x.StrategicLineStrategicAxeId },
                        principalTable: "strategiclines",
                        principalColumns: new[] { "StrategicLineId", "StrategicAxeId" },
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
                name: "strategicprojects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProgramId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_strategicprojects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_strategicprojects_strategicprograms_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "strategicprograms",
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

            migrationBuilder.CreateIndex(
                name: "IX_clasifications_Name",
                table: "clasifications",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_interestareas_Name",
                table: "interestareas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_keyvariables_Alias",
                table: "keyvariables",
                column: "Alias");

            migrationBuilder.CreateIndex(
                name: "IX_keyvariables_Name",
                table: "keyvariables",
                column: "Name");

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
                name: "IX_objectives_Index",
                table: "objectives",
                column: "Index",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_organization_clasification_bridges_LinkedId",
                table: "organization_clasification_bridges",
                column: "LinkedId");

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
                name: "IX_organizations_OrganizationKindId",
                table: "organizations",
                column: "OrganizationKindId");

            migrationBuilder.CreateIndex(
                name: "IX_organizations_OwnerId",
                table: "organizations",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_people_ImageId",
                table: "people",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_person_organization_bridges_LinkedId",
                table: "person_organization_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_publicpolicies_Title",
                table: "publicpolicies",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_role_permission_bridges_LinkedId",
                table: "role_permission_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_roles_Name",
                table: "roles",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_strategicline_organization_bridges_LinkedId",
                table: "strategicline_organization_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicline_strategicactions_StrategicLineId_StrategicAxe~",
                table: "strategicline_strategicactions",
                columns: new[] { "StrategicLineId", "StrategicAxeId" });

            migrationBuilder.CreateIndex(
                name: "IX_strategiclines_CoordinadorId",
                table: "strategiclines",
                column: "CoordinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_strategiclines_StrategicAxeId",
                table: "strategiclines",
                column: "StrategicAxeId");

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
                name: "IX_strategicprograms_CoordinatorId",
                table: "strategicprograms",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprograms_Index_Id_StrategicLineId_StrategicAxeId",
                table: "strategicprograms",
                columns: new[] { "Index", "Id", "StrategicLineId", "StrategicAxeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicprograms_StrategicLineId1_StrategicLineStrategicAx~",
                table: "strategicprograms",
                columns: new[] { "StrategicLineId1", "StrategicLineStrategicAxeId" });

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
                name: "IX_territorialbarriers_Title",
                table: "territorialbarriers",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_territorypotentials_Title",
                table: "territorypotentials",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_unitmeasurements_Name",
                table: "unitmeasurements",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_bridges_LinkedId",
                table: "user_role_bridges",
                column: "LinkedId");

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
                name: "macroprograms");

            migrationBuilder.DropTable(
                name: "objective_actions");

            migrationBuilder.DropTable(
                name: "objective_challanges");

            migrationBuilder.DropTable(
                name: "objective_keyvariable_bridges");

            migrationBuilder.DropTable(
                name: "objective_projections");

            migrationBuilder.DropTable(
                name: "organization_clasification_bridges");

            migrationBuilder.DropTable(
                name: "organizations_EmailAddresses");

            migrationBuilder.DropTable(
                name: "organizations_PhoneNumbers");

            migrationBuilder.DropTable(
                name: "organizations_PostalAddresses");

            migrationBuilder.DropTable(
                name: "organizations_WebSites");

            migrationBuilder.DropTable(
                name: "people_EmailAddresses");

            migrationBuilder.DropTable(
                name: "people_PhoneNumbers");

            migrationBuilder.DropTable(
                name: "people_PostalAddresses");

            migrationBuilder.DropTable(
                name: "people_WebSites");

            migrationBuilder.DropTable(
                name: "person_organization_bridges");

            migrationBuilder.DropTable(
                name: "publicpolicies");

            migrationBuilder.DropTable(
                name: "role_permission_bridges");

            migrationBuilder.DropTable(
                name: "strategicline_organization_bridges");

            migrationBuilder.DropTable(
                name: "strategicline_strategicactions");

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
                name: "territorialbarriers");

            migrationBuilder.DropTable(
                name: "territorypotentials");

            migrationBuilder.DropTable(
                name: "user_role_bridges");

            migrationBuilder.DropTable(
                name: "keyvariables");

            migrationBuilder.DropTable(
                name: "objectives");

            migrationBuilder.DropTable(
                name: "clasifications");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "interestareas");

            migrationBuilder.DropTable(
                name: "strategicprogram_actions");

            migrationBuilder.DropTable(
                name: "strategicprogram_impacts");

            migrationBuilder.DropTable(
                name: "unitmeasurements");

            migrationBuilder.DropTable(
                name: "strategicprojects");

            migrationBuilder.DropTable(
                name: "strategicprogram_objetives");

            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "strategicprograms");

            migrationBuilder.DropTable(
                name: "organizationkinds");

            migrationBuilder.DropTable(
                name: "strategiclines");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "strategicaxes");

            migrationBuilder.DropTable(
                name: "images");
        }
    }
}
