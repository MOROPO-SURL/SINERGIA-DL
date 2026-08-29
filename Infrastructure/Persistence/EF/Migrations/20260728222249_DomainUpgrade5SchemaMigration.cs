using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpgrade5SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "socialsupportdemand_locations");

            migrationBuilder.AddColumn<Guid>(
                name: "MainLocationId",
                table: "srldevelopmentactorprofiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MainLocationId",
                table: "pdldevelopmentactorprofiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_locations_images_FeatureImageId",
                        column: x => x.FeatureImageId,
                        principalTable: "images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pdldevelopmentactorprofile_location_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdldevelopmentactorprofile_location_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_pdldevelopmentactorprofile_location_bridges_locations_Linke~",
                        column: x => x.LinkedId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pdldevelopmentactorprofile_location_bridges_pdldevelopmenta~",
                        column: x => x.MainId,
                        principalTable: "pdldevelopmentactorprofiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "socialsupportdemand_location_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socialsupportdemand_location_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_socialsupportdemand_location_bridges_locations_LinkedId",
                        column: x => x.LinkedId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_socialsupportdemand_location_bridges_socialsupportdemands_M~",
                        column: x => x.MainId,
                        principalTable: "socialsupportdemands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "srldevelopmentactorprofile_location_bridges",
                columns: table => new
                {
                    MainId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_srldevelopmentactorprofile_location_bridges", x => new { x.MainId, x.LinkedId });
                    table.ForeignKey(
                        name: "FK_srldevelopmentactorprofile_location_bridges_locations_Linke~",
                        column: x => x.LinkedId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_srldevelopmentactorprofile_location_bridges_srldevelopmenta~",
                        column: x => x.MainId,
                        principalTable: "srldevelopmentactorprofiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_srldevelopmentactorprofiles_MainLocationId",
                table: "srldevelopmentactorprofiles",
                column: "MainLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofiles_MainLocationId",
                table: "pdldevelopmentactorprofiles",
                column: "MainLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_locations_FeatureImageId",
                table: "locations",
                column: "FeatureImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofile_location_bridges_LinkedId",
                table: "pdldevelopmentactorprofile_location_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_socialsupportdemand_location_bridges_LinkedId",
                table: "socialsupportdemand_location_bridges",
                column: "LinkedId");

            migrationBuilder.CreateIndex(
                name: "IX_srldevelopmentactorprofile_location_bridges_LinkedId",
                table: "srldevelopmentactorprofile_location_bridges",
                column: "LinkedId");

            migrationBuilder.AddForeignKey(
                name: "FK_pdldevelopmentactorprofiles_locations_MainLocationId",
                table: "pdldevelopmentactorprofiles",
                column: "MainLocationId",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_srldevelopmentactorprofiles_locations_MainLocationId",
                table: "srldevelopmentactorprofiles",
                column: "MainLocationId",
                principalTable: "locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pdldevelopmentactorprofiles_locations_MainLocationId",
                table: "pdldevelopmentactorprofiles");

            migrationBuilder.DropForeignKey(
                name: "FK_srldevelopmentactorprofiles_locations_MainLocationId",
                table: "srldevelopmentactorprofiles");

            migrationBuilder.DropTable(
                name: "pdldevelopmentactorprofile_location_bridges");

            migrationBuilder.DropTable(
                name: "socialsupportdemand_location_bridges");

            migrationBuilder.DropTable(
                name: "srldevelopmentactorprofile_location_bridges");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropIndex(
                name: "IX_srldevelopmentactorprofiles_MainLocationId",
                table: "srldevelopmentactorprofiles");

            migrationBuilder.DropIndex(
                name: "IX_pdldevelopmentactorprofiles_MainLocationId",
                table: "pdldevelopmentactorprofiles");

            migrationBuilder.DropColumn(
                name: "MainLocationId",
                table: "srldevelopmentactorprofiles");

            migrationBuilder.DropColumn(
                name: "MainLocationId",
                table: "pdldevelopmentactorprofiles");

            migrationBuilder.CreateTable(
                name: "socialsupportdemand_locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SocialSupportDemandId = table.Column<Guid>(type: "uuid", nullable: false),
                    FeatureImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    Description = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true),
                    Name = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Coordinate_Latitude = table.Column<float>(type: "real", nullable: false),
                    Coordinate_Longitude = table.Column<float>(type: "real", nullable: false),
                    PostalAddress_Context = table.Column<string>(type: "text", nullable: true),
                    PostalAddress_Name = table.Column<string>(type: "text", nullable: true),
                    PostalAddress_Number = table.Column<string>(type: "text", nullable: true),
                    PostalAddress_Street = table.Column<string>(type: "text", nullable: false),
                    PostalAddress_ZipCode = table.Column<int>(type: "integer", nullable: true)
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
                name: "IX_socialsupportdemand_locations_FeatureImageId",
                table: "socialsupportdemand_locations",
                column: "FeatureImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_socialsupportdemand_locations_SocialSupportDemandId",
                table: "socialsupportdemand_locations",
                column: "SocialSupportDemandId");
        }
    }
}
