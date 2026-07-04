using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpgrade2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pdldevelopmentactorprofiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(55)", maxLength: 55, nullable: false),
                    TitularOrganizationId = table.Column<Guid>(type: "uuid", nullable: true),
                    TitularPersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "FK_pdldevelopmentactorprofiles_organizations_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pdldevelopmentactorprofiles_organizations_TitularOrganizati~",
                        column: x => x.TitularOrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pdldevelopmentactorprofiles_people_TitularPersonId",
                        column: x => x.TitularPersonId,
                        principalTable: "people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "srldevelopmentactorprofiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
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
                name: "IX_pdldevelopmentactorprofiles_MainEconomicActivityId",
                table: "pdldevelopmentactorprofiles",
                column: "MainEconomicActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofiles_OwnerId",
                table: "pdldevelopmentactorprofiles",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofiles_TitularOrganizationId",
                table: "pdldevelopmentactorprofiles",
                column: "TitularOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofiles_TitularPersonId",
                table: "pdldevelopmentactorprofiles",
                column: "TitularPersonId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pdldevelopmentactorprofile_commercialactivities");

            migrationBuilder.DropTable(
                name: "pdldevelopmentactorprofile_economicactivity_bridges");

            migrationBuilder.DropTable(
                name: "pdldevelopmentactorprofile_productionactivities");

            migrationBuilder.DropTable(
                name: "pdldevelopmentactorprofile_servicingactivities");

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
                name: "pdldevelopmentactorprofiles");

            migrationBuilder.DropTable(
                name: "srldevelopmentactorprofiles");
        }
    }
}
