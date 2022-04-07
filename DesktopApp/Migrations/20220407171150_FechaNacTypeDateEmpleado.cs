using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesktopApp.Migrations
{
    public partial class FechaNacTypeDateEmpleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdEmpleado",
                table: "Empleados",
                newName: "EmpleadoId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaIngreso",
                table: "Empleados",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmpleadoId",
                table: "Empleados",
                newName: "IdEmpleado");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaIngreso",
                table: "Empleados",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
