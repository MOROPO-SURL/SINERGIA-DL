using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpgrade11SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "srlsocialresposabilityactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    StartAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DemandId = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_srlsocialresposabilityactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_srlsocialresposabilityactions_socialsupportdemands_DemandId",
                        column: x => x.DemandId,
                        principalTable: "socialsupportdemands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_srlsocialresposabilityactions_srldevelopmentactorprofiles_O~",
                        column: x => x.OwnerId,
                        principalTable: "srldevelopmentactorprofiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "srlsocialresposabilityaction_image_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_srlsocialresposabilityaction_image_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_srlsocialresposabilityaction_image_bridges_images_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_srlsocialresposabilityaction_image_bridges_srlsocialresposa~",
                        column: x => x.MainId,
                        principalTable: "srlsocialresposabilityactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "srlsocialresposabilityaction_location_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_srlsocialresposabilityaction_location_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_srlsocialresposabilityaction_location_bridges_locations_Lin~",
                        column: x => x.LinkedId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_srlsocialresposabilityaction_location_bridges_srlsocialresp~",
                        column: x => x.MainId,
                        principalTable: "srlsocialresposabilityactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_srlsocialresposabilityaction_image_bridges_LinkedId",
                table: "srlsocialresposabilityaction_image_bridges",
                column: "LinkedId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_srlsocialresposabilityaction_location_bridges_LinkedId",
                table: "srlsocialresposabilityaction_location_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_srlsocialresposabilityactions_DemandId",
                table: "srlsocialresposabilityactions",
                column: "DemandId");

            migrationBuilder.CreateIndex(
                name: "IX_srlsocialresposabilityactions_OwnerId",
                table: "srlsocialresposabilityactions",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "srlsocialresposabilityaction_image_bridges");

            migrationBuilder.DropTable(
                name: "srlsocialresposabilityaction_location_bridges");

            migrationBuilder.DropTable(
                name: "srlsocialresposabilityactions");
        }
    }
}
