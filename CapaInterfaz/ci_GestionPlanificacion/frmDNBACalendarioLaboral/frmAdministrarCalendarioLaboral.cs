using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CapaLogicaNegocio.cln_GestionPlanificacion;
using CapaInterfaz.ci_GestionPlanificacion.frmDNBACalendarioLaboral;

namespace CapaInterfaz.ci_GestionPlanificacion.frmDNBAdministrarCalendarioLab
{
    public partial class frmAdministrarCalendarioLaboral : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmAdministrarCalendarioLaboral()
        {
            InitializeComponent();
        }

        CalendarioLN CLN = new CalendarioLN();

        private void frmAdministrarCalendarioLaboral_Load(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = CLN.ListarCalendario();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = CLN.ListarCalendario();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("¿Está seguro que desea eliminar el Calendario Laboral?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                string idCalendario = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();

                CLN.EliminarCalendario(idCalendario);
                dataGridViewX1.DataSource = CLN.ListarCalendario();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmNuevoCalendarioLaboral FRMNCL = new frmNuevoCalendarioLaboral();
            FRMNCL.Show();
        }
    }
}