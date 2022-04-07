using Microsoft.EntityFrameworkCore;

namespace DesktopApp.Model
{
    public class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DesktopAppEmpleados;");
        }

        //API FLUENT
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Empleado>().HasKey(prop => prop.Rut);
            modelBuilder.Entity<Empleado>().Property(prop => prop.FechaIngreso)
                .HasColumnType("date");

        }


        public DbSet<Empleado> Empleados { get; set; }

    }
}
