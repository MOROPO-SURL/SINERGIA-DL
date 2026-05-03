using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class OrganizationMinorRename1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_organizations_organizationkinds_OrganizationKindId",
                table: "organizations");

            migrationBuilder.RenameColumn(
                name: "OrganizationKindId",
                table: "organizations",
                newName: "KindId");

            migrationBuilder.RenameIndex(
                name: "IX_organizations_OrganizationKindId",
                table: "organizations",
                newName: "IX_organizations_KindId");

            migrationBuilder.AddForeignKey(
                name: "FK_organizations_organizationkinds_KindId",
                table: "organizations",
                column: "KindId",
                principalTable: "organizationkinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_organizations_organizationkinds_KindId",
                table: "organizations");

            migrationBuilder.RenameColumn(
                name: "KindId",
                table: "organizations",
                newName: "OrganizationKindId");

            migrationBuilder.RenameIndex(
                name: "IX_organizations_KindId",
                table: "organizations",
                newName: "IX_organizations_OrganizationKindId");

            migrationBuilder.AddForeignKey(
                name: "FK_organizations_organizationkinds_OrganizationKindId",
                table: "organizations",
                column: "OrganizationKindId",
                principalTable: "organizationkinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
