using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CapaEntidades.GestionPersonal;
using CapaLogicaNegocio.cln_GestionPersonal;
using CapaLogicaNegocio.cln_GestionPlanificacion;
using SecuGen.FDxSDKPro.Windows;
using CapaDatos.cd_GestionPlanificacion;

using CapaDatos.cd_GestionPersonal;


namespace CapaInterfaz.ci_GestionPersonal.frmDNBPersonal
{
    public partial class frmNuevoPersonal : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmNuevoPersonal()
        {
            InitializeComponent();
        }

        private SGFingerPrintManager m_FPM;
        private int m_ImageWidth;
        private int m_ImageHeight;
        private Byte[] arrayHuella1;
        private Byte[] arrayHuella2;

        PersonalLN PLN = new PersonalLN();
        HuellaLN HLN = new HuellaLN();

        private void labelX8_Click(object sender, EventArgs e)
        {

        }
        List<string> lista;
        CalendarioLN CLN = new CalendarioLN();
        private void frmNuevoPersonal_Load(object sender, EventArgs e)
        {
            lista = new List<string>();
            var sql = (from p in CLN.ListarCalendario() select p).ToList();
            for (int f = 0; f < sql.Count;f++ ) {
                lista.Add(sql[f].IDCALENDARIO);
                comboCalendario.Items.Add(sql[f].NOMBRE+","+f);    
            } 
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();


            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        Bitmap picture;
        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //this.errorProvider1.Clear();

            //if (this.textCedula.Text == "")
            //{
            //    errorProvider1.SetError(this.textCedula, "Ingrese el Número de Cédula");
            //    return;
            //}
            //else
            //{
            //    //ubicar bien la ubicacion del this.Close();
            //    OPTION = "OK";
            //    this.Close();
            //}
            int datico = comboCalendario.SelectedIndex;
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

            Huella h = new Huella();

            h.IdHuella = HLN.GenerarIdHuella();
            h.DataHuella1 = arrayHuella1;
            h.DataHuella2 = arrayHuella2;
            h.Cedula = textCedula.Text;
            h.Nombre = comboNombresDedos.SelectedItem.ToString();
            h.Imagen = ImageToByte(pictureFoto.Image);

            PLN.InsertarPersonal(p);
            HLN.InsertarHuella(h);
           PLN.InsertarPersonalCalendario(textCedula.Text, lista[datico]);

            LimpiarCajasTexto();

        }

        private void LimpiarCajasTexto() {
            textCedula.Text = null;
            textNombres.Text = null;
            textApellidos.Text = null;
            textCargo.Text = null;
            textCiudad.Text = null;
            textCorreo.Text = null;
            textDireccion.Text = null;
            textTelefono.Text = null;
            comboNombresDedos.SelectedItem = null;
            comboCalendario.SelectedItem = null;
            comboSexo.SelectedItem = null;
            comboTipo.SelectedItem = null;
            textTitulo.Text = null;
            pictureFoto.Image = null;
            pictureHuella.Image = null;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

            OpenFileDialog Abrir = new OpenFileDialog();
            Abrir.Filter = "Archivos JPEG(*.JPG) |*.jpg";
            Abrir.InitialDirectory = "C:/gerson";
            if (Abrir.ShowDialog() == DialogResult.OK)
            {
                string Dir = Abrir.FileName;
                picture = new Bitmap(Dir);
                pictureFoto.Image = (Image)picture;

            }
        }

        //private void buttonX1_Click(object sender, EventArgs e)
        //{

        //    OpenFileDialog Abrir = new OpenFileDialog();
        //    Abrir.Filter = "Archivos JPEG(*.JPG) |*.jpg";
        //    Abrir.InitialDirectory = "C:/gerson";
        //    if (Abrir.ShowDialog() == DialogResult.OK)
        //    {
        //        string Dir = Abrir.FileName;
        //        picture = new Bitmap(Dir);
        //        pictureFoto.Image = (Image)picture;

        //    }
        //}



        private void buttonX2_Click(object sender, EventArgs e)
        {
            
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
            iError = m_FPM.GetImageEx(fp_image, timeout, this.pictureHuella.Handle.ToInt32(), quality);
            //Ajusta el brillo a 70
            iError = m_FPM.SetBrightness(70);
            Int32 max_template_size = 0;
            //Obtiene el maximo tamaño que posee el buffer.
            m_FPM.GetMaxTemplateSize(ref max_template_size);
            arrayHuella1 = new Byte[max_template_size];
            arrayHuella2 = new Byte[max_template_size];
            //Crea un formato(minucia) a partir de la imagen
            m_FPM.CreateTemplate(fp_image, arrayHuella1);
            iError = m_FPM.GetImageEx(fp_image, timeout, this.pictureHuella.Handle.ToInt32(), quality);
            m_FPM.CreateTemplate(fp_image, arrayHuella2);
            // Match for registration
            bool matched = false;
            SGFPMSecurityLevel secu_level = SGFPMSecurityLevel.NORMAL;
            iError = m_FPM.MatchTemplate(arrayHuella1, arrayHuella2, secu_level, ref matched);

            if (iError == 0)
            {
                MessageBox.Show("Lectura de huella con éxito:   "+iError.ToString());
            }
            else {
                MessageBox.Show("Error en lectura de su huella. Por favor cargue su huella otra vez:   " + iError.ToString());

            }

            m_FPM.CloseDevice();


        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click_2(object sender, EventArgs e)
        {
            try
            {


                Inicializar();
                
            }
            catch (Exception error)
            {
                MessageBox.Show("Error, no se ha encontrado el dispositivo: " + error.GetBaseException());
            }
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog Abrir = new OpenFileDialog();
            Abrir.Filter = "Archivos JPEG(*.JPG) |*.jpg";
            Abrir.InitialDirectory = "C:/gerson";
            if (Abrir.ShowDialog() == DialogResult.OK)
            {
                string Dir = Abrir.FileName;
                picture = new Bitmap(Dir);
                pictureFoto.Image = (Image)picture;

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}