using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpgrade13SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndAt",
                table: "srlsocialresposabilityactions");

            migrationBuilder.RenameColumn(
                name: "StartAt",
                table: "srlsocialresposabilityactions",
                newName: "At");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "At",
                table: "srlsocialresposabilityactions",
                newName: "StartAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndAt",
                table: "srlsocialresposabilityactions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
