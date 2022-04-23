using Microsoft.EntityFrameworkCore.Migrations;

namespace DesktopApp.Migrations
{
    public partial class EmpleadosActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Empleados",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Empleados");
        }
    }
}
