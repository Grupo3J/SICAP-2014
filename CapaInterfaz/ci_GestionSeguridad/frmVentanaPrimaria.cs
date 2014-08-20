using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaInterfaz.ci_GestionPersonal.frmPersonal;


namespace CapaInterfaz.ci_GestionPersonal
{
    public partial class frmVentanaPrimaria : Form
    {
        public frmVentanaPrimaria()
        {
            InitializeComponent();
        }

        private void proveedoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        frmAdministrarPersonal frmap = new frmAdministrarPersonal();
        private void registrarPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmap.Visible == true)
            {
                return;
            }
           // frmap.MdiParent = this;
            frmap.Show();
        }

        private void registrarPersonalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //if (frmap.Visible == true)
            //{
            //    return;
            //}
            //frmap.Parent = panel1;
            //frmap.Show();
        }

        private void frmVentanaPrimaria_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void administrarPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmap.Visible == true)
            {
                return;
            }
            frmap.MdiParent = this;
            frmap.Show();
        }
    }
}
