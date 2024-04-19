using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrupaID",
                table: "Studenci",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Studenci_GrupaID",
                table: "Studenci",
                column: "GrupaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Studenci_Grupy_GrupaID",
                table: "Studenci",
                column: "GrupaID",
                principalTable: "Grupy",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studenci_Grupy_GrupaID",
                table: "Studenci");

            migrationBuilder.DropIndex(
                name: "IX_Studenci_GrupaID",
                table: "Studenci");

            migrationBuilder.DropColumn(
                name: "GrupaID",
                table: "Studenci");
        }
    }
}
