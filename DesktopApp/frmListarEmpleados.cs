using DesktopApp.Model;
using Microsoft.EntityFrameworkCore;
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

            Task.Run(async () =>
            {

                await LlenarListaAsync();

            });
        }

        private async Task<bool> LlenarListaAsync()
        {
            using (var context = new AppDbContext())
            {
                var empleados = context.Empleados.Include(x => x.Departamento).ToList();
                foreach (var E in empleados)
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
                    lvitem.SubItems.Add(E.Departamento.Descripcion.ToString());
                    listviewEmpleados.Items.Add(lvitem);
                }
            }
            return true;
            
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
                lvitem.SubItems.Add(E.DepartamentoId.ToString());
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
            btnEliminar.Enabled = true;

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
                //var allempleados = context.Empleados.IgnoreQueryFilters().ToList();
                LlenarLista(empleados);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Estas seguro de Eliminar el Empleado?","Info",MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //Eliminar Empleado
                using (var context = new AppDbContext())
                {
                    var emp = context.Empleados.Where(emp => emp.EmpleadoId == EmpleadoId).First();
                    //context.Remove(emp); Eliminar
                    emp.Activo = false;
                    context.Update(emp);
                    context.SaveChanges();
                    listviewEmpleados.Items.Clear();
                    LlenarLista(context.Empleados.ToList());
                }
            }
        }

        private void frmListarEmpleados_Load(object sender, EventArgs e)
        {
            
        }
    }
}
