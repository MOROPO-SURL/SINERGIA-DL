using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class UserTraceFix3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_traces_TargetId",
                table: "user_traces");

            migrationBuilder.CreateIndex(
                name: "IX_user_traces_TargetId",
                table: "user_traces",
                column: "TargetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_traces_TargetId",
                table: "user_traces");

            migrationBuilder.CreateIndex(
                name: "IX_user_traces_TargetId",
                table: "user_traces",
                column: "TargetId",
                unique: true);
        }
    }
}
