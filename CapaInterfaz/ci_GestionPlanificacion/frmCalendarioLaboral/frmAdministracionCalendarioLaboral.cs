using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocio.cln_GestionPlanificacion;


namespace CapaInterfaz.ci_GestionPlanificacion.frmCalendarioLaboral
{
    public partial class frmAdministracionCalendarioLaboral : Form
    {
        public frmAdministracionCalendarioLaboral()
        {
            InitializeComponent();
        }

        CalendarioLN CLN = new CalendarioLN();
        
        private void frmAdministracionCalendarioLaboral_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CLN.ListarCalendario();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmRegistrarCalendario frmrc = new frmRegistrarCalendario();
            frmrc.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string idCalendario = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string descripcion = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            DateTime fechInicio = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;
            DateTime fechFin = (DateTime)dataGridView1.CurrentRow.Cells[4].Value;
           
            frmModificarCalendario frmmc = new frmModificarCalendario(idCalendario, nombre, descripcion, fechInicio, fechFin);
            frmmc.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CLN.ListarCalendario();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("¿Está seguro que desea eliminar el calendario?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                string idCalendario = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                CLN.EliminarCalendario(idCalendario);
                dataGridView1.DataSource = CLN.ListarCalendario();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
