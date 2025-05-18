using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApp2025Spring.Api.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.CreateTable(
                name: "Kolcsonzesek",
                columns: table => new
                {
                    KolcsonzesSzam = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OlvasoSzam = table.Column<int>(type: "INTEGER", nullable: false),
                    LeltariSzam = table.Column<int>(type: "INTEGER", nullable: false),
                    KolcsonzesIdeje = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    VisszahozasHatarido = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kolcsonzesek", x => x.KolcsonzesSzam);
                });

            migrationBuilder.CreateTable(
                name: "Konyvek",
                columns: table => new
                {
                    LeltariSzam = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cim = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Szerzo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Kiado = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    KiadasEve = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konyvek", x => x.LeltariSzam);
                });

            migrationBuilder.CreateTable(
                name: "Olvasok",
                columns: table => new
                {
                    OlvasoSzam = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OlvasoNev = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Lakcim = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SzuletesiDatum = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Olvasok", x => x.OlvasoSzam);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kolcsonzesek");

            migrationBuilder.DropTable(
                name: "Konyvek");

            migrationBuilder.DropTable(
                name: "Olvasok");

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PersonId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_PersonId",
                table: "Items",
                column: "PersonId");
        }
    }
}
