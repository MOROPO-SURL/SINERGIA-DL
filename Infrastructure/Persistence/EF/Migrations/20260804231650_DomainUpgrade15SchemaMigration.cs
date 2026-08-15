using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpgrade15SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pdloperationreports",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Income = table.Column<float>(type: "real", nullable: false),
                    IncomeBankDeposit = table.Column<float>(type: "real", nullable: false),
                    PeriodResult = table.Column<float>(type: "real", nullable: false),
                    CAMComission = table.Column<float>(type: "real", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Period = table.Column<DateOnly>(type: "date", nullable: false),
                    At = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EmployeeCount = table.Column<int>(type: "integer", nullable: false),
                    FemaleEmployeeCount = table.Column<int>(type: "integer", nullable: false),
                    DiscapacityEmployeeCount = table.Column<int>(type: "integer", nullable: false),
                    GridEnergySpend = table.Column<float>(type: "real", nullable: false),
                    RenerenewableEnergyGeneration = table.Column<float>(type: "real", nullable: false),
                    RenerenewableEnergyExportation = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdloperationreports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pdloperationreports_pdldevelopmentactorprofiles_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "pdldevelopmentactorprofiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pdloperationreports_OwnerId_Period",
                table: "pdloperationreports",
                columns: new[] { "OwnerId", "Period" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pdloperationreports");
        }
    }
}
