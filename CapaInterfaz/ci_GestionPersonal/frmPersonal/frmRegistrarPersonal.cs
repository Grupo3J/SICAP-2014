using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades.GestionPersonal;
using CapaDatos.cd_GestionPersonal;

namespace CapaInterfaz.ci_GestionPersonal.frmPersonal
{
    public partial class frmRegistrarPersonal : Form
    {
        public frmRegistrarPersonal()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog Abrir = new OpenFileDialog();
            Abrir.Filter = "Archivos JPEG(*.JPG) |*.jpg";
            Abrir.InitialDirectory = "C:/gerson";
            if (Abrir.ShowDialog() == DialogResult.OK)
            {
                string Dir = Abrir.FileName;
                Bitmap picture = new Bitmap(Dir);
                pictureBox1.Image = (Image)picture;

            }
        }
        Bitmap picture2;
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog Abrir2 = new OpenFileDialog();
            Abrir2.Filter = "Archivos JPEG(*.JPG) |*.jpg";
            Abrir2.InitialDirectory = "C:/gerson";
            if (Abrir2.ShowDialog() == DialogResult.OK)
            {
                string Dir = Abrir2.FileName;
                picture2 = new Bitmap(Dir);
                pictureBox2.Image = (Image)picture2;
            }
        }
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        private void butGuardar_Click(object sender, EventArgs e)
        {
            string sex = Convert.ToString(comboSexo.SelectedItem);

            Personal p = new Personal();
            p.Cedula = textCedula.Text;
            p.Nombre = textNombres.Text;
            p.Apellido = textApellidos.Text;
            p.Cargo = textCargo.Text;
            p.Titulo = textTitulo.Text;
            p.Correo = textCorreo.Text;
            p.Sexo = sex[0];
            p.Ciudad = textCiudad.Text;
            p.Direccion = textDireccion.Text;
            p.Telefono = textTelefono.Text;
            p.Tipo = Convert.ToString(comboSexo.SelectedItem);
            p.DataFoto = ImageToByte(picture2);


            PersonalCd.Create(p);
        }

    }
}
