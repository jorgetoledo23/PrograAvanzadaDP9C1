using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio2
{
    public class Reponedor : Persona
    {
        public int numCredencial { get; set; }


        public override string ToString()
        {
            return $"{base.ToString()}, Credencial N°: {numCredencial}";
        }
    }
}
