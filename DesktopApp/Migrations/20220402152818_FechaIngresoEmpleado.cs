using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesktopApp.Migrations
{
    public partial class FechaIngresoEmpleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIngreso",
                table: "Empleados",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaIngreso",
                table: "Empleados");
        }
    }
}
