using Microsoft.EntityFrameworkCore.Migrations;

namespace SWProvincias_Ramos.Migrations
{
    public partial class nombre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Provincia",
                newName: "Nombre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Provincia",
                newName: "Name");
        }
    }
}
