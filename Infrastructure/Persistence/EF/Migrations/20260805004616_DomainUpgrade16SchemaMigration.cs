using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpgrade16SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pdlsocialresposabilityactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Title = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    At = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DemandId = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdlsocialresposabilityactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pdlsocialresposabilityactions_pdldevelopmentactorprofiles_O~",
                        column: x => x.OwnerId,
                        principalTable: "pdldevelopmentactorprofiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pdlsocialresposabilityactions_socialsupportdemands_DemandId",
                        column: x => x.DemandId,
                        principalTable: "socialsupportdemands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "pdlsocialresposabilityaction_image_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdlsocialresposabilityaction_image_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_pdlsocialresposabilityaction_image_bridges_images_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pdlsocialresposabilityaction_image_bridges_pdlsocialresposa~",
                        column: x => x.MainId,
                        principalTable: "pdlsocialresposabilityactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pdlsocialresposabilityaction_location_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdlsocialresposabilityaction_location_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_pdlsocialresposabilityaction_location_bridges_locations_Lin~",
                        column: x => x.LinkedId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pdlsocialresposabilityaction_location_bridges_pdlsocialresp~",
                        column: x => x.MainId,
                        principalTable: "pdlsocialresposabilityactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pdlsocialresposabilityaction_image_bridges_LinkedId",
                table: "pdlsocialresposabilityaction_image_bridges",
                column: "LinkedId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pdlsocialresposabilityaction_location_bridges_LinkedId",
                table: "pdlsocialresposabilityaction_location_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_pdlsocialresposabilityactions_DemandId",
                table: "pdlsocialresposabilityactions",
                column: "DemandId");

            migrationBuilder.CreateIndex(
                name: "IX_pdlsocialresposabilityactions_OwnerId",
                table: "pdlsocialresposabilityactions",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pdlsocialresposabilityaction_image_bridges");

            migrationBuilder.DropTable(
                name: "pdlsocialresposabilityaction_location_bridges");

            migrationBuilder.DropTable(
                name: "pdlsocialresposabilityactions");
        }
    }
}
