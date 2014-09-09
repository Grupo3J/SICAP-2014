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

namespace CapaInterfaz.ci_GestionSeguridad
{
    public partial class frmPersonalselect : DevComponents.DotNetBar.Metro.MetroForm
    {
        PersonalLN PLN= new PersonalLN();
        public string OPTION = "";

        public frmPersonalselect()
        {
            InitializeComponent();
        }

        private void txtBuscarUser_TextChanged(object sender, EventArgs e)
        {
            Mostrarusers();
        }

        private void frmPersonalselect_Load(object sender, EventArgs e)
        {
            Mostrarusers();
        }

        private void Mostrarusers()
        {
            DtgPersonal.DataSource = PLN.ListarPersonal(txtBuscarUser.Text);
        }

        private void dtgdoubleclick(object sender, EventArgs e)
        {           
            OPTION = "OK";
            this.Close();

        }
    }
}
