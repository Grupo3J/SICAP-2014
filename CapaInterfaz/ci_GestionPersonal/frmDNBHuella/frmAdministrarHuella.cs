using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.IO.MemoryMappedFiles;
using SecuGen.FDxSDKPro.Windows;
using CapaLogicaNegocio.cln_GestionPersonal;
using CapaEntidades.GestionPersonal;
using CapaDatos.cd_GestionPersonal;
using System.IO;
using CapaLogicaNegocio;
using CapaEntidades.GestionSeguridad;


namespace CapaInterfaz.ci_GestionPersonal.frmDNBHuella
{
    public partial class frmAdministrarHuella : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmAdministrarHuella(string ced)
        {
            cedula = ced;
            InitializeComponent();
        }
        Validaciones VAL = new Validaciones();
        HuellaLN hln = new HuellaLN();

        private string cedula;
        private SGFingerPrintManager m_FPM;
        private int m_ImageWidth;
        private int m_ImageHeight;
        private Byte[] arrayHuella1;
        private Byte[] arrayHuella2;
       
        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonXCargarHuella_Click(object sender, EventArgs e)
        {
            try
            {


                Inicializar();

            }
            catch (Exception)
            {
                MessageBox.Show("Error, no se ha encontrado el disposito biométrico.");
            }
            
        }

        //metodo para capturar la huella
        public void Inicializar()
        {
            try
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
                    MessageBox.Show("Error al inicializar Lector de Huellas");

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
                iError = m_FPM.GetImageEx(fp_image, timeout, this.pictureBox1Huella.Handle.ToInt32(), quality);
                //Ajusta el brillo a 70
                iError = m_FPM.SetBrightness(70);
                Int32 max_template_size = 0;
                //Obtiene el maximo tamaño que posee el buffer.
                m_FPM.GetMaxTemplateSize(ref max_template_size);
                arrayHuella1 = new Byte[max_template_size];
                arrayHuella2 = new Byte[max_template_size];
                //Crea un formato(minucia) a partir de la imagen
                m_FPM.CreateTemplate(fp_image, arrayHuella1);
                iError = m_FPM.GetImageEx(fp_image, timeout, this.pictureBox1Huella.Handle.ToInt32(), quality);
                m_FPM.CreateTemplate(fp_image, arrayHuella2);
                // Match for registration
                bool matched = false;
                SGFPMSecurityLevel secu_level = SGFPMSecurityLevel.NORMAL;
                iError = m_FPM.MatchTemplate(arrayHuella1, arrayHuella2, secu_level, ref matched);
                string er = iError.ToString();

                if (er.Equals("0"))
                {
                    MessageBox.Show("Lectura de huella exitosa");
                }
                else
                {
                    MessageBox.Show("Error en la lectura de su huella....Por favor intentelo otras vez");
                }
                m_FPM.CloseDevice();
            }
            catch (Exception) {
                MessageBoxEx.Show("No se encuentra el dispositivo bómétrico...Por favor verifique su conexión.");
            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = hln.ListarHuella(cedula);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            try {
                if (hln.SiExisteMasDeUnaHuella(cedula))
                {
                    dialog = MessageBox.Show("¿Está seguro que desea eliminar la huella?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialog == DialogResult.Yes)
                    {
                        string idHuella = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                        cedula = dataGridViewX1.CurrentRow.Cells[1].Value.ToString();

                        hln.EliminarHuellaIdHuella(idHuella);
                        hln.ListarHuella(cedula);
                    }
                }
                else {
                    MessageBoxEx.Show("No se puede eliminar todas las huelas de una persona");
                }
            }
            catch (Exception) { }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
            if (this.comboBoxEx1.SelectedIndex == -1) { errorProvider1.SetError(comboBoxEx1, "Seleccione un nombre de huella"); return; }


            try
            {
                Huella h = new Huella();
                h.IdHuella = hln.GenerarIdHuella();
                h.Cedula = cedula;
                h.Nombre = comboBoxEx1.SelectedItem.ToString();
                h.DataHuella1 = arrayHuella1;
                h.DataHuella2 = arrayHuella2;

                Image im = pictureBox1Huella.Image;
                h.Imagen = ImageToByte(im);

                if (arrayHuella1 == null)
                {
                    MessageBox.Show("Por favor cargue una huella");
                }
                else
                {
                   // if (hln.InsertarHuella(h))
                    //if
                    hln.InsertarHuellaSinReturn(h);
                    MessageBoxEx.Show("Huella registrada Exitosamente");
                    hln.ListarHuella(cedula);

                    //{
                        ///MessageBox.Show("Ya existe una huella con ese nombre");
                    //}
                }
            }
            catch (Exception er){
                MessageBoxEx.Show(er.Message);
            }

            limpiarFormulario();
        }


        //metodo para limpiar controladores
        private void limpiarFormulario() {
            comboBoxEx1.SelectedItem = null;
            pictureBox1Huella.Image = null;
            arrayHuella1 = null;
        }



        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();


            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void frmAdministrarHuella_Load(object sender, EventArgs e)
        {
            
            dataGridViewX1.DataSource = hln.ListarHuella(cedula);
            
        }

        private void dataGridViewX1_CursorChanged(object sender, EventArgs e)
        {
           
        }

        private void presentarImagenEnPictureBox(string id)
        {
            try
            {
                byte[] imageData;
                imageData = HuellaCD.getImageById(dataGridViewX1.CurrentRow.Cells[0].Value.ToString());

                //byte[] imageData = foto.ToArray();

                Image newImage;
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);
                    newImage = Image.FromStream(ms, true);
                }

            }
            catch (Exception)
            {
                //MessageBox.Show("Error: " + error.GetBaseException());
            }
        }

        private void dataGridViewX1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
               
            //    presentarImagenEnPictureBox(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value.ToString());

            //}
            //catch (Exception)
            //{


            //}
        }

        private void buttonXCargarHuella_Click_1(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
    }
}