using CapaEntidades.GestionSeguridad;
using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaInterfaz.ci_GestionSeguridad
{
    public partial class frmMiPerfil : DevComponents.DotNetBar.Metro.MetroForm
    {
        public byte[] foto;
        RolesLN OPRLN = new RolesLN();
        public frmMiPerfil()
        {
            InitializeComponent();
        }

        private void frmMiPerfil_Load(object sender, EventArgs e)
        {

        }
        public void llenaruser(Usuarios user)
        {
            cmbRoles.DataSource = OPRLN.getnombRoles();
            txtcedula.Text = user.Cedula;
            txtcedula.Enabled = false;
            txtNombres.Text = user.Nombre;
            txtApellidos.Text = user.Apellido;
            txtCargo.Text = user.Cargo;
            txtTitulo.Text = user.Titulo;
            txtCorreo.Text = user.Correo;
            cmbsexo.SelectedItem = user.Sexo == 'M' ? "MASCULINO" : "FEMENINO";
            txtCiudad.Text = user.Ciudad;
            txtDireccion.Text = user.Direccion;
            txtTelefono.Text = user.Telefono;
            cmbTipo.SelectedItem = user.Tipo;
            cargarimagen(user.DataFoto);

            cmbRoles.SelectedItem = OPRLN.getNombrerolByIdRol(user.IdRol);
            txtlogin.Text = user.Nick;
            txtclave.Text = user.Clave;

        }
        public void cargarimagen(byte[] foto)
        {
            this.foto = foto;
            try
            {
                byte[] imageData = foto.ToArray();
                Image newImage;
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);
                    newImage = Image.FromStream(ms, true);
                }
                pict_foto.SizeMode = PictureBoxSizeMode.StretchImage;
                pict_foto.Image = newImage;

            }
            catch (Exception)
            {

            }
        }

       
    }
}
