using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CapaLogicaNegocio.cln_GestionPlanificacion;
using CapaEntidades.GestionSeguridad;

namespace CapaInterfaz.ci_GestionPlanificacion.frmDNBDiasNoLaborables
{
    public partial class frmAdministrarDiasNoLaborables : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmAdministrarDiasNoLaborables()
        {
            InitializeComponent();
        }

        DiaNoLAborableLN DNLLN = new DiaNoLAborableLN();
        public void setUser(Usuarios s, Permisos per)
        {
            user = s;
            permiso = per;
        }
        private void frmDiasNoLaborables_Load(object sender, EventArgs e)
        {
            if (!permiso.Escritura) { toolStrip1.Items.Remove(toolnuevo); }
            if (!permiso.Eliminacion) { toolStrip1.Items.Remove(tooleliminar); }
            if (!permiso.Modificacion) { toolStrip1.Items.Remove(toolmodificar); }
            dataGridViewX1.DataSource = DNLLN.ListarDiasNoLaborables();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = DNLLN.ListarDiasNoLaborables();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("¿Está seguro que desea eliminar el Día No Laborable?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                string iddian = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();

                DNLLN.EliminarDiaNoLaborable(iddian);
                dataGridViewX1.DataSource = DNLLN.ListarDiasNoLaborables();
            }  
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmNuevoDiaNoLaborable FRMDNL = new frmNuevoDiaNoLaborable();
            FRMDNL.Show();
        }

        public Usuarios user { get; set; }

        public Permisos permiso { get; set; }
    }
}