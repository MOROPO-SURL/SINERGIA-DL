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
                name: "socialsupportdemands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    StartAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EndAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socialsupportdemands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "socialsupportdemand_image_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socialsupportdemand_image_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_socialsupportdemand_image_bridges_images_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_socialsupportdemand_image_bridges_socialsupportdemands_Main~",
                        column: x => x.MainId,
                        principalTable: "socialsupportdemands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "socialsupportdemand_locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SocialSupportDemandId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    PostalAddress_Street = table.Column<string>(type: "text", nullable: false),
                    PostalAddress_Number = table.Column<string>(type: "text", nullable: true),
                    PostalAddress_Context = table.Column<string>(type: "text", nullable: true),
                    PostalAddress_ZipCode = table.Column<int>(type: "integer", nullable: true),
                    PostalAddress_Name = table.Column<string>(type: "text", nullable: true),
                    Coordinate_Latitude = table.Column<float>(type: "real", nullable: false),
                    Coordinate_Longitude = table.Column<float>(type: "real", nullable: false),
                    FeatureImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socialsupportdemand_locations", x => new { x.Id, x.SocialSupportDemandId });
                    table.ForeignKey(
                        name: "FK_socialsupportdemand_locations_images_FeatureImageId",
                        column: x => x.FeatureImageId,
                        principalTable: "images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_socialsupportdemand_locations_socialsupportdemands_SocialSu~",
                        column: x => x.SocialSupportDemandId,
                        principalTable: "socialsupportdemands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_socialsupportdemand_image_bridges_LinkedId",
                table: "socialsupportdemand_image_bridges",
                column: "LinkedId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_socialsupportdemand_locations_FeatureImageId",
                table: "socialsupportdemand_locations",
                column: "FeatureImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_socialsupportdemand_locations_SocialSupportDemandId",
                table: "socialsupportdemand_locations",
                column: "SocialSupportDemandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "socialsupportdemand_image_bridges");

            migrationBuilder.DropTable(
                name: "socialsupportdemand_locations");

            migrationBuilder.DropTable(
                name: "socialsupportdemands");
        }
    }
}
