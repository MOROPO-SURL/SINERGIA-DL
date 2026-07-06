using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpgrade5SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DevelopmentActorProfileKind",
                table: "organizations");

            migrationBuilder.AddColumn<int>(
                name: "DevelopmentActorProfileKind",
                table: "organizationkinds",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DevelopmentActorProfileKind",
                table: "organizationkinds");

            migrationBuilder.AddColumn<int>(
                name: "DevelopmentActorProfileKind",
                table: "organizations",
                type: "integer",
                nullable: true);
        }
    }
}
