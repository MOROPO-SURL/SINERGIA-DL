using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class PublicPolicyMinorUpdate1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "organizations_WebSites");

            migrationBuilder.RenameColumn(
                name: "PublisheAt",
                table: "publicpolicies",
                newName: "PublishedAt");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "organizations",
                type: "text",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "organizations_WebSiteAddresses");

            migrationBuilder.DropColumn(
                name: "About",
                table: "organizations");

            migrationBuilder.RenameColumn(
                name: "PublishedAt",
                table: "publicpolicies",
                newName: "PublisheAt");

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
        }
    }
}
