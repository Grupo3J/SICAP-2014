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
using CapaInterfaz.ci_GestionPlanificacion.frmDiasAdicionales;


namespace CapaInterfaz.ci_GestionPlanificacion.frmCalendarioLaboral
{
    public partial class frmAdministracionCalendarioLaboral : Form
    {
       // string valor = "";
      
        public frmAdministracionCalendarioLaboral()
        {
          
            InitializeComponent();
        }

        CalendarioLN CLN = new CalendarioLN();
        DiasAdicionalesLN DALN = new DiasAdicionalesLN();

        private void frmAdministracionCalendarioLaboral_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CLN.ListarCalendario();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try {
                frmRegistrarCalendario frmrc = new frmRegistrarCalendario();
                frmrc.Show();
            }catch(Exception error){
                MessageBox.Show("Error: " + error.GetBaseException());
            }


            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string idCalendario = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string nombre = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string descripcion = dataGridView1.CurrentRow.Cells[1].Value.ToString();
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
            dialog = MessageBox.Show("¿Está seguro que desea eliminar el Calendario Laboral?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                string idCalendario = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                CLN.EliminarCalendario(idCalendario);
                dataGridView1.DataSource = CLN.ListarCalendario();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            dataGridView1.DataSource = CLN.ListarCalendario();
        }
        frmRegistrarDiasAdicionales frmda = new frmRegistrarDiasAdicionales();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string idcal = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //frmda.idCalendariol(idcal);
            //this.Close();

            //if (valor.Equals("frmRegistrar"))
            //{
            //    frmRegistrarDiasAdicionales frmrda = new frmRegistrarDiasAdicionales(idcal);
            //    frmrda.Show();
            //}
            //else
            //{
            //    frmModificarDiasAdicionales frmrda = new frmModificarDiasAdicionales(idcal);
            //    frmrda.Show();
            //}
            
        }

        //metodo para coger el id de calendario
        public string co;
        public string op;
        private void Data_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (op == "True")
            {
                co = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                op = "OK";
                this.Close();
            }
        }

    }
}
