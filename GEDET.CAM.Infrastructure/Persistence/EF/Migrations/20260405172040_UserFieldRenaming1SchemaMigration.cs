using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.GEDET.CAM.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class UserFieldRenaming1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordChangeRequired",
                table: "users",
                newName: "IsPasswordChangeRequired");

            migrationBuilder.RenameColumn(
                name: "Enabled",
                table: "users",
                newName: "IsEnabled");

            migrationBuilder.RenameColumn(
                name: "Enabled",
                table: "objectives",
                newName: "IsEnabled");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPasswordChangeRequired",
                table: "users",
                newName: "PasswordChangeRequired");

            migrationBuilder.RenameColumn(
                name: "IsEnabled",
                table: "users",
                newName: "Enabled");

            migrationBuilder.RenameColumn(
                name: "IsEnabled",
                table: "objectives",
                newName: "Enabled");
        }
    }
}
