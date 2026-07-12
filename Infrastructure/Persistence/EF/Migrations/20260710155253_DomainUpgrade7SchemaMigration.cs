using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainUpgrade7SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pdldevelopmentactorprofiles_organizations_TitularOrganizati~",
                table: "pdldevelopmentactorprofiles");

            migrationBuilder.DropForeignKey(
                name: "FK_pdldevelopmentactorprofiles_people_TitularPersonId",
                table: "pdldevelopmentactorprofiles");

            migrationBuilder.RenameColumn(
                name: "TitularPersonId",
                table: "pdldevelopmentactorprofiles",
                newName: "HolderPersonId");

            migrationBuilder.RenameColumn(
                name: "TitularOrganizationId",
                table: "pdldevelopmentactorprofiles",
                newName: "HolderOrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_pdldevelopmentactorprofiles_TitularPersonId",
                table: "pdldevelopmentactorprofiles",
                newName: "IX_pdldevelopmentactorprofiles_HolderPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_pdldevelopmentactorprofiles_TitularOrganizationId",
                table: "pdldevelopmentactorprofiles",
                newName: "IX_pdldevelopmentactorprofiles_HolderOrganizationId");

            migrationBuilder.AddColumn<string>(
                name: "FiscalIdentificationCode",
                table: "srldevelopmentactorprofiles",
                type: "character varying(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FiscalIdentificationCode",
                table: "pdldevelopmentactorprofiles",
                type: "character varying(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ModalityId",
                table: "pdldevelopmentactorprofiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "pdlmodalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pdlmodalities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pdldevelopmentactorprofiles_ModalityId",
                table: "pdldevelopmentactorprofiles",
                column: "ModalityId");

            migrationBuilder.CreateIndex(
                name: "IX_pdlmodalities_Name",
                table: "pdlmodalities",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_pdldevelopmentactorprofiles_organizations_HolderOrganizatio~",
                table: "pdldevelopmentactorprofiles",
                column: "HolderOrganizationId",
                principalTable: "organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_pdldevelopmentactorprofiles_pdlmodalities_ModalityId",
                table: "pdldevelopmentactorprofiles",
                column: "ModalityId",
                principalTable: "pdlmodalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_pdldevelopmentactorprofiles_people_HolderPersonId",
                table: "pdldevelopmentactorprofiles",
                column: "HolderPersonId",
                principalTable: "people",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pdldevelopmentactorprofiles_organizations_HolderOrganizatio~",
                table: "pdldevelopmentactorprofiles");

            migrationBuilder.DropForeignKey(
                name: "FK_pdldevelopmentactorprofiles_pdlmodalities_ModalityId",
                table: "pdldevelopmentactorprofiles");

            migrationBuilder.DropForeignKey(
                name: "FK_pdldevelopmentactorprofiles_people_HolderPersonId",
                table: "pdldevelopmentactorprofiles");

            migrationBuilder.DropTable(
                name: "pdlmodalities");

            migrationBuilder.DropIndex(
                name: "IX_pdldevelopmentactorprofiles_ModalityId",
                table: "pdldevelopmentactorprofiles");

            migrationBuilder.DropColumn(
                name: "FiscalIdentificationCode",
                table: "srldevelopmentactorprofiles");

            migrationBuilder.DropColumn(
                name: "FiscalIdentificationCode",
                table: "pdldevelopmentactorprofiles");

            migrationBuilder.DropColumn(
                name: "ModalityId",
                table: "pdldevelopmentactorprofiles");

            migrationBuilder.RenameColumn(
                name: "HolderPersonId",
                table: "pdldevelopmentactorprofiles",
                newName: "TitularPersonId");

            migrationBuilder.RenameColumn(
                name: "HolderOrganizationId",
                table: "pdldevelopmentactorprofiles",
                newName: "TitularOrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_pdldevelopmentactorprofiles_HolderPersonId",
                table: "pdldevelopmentactorprofiles",
                newName: "IX_pdldevelopmentactorprofiles_TitularPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_pdldevelopmentactorprofiles_HolderOrganizationId",
                table: "pdldevelopmentactorprofiles",
                newName: "IX_pdldevelopmentactorprofiles_TitularOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_pdldevelopmentactorprofiles_organizations_TitularOrganizati~",
                table: "pdldevelopmentactorprofiles",
                column: "TitularOrganizationId",
                principalTable: "organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_pdldevelopmentactorprofiles_people_TitularPersonId",
                table: "pdldevelopmentactorprofiles",
                column: "TitularPersonId",
                principalTable: "people",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
