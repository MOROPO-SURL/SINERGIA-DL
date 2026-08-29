using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpgrade9SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_srloperationreports_OwnerId_PeriodMonth_PeriodYear",
                table: "srloperationreports");

            migrationBuilder.DropColumn(
                name: "PeriodMonth",
                table: "srloperationreports");

            migrationBuilder.DropColumn(
                name: "PeriodYear",
                table: "srloperationreports");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Period",
                table: "srloperationreports",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<float>(
                name: "RenerenewableEnergyExportation",
                table: "srloperationreports",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_srloperationreports_OwnerId_Period",
                table: "srloperationreports",
                columns: new[] { "OwnerId", "Period" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_srloperationreports_OwnerId_Period",
                table: "srloperationreports");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "srloperationreports");

            migrationBuilder.DropColumn(
                name: "RenerenewableEnergyExportation",
                table: "srloperationreports");

            migrationBuilder.AddColumn<int>(
                name: "PeriodMonth",
                table: "srloperationreports",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodYear",
                table: "srloperationreports",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_srloperationreports_OwnerId_PeriodMonth_PeriodYear",
                table: "srloperationreports",
                columns: new[] { "OwnerId", "PeriodMonth", "PeriodYear" },
                unique: true);
        }
    }
}
