using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CapaEntidades.GestionSeguridad;
using CapaLogicaNegocio;
using System.IO;

namespace CapaInterfaz.ci_GestionSeguridad
{
    public partial class frmUsuarioLogged : DevComponents.DotNetBar.Metro.MetroForm
    {
        RolesLN OPRLN = new RolesLN();
        private Form children;
        private Form paretn;

        public Form Paretn
        {
            get { return paretn; }
            set { paretn = value; }
        }
        public Form Children
        {
            get { return children; }
            set { children = value; }
        }

        public frmUsuarioLogged(Usuarios user,Form children,Form paretn)
        {
            InitializeComponent();
            cargarUsuario(user);
            Children = children;
            Paretn = paretn;
        }

        private void cargarUsuario(Usuarios user)
        {
            try
            {

                lblnameuser.Text = user.Nombre;
                lblrol.Text = OPRLN.getNombrerolByIdRol(user.IdRol);
                //lbluser.Text = user.Nombre + " " + user.Apellido + " (" + OPRLN.getNombrerolByIdRol(user.IdRol) + ")";
                byte[] imageData = user.DataFoto;
                Image newImage;
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);
                    newImage = Image.FromStream(ms, true);
                }
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = newImage;
            }
            catch (Exception)
            {

            }
        }

        private void radialMenu1_ItemClick(object sender, EventArgs e)
        {
            try
            {
                RadialMenuItem j = ((RadialMenuItem)sender);
                if (j == raidalhome)
                {
                    paretn.Hide();
                    Children.Show();
                }
                if (j == raidallogout)
                {
                    frmLog_In padr = (frmLog_In)paretn;
                    paretn.Hide();
                    padr.Return("LOGOUT");
                    paretn.Show();
                }
                if (j == raidalacercade)
                {
                    frmLog_In padr = (frmLog_In)paretn;
                    padr.Hide();
                    ci_GestionAyuda.frmAcercaDe acercade = new ci_GestionAyuda.frmAcercaDe();
                    frmSICAP2014 child2 = (frmSICAP2014)padr.Children;
                    child2.groupPanel1.Text = "Acerca de";
                    child2.addPanel(acercade);
                    child2.Show(); 
                }
                if (j == raidalmiperfil)
                {
                    frmLog_In padr = (frmLog_In)paretn;
                    padr.Hide();
                    frmMiPerfil perfil = new frmMiPerfil();
                    frmSICAP2014 child2 = (frmSICAP2014)padr.Children;
                    perfil.llenaruser(child2.user);
                    child2.addPanel(perfil);
                    child2.groupPanel1.Text = "Mi Perfil ";
                    child2.Show();
                }
            }
            catch (Exception)
            {
                
            }
        }

    }
}