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
    public partial class frmListarEmpleados : Form
    {
        private int EmpleadoId;
        public frmListarEmpleados()
        {
            InitializeComponent();

            LimpiarLista();

            using (var context = new AppDbContext())
            {
                //SELECT * FROM tabla
                var empleados = context.Empleados.ToList();
                LlenarLista(empleados);
            }
        }


        private void LimpiarLista() => listviewEmpleados.Items.Clear();

        private void LlenarLista(List<Empleado> lista)
        {
            foreach (var E in lista)
            {
                ListViewItem lvitem = new ListViewItem();
                lvitem.Text = E.EmpleadoId.ToString();
                lvitem.SubItems.Add(E.Rut);
                lvitem.SubItems.Add(E.Name);
                lvitem.SubItems.Add(E.Apellidos);
                lvitem.SubItems.Add(E.Correo);
                lvitem.SubItems.Add(E.Telefono);
                lvitem.SubItems.Add(E.TipoEmpleado.ToString());
                lvitem.SubItems.Add(E.FechaIngreso.ToString("d"));
                lvitem.SubItems.Add(E.CodigoEmpleado.ToString());
                listviewEmpleados.Items.Add(lvitem);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (var context = new AppDbContext())
            {
                var filtro = txtFiltro.Text;

                var empleados = context.Empleados.Where(e => e.Rut == filtro).ToList();

                if (empleados.Count == 0)
                {
                    MessageBox.Show("NO hay resultados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LlenarLista(context.Empleados.ToList());
                }
                else
                {
                    LimpiarLista();
                    LlenarLista(empleados);
                }
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            using (var context = new AppDbContext())
            {
                var filtro = txtFiltro.Text;

                var empleados = context.Empleados.
                    Where(e => e.Rut.Contains(filtro)
                    || e.Name.Contains(filtro)
                    || e.Apellidos.Contains(filtro)
                    || e.Correo.Contains(filtro)
                    || e.Telefono.Contains(filtro)
                    || e.CodigoEmpleado.Contains(filtro))
                    .ToList();

                    LimpiarLista();
                    LlenarLista(empleados);
                
            }
        }

        private void listviewEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            ListViewItem listViewItem = null;
            if (listviewEmpleados.SelectedItems.Count > 0)
            {
                listViewItem = listviewEmpleados.SelectedItems[0];

                EmpleadoId = Convert.ToInt32(listViewItem.Text);
                //MessageBox.Show(EmpleadoId);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEditEmpleado frmEdit = new frmEditEmpleado(EmpleadoId);
            frmEdit.ShowDialog();
            LimpiarLista();
            using (var context = new AppDbContext())
            {
                //SELECT * FROM tabla
                var empleados = context.Empleados.ToList();
                LlenarLista(empleados);
            }
        }
    }
}
