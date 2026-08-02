using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpgrade6SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pdldevelopmentactorprofile_location_bridges_locations_Linke~",
                table: "pdldevelopmentactorprofile_location_bridges");

            migrationBuilder.DropForeignKey(
                name: "FK_socialsupportdemand_location_bridges_locations_LinkedId",
                table: "socialsupportdemand_location_bridges");

            migrationBuilder.DropForeignKey(
                name: "FK_srldevelopmentactorprofile_location_bridges_locations_Linke~",
                table: "srldevelopmentactorprofile_location_bridges");

            migrationBuilder.CreateTable(
                name: "srloperationreports",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    DevelopmentActorProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    PeriodMonth = table.Column<int>(type: "integer", nullable: false),
                    PeriodYear = table.Column<int>(type: "integer", nullable: false),
                    EmployeeCount = table.Column<int>(type: "integer", nullable: false),
                    FemaleEmployeeCount = table.Column<int>(type: "integer", nullable: false),
                    DiscapacityEmployeeCount = table.Column<int>(type: "integer", nullable: false),
                    GridEnergySpend = table.Column<float>(type: "real", nullable: false),
                    RenerenewableEnergyGeneration = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_srloperationreports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_srloperationreports_srldevelopmentactorprofiles_Development~",
                        column: x => x.DevelopmentActorProfileId,
                        principalTable: "srldevelopmentactorprofiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "srloperationreport_accountingentries",
                columns: table => new
                {
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    ReportId = table.Column<long>(type: "bigint", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_srloperationreport_accountingentries", x => new { x.Kind, x.ReportId, x.Currency });
                    table.ForeignKey(
                        name: "FK_srloperationreport_accountingentries_srloperationreports_Re~",
                        column: x => x.ReportId,
                        principalTable: "srloperationreports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_srloperationreport_accountingentries_ReportId",
                table: "srloperationreport_accountingentries",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_srloperationreports_DevelopmentActorProfileId",
                table: "srloperationreports",
                column: "DevelopmentActorProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_pdldevelopmentactorprofile_location_bridges_locations_Linke~",
                table: "pdldevelopmentactorprofile_location_bridges",
                column: "LinkedId",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_socialsupportdemand_location_bridges_locations_LinkedId",
                table: "socialsupportdemand_location_bridges",
                column: "LinkedId",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_srldevelopmentactorprofile_location_bridges_locations_Linke~",
                table: "srldevelopmentactorprofile_location_bridges",
                column: "LinkedId",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pdldevelopmentactorprofile_location_bridges_locations_Linke~",
                table: "pdldevelopmentactorprofile_location_bridges");

            migrationBuilder.DropForeignKey(
                name: "FK_socialsupportdemand_location_bridges_locations_LinkedId",
                table: "socialsupportdemand_location_bridges");

            migrationBuilder.DropForeignKey(
                name: "FK_srldevelopmentactorprofile_location_bridges_locations_Linke~",
                table: "srldevelopmentactorprofile_location_bridges");

            migrationBuilder.DropTable(
                name: "srloperationreport_accountingentries");

            migrationBuilder.DropTable(
                name: "srloperationreports");

            migrationBuilder.AddForeignKey(
                name: "FK_pdldevelopmentactorprofile_location_bridges_locations_Linke~",
                table: "pdldevelopmentactorprofile_location_bridges",
                column: "LinkedId",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_socialsupportdemand_location_bridges_locations_LinkedId",
                table: "socialsupportdemand_location_bridges",
                column: "LinkedId",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_srldevelopmentactorprofile_location_bridges_locations_Linke~",
                table: "srldevelopmentactorprofile_location_bridges",
                column: "LinkedId",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
