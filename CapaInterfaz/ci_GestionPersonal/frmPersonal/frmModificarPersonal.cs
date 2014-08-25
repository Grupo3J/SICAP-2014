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
using CapaLogicaNegocio.cln_GestionPersonal;
using System.IO;

namespace CapaInterfaz.ci_GestionPersonal.frmPersonal
{
    public partial class frmModificarPersonal : Form
    {
        public string ced;
        public string nom;
        public string ape;
        public string car;
        public string tit;
        public string corr;
        public string sex;
        public string ciu;
        public string dir;
        public string tel;
        public string tip;
        public byte[] fot;

        Bitmap picture;
        Bitmap picture2;
       
        PersonalLN PLN = new PersonalLN();

        public frmModificarPersonal(string cedula, string nombre, string apellidos,string cargo,string titulo, string correo,
                string sexo, string ciudad, string direccion, string telefono, string tipo, byte []foto){
            ced = cedula;
            nom = nombre;
            ape = apellidos;
            car = cargo;
            tit = titulo;
            corr = correo;
            sex = sexo;
            ciu = ciudad;
            dir = direccion;
            tel = telefono;
            tip = tipo;
            fot = foto;
            InitializeComponent();
        }
        frmAdministrarPersonal frmap = new frmAdministrarPersonal();
        private void butGuardar_Click(object sender, EventArgs e)
        {

            string sex = "" + comboSexo.SelectedItem;

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
            p.Tipo = Convert.ToString(comboTipo.SelectedItem);
            p.DataFoto = ImageToByte(picture);

            PLN.ModificarPersonal(p);
           //PersonalCd.ModificarPersonalCedula(p);
            frmap.dataGridView1.DataSource = PLN.ListarPersonal("");
            //frmap.dataGridView1.DataSource = PersonalCd.ObtenerPresonal("");

            this.Close();
        }
        frmAdministrarPersonal frmdp = new frmAdministrarPersonal();

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }


        
        
        private void frmModificarPersonal_Load(object sender, EventArgs e)
        {
            if(sex.Equals("H")||sex.Equals("h")){
                comboSexo.Text = "Hombre";
            }else{
            comboSexo.Text = "Mujer";
            }
            textCedula.Text = ced;
            textNombres.Text = nom;
            textApellidos.Text = ape;
            textCargo.Text = car;
            textTitulo.Text = tit;
            textCorreo.Text = corr;
            
            textCiudad.Text = ciu;
            textDireccion.Text = dir;
            textTelefono.Text = tel;
            comboTipo.Text = tip;

            try
            {
                byte[] imageData = fot.ToArray();
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

        private void butCargarFoto(object sender, EventArgs e)
        {

            OpenFileDialog Abrir = new OpenFileDialog();
            Abrir.Filter = "Archivos JPEG(*.JPG) |*.jpg";
            Abrir.InitialDirectory = "C:/gerson";
            if (Abrir.ShowDialog() == DialogResult.OK)
            {
                string Dir = Abrir.FileName;
                picture = new Bitmap(Dir);
                pictureBox1.Image = (Image)picture;

            }
        }

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
    }
}
