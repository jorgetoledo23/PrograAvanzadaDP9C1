using System;
using System.ComponentModel.DataAnnotations;

namespace APIEmpleados.Model
{
    public class Empleado
    {
        //[Key]
        public int EmpleadoId { get; set; }

        [Required]
        [StringLength(12)]
        public string Rut { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Apellidos { get; set; }
        
        [Required]
        public string CodigoEmpleado { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public DateTime FechaIngreso { get; set; }

        public TipoEmpleado TipoEmpleado { get; set; }

        public bool Activo { get; set; }

        public int DepartamentoId { get; set; }
        
        //Prop de Navegacion
        public Departamento Departamento { get; set; }

    }
}
