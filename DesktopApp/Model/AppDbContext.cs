using Microsoft.EntityFrameworkCore;

namespace DesktopApp.Model
{
    public class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DesktopAppEmpleados;");
        }

        public DbSet<Empleado> Empleados { get; set; }

    }
}
