using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecuGen.FDxSDKPro.Windows;
using System.Windows.Forms;
using CapaInterfaz.ci_GestionAsistencia.frmAsistencia;

namespace CapaDatos
{
    public class Secugen
    {

        
        //variables que utiliza SecuGen
        private SGFingerPrintManager m_FPM;
        private int m_ImageWidth;
        private int m_ImageHeight;
        private Byte[] arrayHuella1;

        public Secugen() 
        {

        }

        ~Secugen() 
        {
            m_FPM.CloseDevice();
        }

        public Byte[] ArrayHuella1
        {
            get { return arrayHuella1; }
            set { arrayHuella1 = value; }
        }

        private Byte[] arrayHuella2;

        public Byte[] ArrayHuella2
        {
            get { return arrayHuella2; }
            set { arrayHuella2 = value; }
        }

        //metodo para capturar huella
        public void Inicializar()
        {
            //Tipo de Secugen Fingerprint reader utilizado 
            SGFPMDeviceName device_name = SGFPMDeviceName.DEV_FDU05;
            //Inicializar SGFingerPrintManager para que cargue el driver del dispositivo utilizado
            m_FPM = new SGFingerPrintManager();
            m_FPM.Init(device_name);
        }

        public void LeerHuella(PictureBox pictureBox1, PictureBox pictureBox2)
        {
            Inicializar();
            //Escoge el Puerto en el que se ejecuta el dispositivo
            Int32 port_addr = (Int32)SGFPMPortAddr.USB_AUTO_DETECT;
            Int32 iError = m_FPM.OpenDevice(port_addr);
            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                MessageBox.Show("Por favor coloque su dedo en el lector de huellas");

            }
            else
                MessageBox.Show("Error en inicializar SecuGen: " + iError);

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
            iError = m_FPM.GetImageEx(fp_image, timeout, pictureBox1.Handle.ToInt32(), quality);
            //Ajusta el brillo a 70
            iError = m_FPM.SetBrightness(70);
            Int32 max_template_size = 0;
            //Obtiene el maximo tamaño que posee el buffer.
            m_FPM.GetMaxTemplateSize(ref max_template_size);
            arrayHuella1 = new Byte[max_template_size];
            arrayHuella2 = new Byte[max_template_size];
            //Crea un formato(minucia) a partir de la imagen
            m_FPM.CreateTemplate(fp_image, arrayHuella1);
            iError = m_FPM.GetImageEx(fp_image, timeout, pictureBox2.Handle.ToInt32(), quality);
            m_FPM.CreateTemplate(fp_image, arrayHuella2);
            // Match for registration
            bool matched = false;
            SGFPMSecurityLevel secu_level = SGFPMSecurityLevel.NORMAL;
            iError = m_FPM.MatchTemplate(arrayHuella1, arrayHuella2, secu_level, ref matched);
            // MessageBox.Show(iError.ToString());
            m_FPM.CloseDevice();
        }

        public void AutoOn(bool enable,Int32 hwnd) 
        {
            m_FPM.EnableAutoOnEvent(enable,hwnd);
            Int32 port_addr = (Int32)SGFPMPortAddr.USB_AUTO_DETECT;
            Int32 iError = m_FPM.OpenDevice(port_addr);
        }

        public bool MatchTemplate(byte[] m_RegMin1,byte[] m_RegMin2) 
        {
            Inicializar();
            //Escoge el Puerto en el que se ejecuta el dispositivo
            Int32 port_addr = (Int32)SGFPMPortAddr.USB_AUTO_DETECT;
            Int32 iError = m_FPM.OpenDevice(port_addr);
            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                MessageBox.Show("Por favor coloque su dedo en el lector de huellas");

            }
            else
                MessageBox.Show("Error en inicializar SecuGen: " + iError);
            //Obtener Informacion del dispositivo inicializado
            SGFPMDeviceInfoParam pInfo = new SGFPMDeviceInfoParam();
            iError = m_FPM.GetDeviceInfo(pInfo);
            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                // This should be done GetDeviceInfo();
                m_ImageWidth = pInfo.ImageWidth;
                m_ImageHeight = pInfo.ImageHeight;
            }
            Byte[] fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            SGFPMSecurityLevel secu_level = SGFPMSecurityLevel.NORMAL; // Adjust this value according to application type
            bool matched1 = false;
            bool matched2 = false;
            //Step 1: Capture Image
            m_FPM.GetImage(fp_image);
            Int32 max_template_size = 0;
            //Obtiene el maximo tamaño que posee el buffer.
            m_FPM.GetMaxTemplateSize(ref max_template_size);
            arrayHuella1 = new Byte[max_template_size];
            // Step 2: Create Template
            m_FPM.CreateTemplate(fp_image, arrayHuella1);
            // Step 3: Match for verificatation against registered template- m_RegMin1, m_RegMin2
            iError = m_FPM.MatchTemplate(m_RegMin1, arrayHuella1, secu_level, ref matched1);
            iError = m_FPM.MatchTemplate(m_RegMin2, arrayHuella1, secu_level, ref matched2);
            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                if (matched1 & matched2)
                    return true;
                else
                    return false;
            }
            else 
            {
                MessageBox.Show("Error: " + iError.ToString());
                return false;
            }
                
        }


    }
}
