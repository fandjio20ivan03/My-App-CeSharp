using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filiere",
                columns: table => new
                {
                    FiliereId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiere", x => x.FiliereId);
                });

            migrationBuilder.CreateTable(
                name: "Cour",
                columns: table => new
                {
                    FiliereID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    Filiere_idFiliereId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cour", x => x.FiliereID);
                    table.ForeignKey(
                        name: "FK_Cour_Filiere_Filiere_idFiliereId",
                        column: x => x.Filiere_idFiliereId,
                        principalTable: "Filiere",
                        principalColumn: "FiliereId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    FiliereID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Filiere_idFiliereId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.FiliereID);
                    table.ForeignKey(
                        name: "FK_Student_Filiere_Filiere_idFiliereId",
                        column: x => x.Filiere_idFiliereId,
                        principalTable: "Filiere",
                        principalColumn: "FiliereId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FiliereID = table.Column<int>(type: "INTEGER", nullable: false),
                    CourID = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Note_Cour_CourID",
                        column: x => x.CourID,
                        principalTable: "Cour",
                        principalColumn: "FiliereID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Note_Filiere_FiliereID",
                        column: x => x.FiliereID,
                        principalTable: "Filiere",
                        principalColumn: "FiliereId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cour_Filiere_idFiliereId",
                table: "Cour",
                column: "Filiere_idFiliereId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_CourID",
                table: "Note",
                column: "CourID");

            migrationBuilder.CreateIndex(
                name: "IX_Note_FiliereID",
                table: "Note",
                column: "FiliereID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Filiere_idFiliereId",
                table: "Student",
                column: "Filiere_idFiliereId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Cour");

            migrationBuilder.DropTable(
                name: "Filiere");
        }
    }
}
