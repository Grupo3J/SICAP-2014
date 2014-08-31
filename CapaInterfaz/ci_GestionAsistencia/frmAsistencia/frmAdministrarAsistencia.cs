using CapaLogicaNegocio.cln_GestionAsistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaInterfaz.ci_GestionAsistencia.frmAsistencia
{
    public partial class frmAdministrarAsistencia : Form
    {
        public frmAdministrarAsistencia()
        {
            InitializeComponent();
        }

        AsistenciaLN asistencia = new AsistenciaLN();

        private void frmAdministrarAsistencia_Load(object sender, EventArgs e)
        {
            toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripcmbTipo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            label2.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
            dataGridView1.DataSource = asistencia.ListarAsistenciaPersonal("123ab",DateTime.Parse("2012-11-12"));
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            
        }


        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString(); 
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }   
    }
}
