using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class addedchangestoclasseshouseandmuni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MunicipalityId",
                table: "Houses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Houses_MunicipalityId",
                table: "Houses",
                column: "MunicipalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_Municipalities_MunicipalityId",
                table: "Houses",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "MunicipalityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_Municipalities_MunicipalityId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_MunicipalityId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "MunicipalityId",
                table: "Houses");
        }
    }
}
