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
                    TipoEmpleado = tipoEmpleado,
                    FechaIngreso = dtFechaIngreso.Value
                };
                //INSERT ENTITY FRAMEWORK
                context.Add(E);
                context.SaveChanges();
            }
            if(MessageBox.Show("Empleado Agregado Exitosamente!, ¿Quires seguir agregando Empleados?",
                "Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes) LimpiarCajas();
            else this.Close();
            
            
        }

        private void LimpiarCajas()
        {
            txtRut.Text = String.Empty;
            txtNombres.Text = String.Empty;
            txtApellidos.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtCorreo.Text = String.Empty;
            txtCodigo.Text = String.Empty;
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
