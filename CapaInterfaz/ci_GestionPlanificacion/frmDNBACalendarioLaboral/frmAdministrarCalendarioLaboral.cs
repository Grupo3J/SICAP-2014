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
using CapaEntidades.GestionSeguridad;

namespace CapaInterfaz.ci_GestionPlanificacion.frmDNBAdministrarCalendarioLab
{
    public partial class frmAdministrarCalendarioLaboral : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmAdministrarCalendarioLaboral()
        {
            InitializeComponent();
        }
        public void setUser(Usuarios s, Permisos per)
        {
            user = s;
            permiso = per;
        }
        CalendarioLN CLN = new CalendarioLN();

        private void frmAdministrarCalendarioLaboral_Load(object sender, EventArgs e)
        {
            if (!permiso.Escritura) { toolStrip1.Items.Remove(toolnuevo); }
            if (!permiso.Eliminacion) { toolStrip1.Items.Remove(tooleliminar); }
            if (!permiso.Modificacion) { toolStrip1.Items.Remove(toolmodificar); }
            
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
            string idCalendario = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();

            try
            {
                if (CLN.ExisteCalendarioEnDetalleCalendario(idCalendario))
                {
                    MessageBoxEx.Show("No se puede eliminar calendario laboral porque ya hay personas asignadas a éste");
                }
                else {
                    dialog = MessageBox.Show("¿Está seguro que desea eliminar el Calendario Laboral?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialog == DialogResult.Yes)
                    {

                        CLN.EliminarCalendario(idCalendario);
                        dataGridViewX1.DataSource = CLN.ListarCalendario();
                    }
                }
            }
            catch (Exception er) {
                MessageBoxEx.Show(er.Message);
            }

            
            
            
            
            
            
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmNuevoCalendarioLaboral FRMNCL = new frmNuevoCalendarioLaboral();
            FRMNCL.Show();
        }

        public Usuarios user { get; set; }

        public Permisos permiso { get; set; }
    }
}