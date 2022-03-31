using System;
using System.Collections.Generic;
using System.Text;

namespace Empleados
{
    /* ABSTRACT quiere decir que no se podran tener INSTANCIAS de la Clase Persona 
     * Solo podre crear instancias de clase Hijas (derivadas) de la Clase Persona */
    public abstract class Persona
    {
        private string? _nombre;
        private string? _apellido;
        private string? _rut;
        private string? _correo;
        private string? _telefono;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Rut { get => _rut; set => _rut = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }


        public override string ToString()
        {
            return $"Nombre: {_nombre}, Apellido: {_apellido}";
        }

        /* Metodos Virtual pueden ser sobreesritos por las clases hijas (derivadas) pero
         * es OPCIONAL si lo sobreescribo o no */
        public virtual void marcarEntrada()
        {
            //Registra Llegada en Tarjeta
        }

        /* Metodos Abstract solo pueden aparecer en clases Abstract
         * Y significa que cada clase Hija(derivada) debe tener OBLIGATORIAMENTE
         * su propia implementacion del METODO */
        public abstract void marcarSalida();

    }
}
