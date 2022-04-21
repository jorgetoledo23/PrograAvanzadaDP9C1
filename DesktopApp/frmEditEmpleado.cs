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
    public partial class frmEditEmpleado : Form
    {
        private readonly int EmpleadoId;
        private Empleado? Emp;
        private TipoEmpleado tipoEmpleado;
        public frmEditEmpleado(int Id)
        {
            InitializeComponent();
            EmpleadoId = Id;
            LlenarCampos();
        }

        private void LlenarCampos()
        { 
            using (var context = new AppDbContext())
            {
                Emp = context.Empleados
                    .Where(emp => emp.EmpleadoId == EmpleadoId).FirstOrDefault();
            }
            txtRut.Text = Emp.Rut;
            txtNombres.Text = Emp.Name;
            txtApellidos.Text = Emp.Apellidos;
            txtCodigo.Text = Emp.CodigoEmpleado;
            txtCorreo.Text = Emp.Correo;
            txtTelefono.Text = Emp.Telefono;
            switch (Emp.TipoEmpleado)
            {
                case TipoEmpleado.Vendedor:
                    rbVendedor.Checked = true;
                    tipoEmpleado = TipoEmpleado.Vendedor;
                    break;
                case TipoEmpleado.Contratista:
                    rbContratista.Checked = true;
                    tipoEmpleado = TipoEmpleado.Contratista;
                    break;
                case TipoEmpleado.Reponedor:
                    rbReponedor.Checked = true;
                    tipoEmpleado = TipoEmpleado.Reponedor;
                    break;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Emp.Rut = txtRut.Text;
            Emp.Name = txtNombres.Text;
            Emp.Apellidos = txtApellidos.Text;
            Emp.CodigoEmpleado = txtCodigo.Text;
            Emp.FechaIngreso = dtFechaIngreso.Value;
            Emp.Telefono = txtTelefono.Text;
            Emp.TipoEmpleado = tipoEmpleado;
            Emp.Correo = txtCorreo.Text;

            using (var context = new AppDbContext())
            {
                context.Update(Emp);
                context.SaveChanges();
            }

            MessageBox.Show("Empleado Editado!");

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
    }
}
