using CapaDatos;
using CapaEntidades.GestionAsistencia;
using CapaLogicaNegocio;
using CapaLogicaNegocio.cln_GestionAsistencia;
using CapaLogicaNegocio.cln_GestionPersonal;
using CapaLogicaNegocio.cln_GestionPlanificacion;
using CapaLogicaNegocio.cln_GestionSeguridad;
using DevComponents.DotNetBar;
using SecuGen.FDxSDKPro.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaInterfaz.ci_GestionSeguridad
{
    public partial class frmLog_In : DevComponents.DotNetBar.Metro.MetroForm
    {
     
        public frmLog_In()
        {
            InitializeComponent();
            txtLogin.Focus();
            //Tipo de Secugen Fingerprint reader utilizado 
            SGFPMDeviceName device_name = SGFPMDeviceName.DEV_FDU05;
            //Inicializar SGFingerPrintManager para que cargue el driver del dispositivo utilizado
            m_FPM = new SGFingerPrintManager();
            m_FPM.Init(device_name);
            //Escoge el Puerto en el que se ejecuta el dispositivo
            Int32 port_addr = (Int32)SGFPMPortAddr.USB_AUTO_DETECT;
            Int32 iError = m_FPM.OpenDevice(port_addr);
            m_FPM.EnableAutoOnEvent(true, (int)this.Handle);
            //Obtener Informacion del dispositivo inicializado
            SGFPMDeviceInfoParam pInfo = new SGFPMDeviceInfoParam();
            iError = m_FPM.GetDeviceInfo(pInfo);
            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                // This should be done GetDeviceInfo();
                m_ImageWidth = pInfo.ImageWidth;
                m_ImageHeight = pInfo.ImageHeight;
            }
        }

        AsistenciaLN asistencia = new AsistenciaLN();
        CalendarioLN calendario = new CalendarioLN();
        FaltasLN faltas = new FaltasLN();
        PersonalLN personal = new PersonalLN();
        HuellaLN huella = new HuellaLN();
        ImprevistoLN imprevistos = new ImprevistoLN();
        private SGFingerPrintManager m_FPM;
        private int m_ImageWidth;
        private int m_ImageHeight;
        private Byte[] arrayHuella1;
        List<sp_PersonalporCalendarioResult> personalporc;
        List<sp_ListarHuellaCedulaResult> huellaporc= new List<sp_ListarHuellaCedulaResult>();
        private string idcalendario;
        private Form children;

        public Form Children
        {
            get { return children; }
            set { children = value; }
        }

        public static string IdUsuario="";

        private void frmLog_In_Load(object sender, EventArgs e)
        {
            //Cargar calendarios en combo
            var linq = (from lp in calendario.ListarCalendario() select lp).ToList();
            foreach (sp_ListarCalendarioResult temp in linq)
            {
                if (!cmbcalendario.Items.Contains(temp.NOMBRE))
                    cmbcalendario.Items.Add(temp.NOMBRE);
            }
        }

        private void AsistenciaperReader(string cedula)
        {
            Asistencia temp = new Asistencia();
            temp.IdAsistencia = GenerarIdAsistencia();
            temp.FechaHoraEntrada = DateTime.Now;
            temp.FechaHoraSalida = DateTime.Now;
            temp.IdCalendario = idcalendario;
            temp.Cedula = cedula;

            if (asistencia.ContarAsistenciaPersonal(cedula, DateTime.Now, idcalendario) > 0)
            {
                var linq = asistencia.AsistenciaPersonalDia(cedula, DateTime.Now, idcalendario);
                if (linq.FECHAHORASALIDA == linq.FECHAHORAENTRADA)
                {
                    //ModificarAsistenciaFechaHoraSalida
                    temp.FechaHoraSalida = DateTime.Now;
                    temp.IdAsistencia = linq.IDASISTENCIA;
                    asistencia.ModificarAsistenciaPersonal(temp);
                }
                else
                {
                    //AutoClosingMessageBox.Show("Ya se ha Ingresado Asistencia", "Administrar Asistencia", 700);
                    onePing(1);
                }
            }
            else
            {
                //Imgresar FAlta Normal
                if (imprevistos.ContarImprevisto(cedula, DateTime.Now, idcalendario) == 0)
                {
                    asistencia.InsertarAsistencia(temp);
                    onePing(0);
                }
                else
                {
                    //AutoClosingMessageBox.Show("Existe un Imprevisto en esta Fecha\nRevise Administracion de Imprevistos", "Administrar Asistencia", 2000);
                    onePing(1);
                }
            }

            MostrarPersonalDia(idcalendario, DateTime.Now);
            var cont = faltas.ContarFaltaPersonalDia(cedula, DateTime.Now, idcalendario);
            if (cont > 0)
                faltas.ELiminarFaltaPersonalDia(idcalendario, DateTime.Now, cedula);

        }

        protected override void WndProc(ref Message message)
        {   
            if (message.Msg == (int)SGFPMMessages.DEV_AUTOONEVENT)
            {
                if (message.WParam.ToInt32() == (Int32)SGFPMAutoOnEvent.FINGER_ON)
                {
                    try 
                    {
                        ////StatusBar.Text = "Device Message: Finger On";
                        bool matched = false;
                        if (cmbcalendario.SelectedIndex!=-1 ) 
                        {
                            List<sp_ListarHuellaCedulaResult> list;
                            foreach (sp_PersonalporCalendarioResult temp in personalporc)
                            {
                                if (matched == true)
                                    break;
                                list = huella.ListarHuella(temp.CEDULA);
                                foreach (sp_ListarHuellaCedulaResult huell in list)
                                {
                                    if (MatchTemplate(huell.DATAHUELLA1.ToArray(), huell.DATAHUELLA2.ToArray()))
                                    {
                                        matched = true;
                                        AsistenciaperReader(temp.CEDULA);
                                        break;
                                    }
                                }
                            }
                            if (matched == false)
                            {
                                //AutoClosingMessageBox.Show("Huella No Encontrada", "Administracion de Huellas", 1000);
                                onePing(1);
                            }
                        }
                        //AutoClosingMessageBox.Show("Dedo Aqui :)","Hehehe",100);
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Seleccione un Calendario..");
                    }
                }
                else if (message.WParam.ToInt32() == (Int32)SGFPMAutoOnEvent.FINGER_OFF)
                {
                    //StatusBar.Text = "Device Message: Finger Off";
                    //MessageBox.Show("Here");
                    //AutoClosingMessageBox.Show("Dedo se fue :(", "Hehehe", 100);
                }
            }

            base.WndProc(ref message);
        }

        private string GenerarIdAsistencia()
        {
            Random ran = new Random();
            int num = ran.Next(00000, 10000);
            int num2 = ran.Next(000, 100);

            string idhuella = "A" + num.ToString() + num2.ToString();
            return idhuella;
        }

        private bool MatchTemplate(byte[] m_RegMin1, byte[] m_RegMin2)
        {
            Int32 iError;
            Byte[] fp_image = new Byte[m_ImageWidth * m_ImageHeight];
            SGFPMSecurityLevel secu_level = SGFPMSecurityLevel.LOWEST; // Adjust this value according to application type
            bool matched1 = false;
            bool matched2 = false;
            //Convierte el huella en una imagen y la presenta en un picturebox
            iError = m_FPM.GetImage(fp_image);
            if (iError == (Int32)SGFPMError.ERROR_NONE)
            {
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                DrawImage(fp_image, pictureBox2);
            }
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
                //AutoClosingMessageBox.Show("Error: " + iError.ToString(), "Secugen U20", 800);
                return false;
            }
        }

        private void MostrarPersonalDia(string calendario, DateTime fecha)
        {
            dataGridViewX1.Columns.Clear();
            dataGridViewX1.DataSource = asistencia.ListarAsistenciaPersonal(idcalendario, fecha);
            foreach(DataGridViewRow temp in dataGridViewX1.Rows)
            {
                if (Convert.ToDateTime(temp.Cells[1].Value) == Convert.ToDateTime(temp.Cells[2].Value)) 
                {
                    temp.Cells[2].Value = "-";
                    temp.Cells[3].Value = "0";
                }
            }
            dataGridViewX1.Columns[4].Visible = false;
            dataGridViewX1.Columns[5].Visible = false;
            dataGridViewX1.Columns[6].Visible = false;
            dataGridViewX1.Columns[7].Visible = false;
            dataGridViewX1.Columns[8].Visible = false;
        }

        public void onePing(int num)
        {
            if(num==0)
                SystemSounds.Exclamation.Play();
            else
                SystemSounds.Asterisk.Play();
        }

        private void Hidden()
        {
            label1.Visible = false;
            label3.Visible = false;
            label6.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            pictureBox1.Visible = false;
            txtLogin.Visible = false;
            txtClave.Visible = false;
            Acceder.Visible = false;
        }

        private void Discovered() 
        {
            label1.Visible = true;
            label3.Visible = true;
            label6.Visible = true;
            label2.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            pictureBox1.Visible = true;
            txtLogin.Visible = true;
            txtClave.Visible = true;
            Acceder.Visible = true;
        }
        
        private void addPanel(object form)
        {
            Form fh = form as Form;
            fh.Name = "fh";
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelEx1.Controls.Add(fh);
            this.panelEx1.Tag = fh;
            fh.Show();
        }

        private void Acceder_Click(object sender, EventArgs e)
        {
            verificaeingresa();
        }
       
        private void verificaeingresa()
        {
            Sistema sit = new Sistema();
            UsuariosLN USLN = new UsuariosLN();

            if (sit.Login(txtLogin.Text, txtClave.Text))
            {
                frmSICAP2014 fp = new frmSICAP2014(this);
                fp.user = USLN.getUserbyced(sit.Cedula);
                frmUsuarioLogged frm = new frmUsuarioLogged(fp.user,Children,this);                
                Hidden();
                addPanel(frm);
                this.Hide();
                txtLogin.Text = "";
                txtClave.Text = "";
                fp.Show();
                //frmSICAP2014 k = new frmSICAP2014();
                // k.user = USLN.getUserbyced(sit.Cedula);
                //k.Show();
            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(this,"Nombre de Usuario o Clave incorrectas vuelve a intentarlo","Acceso Denegado",MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

        private void txtcontrasekeydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                verificaeingresa();

            }
        }

        private void cmbcalendario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcalendario.SelectedIndex >= 0)
            {
                sp_ListarCalendarioResult temp = calendario.ListarCalendario()[cmbcalendario.SelectedIndex];
                idcalendario = temp.IDCALENDARIO;
                CargarPersonalporCalendario(idcalendario);
                MostrarPersonalDia(idcalendario, DateTime.Now);
            }
            else
                MessageBoxEx.Show("Por favor escoja un Calendario");
        }

        private void CargarPersonalporCalendario(string idcalendario)
        {
            try 
            {
                personalporc = calendario.PersonalporCalendario(idcalendario);
            }
            catch(Exception){}
        }

        ~frmLog_In() 
        {
            m_FPM.CloseDevice();
        }

        private void DrawImage(Byte[] imgData, PictureBox picBox)
        {
            int colorval;
            Bitmap bmp = new Bitmap(m_ImageWidth, m_ImageHeight);
            picBox.Image = (Image)bmp;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    colorval = (int)imgData[(j * m_ImageWidth) + i];
                    bmp.SetPixel(i, j, Color.FromArgb(colorval, colorval, colorval));
                }
            }
            picBox.Refresh();
        }

        public void Return() 
        {
            frmSICAP2014 fp = (frmSICAP2014)children;
            if (fp.OPTION == "EXIT")
            {
                this.Show();
                txtLogin.Focus();
            }
            if (fp.OPTION == "LOGOUT")
            {
                panelEx1.Controls.RemoveByKey("fh");
                Discovered();
                panelEx1.Refresh();
                this.Show();
            }
        }
    }
}

