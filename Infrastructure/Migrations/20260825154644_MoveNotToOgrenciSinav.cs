using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoveNotToOgrenciSinav : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Not",
                table: "Sinavs");

            migrationBuilder.AddColumn<float>(
                name: "Not",
                table: "OgrenciSinavs",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Not",
                table: "OgrenciSinavs");

            migrationBuilder.AddColumn<float>(
                name: "Not",
                table: "Sinavs",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
