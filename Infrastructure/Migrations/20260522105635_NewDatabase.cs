using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Derss",
                columns: table => new
                {
                    Ders_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kredi = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Derss", x => x.Ders_Id);
                });

            migrationBuilder.CreateTable(
                name: "Sinifs",
                columns: table => new
                {
                    Sinif_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinifNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinifs", x => x.Sinif_Id);
                });

            migrationBuilder.CreateTable(
                name: "Velis",
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
                    table.PrimaryKey("PK_Velis", x => x.Veli_Id);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    PerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: true),
                    jobTitle = table.Column<int>(type: "int", nullable: false),
                    hasPassword = table.Column<bool>(type: "bit", nullable: false),
                    UzmanAlani = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.PerId);
                    table.ForeignKey(
                        name: "FK_Personels_Derss_DersId",
                        column: x => x.DersId,
                        principalTable: "Derss",
                        principalColumn: "Ders_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ogrencis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ogrenci_No = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: true),
                    sube = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    hasPassword = table.Column<bool>(type: "bit", nullable: false),
                    Sinif_Id = table.Column<int>(type: "int", nullable: false),
                    Veli_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrencis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ogrencis_Sinifs_Sinif_Id",
                        column: x => x.Sinif_Id,
                        principalTable: "Sinifs",
                        principalColumn: "Sinif_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ogrencis_Velis_Veli_Id",
                        column: x => x.Veli_Id,
                        principalTable: "Velis",
                        principalColumn: "Veli_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Program_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    time = table.Column<TimeOnly>(type: "time", nullable: false),
                    ders_Id = table.Column<int>(type: "int", nullable: false),
                    Per_id = table.Column<int>(type: "int", nullable: false),
                    Sinif_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Program_Id);
                    table.ForeignKey(
                        name: "FK_Programs_Derss_ders_Id",
                        column: x => x.ders_Id,
                        principalTable: "Derss",
                        principalColumn: "Ders_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Programs_Personels_Per_id",
                        column: x => x.Per_id,
                        principalTable: "Personels",
                        principalColumn: "PerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Programs_Sinifs_Sinif_id",
                        column: x => x.Sinif_id,
                        principalTable: "Sinifs",
                        principalColumn: "Sinif_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sinavs",
                columns: table => new
                {
                    Sinav_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Not = table.Column<float>(type: "real", nullable: false),
                    SinavType = table.Column<int>(type: "int", nullable: false),
                    Ders_Id = table.Column<int>(type: "int", nullable: false),
                    Hoca_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinavs", x => x.Sinav_Id);
                    table.ForeignKey(
                        name: "FK_Sinavs_Derss_Ders_Id",
                        column: x => x.Ders_Id,
                        principalTable: "Derss",
                        principalColumn: "Ders_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sinavs_Personels_Hoca_Id",
                        column: x => x.Hoca_Id,
                        principalTable: "Personels",
                        principalColumn: "PerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GirisNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ogrenci_id = table.Column<int>(type: "int", nullable: true),
                    personel_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Ogrencis_Ogrenci_id",
                        column: x => x.Ogrenci_id,
                        principalTable: "Ogrencis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Personels_personel_id",
                        column: x => x.personel_id,
                        principalTable: "Personels",
                        principalColumn: "PerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciSinavs",
                columns: table => new
                {
                    Ogrenci_Sinav_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ogrenci_id = table.Column<int>(type: "int", nullable: false),
                    Sinav_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciSinavs", x => x.Ogrenci_Sinav_Id);
                    table.ForeignKey(
                        name: "FK_OgrenciSinavs_Ogrencis_Ogrenci_id",
                        column: x => x.Ogrenci_id,
                        principalTable: "Ogrencis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OgrenciSinavs_Sinavs_Sinav_id",
                        column: x => x.Sinav_id,
                        principalTable: "Sinavs",
                        principalColumn: "Sinav_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ogrencis_Ogrenci_No",
                table: "Ogrencis",
                column: "Ogrenci_No",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ogrencis_Sinif_Id",
                table: "Ogrencis",
                column: "Sinif_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrencis_Veli_Id",
                table: "Ogrencis",
                column: "Veli_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSinavs_Ogrenci_id",
                table: "OgrenciSinavs",
                column: "Ogrenci_id");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciSinavs_Sinav_id",
                table: "OgrenciSinavs",
                column: "Sinav_id");

            migrationBuilder.CreateIndex(
                name: "IX_Personels_DersId",
                table: "Personels",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_Personels_TC",
                table: "Personels",
                column: "TC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Programs_ders_Id",
                table: "Programs",
                column: "ders_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_Per_id",
                table: "Programs",
                column: "Per_id");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_Sinif_id",
                table: "Programs",
                column: "Sinif_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sinavs_Ders_Id",
                table: "Sinavs",
                column: "Ders_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sinavs_Hoca_Id",
                table: "Sinavs",
                column: "Hoca_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Ogrenci_id",
                table: "Users",
                column: "Ogrenci_id",
                unique: true,
                filter: "[Ogrenci_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_personel_id",
                table: "Users",
                column: "personel_id",
                unique: true,
                filter: "[personel_id] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgrenciSinavs");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sinavs");

            migrationBuilder.DropTable(
                name: "Ogrencis");

            migrationBuilder.DropTable(
                name: "Personels");

            migrationBuilder.DropTable(
                name: "Sinifs");

            migrationBuilder.DropTable(
                name: "Velis");

            migrationBuilder.DropTable(
                name: "Derss");
        }
    }
}
