using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TC",
                table: "Personels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Ders",
                columns: table => new
                {
                    Ders_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kredi = table.Column<int>(type: "int", nullable: true),
                    Hoca_No = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ders", x => x.Ders_Id);
                    table.ForeignKey(
                        name: "FK_Ders_Personels_Hoca_No",
                        column: x => x.Hoca_No,
                        principalTable: "Personels",
                        principalColumn: "PerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Veli",
                columns: table => new
                {
                    Veli_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veli", x => x.Veli_Id);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    Program_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    time = table.Column<TimeOnly>(type: "time", nullable: false),
                    ders_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.Program_Id);
                    table.ForeignKey(
                        name: "FK_Program_Ders_ders_Id",
                        column: x => x.ders_Id,
                        principalTable: "Ders",
                        principalColumn: "Ders_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sinif",
                columns: table => new
                {
                    Sinif_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinifNo = table.Column<int>(type: "int", nullable: false),
                    Program_Id = table.Column<int>(type: "int", nullable: false),
                    Program_Id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinif", x => x.Sinif_Id);
                    table.ForeignKey(
                        name: "FK_Sinif_Program_Program_Id1",
                        column: x => x.Program_Id1,
                        principalTable: "Program",
                        principalColumn: "Program_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenciler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ogrenci_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: true),
                    sube = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Sinif_Id = table.Column<int>(type: "int", nullable: false),
                    Sinif_Id1 = table.Column<int>(type: "int", nullable: false),
                    Veli_Id = table.Column<int>(type: "int", nullable: false),
                    Veli_Id1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenciler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ogrenciler_Sinif_Sinif_Id1",
                        column: x => x.Sinif_Id1,
                        principalTable: "Sinif",
                        principalColumn: "Sinif_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ogrenciler_Veli_Veli_Id1",
                        column: x => x.Veli_Id1,
                        principalTable: "Veli",
                        principalColumn: "Veli_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sinavlar",
                columns: table => new
                {
                    Sinav_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Not = table.Column<float>(type: "real", nullable: false),
                    Ders_Id = table.Column<int>(type: "int", nullable: false),
                    Ogrenci_Id = table.Column<int>(type: "int", nullable: false),
                    Hoca_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinavlar", x => x.Sinav_Id);
                    table.ForeignKey(
                        name: "FK_Sinavlar_Ders_Ders_Id",
                        column: x => x.Ders_Id,
                        principalTable: "Ders",
                        principalColumn: "Ders_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sinavlar_Ogrenciler_Ogrenci_Id",
                        column: x => x.Ogrenci_Id,
                        principalTable: "Ogrenciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sinavlar_Personels_Hoca_Id",
                        column: x => x.Hoca_Id,
                        principalTable: "Personels",
                        principalColumn: "PerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ders_Hoca_No",
                table: "Ders",
                column: "Hoca_No");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenciler_Sinif_Id1",
                table: "Ogrenciler",
                column: "Sinif_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrenciler_Veli_Id1",
                table: "Ogrenciler",
                column: "Veli_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Program_ders_Id",
                table: "Program",
                column: "ders_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sinavlar_Ders_Id",
                table: "Sinavlar",
                column: "Ders_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sinavlar_Hoca_Id",
                table: "Sinavlar",
                column: "Hoca_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sinavlar_Ogrenci_Id",
                table: "Sinavlar",
                column: "Ogrenci_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sinif_Program_Id1",
                table: "Sinif",
                column: "Program_Id1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sinavlar");

            migrationBuilder.DropTable(
                name: "Ogrenciler");

            migrationBuilder.DropTable(
                name: "Sinif");

            migrationBuilder.DropTable(
                name: "Veli");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "Ders");

            migrationBuilder.DropColumn(
                name: "TC",
                table: "Personels");
        }
    }
}
