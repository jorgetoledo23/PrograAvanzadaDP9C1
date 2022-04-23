using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Model
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string CompanyNo { get; set; }
        public string Descripcion { get; set; }
        public List<Empleado> Empleados { get; set; }
    }
}
