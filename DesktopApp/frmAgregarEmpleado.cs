using DesktopApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class frmAgregarEmpleado : Form
    {
        TipoEmpleado tipoEmpleado = TipoEmpleado.Vendedor;
        public frmAgregarEmpleado()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var context = new AppDbContext())
            {
                Empleado E = new Empleado()
                {
                    Rut = txtRut.Text,
                    Name = txtNombres.Text,
                    Apellidos = txtApellidos.Text,
                    Telefono = txtTelefono.Text,
                    Correo = txtCorreo.Text,
                    CodigoEmpleado = txtCodigo.Text,
                    TipoEmpleado = tipoEmpleado
                };
                context.Add(E);
                context.SaveChanges();
            }

        }

        private void rbVendedor_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            if (rb.Checked)
            {
                switch (rb.Name)
                {
                    case "rbVendedor":
                        tipoEmpleado = TipoEmpleado.Vendedor;
                        break;
                    case "rbContratista":
                        tipoEmpleado = TipoEmpleado.Contratista;
                        break;
                    case "rbReponedor":
                        tipoEmpleado = TipoEmpleado.Reponedor;
                        break;
                }
            }
            
            //MessageBox.Show(tipoEmpleado.ToString());   

        }

        private void rbVendedor_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
