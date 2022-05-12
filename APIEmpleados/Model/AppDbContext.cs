using Microsoft.EntityFrameworkCore;

namespace APIEmpleados.Model
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connection = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connection);
        }

        //API FLUENT
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Empleado>().HasKey(prop => prop.Rut);
            modelBuilder.Entity<Empleado>().Property(prop => prop.FechaIngreso)
                .HasColumnType("date");

            modelBuilder.Entity<Empleado>().Property(prop => prop.Activo)
                .HasDefaultValue(true);

            //Filtro a nivel del Modelo
            modelBuilder.Entity<Empleado>()
                .HasQueryFilter(prop => prop.Activo == true);

        }


        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
