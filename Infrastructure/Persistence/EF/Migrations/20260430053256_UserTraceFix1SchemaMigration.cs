using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class UserTraceFix1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_traces_users_TargetId",
                table: "user_traces");

            migrationBuilder.AlterColumn<string>(
                name: "TargetId",
                table: "user_traces",
                type: "character varying(64)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(64)");

            migrationBuilder.AddForeignKey(
                name: "FK_user_traces_users_TargetId",
                table: "user_traces",
                column: "TargetId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_traces_users_TargetId",
                table: "user_traces");

            migrationBuilder.AlterColumn<string>(
                name: "TargetId",
                table: "user_traces",
                type: "character varying(64)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_user_traces_users_TargetId",
                table: "user_traces",
                column: "TargetId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
