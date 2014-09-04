using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DevComponents.DotNetBar;
using System.Windows.Forms;
using CapaLogicaNegocio.cln_GestionPersonal;

namespace CapaInterfaz.ci_GestionPersonal.frmPersonal
{
    public partial class FrmAdministracionPersonal : Form
    {
        public FrmAdministracionPersonal()
        {
            InitializeComponent();
        }
        PersonalLN PLN = new PersonalLN();
        private void FrmAdministracionPersonal_Load(object sender, EventArgs e)
        {
           // dataGridViewX1.DataSource = PLN.ListarPersonal("");

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            FrmInsertarPersonal frmip = new FrmInsertarPersonal();
            frmip.Show();
        }

        private void panelDockContainer1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
