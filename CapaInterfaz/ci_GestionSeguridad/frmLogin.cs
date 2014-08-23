using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaInterfaz.ci_GestionPersonal;
using CapaInterfaz.ci_GestionSeguridad;
using CapaInterfaz.ci_GestionPersonal.frmPersonal;
namespace CapaInterfaz.ci_GestionSeguridad
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
        frmVentanaPrimaria frmvp = new frmVentanaPrimaria();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmvp.Show();
            
        }
    }
}
