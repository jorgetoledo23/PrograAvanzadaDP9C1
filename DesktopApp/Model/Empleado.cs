using System;
using System.ComponentModel.DataAnnotations;

namespace DesktopApp.Model
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }

        [Required]
        [StringLength(12)]
        public string Rut { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Apellidos { get; set; }
        
        [Required]
        public string TipoEmpleado { get; set; }

        [Required]
        public string CodigoEmpleado { get; set; }

        public string Telefono { get; set; }
        public string Correo { get; set; }

        public DateTime FechaIngreso { get; set; }

    }
}
