using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grupy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupy", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Historie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idGrupy = table.Column<int>(type: "int", nullable: false),
                    tryb_akcji = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Studenci",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDGrupy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenci", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grupy");

            migrationBuilder.DropTable(
                name: "Historie");

            migrationBuilder.DropTable(
                name: "Studenci");
        }
    }
}
