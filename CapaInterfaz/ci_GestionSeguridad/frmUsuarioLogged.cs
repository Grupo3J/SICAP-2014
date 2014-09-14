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

        public frmUsuarioLogged(Usuarios user)
        {
            InitializeComponent();
            cargarUsuario(user);
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
                    //addPanel(new frmHome());
                    //groupPanel1.Text = "SICAP Sistema de control de asistencia de Personal";
                }
                if (j == raidallogout)
                {
                    //OPTION = "OK";
                    //this.Close();
                }
                if (j == raidalacercade)
                {
                    //ci_GestionAyuda.frmAcercaDe acercade = new ci_GestionAyuda.frmAcercaDe();
                    //groupPanel1.Text = "Acerca de";
                    //addPanel(acercade);
                }
                if (j == raidalmiperfil)
                {
                    //frmMiPerfil perfil = new frmMiPerfil();
                    //perfil.llenaruser(user);
                    //addPanel(perfil);
                    //groupPanel1.Text = "Mi Perfil ";
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}