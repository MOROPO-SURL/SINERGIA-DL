using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendDomain2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "KindId",
                table: "strategicprojects",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "strategicprojectkinds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "character varying(480)", maxLength: 480, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_strategicprojectkinds", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_strategicprojects_KindId",
                table: "strategicprojects",
                column: "KindId");

            migrationBuilder.CreateIndex(
                name: "IX_strategicprojectkinds_Name",
                table: "strategicprojectkinds",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_strategicprojects_strategicprojectkinds_KindId",
                table: "strategicprojects",
                column: "KindId",
                principalTable: "strategicprojectkinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_strategicprojects_strategicprojectkinds_KindId",
                table: "strategicprojects");

            migrationBuilder.DropTable(
                name: "strategicprojectkinds");

            migrationBuilder.DropIndex(
                name: "IX_strategicprojects_KindId",
                table: "strategicprojects");

            migrationBuilder.DropColumn(
                name: "KindId",
                table: "strategicprojects");
        }
    }
}
