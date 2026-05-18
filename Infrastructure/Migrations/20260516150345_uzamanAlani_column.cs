using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class uzamanAlani_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ders_Personels_Hoca_No",
                table: "Ders");

            migrationBuilder.DropForeignKey(
                name: "FK_Program_Ders_ders_Id",
                table: "Program");

            migrationBuilder.DropForeignKey(
                name: "FK_Sinavlar_Ders_Ders_Id",
                table: "Sinavlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ders",
                table: "Ders");

            migrationBuilder.RenameTable(
                name: "Ders",
                newName: "Dersler");

            migrationBuilder.RenameIndex(
                name: "IX_Ders_Hoca_No",
                table: "Dersler",
                newName: "IX_Dersler_Hoca_No");

            migrationBuilder.AddColumn<string>(
                name: "UzmanAlani",
                table: "Personels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dersler",
                table: "Dersler",
                column: "Ders_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dersler_Personels_Hoca_No",
                table: "Dersler",
                column: "Hoca_No",
                principalTable: "Personels",
                principalColumn: "PerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Program_Dersler_ders_Id",
                table: "Program",
                column: "ders_Id",
                principalTable: "Dersler",
                principalColumn: "Ders_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sinavlar_Dersler_Ders_Id",
                table: "Sinavlar",
                column: "Ders_Id",
                principalTable: "Dersler",
                principalColumn: "Ders_Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dersler_Personels_Hoca_No",
                table: "Dersler");

            migrationBuilder.DropForeignKey(
                name: "FK_Program_Dersler_ders_Id",
                table: "Program");

            migrationBuilder.DropForeignKey(
                name: "FK_Sinavlar_Dersler_Ders_Id",
                table: "Sinavlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dersler",
                table: "Dersler");

            migrationBuilder.DropColumn(
                name: "UzmanAlani",
                table: "Personels");

            migrationBuilder.RenameTable(
                name: "Dersler",
                newName: "Ders");

            migrationBuilder.RenameIndex(
                name: "IX_Dersler_Hoca_No",
                table: "Ders",
                newName: "IX_Ders_Hoca_No");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ders",
                table: "Ders",
                column: "Ders_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ders_Personels_Hoca_No",
                table: "Ders",
                column: "Hoca_No",
                principalTable: "Personels",
                principalColumn: "PerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Program_Ders_ders_Id",
                table: "Program",
                column: "ders_Id",
                principalTable: "Ders",
                principalColumn: "Ders_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sinavlar_Ders_Ders_Id",
                table: "Sinavlar",
                column: "Ders_Id",
                principalTable: "Ders",
                principalColumn: "Ders_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
