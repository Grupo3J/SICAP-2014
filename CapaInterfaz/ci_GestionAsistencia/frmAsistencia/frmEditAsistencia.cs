using CapaLogicaNegocio.cln_GestionPersonal;
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
    public partial class frmEditAsistencia : Form
    {
        public frmEditAsistencia()
        {
            InitializeComponent();

        }
        static string idPersonal;

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor Escoja un Tipo de Personal..");
            }
            else 
            {
                frmEscogerPersonal frmPersonal = new frmEscogerPersonal(cmbTipo.SelectedItem.ToString());
                frmPersonal.ShowDialog();
            }
            
        }
    }
}
