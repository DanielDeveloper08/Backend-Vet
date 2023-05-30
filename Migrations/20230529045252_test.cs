using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BACK_CRUD_Mascota.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Breek",
                table: "Pets",
                newName: "Breed");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Breed",
                table: "Pets",
                newName: "Breek");
        }
    }
}
