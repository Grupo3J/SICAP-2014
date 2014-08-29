using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.MemoryMappedFiles;

using System.IO;
using SecuGen.FDxSDKPro.Windows;
using CapaLogicaNegocio.cln_GestionPersonal;
using CapaDatos.cd_GestionPersonal;
using CapaEntidades.GestionPersonal;

namespace CapaInterfaz.ci_GestionPersonal.frmPersonal
{
    public partial class frmAdministrarHuella : Form
    {
        string cedula;
        public frmAdministrarHuella(string ced)
        {
            cedula = ced;
            InitializeComponent();
        }

        HuellaLN hln = new HuellaLN();

        private SGFingerPrintManager m_FPM;
        private int m_ImageWidth;
        private int m_ImageHeight;
        private Byte[] arrayHuella1;
        private Byte[] arrayHuella2;

        private void butCargarHuella1_Click(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void butCargarHuella2_Click(object sender, EventArgs e)
        {
            Inicializar();
        }

        //metodo para capturar la huella
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
            iError = m_FPM.GetImageEx(fp_image, timeout, this.pictureBoxHuella1.Handle.ToInt32(), quality);
            //Ajusta el brillo a 70
            iError = m_FPM.SetBrightness(70);
            Int32 max_template_size = 0;
            //Obtiene el maximo tamaño que posee el buffer.
            m_FPM.GetMaxTemplateSize(ref max_template_size);
            arrayHuella1 = new Byte[max_template_size];
            arrayHuella2 = new Byte[max_template_size];
            //Crea un formato(minucia) a partir de la imagen
            m_FPM.CreateTemplate(fp_image, arrayHuella1);
            iError = m_FPM.GetImageEx(fp_image, timeout, this.pictureBoxHuella2.Handle.ToInt32(), quality);
            m_FPM.CreateTemplate(fp_image, arrayHuella2);
            // Match for registration
            bool matched = false;
            SGFPMSecurityLevel secu_level = SGFPMSecurityLevel.NORMAL;
            iError = m_FPM.MatchTemplate(arrayHuella1, arrayHuella2, secu_level, ref matched);
            MessageBox.Show(iError.ToString());
            m_FPM.CloseDevice();

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Huella h = new Huella();
            h.IdHuella = GenerarIdHuella();
            h.DataHuella1 = arrayHuella1;
            h.DataHuella2 = arrayHuella2;
            h.Cedula = cedula;
            string acum = null;
            string acum2 = null;

            for (int f = 0; f < arrayHuella1.Length;f++ ) {
                acum = acum + arrayHuella1[f];
                acum2 = acum2 + arrayHuella2[f];
            }

            MessageBox.Show("acumsito: " + acum + "   acumsito2: " + acum);

            hln.InsertarHuella(h);
        }

        private string GenerarIdHuella()
        {
            Random ran = new Random();
            int num = ran.Next(0000, 1000);
            int num2 = ran.Next(000, 100);

            string idhuella = "i" + num.ToString() + num2.ToString();
            return idhuella;
        }

        private void frmAdministrarHuella_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = hln.ListarHuella(cedula);
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string idhuella = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            byte[] imageData;
            byte[] huella2;
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            imageData = HuellaCD.getImageById(id);
            huella2 = HuellaCD.getImageById(dataGridView1.CurrentRow.Cells[0].Value.ToString());
           
            
            try
            {
    //            byte[] imageData = huella1;

                string valor = "";
                foreach(byte i in imageData)
                {
                    valor += i.ToString();
                }
                MessageBox.Show(valor);
                Image newImage;
                using (MemoryStream ms2 = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms2.Write(imageData, 0, imageData.Length);
                    newImage = Image.FromStream(ms2, true);
                }
                pictureBoxPrueba.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBoxPrueba.Image = newImage;
                pictureBoxPrueba.Refresh();
                MessageBox.Show("no entro");
            }
            catch (Exception er)
            {
                MessageBox.Show("pasando: " + er.GetBaseException());
                MessageBox.Show(er.Message+"\n"+er.StackTrace+"\n"+er.TargetSite);

            }

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("¿Está seguro que desea eliminar la huella?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                string idHuella = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string cedula = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                hln.EliminarHuellaIdHuella(idHuella);

                dataGridView1.DataSource = hln.ListarHuella(cedula);
            }
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = hln.ListarHuella(cedula);
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label1.Text = (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                presentarImagenEnPictureBox(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            }
            catch (Exception)
            {


            }
        }

        private void presentarImagenEnPictureBox(string id)
        {
            byte[] foto;
            // foto = PersonalCd.getImageById(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            foto = HuellaCD.getImageById(id);

            byte[] imageData = foto.ToArray();
            try
            {
                Image newImage;
            using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
            {
                ms.Write(imageData, 0, imageData.Length);
                newImage = Image.FromStream(ms, true);
            }
            pictureBoxPrueba.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxPrueba.Image = newImage;
            }
            catch (Exception ex){
                MessageBox.Show("Error: "+ex.GetBaseException());
            }
            
        }

    }
}
