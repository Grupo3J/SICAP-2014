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

namespace CapaInterfaz.ci_GestionPlanificacion.frmDiasAdicionales
{
    public partial class frmAdministracionDiasAdicionales : Form
    {
        public frmAdministracionDiasAdicionales()
        {
            InitializeComponent();
        }

        DiasAdicionalesLN DALN = new DiasAdicionalesLN();

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmRegistrarDiasAdicionales frmda = new frmRegistrarDiasAdicionales();
            frmda.Show();
            
        }

        private void frmAdministracionDiasAdicionales_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DALN.ListarDiasAdicionales();
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

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DALN.ListarDiasAdicionales();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("¿Está seguro que desea eliminar el Día Adicional?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                string iddia = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                DALN.EliminarDiaAdicional(iddia);
                dataGridView1.DataSource = DALN.ListarDiasAdicionales();
            }         
           
        }
    }
}
