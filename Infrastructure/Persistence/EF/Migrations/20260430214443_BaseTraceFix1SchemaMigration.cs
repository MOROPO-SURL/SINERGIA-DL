using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class BaseTraceFix1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "user_traces",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "role_traces",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "person_traces",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "organization_traces",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "user_traces",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "role_traces",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "person_traces",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "organization_traces",
                newName: "CreateAt");
        }
    }
}
