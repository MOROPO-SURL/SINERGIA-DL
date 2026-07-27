using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpgrade4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "strategicprojectideas",
                newName: "Title");

            migrationBuilder.RenameIndex(
                name: "IX_strategicprojectideas_Name",
                table: "strategicprojectideas",
                newName: "IX_strategicprojectideas_Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "strategicprojectideas",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_strategicprojectideas_Title",
                table: "strategicprojectideas",
                newName: "IX_strategicprojectideas_Name");
        }
    }
}
