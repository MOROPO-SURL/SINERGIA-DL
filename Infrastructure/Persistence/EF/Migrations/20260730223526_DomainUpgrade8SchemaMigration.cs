using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpgrade8SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_srloperationreports_srldevelopmentactorprofiles_Development~",
                table: "srloperationreports");

            migrationBuilder.DropIndex(
                name: "IX_srloperationreports_DevelopmentActorProfileId",
                table: "srloperationreports");

            migrationBuilder.RenameColumn(
                name: "DevelopmentActorProfileId",
                table: "srloperationreports",
                newName: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_srloperationreports_OwnerId_PeriodMonth_PeriodYear",
                table: "srloperationreports",
                columns: new[] { "OwnerId", "PeriodMonth", "PeriodYear" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_srloperationreports_srldevelopmentactorprofiles_OwnerId",
                table: "srloperationreports",
                column: "OwnerId",
                principalTable: "srldevelopmentactorprofiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_srloperationreports_srldevelopmentactorprofiles_OwnerId",
                table: "srloperationreports");

            migrationBuilder.DropIndex(
                name: "IX_srloperationreports_OwnerId_PeriodMonth_PeriodYear",
                table: "srloperationreports");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "srloperationreports",
                newName: "DevelopmentActorProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_srloperationreports_DevelopmentActorProfileId",
                table: "srloperationreports",
                column: "DevelopmentActorProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_srloperationreports_srldevelopmentactorprofiles_Development~",
                table: "srloperationreports",
                column: "DevelopmentActorProfileId",
                principalTable: "srldevelopmentactorprofiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
