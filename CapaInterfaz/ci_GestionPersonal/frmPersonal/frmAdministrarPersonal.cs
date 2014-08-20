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
namespace CapaInterfaz.ci_GestionPersonal.frmPersonal
{
    public partial class frmAdministrarPersonal : Form
    {
        public frmAdministrarPersonal()
        {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistrarPersonal frmrp = new frmRegistrarPersonal();
            frmrp.Show();
        }
    }
}
