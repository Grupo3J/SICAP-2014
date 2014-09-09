using CapaEntidades.GestionSeguridad;
using CapaLogicaNegocio;
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
    public partial class frmEditRol : DevComponents.DotNetBar.Metro.MetroForm
    {
        RolesLN RLN = new RolesLN();
        public string OPTION = "";
        public bool MODIFICAR = false;
        Validaciones val = new Validaciones();
        public frmEditRol()
        {
            InitializeComponent();
        }

        private void frmEditRol_Load(object sender, EventArgs e)
        {
            txtIdRol.Enabled = false;
            if (!MODIFICAR)
            {
                txtIdRol.Text = RLN.getNextIdRol();
            }
            
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            

          
        }
        public Roles getRol()
        {
            Roles tem = new Roles();
            tem.IdRol = txtIdRol.Text;
            tem.Nombre = txtNombres.Text;
            tem.Descripcion = txtDescripcion.Text;
            tem.Estado = true;
            return tem;
        }
        public void setRol(Roles rol){

            txtIdRol.Text = rol.IdRol;
            txtNombres.Text = rol.Nombre;
            txtDescripcion.Text = rol.Descripcion;
        }

        private void txtnombrekeypress(object sender, KeyPressEventArgs e)
        {
            val.Letras(e);
            val.Enter(e, txtDescripcion);
        }

        private void txtdescripcionkeypress(object sender, KeyPressEventArgs e)
        {
            val.Letras(e);
            val.Enter(e, btnGuardar);
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
            if (this.txtNombres.Text == "") { errorProvider1.SetError(txtNombres, "Ingrese el nombre del Rol"); return; }
            if (this.txtDescripcion.Text == "") { errorProvider1.SetError(txtDescripcion, "Ingrese una descripcion del rol"); return; }

            else
            {
                OPTION = "OK";
                this.Close();
            }

        }
    }
}
