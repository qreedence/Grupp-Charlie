using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddedMunicipalities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipality_Counties_CountyId",
                table: "Municipality");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipality",
                table: "Municipality");

            migrationBuilder.RenameTable(
                name: "Municipality",
                newName: "Municipalities");

            migrationBuilder.RenameIndex(
                name: "IX_Municipality_CountyId",
                table: "Municipalities",
                newName: "IX_Municipalities_CountyId");

            migrationBuilder.AddColumn<string>(
                name: "CountyName",
                table: "Municipalities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipalities",
                table: "Municipalities",
                column: "MunicipalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipalities_Counties_CountyId",
                table: "Municipalities",
                column: "CountyId",
                principalTable: "Counties",
                principalColumn: "CountyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipalities_Counties_CountyId",
                table: "Municipalities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Municipalities",
                table: "Municipalities");

            migrationBuilder.DropColumn(
                name: "CountyName",
                table: "Municipalities");

            migrationBuilder.RenameTable(
                name: "Municipalities",
                newName: "Municipality");

            migrationBuilder.RenameIndex(
                name: "IX_Municipalities_CountyId",
                table: "Municipality",
                newName: "IX_Municipality_CountyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Municipality",
                table: "Municipality",
                column: "MunicipalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipality_Counties_CountyId",
                table: "Municipality",
                column: "CountyId",
                principalTable: "Counties",
                principalColumn: "CountyId");
        }
    }
}
