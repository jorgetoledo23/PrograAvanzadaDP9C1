using System;
using System.Collections.Generic;
using System.Text;

namespace Empleados
{

    /* Contratista es clase HIJA (derivada) de Persona */
    public class Contratista : Persona
    {
        public string numContrato { get; set; }

        /* Creamos nuestra propia implementacion para el Metodo ToString() */
        public override string ToString()
        {
            /* base hace referencia a la clase Base (osea Persona) */
            return $"{base.ToString()}, Contrato N°: {numContrato}";
        }

        public override void marcarEntrada()
        {
            base.marcarEntrada();
            // Firma su Libro de Asistencia
        }

        public override void marcarSalida()
        {
            //Marcar Salida
        }
    }
}
