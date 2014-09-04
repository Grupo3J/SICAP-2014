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
using SecuGen.FDxSDKPro.Windows;

namespace CapaInterfaz.ci_GestionPersonal.frmPersonal
{
    public partial class frmModificarPersonal : Form
    {
        private SGFingerPrintManager m_FPM;
        private int m_ImageWidth;
        private int m_ImageHeight;
        private Byte[] arrayHuella1;
        private Byte[] arrayHuella2;
       

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
            //MessageBox.Show(p.Cedula);
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

            presentarImagenEnPictureBox(ced);


        }

        private void presentarImagenEnPictureBox(string id)
        {
            byte[] foto;
            // foto = PersonalCd.getImageById(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            foto = PersonalCd.getImageById(id);

            byte[] imageData = foto.ToArray();

            Image newImage;
            using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
            {
                ms.Write(imageData, 0, imageData.Length);
                newImage = Image.FromStream(ms, true);
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = newImage;
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
            //Inicializar();
            frmAdministrarHuella frmah = new frmAdministrarHuella(textCedula.Text);
            frmah.Show();
        }

        //metodo para capturar huella
        public void Inicializar()
        {
            //Tipo de Secugen Fingerprint reader utilizado 
            SGFPMDeviceName device_name = SGFPMDeviceName.DEV_FDU05;
            //Inicializar SGFingerPrintManager para que cargue el driver del dispositivo utilizado
            m_FPM = new SGFingerPrintManager();
            m_FPM.Init(device_name);
            //Escoge el Puerto en el que se ejecuta el dispositivo
            Int32 port_addr = (Int32)SGFPMPortAddr.USB_AUTO_DETECT;
            Int32 iError = m_FPM.OpenDevice(port_addr);
            if (iError == (Int32)SGFPMError.ERROR_NONE)
                //toolStrip1.Text = "Initialization Success";
                MessageBox.Show("Por favor coloque su dedo en el lector de huellas");
            else
                MessageBox.Show("Error en inicializar SecuGen");

            //toolStrip1.Text = "OpenDevice() Error : " + iError;
            //Obtener Informacion del dispositivo inicializado
            SGFPMDeviceInfoParam pInfo = new SGFPMDeviceInfoParam();
            iError = m_FPM.GetDeviceInfo(pInfo);
            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                // This should be done GetDeviceInfo();
                m_ImageWidth = pInfo.ImageWidth;
                m_ImageHeight = pInfo.ImageHeight;
            }
            Int32 timeout = 3000;
            Int32 quality = 80;
            Byte[] fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            //Convierte el huella en una imagen y la presenta en un picturebox
            iError = m_FPM.GetImageEx(fp_image, timeout, this.pictureBox2.Handle.ToInt32(), quality);
            //Ajusta el brillo a 70
            iError = m_FPM.SetBrightness(70);
            Int32 max_template_size = 0;
            //Obtiene el maximo tamaño que posee el buffer.
            m_FPM.GetMaxTemplateSize(ref max_template_size);
            arrayHuella1 = new Byte[max_template_size];
            arrayHuella2 = new Byte[max_template_size];
            //Crea un formato(minucia) a partir de la imagen
            m_FPM.CreateTemplate(fp_image, arrayHuella1);
            iError = m_FPM.GetImageEx(fp_image, timeout, this.pictureBox2.Handle.ToInt32(), quality);
            m_FPM.CreateTemplate(fp_image, arrayHuella2);
            // Match for registration
            bool matched = false;
            SGFPMSecurityLevel secu_level = SGFPMSecurityLevel.NORMAL;
            iError = m_FPM.MatchTemplate(arrayHuella1, arrayHuella2, secu_level, ref matched);
            MessageBox.Show(iError.ToString());
            m_FPM.CloseDevice();


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
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
            //MessageBox.Show(p.Cedula);
            //PersonalCd.ModificarPersonalCedula(p);
            frmap.dataGridView1.DataSource = PLN.ListarPersonal("");
            //frmap.dataGridView1.DataSource = PersonalCd.ObtenerPresonal("");

            this.Close();
        }

        private void butAtras_Click(object sender, EventArgs e)
        {

        }

        private void butCancelar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
