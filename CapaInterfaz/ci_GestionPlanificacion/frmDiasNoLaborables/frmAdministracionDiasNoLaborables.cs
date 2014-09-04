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

namespace CapaInterfaz.ci_GestionPlanificacion.frmDiasNoLaborables
{
    public partial class frmAdministracionDiasNoLaborables : Form
    {
        public frmAdministracionDiasNoLaborables()
        {
            InitializeComponent();
        }
        DiaNoLAborableLN DNLN = new DiaNoLAborableLN();
        private void frmAdministracionDiasNoLaborables_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DNLN.ListarDiasNoLaborables();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DNLN.ListarDiasNoLaborables();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmRegistrarDiasNoLaborables frmrdnl = new frmRegistrarDiasNoLaborables();
            frmrdnl.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("¿Está seguro que desea eliminar el Día No Laborable?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                string iddian = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                DNLN.EliminarDiaNoLaborable(iddian);
                dataGridView1.DataSource = DNLN.ListarDiasNoLaborables();
            }  
        }
    }
}
