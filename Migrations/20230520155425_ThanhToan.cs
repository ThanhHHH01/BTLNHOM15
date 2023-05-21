using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTLNHOM15.Migrations
{
    /// <inheritdoc />
    public partial class ThanhToan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TinhTrang_ThietBi_MaTB",
                table: "TinhTrang");

            migrationBuilder.DropIndex(
                name: "IX_TinhTrang_MaTB",
                table: "TinhTrang");

            migrationBuilder.RenameColumn(
                name: "MaTB",
                table: "TinhTrang",
                newName: "TenND");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenND",
                table: "TinhTrang",
                newName: "MaTB");

            migrationBuilder.CreateIndex(
                name: "IX_TinhTrang_MaTB",
                table: "TinhTrang",
                column: "MaTB");

            migrationBuilder.AddForeignKey(
                name: "FK_TinhTrang_ThietBi_MaTB",
                table: "TinhTrang",
                column: "MaTB",
                principalTable: "ThietBi",
                principalColumn: "MaTB");
        }
    }
}
