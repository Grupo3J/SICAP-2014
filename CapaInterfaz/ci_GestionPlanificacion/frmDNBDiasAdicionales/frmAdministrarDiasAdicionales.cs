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

namespace CapaInterfaz.ci_GestionPlanificacion.frmDNBDiasAdicionales
{
    public partial class frmAdministrarDiasAdicionales : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmAdministrarDiasAdicionales()
        {
            InitializeComponent();
        }
        DiasAdicionalesLN DALN = new DiasAdicionalesLN();
        public void setUser(Usuarios s, Permisos per)
        {
            user = s;
            permiso = per;
        }
        private void frmAdministrarDiasAdicionales_Load(object sender, EventArgs e)
        {
            if (!permiso.Escritura) { toolStrip1.Items.Remove(toolnuevo); }
            //if (!permiso.Eliminacion) { toolStrip1.Items.Remove(tooleliminar); }
            if (!permiso.Modificacion) { toolStrip1.Items.Remove(toolmodificar); }
            dataGridViewX1.DataSource = DALN.ListarDiasAdicionales();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmNuevoDiaAdicional FRMNDA = new frmNuevoDiaAdicional();
            FRMNDA.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = DALN.ListarDiasAdicionales();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("¿Está seguro que desea eliminar el Día Adicional?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                string iddia = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();

                DALN.EliminarDiaAdicional(iddia);
                dataGridViewX1.DataSource = DALN.ListarDiasAdicionales();
            }       
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //string iddia = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //string idCalendario = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //DateTime fecha = (DateTime)dataGridView1.CurrentRow.Cells[2].Value;
            //string descripcion = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            //frmModificarDiasAdicionales frmda = new frmModificarDiasAdicionales(idCalendario, iddia, fecha, descripcion);
            //frmda.Show();
        }

        public Usuarios user { get; set; }

        public Permisos permiso { get; set; }
    }
}