using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainExtend1SchemaMigration : Migration
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
                name: "strategicaxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
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
                name: "strategicaxe_strategiclines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicAxesId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    CoordinadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicaxe_strategiclines", x => new { x.Id, x.StrategicAxesId });
                    table.ForeignKey(
                        name: "FK_strategicaxe_strategiclines_people_CoordinadorId",
                        column: x => x.CoordinadorId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_strategicaxe_strategiclines_strategicaxes_StrategicAxesId",
                        column: x => x.StrategicAxesId,
                        principalTable: "strategicaxes",
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
                name: "strategicaxe_strategicactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicAxesId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicLineId = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicaxe_strategicactions", x => new { x.Id, x.StrategicLineId, x.StrategicAxesId });
                    table.ForeignKey(
                        name: "FK_strategicaxe_strategicactions_strategicaxe_strategiclines_S~",
                        columns: x => new { x.StrategicLineId, x.StrategicAxesId },
                        principalTable: "strategicaxe_strategiclines",
                        principalColumns: new[] { "Id", "StrategicAxesId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicaxe_strategicline_organization_bridges",
                columns: table => new
                {
                    StrategicLineId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicAxesId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicaxe_strategicline_organization_bridges", x => new { x.StrategicLineId, x.StrategicAxesId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_strategicaxe_strategicline_organization_bridges_organizatio~",
                        column: x => x.LinkedId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_strategicaxe_strategicline_organization_bridges_strategicax~",
                        columns: x => new { x.StrategicLineId, x.StrategicAxesId },
                        principalTable: "strategicaxe_strategiclines",
                        principalColumns: new[] { "Id", "StrategicAxesId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicaxe_strategicprograms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicAxesId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicLineId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_strategicaxe_strategicprograms", x => new { x.Id, x.StrategicLineId, x.StrategicAxesId });
                    table.ForeignKey(
                        name: "FK_strategicaxe_strategicprograms_people_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_strategicaxe_strategicprograms_strategicaxe_strategiclines_~",
                        columns: x => new { x.StrategicLineId, x.StrategicAxesId },
                        principalTable: "strategicaxe_strategiclines",
                        principalColumns: new[] { "Id", "StrategicAxesId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicaxe_programactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicAxesId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicLineId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicaxe_programactions", x => new { x.Id, x.StrategicProgramId, x.StrategicLineId, x.StrategicAxesId });
                    table.ForeignKey(
                        name: "FK_strategicaxe_programactions_strategicaxe_strategicprograms_~",
                        columns: x => new { x.StrategicProgramId, x.StrategicLineId, x.StrategicAxesId },
                        principalTable: "strategicaxe_strategicprograms",
                        principalColumns: new[] { "Id", "StrategicLineId", "StrategicAxesId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicaxe_programexecutionprojects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicAxesId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicLineId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicaxe_programexecutionprojects", x => new { x.Id, x.StrategicProgramId, x.StrategicLineId, x.StrategicAxesId });
                    table.ForeignKey(
                        name: "FK_strategicaxe_programexecutionprojects_strategicaxe_strategi~",
                        columns: x => new { x.StrategicProgramId, x.StrategicLineId, x.StrategicAxesId },
                        principalTable: "strategicaxe_strategicprograms",
                        principalColumns: new[] { "Id", "StrategicLineId", "StrategicAxesId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicaxe_programideaprojects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicAxesId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicLineId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicaxe_programideaprojects", x => new { x.Id, x.StrategicProgramId, x.StrategicLineId, x.StrategicAxesId });
                    table.ForeignKey(
                        name: "FK_strategicaxe_programideaprojects_strategicaxe_strategicprog~",
                        columns: x => new { x.StrategicProgramId, x.StrategicLineId, x.StrategicAxesId },
                        principalTable: "strategicaxe_strategicprograms",
                        principalColumns: new[] { "Id", "StrategicLineId", "StrategicAxesId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicaxe_programimpacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicAxesId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicLineId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicaxe_programimpacts", x => new { x.Id, x.StrategicProgramId, x.StrategicLineId, x.StrategicAxesId });
                    table.ForeignKey(
                        name: "FK_strategicaxe_programimpacts_strategicaxe_strategicprograms_~",
                        columns: x => new { x.StrategicProgramId, x.StrategicLineId, x.StrategicAxesId },
                        principalTable: "strategicaxe_strategicprograms",
                        principalColumns: new[] { "Id", "StrategicLineId", "StrategicAxesId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicaxe_programobjetives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicAxesId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicLineId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(360)", maxLength: 360, nullable: false),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    Index = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicaxe_programobjetives", x => new { x.Id, x.StrategicProgramId, x.StrategicLineId, x.StrategicAxesId });
                    table.ForeignKey(
                        name: "FK_strategicaxe_programobjetives_strategicaxe_strategicprogram~",
                        columns: x => new { x.StrategicProgramId, x.StrategicLineId, x.StrategicAxesId },
                        principalTable: "strategicaxe_strategicprograms",
                        principalColumns: new[] { "Id", "StrategicLineId", "StrategicAxesId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicaxe_strategicprogram_organization_bridges",
                columns: table => new
                {
                    StrategicProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicAxesId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicLineId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicaxe_strategicprogram_organization_bridges", x => new { x.StrategicProgramId, x.StrategicLineId, x.StrategicAxesId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_strategicaxe_strategicprogram_organization_bridges_organiza~",
                        column: x => x.LinkedId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_strategicaxe_strategicprogram_organization_bridges_strategi~",
                        columns: x => new { x.StrategicProgramId, x.StrategicLineId, x.StrategicAxesId },
                        principalTable: "strategicaxe_strategicprograms",
                        principalColumns: new[] { "Id", "StrategicLineId", "StrategicAxesId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "strategicaxe_programaction_interestarea_bridges",
                columns: table => new
                {
                    ProgramActionId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicAxesId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicLineId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicProgramId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicaxe_programaction_interestarea_bridges", x => new { x.ProgramActionId, x.StrategicProgramId, x.StrategicLineId, x.StrategicAxesId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_strategicaxe_programaction_interestarea_bridges_interestare~",
                        column: x => x.LinkedId,
                        principalTable: "interestareas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_strategicaxe_programaction_interestarea_bridges_strategicax~",
                        columns: x => new { x.ProgramActionId, x.StrategicProgramId, x.StrategicLineId, x.StrategicAxesId },
                        principalTable: "strategicaxe_programactions",
                        principalColumns: new[] { "Id", "StrategicProgramId", "StrategicLineId", "StrategicAxesId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "impactindicators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicAxesId = table.Column<Guid>(type: "uuid", nullable: false),
                    StrategicLineId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_impactindicators", x => new { x.Id, x.ProgramImpactId, x.StrategicProgramId, x.StrategicLineId, x.StrategicAxesId });
                    table.ForeignKey(
                        name: "FK_impactindicators_strategicaxe_programimpacts_ProgramImpactI~",
                        columns: x => new { x.ProgramImpactId, x.StrategicProgramId, x.StrategicLineId, x.StrategicAxesId },
                        principalTable: "strategicaxe_programimpacts",
                        principalColumns: new[] { "Id", "StrategicProgramId", "StrategicLineId", "StrategicAxesId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_impactindicators_unitmeasurements_UnitMeasurementId",
                        column: x => x.UnitMeasurementId,
                        principalTable: "unitmeasurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clasifications_Name",
                table: "clasifications",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_impactindicators_Name_Id_ProgramImpactId_StrategicProgramId~",
                table: "impactindicators",
                columns: new[] { "Name", "Id", "ProgramImpactId", "StrategicProgramId", "StrategicLineId", "StrategicAxesId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_impactindicators_ProgramImpactId_StrategicProgramId_Strateg~",
                table: "impactindicators",
                columns: new[] { "ProgramImpactId", "StrategicProgramId", "StrategicLineId", "StrategicAxesId" });

            migrationBuilder.CreateIndex(
                name: "IX_impactindicators_UnitMeasurementId",
                table: "impactindicators",
                column: "UnitMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_interestareas_Name",
                table: "interestareas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_macroprograms_Index",
                table: "macroprograms",
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
                name: "IX_strategicaxe_programaction_interestarea_bridges_LinkedId",
                table: "strategicaxe_programaction_interestarea_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_programactions_Index_Id_StrategicProgramId_Str~",
                table: "strategicaxe_programactions",
                columns: new[] { "Index", "Id", "StrategicProgramId", "StrategicLineId", "StrategicAxesId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_programactions_StrategicProgramId_StrategicLin~",
                table: "strategicaxe_programactions",
                columns: new[] { "StrategicProgramId", "StrategicLineId", "StrategicAxesId" });

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_programexecutionprojects_Name_Id_StrategicProg~",
                table: "strategicaxe_programexecutionprojects",
                columns: new[] { "Name", "Id", "StrategicProgramId", "StrategicLineId", "StrategicAxesId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_programexecutionprojects_StrategicProgramId_St~",
                table: "strategicaxe_programexecutionprojects",
                columns: new[] { "StrategicProgramId", "StrategicLineId", "StrategicAxesId" });

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_programideaprojects_Name_Id_StrategicProgramId~",
                table: "strategicaxe_programideaprojects",
                columns: new[] { "Name", "Id", "StrategicProgramId", "StrategicLineId", "StrategicAxesId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_programideaprojects_StrategicProgramId_Strateg~",
                table: "strategicaxe_programideaprojects",
                columns: new[] { "StrategicProgramId", "StrategicLineId", "StrategicAxesId" });

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_programimpacts_Name_Id_StrategicProgramId_Stra~",
                table: "strategicaxe_programimpacts",
                columns: new[] { "Name", "Id", "StrategicProgramId", "StrategicLineId", "StrategicAxesId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_programimpacts_StrategicProgramId_StrategicLin~",
                table: "strategicaxe_programimpacts",
                columns: new[] { "StrategicProgramId", "StrategicLineId", "StrategicAxesId" });

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_programobjetives_Index_Id_StrategicProgramId_S~",
                table: "strategicaxe_programobjetives",
                columns: new[] { "Index", "Id", "StrategicProgramId", "StrategicLineId", "StrategicAxesId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_programobjetives_StrategicProgramId_StrategicL~",
                table: "strategicaxe_programobjetives",
                columns: new[] { "StrategicProgramId", "StrategicLineId", "StrategicAxesId" });

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_strategicactions_Index_Id_StrategicLineId_Stra~",
                table: "strategicaxe_strategicactions",
                columns: new[] { "Index", "Id", "StrategicLineId", "StrategicAxesId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_strategicactions_StrategicLineId_StrategicAxes~",
                table: "strategicaxe_strategicactions",
                columns: new[] { "StrategicLineId", "StrategicAxesId" });

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_strategicline_organization_bridges_LinkedId",
                table: "strategicaxe_strategicline_organization_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_strategiclines_CoordinadorId",
                table: "strategicaxe_strategiclines",
                column: "CoordinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_strategiclines_Index_Id_StrategicAxesId",
                table: "strategicaxe_strategiclines",
                columns: new[] { "Index", "Id", "StrategicAxesId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_strategiclines_StrategicAxesId",
                table: "strategicaxe_strategiclines",
                column: "StrategicAxesId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_strategicprogram_organization_bridges_LinkedId",
                table: "strategicaxe_strategicprogram_organization_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_strategicprograms_CoordinatorId",
                table: "strategicaxe_strategicprograms",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_strategicprograms_Index_Id_StrategicLineId_Str~",
                table: "strategicaxe_strategicprograms",
                columns: new[] { "Index", "Id", "StrategicLineId", "StrategicAxesId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxe_strategicprograms_StrategicLineId_StrategicAxe~",
                table: "strategicaxe_strategicprograms",
                columns: new[] { "StrategicLineId", "StrategicAxesId" });

            migrationBuilder.CreateIndex(
                name: "IX_strategicaxes_Index",
                table: "strategicaxes",
                column: "Index",
                unique: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "impactindicators");

            migrationBuilder.DropTable(
                name: "macroprograms");

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
                name: "strategicaxe_programaction_interestarea_bridges");

            migrationBuilder.DropTable(
                name: "strategicaxe_programexecutionprojects");

            migrationBuilder.DropTable(
                name: "strategicaxe_programideaprojects");

            migrationBuilder.DropTable(
                name: "strategicaxe_programobjetives");

            migrationBuilder.DropTable(
                name: "strategicaxe_strategicactions");

            migrationBuilder.DropTable(
                name: "strategicaxe_strategicline_organization_bridges");

            migrationBuilder.DropTable(
                name: "strategicaxe_strategicprogram_organization_bridges");

            migrationBuilder.DropTable(
                name: "territorialbarriers");

            migrationBuilder.DropTable(
                name: "territorypotentials");

            migrationBuilder.DropTable(
                name: "strategicaxe_programimpacts");

            migrationBuilder.DropTable(
                name: "unitmeasurements");

            migrationBuilder.DropTable(
                name: "clasifications");

            migrationBuilder.DropTable(
                name: "interestareas");

            migrationBuilder.DropTable(
                name: "strategicaxe_programactions");

            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.DropTable(
                name: "strategicaxe_strategicprograms");

            migrationBuilder.DropTable(
                name: "organizationkinds");

            migrationBuilder.DropTable(
                name: "strategicaxe_strategiclines");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "strategicaxes");
        }
    }
}
