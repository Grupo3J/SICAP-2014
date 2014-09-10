using CapaLogicaNegocio;
using CapaLogicaNegocio.cln_GestionSeguridad;
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
    public partial class frmLog_In : DevComponents.DotNetBar.Metro.MetroForm
    {
     
       
        public frmLog_In()
        {
            InitializeComponent();
            txtLogin.Focus();
        }

        private void frmLog_In_Load(object sender, EventArgs e)
        {
            
        }

        private void Acceder_Click(object sender, EventArgs e)
        {
               verificaeingresa();
        }
       
        private void verificaeingresa()
        {
            Sistema sit = new Sistema();
            UsuariosLN USLN = new UsuariosLN();

            if (sit.Login(txtLogin.Text, txtClave.Text))
            {
                frmSICAP2014 fp = new frmSICAP2014();
                fp.user = USLN.getUserbyced(sit.Cedula);
                DialogResult resul = new DialogResult();
                this.Hide();
                txtLogin.Text = "";
                txtClave.Text = "";
                resul = fp.ShowDialog();

                if (fp.OPTION == "OK")
                {
                    this.Show();
                    txtLogin.Focus();

                }


                //frmSICAP2014 k = new frmSICAP2014();

                // k.user = USLN.getUserbyced(sit.Cedula);
                //k.Show();

            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(this,"Nombre de Usuario o Clave incorrectas vuelve a intentarlo","Acceso Denegado",MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private void txtcontrasekeydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                verificaeingresa();

            }
        }
    }
}
