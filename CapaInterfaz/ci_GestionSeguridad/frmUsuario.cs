using CapaEntidades.GestionPersonal;
using CapaEntidades.GestionSeguridad;
using CapaLogicaNegocio;
using CapaLogicaNegocio.cln_GestionPersonal;
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
    public partial class frmUsuario : DevComponents.DotNetBar.Metro.MetroForm
    {
        Usuarios user = new Usuarios();//En todos los formularios       
        Permisos permiso = new Permisos();//En todos los formularios
        UsuariosLN USLN = new UsuariosLN();//
        RolesLN OPRLN = new RolesLN();
        PersonalLN Pln = new PersonalLN();
        Validaciones val = new Validaciones();
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            mostrarUsuarios();

            object y = user;
           // if (permiso.Lectura){            toolStrip1.Items.RemoveAt(0);}
            if (!permiso.Escritura){toolStrip1.Items.Remove(tool_nuevo);}
            if (!permiso.Eliminacion){toolStrip1.Items.Remove(tool_eliminar);}
            if (!permiso.Modificacion){toolStrip1.Items.Remove(tool_editar);}
            //if (permiso.Busqueda) { toolStrip1.Items.RemoveAt(0); };
        }

        private void mostrarUsuarios()
        {
            DtgUsuarios.DataSource =  USLN.getUsersfiltrado(txtBuscarUser.Text);
            DtgUsuarios.Columns[0].Width = 100;
            DtgUsuarios.Columns[1].Width = 140;
            DtgUsuarios.Columns[2].Width = 190;
            DtgUsuarios.Columns[3].Width = 170;
            DtgUsuarios.Columns[4].Width = 125;
        }
        //En todos los formularios
        public void setUser(Usuarios s,Permisos per)
        {
            user = s;
            permiso = per;            
        }
        private void tool_nuevo_Click(object sender, EventArgs e)
        {
            frmEditUser feu = new frmEditUser();
            DialogResult resul = new DialogResult();            
            resul = feu.ShowDialog();
            if (feu.OPTION == "OK")
            {
                if (Pln.existePersonal(feu.txtcedula.Text))
                {
                    if (USLN.existe(feu.txtcedula.Text))
                    {
                        MessageBox.Show("Usuario ya registrado");
                    }
                    else
                    {
                        user.Cedula = feu.txtcedula.Text;
                        user.Nombre = feu.txtNombres.Text;
                        user.Apellido = feu.txtApellidos.Text;
                        user.Cargo = feu.txtCargo.Text;
                        user.Titulo = feu.txtTitulo.Text;
                        user.Correo = feu.txtCorreo.Text;
                        user.Sexo = feu.cmbsexo.SelectedItem.ToString() == "MASCULINO" ? 'M' : 'F';
                        user.Ciudad = feu.txtCiudad.Text;
                        user.Direccion = feu.txtDireccion.Text;
                        user.Telefono = feu.txtTelefono.Text;
                        user.Tipo = feu.cmbTipo.SelectedItem.ToString();
                        user.DataFoto = (feu.foto);
                        user.IdRol = OPRLN.getIdRolByNombrRol(feu.cmbRoles.SelectedItem.ToString());
                        user.Nick = feu.txtlogin.Text;
                        user.Clave = feu.txtclave.Text;
                        USLN.insertaruser(user);

                        Pln.ModificarPersonal((Personal)user);
                    }
                }
                else
                {
                    user.Cedula = feu.txtcedula.Text;
                    user.Nombre = feu.txtNombres.Text;
                    user.Apellido = feu.txtApellidos.Text;
                    user.Cargo = feu.txtCargo.Text;
                    user.Titulo = feu.txtTitulo.Text;
                    user.Correo = feu.txtCorreo.Text;
                    user.Sexo = feu.cmbsexo.SelectedItem.ToString() == "MASCULINO" ? 'M' : 'F';
                    user.Ciudad = feu.txtCiudad.Text;
                    user.Direccion = feu.txtDireccion.Text;
                    user.Telefono = feu.txtTelefono.Text;
                    user.Tipo = feu.cmbTipo.SelectedItem.ToString();
                    user.DataFoto = ImageToByte(feu.pict_foto.Image);
                    user.IdRol = OPRLN.getIdRolByNombrRol(feu.cmbRoles.SelectedItem.ToString());
                    user.Nick = feu.txtlogin.Text;
                    user.Clave = feu.txtclave.Text;
                    USLN.insertaruser(user,(Personal)user);
                    MessageBox.Show("Usuario Registrado Correctamente");
                }

                

            }
        }
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();


            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void tool_editar_Click(object sender, EventArgs e)
        {
            frmEditUser mpp = new frmEditUser();
            DialogResult resul = new DialogResult();
            mpp.MODIFICAR = true;
            Usuarios tem = USLN.getUserbyced(DtgUsuarios.CurrentRow.Cells[0].Value.ToString());
            mpp.llenaruser(tem);
            //mpp.txtcedula.Text = tem.Cedula;
            //mpp.txtNombres.Text = tem.Nombre;
            //mpp.txtApellidos.Text = tem.Apellido;
            //mpp.txtCargo.Text = tem.Cargo;
            //mpp.txtTitulo.Text = tem.Titulo;
            //mpp.txtCorreo.Text = tem.Correo;
            //mpp.cmbsexo.SelectedItem =tem.Sexo=='M'?"MASCULINO":"FEMENINO";
            //mpp.txtCiudad.Text = tem.Ciudad;
            //mpp.txtDireccion.Text = tem.Direccion;
            //mpp.txtTelefono.Text = tem.Telefono;
            //mpp.txtTipo.Text = tem.Tipo;
            //mpp.cmbRoles.SelectedItem = OPRLN.getNombrerolByIdRol(tem.IdRol);
            //mpp.txtlogin.Text = tem.Nick;
            //mpp.txtclave.Text = tem.Clave;
            //mpp.foto = tem.DataFoto;
            resul = mpp.ShowDialog();
            if (mpp.OPTION == "OK")
            {
                try
                {

                    Usuarios tem2 = mpp.getuser();

                    USLN.modificaruser(tem2);
                    mostrarUsuarios();

                }
                catch (Exception mes)
                {
                    MessageBox.Show(mes.Message);
                }
            }
        }

        private void txtBuscarUser_TextChanged(object sender, EventArgs e)
        {
            mostrarUsuarios();
        }

        private void tool_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult resul;

            resul = MessageBox.Show("Esta seguro de eliminar registro", "Informacion del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resul == DialogResult.Yes)
            {
                try
                {
                    string cedula = (DtgUsuarios.CurrentRow.Cells[0].Value.ToString());
                    
                   
                    USLN.eliminarUser(cedula);
                    mostrarUsuarios();
                }

                catch (Exception mes)
                {
                    MessageBox.Show(mes.Message);
                }
            }
        }

        private void tool_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       

    }
}
