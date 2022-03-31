using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados
{
    public class Vendedor : Persona
    {
        public string Codigo { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, Codigo N°: {Codigo}";
        }
        public override void marcarSalida()
        {
            throw new NotImplementedException();
        }
    }
}
