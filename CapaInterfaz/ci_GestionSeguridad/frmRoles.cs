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
    public partial class frmRoles :DevComponents.DotNetBar.Metro.MetroForm
    {
        Usuarios user = new Usuarios();//En todos los formularios       
        Permisos permiso = new Permisos();//En todos los formularios
        RolesLN RLN = new RolesLN();
        public frmRoles()
        {
            InitializeComponent();
        }

        private void frmRoles_Load(object sender, EventArgs e)
        {
            mostraroles();
        }
        public void setUser(Usuarios s, Permisos per)
        {
            user = s;
            permiso = per;
        }
        public void mostraroles()
        {
            DtgRoles.DataSource = RLN.getRoles(txtBuscarUser.Text);
        }

        private void tool_nuevo_Click(object sender, EventArgs e)
        {

            frmEditRol feu = new frmEditRol();
            DialogResult resul = new DialogResult();
            resul = feu.ShowDialog();
            if (feu.OPTION == "OK")
            {
                Roles rol = new Roles();
                rol.IdRol = feu.txtIdRol.Text;
                rol.Nombre = feu.txtNombres.Text;
                rol.Descripcion = feu.txtDescripcion.Text;
                RLN.insertarRol(rol);
                mostraroles();
            }
        }

        private void txtBuscarUser_TextChanged(object sender, EventArgs e)
        {
            mostraroles();
        }

        private void tool_editar_Click(object sender, EventArgs e)
        {
            frmEditRol mpp = new frmEditRol();
            DialogResult resul = new DialogResult();
            mpp.MODIFICAR = true;
            mpp.txtIdRol.Text = DtgRoles.CurrentRow.Cells[0].Value.ToString();
            mpp.txtNombres.Text = DtgRoles.CurrentRow.Cells[1].Value.ToString();
            mpp.txtDescripcion.Text = DtgRoles.CurrentRow.Cells[2].Value.ToString();
            resul = mpp.ShowDialog();
            if (mpp.OPTION == "OK")
            {
                Roles rol = mpp.getRol();               
                RLN.modificarRol(rol);
                mostraroles();
            }
        }

        private void tool_eliminar_Click(object sender, EventArgs e)
        {
             DialogResult resul;

            resul = MessageBox.Show("Esta seguro de eliminar registro", "Informacion del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resul == DialogResult.Yes)
            {
                try
                {
                    string idrol = (DtgRoles.CurrentRow.Cells[0].Value.ToString());
                    
                   
                    RLN.eliminarRol(idrol);
                    mostraroles();
                }

                catch (Exception mes)
                {
                    MessageBox.Show(mes.Message);
                }
            }
        
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
