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
using CapaLogicaNegocio.cln_GestionSeguridad;
using CapaEntidades.GestionSeguridad;
using System.IO;
using CapaLogicaNegocio.cln_GestionPersonal;
using CapaEntidades.GestionPersonal;
namespace CapaInterfaz.ci_GestionSeguridad
{
    public partial class frmEditUser : DevComponents.DotNetBar.Metro.MetroForm
    {
        public string OPTION = "";
        RolesLN OPRLN =new RolesLN();
        Validaciones val = new Validaciones();
        PersonalLN PELN = new PersonalLN();
        UsuariosLN USLN = new UsuariosLN();
        public bool MODIFICAR = false;
        public byte[] foto;
        public frmEditUser()
        {
            InitializeComponent();
            cmbRoles.DataSource = OPRLN.getnombRoles();

        }

        private void lklabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.openFileDialog1.InitialDirectory = "C:/";
            this.openFileDialog1.Filter = "All Files|*.*|Bitmaps|*.bmp|GIFs|*.gif|JPEGs|*.jpg";
            this.openFileDialog1.FilterIndex = 4;

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pict_foto.Image = Image.FromFile(this.openFileDialog1.FileName);
                this.pict_foto.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pict_foto.BorderStyle = BorderStyle.Fixed3D;
                this.pict_foto.Tag = this.openFileDialog1.FileName;
                this.foto = val.ImageToByte(pict_foto.Image);

            }
        }

        private void frmEditUser_Load(object sender, EventArgs e)
        {
           

        }

        private void tool_grabar_Click(object sender, EventArgs e)
        {

                     
        }
        public void llenaruser(Usuarios user)
        {
            txtcedula.Text=user.Cedula;
            txtcedula.Enabled = false;
            txtNombres.Text=user.Nombre;
            txtApellidos.Text= user.Apellido;
            txtCargo.Text=user.Cargo;
            txtTitulo.Text=user.Titulo ;
            txtCorreo.Text=user.Correo;
            cmbsexo.SelectedItem= user.Sexo=='M'?"MASCULINO":"FEMENINO";
            txtCiudad.Text=user.Ciudad;

            txtDireccion.Text= user.Direccion;
            txtTelefono.Text=user.Telefono;
            foreach (var item in cmbTipo.Items)
            {
                if (user.Tipo == item.ToString())
                {
                    cmbTipo.SelectedItem = item;
                    break;
                }
            }
            
                 
            cargarimagen(user.DataFoto);
           
            cmbRoles.SelectedItem = OPRLN.getNombrerolByIdRol(user.IdRol);
            txtlogin.Text= user.Nick;
            txtclave.Text=user.Clave ;
           
        }
        public void llenarpersonal(Personal per)
        {
            txtcedula.Text = per.Cedula;
            txtNombres.Text = per.Nombre;
            txtApellidos.Text = per.Apellido;
            txtCargo.Text = per.Cargo;
            txtTitulo.Text = per.Titulo;
            txtCorreo.Text = per.Correo;
            cmbsexo.SelectedItem = per.Sexo=='M'?"MASCULINO":"FEMENINO";
            txtCiudad.Text = per.Ciudad;
            txtDireccion.Text = per.Direccion;
            txtTelefono.Text = per.Telefono;
            foreach (var item in cmbTipo.Items)
            {
                if (per.Tipo == item.ToString())
                {
                    cmbTipo.SelectedItem = item;
                    break;
                }
            }
            cargarimagen(per.DataFoto);
           

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

       

        private void btnestablecerpersonal_Click(object sender, EventArgs e)
        {
            DialogResult resul = new DialogResult();
            frmPersonalselect frmp = new frmPersonalselect();
            resul = frmp.ShowDialog();
            if (frmp.OPTION == "OK")
            {
                limpiar();
                enableduser(true);
                string cedula = frmp.DtgPersonal.CurrentRow.Cells[0].Value.ToString();
                
                if (USLN.existe(cedula))
                {
                    DevComponents.DotNetBar.MessageBoxEx.Show(this, "", "Ya existe este usuario , seleccione otro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                    llenaruser(USLN.getUserbyced(cedula));
                    enabledpersonalminuser(false);
                    enableduser(false);
                }
                else
                {
                    llenarpersonal(PELN.getPersonalByced(cedula));
                    enabledpersonalminuser(false);
                }

            }
        }

        private void limpiar()
        {
            txtcedula.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtCargo.Text = "";
            txtTitulo.Text = "";
            txtCorreo.Text = ""; 
            cmbsexo.SelectedIndex=0;
            txtCiudad.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            cmbTipo.SelectedIndex=0;
            cmbRoles.SelectedIndex=0;
            txtlogin.Text = "";
            txtclave.Text = "";
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        public Usuarios getuser()
        {
            Usuarios user = new Usuarios();
            user.Cedula = txtcedula.Text;
            user.Nombre = txtNombres.Text;
            user.Apellido = txtApellidos.Text;
            user.Cargo = txtCargo.Text;
            user.Titulo = txtTitulo.Text;
            user.Correo = txtCorreo.Text;
            user.Sexo = cmbsexo.SelectedItem.ToString() == "MASCULINO" ? 'M' : 'F';
            user.Ciudad = txtCiudad.Text;
            user.Direccion = txtDireccion.Text;
            user.Telefono = txtTelefono.Text;
            user.Tipo = cmbTipo.SelectedItem.ToString();
            user.DataFoto = foto; //val.ImageToByte(pict_foto.Image);
            user.IdRol = OPRLN.getIdRolByNombrRol(cmbRoles.SelectedItem.ToString());
            user.Nick = txtlogin.Text;
            user.Clave = txtclave.Text;
            return user;
        }
        public void enabledpersonalminuser(bool estado)
        {
            txtcedula.Enabled = estado;
            txtNombres.Enabled = estado;
            txtApellidos.Enabled = estado;
            txtCargo.Enabled = estado;
            txtTitulo.Enabled = estado;
            txtCorreo.Enabled = estado;
            cmbsexo.Enabled = estado;
            txtCiudad.Enabled = estado;
            txtDireccion.Enabled = estado;
            txtTelefono.Enabled = estado;
            cmbTipo.Enabled = estado;
            lklabel.Enabled = estado;


        }
        public void enableduser(bool estado)
        {
            txtlogin.Enabled = estado;
            txtclave.Enabled = estado;
            cmbRoles.Enabled = estado;
            btnguardar.Enabled = estado;
         }

       
        private void txtcedulavalidated(object sender, EventArgs e)
        {
            if (txtcedula.Text != "")
            {
                if (!val.esCedulaValida(txtcedula.Text) )
                {
                    errorProvider1.SetError(txtcedula, "Cedula no Valida");
                    txtcedula.Focus();
                }
                else
                    errorProvider1.Clear();
            }
        }

        private void txtcorreovalidate(object sender, EventArgs e)
        {
            if (txtCorreo.Text != "")
            {
                if (val.email_bien_escrito(txtCorreo.Text) == false)
                {
                    errorProvider1.SetError(txtCorreo, "Correo no Valido");
                    txtCorreo.Focus();
                }
                else
                    errorProvider1.Clear();
            }
        } 
        private void txtCedulaKeyPress(object sender, KeyPressEventArgs e)
        {
            val.numeros(e);
            val.Enter(e, txtNombres);
        }


        private void txtnombrekeypress(object sender, KeyPressEventArgs e)
        {
            val.Letras(e);
            val.Enter(e, txtApellidos);
        }

        private void txtapellidokeypress(object sender, KeyPressEventArgs e)
        {
            val.Letras(e);
            val.Enter(e, txtCargo);
        }

        private void txtcargokeypress(object sender, KeyPressEventArgs e)
        {
            val.Letras(e);
            val.Enter(e, txtTitulo);
        }

        private void txttitulokeypress(object sender, KeyPressEventArgs e)
        {
            val.Letras(e);
            val.Enter(e, txtCorreo);
        }

        private void txtcorreokeypress(object sender, KeyPressEventArgs e)
        {
            
            val.Enter(e, cmbsexo);
        }

        private void txtciudadakeypress(object sender, KeyPressEventArgs e)
        {
            val.Letras(e);
            val.Enter(e, txtDireccion);
        }

        private void txtdireccionkeypress(object sender, KeyPressEventArgs e)
        {
            val.Letras(e);
            val.Enter(e, txtTelefono);
        }

        private void txttelefonoleypress(object sender, KeyPressEventArgs e)
        {
            val.numeros(e);
            val.Enter(e, cmbTipo);
        }

        private void txtloginkeypress(object sender, KeyPressEventArgs e)
        {
           
            val.Enter(e, txtclave);
        }

        private void txtclavekeypress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {

            this.errorProvider1.Clear();
            if (this.txtcedula.Text == "") { errorProvider1.SetError(txtcedula, "Ingrese el Numero de Cedula"); return; }
            if (this.txtNombres.Text == "") { errorProvider1.SetError(txtNombres, "Ingrese el Nombre del Usuario"); return; }
            if (this.txtApellidos.Text == "") { errorProvider1.SetError(txtApellidos, "Ingrese el Apellido "); return; }
            if (this.txtCargo.Text == "") { errorProvider1.SetError(txtCargo, "Ingrese el Cargo"); return; }
            if (this.cmbsexo.SelectedIndex == -1) { errorProvider1.SetError(cmbsexo, "Seleccione el sexo del Usuario"); return; }
            if (this.txtCiudad.Text == "") { errorProvider1.SetError(txtCiudad, "Ingrese la Ciudad"); return; }
            if (this.txtDireccion.Text == "") { errorProvider1.SetError(txtDireccion, "Ingrese la Direccin "); return; }
            if (this.txtTelefono.Text == "") { errorProvider1.SetError(txtTelefono, "Ingrese el telefono "); return; }
            if (this.cmbTipo.SelectedIndex == -1) { errorProvider1.SetError(cmbTipo, "Seleccione el Tipo de Personal"); return; }
            if (this.cmbRoles.SelectedIndex == -1) { errorProvider1.SetError(cmbRoles, "Seleccione el Rol de Usuario"); return; }
            if (this.txtlogin.Text == "") { errorProvider1.SetError(txtlogin, "Ingrese el Login del Usuario"); return; }
            if (this.txtclave.Text == "") { errorProvider1.SetError(txtclave, "Ingrese La clave de Usuario"); return; }

            else
            {
                OPTION = "OK";
                this.Close();
            }

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtloginvalidated(object sender, EventArgs e)
        {
            if (txtlogin.Text.Length <8 )
            {   
                errorProvider1.SetError(txtlogin, "Al menos debe ingresar 8caracteres");
                txtlogin.Focus();
            }
            if (USLN.existelogin(txtlogin.Text))
            {
                errorProvider1.SetError(txtlogin, "este Login ya existe escriba otro diferente");
                txtlogin.Focus();
            }
            else{errorProvider1.Clear();}
                
            
        }

        private void txtclavevalidated(object sender, EventArgs e)
        {
            if (txtclave.Text.Length < 8)
            {
                errorProvider1.SetError(txtclave, "Al menos debe ingresar 8caracteres");
                txtclave.Focus();
            }
            else { errorProvider1.Clear(); }
                
        }
       
    }
}
