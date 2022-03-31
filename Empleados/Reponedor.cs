using System;
using System.Collections.Generic;
using System.Text;

namespace Empleados
{
    public class Reponedor : Persona
    {
        public string numCredencial { get; set; }

        public override void marcarSalida()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Credencial N°: {numCredencial}";
        }
    }
}
