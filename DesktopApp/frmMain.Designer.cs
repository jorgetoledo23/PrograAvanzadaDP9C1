
namespace DesktopApp
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEmpleadoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarInformacionDeEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archivarEmpleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarBuscarEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.empleadosToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 28);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // empleadosToolStripMenuItem
            // 
            this.empleadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEmpleadoMenuItem,
            this.editarInformacionDeEmpleadoToolStripMenuItem,
            this.archivarEmpleadoToolStripMenuItem,
            this.listarBuscarEmpleadosToolStripMenuItem});
            this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.empleadosToolStripMenuItem.Text = "Empleados";
            // 
            // addEmpleadoMenuItem
            // 
            this.addEmpleadoMenuItem.Name = "addEmpleadoMenuItem";
            this.addEmpleadoMenuItem.Size = new System.Drawing.Size(308, 26);
            this.addEmpleadoMenuItem.Text = "Agregar Nuevo Empleado";
            // 
            // editarInformacionDeEmpleadoToolStripMenuItem
            // 
            this.editarInformacionDeEmpleadoToolStripMenuItem.Name = "editarInformacionDeEmpleadoToolStripMenuItem";
            this.editarInformacionDeEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
            this.editarInformacionDeEmpleadoToolStripMenuItem.Text = "Editar Informacion de Empleado";
            // 
            // archivarEmpleadoToolStripMenuItem
            // 
            this.archivarEmpleadoToolStripMenuItem.Name = "archivarEmpleadoToolStripMenuItem";
            this.archivarEmpleadoToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
            this.archivarEmpleadoToolStripMenuItem.Text = "Archivar Empleado";
            // 
            // listarBuscarEmpleadosToolStripMenuItem
            // 
            this.listarBuscarEmpleadosToolStripMenuItem.Name = "listarBuscarEmpleadosToolStripMenuItem";
            this.listarBuscarEmpleadosToolStripMenuItem.Size = new System.Drawing.Size(308, 26);
            this.listarBuscarEmpleadosToolStripMenuItem.Text = "Listar/Buscar Empleados";
            this.listarBuscarEmpleadosToolStripMenuItem.Click += new System.EventHandler(this.listarBuscarEmpleadosToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empleados APP";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEmpleadoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarInformacionDeEmpleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archivarEmpleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarBuscarEmpleadosToolStripMenuItem;
    }
}
