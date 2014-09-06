using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevComponents.DotNetBar;
using CapaLogicaNegocio.cln_GestionPlanificacion;
using CapaLogicaNegocio.cln_GestionAsistencia;
using SecuGen.FDxSDKPro.Windows;
using CapaEntidades.GestionAsistencia;
using CapaDatos;
using CapaLogicaNegocio.cln_GestionPersonal;

namespace CapaInterfaz.ci_GestionAsistencia.frmDNBAsistencia
{
    public partial class frmDNBAdministrarAsistencia : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDNBAdministrarAsistencia()
        {
            InitializeComponent();
            Inicializar();
            m_FPM.EnableAutoOnEvent(true, (int)this.Handle);
        }

        AsistenciaLN asistencia = new AsistenciaLN();
        CalendarioLN calendario = new CalendarioLN();
        private SGFingerPrintManager m_FPM;
        private int m_ImageWidth;
        private int m_ImageHeight;
        private Byte[] arrayHuella1;

        private void frmDNBAdministrarAsistencia_Load(object sender, EventArgs e)
        {
            toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripcmbcalendario.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            labelX2.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();

           //Cargar calendarios en combo
            var linq = (from lp in calendario.ListarCalendario() select lp).ToList();
            foreach(sp_ListarCalendarioResult temp in linq)
            {
                if (!toolStripcmbcalendario.Items.Contains(temp.NOMBRE))
                    toolStripcmbcalendario.Items.Add(temp.NOMBRE);
            }

            toolStripcmbcalendario.SelectedIndex = 0;
            dataGridViewX1.DataSource = asistencia.ListarAsistenciaPersonal(linq[0].IDCALENDARIO, DateTime.Now);
            dataGridViewX1.Columns[4].Visible = false;
            dataGridViewX1.Columns[5].Visible = false;
            dataGridViewX1.Columns[6].Visible = false;
            dataGridViewX1.Columns[7].Visible = false;
            dataGridViewX1.Columns[8].Visible = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelX2.Text = DateTime.Now.ToLongTimeString(); 
        }

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == (int)SGFPMMessages.DEV_AUTOONEVENT)
            {
                if (message.WParam.ToInt32() == (Int32)SGFPMAutoOnEvent.FINGER_ON)
                {
                    //StatusBar.Text = "Device Message: Finger On";
                    HuellaLN huella = new HuellaLN();
                    bool matched = false;
                    using (CapaDatosDataContext DB = new CapaDatosDataContext())
                    {
                        var linq = (from lq in DB.PERSONAL select lq.CEDULA).ToList();
                        foreach (string temp in linq)
                        {
                            if (matched == true)
                                break;
                            List<sp_ListarHuellaCedulaResult> list = huella.ListarHuella(temp);
                            foreach (sp_ListarHuellaCedulaResult huell in list)
                            {
                                if (MatchTemplate(huell.DATAHUELLA1.ToArray(), huell.DATAHUELLA2.ToArray()))
                                {
                                    matched = true;
                                    AsistenciaperReader(temp);
                                    break;
                                }
                            }

                        }
                    }
                    if (matched == false)
                        MessageBox.Show("Not Matched");
                }
                else if (message.WParam.ToInt32() == (Int32)SGFPMAutoOnEvent.FINGER_OFF)
                {
                    //StatusBar.Text = "Device Message: Finger Off";
                    //MessageBox.Show("Here");
                }
            }
            base.WndProc(ref message);
        }

        private void AsistenciaperReader(string cedula)
        {
            AsistenciaLN asistencia = new AsistenciaLN();
            var linq = (from lp in calendario.ListarCalendario() select lp.IDCALENDARIO).ToList();
            Asistencia temp = new Asistencia();
            temp.IdAsistencia = GenerarIdAsistencia();
            temp.FechaHoraEntrada = DateTime.Now;
            temp.FechaHoraSalida = DateTime.Now;
            temp.IdCalendario = linq[toolStripcmbcalendario.SelectedIndex];
            temp.Cedula = cedula;
            asistencia.InsertarAsistencia(temp);
            MessageBox.Show("Asistencia Ingresada..");
        }

        private string GenerarIdAsistencia()
        {
            Random ran = new Random();
            int num = ran.Next(0000, 1000);
            int num2 = ran.Next(000, 100);

            string idhuella = "A" + num.ToString() + num2.ToString();
            return idhuella;
        }

        private void Inicializar()
        {
            //Tipo de Secugen Fingerprint reader utilizado 
            SGFPMDeviceName device_name = SGFPMDeviceName.DEV_FDU05;
            //Inicializar SGFingerPrintManager para que cargue el driver del dispositivo utilizado
            m_FPM = new SGFingerPrintManager();
            m_FPM.Init(device_name);
            //Escoge el Puerto en el que se ejecuta el dispositivo
            Int32 port_addr = (Int32)SGFPMPortAddr.USB_AUTO_DETECT;
            Int32 iError = m_FPM.OpenDevice(port_addr);
        }

        private bool MatchTemplate(byte[] m_RegMin1, byte[] m_RegMin2)
        {
            //Escoge el Puerto en el que se ejecuta el dispositivo
            Int32 port_addr = (Int32)SGFPMPortAddr.USB_AUTO_DETECT;
            Int32 iError = m_FPM.OpenDevice(port_addr);
            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                //MessageBox.Show("Por favor coloque su dedo en el lector de huellas");
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
            Int32 timeout = 3000;
            Int32 quality = 80;
            //Convierte el huella en una imagen y la presenta en un picturebox
            iError = m_FPM.GetImageEx(fp_image, timeout, 0, quality);
            //Ajusta el brillo a 70
            iError = m_FPM.SetBrightness(70);
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var linq = (from lp in calendario.ListarCalendario() select lp).ToList();
            frmDNBEditAsistencia frmasis = new frmDNBEditAsistencia(linq[toolStripcmbcalendario.SelectedIndex].IDCALENDARIO);
            frmasis.ShowDialog();       
        }


    }
}