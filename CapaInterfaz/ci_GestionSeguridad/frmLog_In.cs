﻿using CapaDatos;
using CapaEntidades.GestionAsistencia;
using CapaEntidades.GestionPersonal;
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
using System.Threading;
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
        }

        AsistenciaLN asistencia = new AsistenciaLN();
        CalendarioLN calendario = new CalendarioLN();
        FaltasLN faltas = new FaltasLN();
        PersonalLN personal = new PersonalLN();
        HuellaLN huella = new HuellaLN();
        ImprevistoLN imprevistos = new ImprevistoLN();
        private SGFingerPrintManager m_FPM = new SGFingerPrintManager();
        private int m_ImageWidth;
        private int m_ImageHeight;
        private Byte[] arrayHuella1;
        List<sp_PersonalporCalendarioResult> personalporc;
        List<sp_ListarHuellaCedulaResult> huellaporc= new List<sp_ListarHuellaCedulaResult>();
        private string idcalendario;
        private Form children;
        DiasAdicionalesLN diasadic = new DiasAdicionalesLN();
        DiaNoLAborableLN diasnolab = new DiaNoLAborableLN();
        List<sp_ListarDiaAdicionalResult> da;
        List<sp_ListarDiaNoLaborablesResult> dnl;

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
            labelX2.Text = DateTime.Now.ToLongDateString(); 
            timer1.Start();

        }

        private void AsistenciaperReader(string cedula)
        {
            try
            {
                frmSICAP2014 frm = (frmSICAP2014)Children;
                Asistencia temp = new Asistencia();
            string id;
            do
            {
                id = GenerarIdAsistencia();
                temp.IdAsistencia = id;
            }
            while (asistencia.existeAsistencia(id));
            DateTime now = DateTime.Now;
            temp.FechaHoraEntrada = now;
            temp.FechaHoraSalida = now;
            temp.HoraMostrada = now;
            temp.IdCalendario = idcalendario;
            temp.Cedula = cedula;

            if (asistencia.ContarAsistenciaPersonal(cedula, DateTime.Now, idcalendario) > 0)
            {
                var linq = asistencia.AsistenciaPersonalDia(cedula, DateTime.Now, idcalendario);
                if (linq.FECHAHORASALIDA == linq.FECHAHORAENTRADA)
                {
                    //ModificarAsistenciaFechaHoraSalida
                    var calen = (from lt in calendario.ListarCalendario() where lt.IDCALENDARIO == idcalendario 
                               select lt).ToList();
                    temp.HoraMostrada = DateTime.Now;
                    if (DateTime.Now.TimeOfDay > calen[0].FECHAFIN.TimeOfDay)
                    {
                        temp.FechaHoraSalida = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, calen[0].FECHAFIN.Hour, calen[0].FECHAFIN.Minute, calen[0].FECHAFIN.Second);
                    }
                    else 
                    {
                        temp.FechaHoraSalida = DateTime.Now;
                    }

                        
                    temp.IdAsistencia = linq.IDASISTENCIA;
                    asistencia.ModificarAsistenciaPersonal(temp);
                    listBox1.Items.Add("---Registrando Salida con Exito");
                    Personal per = personal.getPersonalByced(cedula);
                    frm.balloonTip1.SetBalloonCaption(frm.panelEx1, "Registrando Salida con Exito");
                    frm.balloonTip1.SetBalloonText(frm.panelEx1, per.Nombre + " " + per.Apellido + "\n" + per.Cedula);
                    frm.balloonTip1.CaptionImage = null;
                    frm.balloonTip1.ShowBalloon(frm.panelEx1);
                }
                else
                {
                    //AutoClosingMessageBox.Show("Ya se ha Ingresado Asistencia", "Administrar Asistencia", 700);
                    listBox1.Items.Add("---Ya ha Registrado Asistencia");
                    onePing(1);
                    Personal per = personal.getPersonalByced(cedula);
                    frm.balloonTip1.SetBalloonCaption(frm.panelEx1, "Ya se ha Registrado Asistencia");
                    frm.balloonTip1.SetBalloonText(frm.panelEx1, per.Nombre + " " + per.Apellido + "\n" + per.Cedula);
                    frm.balloonTip1.CaptionImage = null;
                    frm.balloonTip1.ShowBalloon(frm.panelEx1);
                }
            }
            else
            {
                //Imgresar Asistencia Normal
                if (imprevistos.ContarImprevisto(cedula, DateTime.Now, idcalendario) == 0)
                {
                    var calen = (from lt in calendario.ListarCalendario() where lt.IDCALENDARIO == idcalendario 
                               select lt).ToList();
                    DateTime hora =  calen[0].FECHAINICIO;
                    if (DateTime.Now.TimeOfDay > hora.AddMinutes(calen[0].RETRASO.Value).TimeOfDay)
                    {
                        onePing(1);
                        listBox1.Items.Add("---Termino Hora de Registro de Entrada");
                        Personal per = personal.getPersonalByced(cedula);
                        frm.balloonTip1.SetBalloonCaption(frm.panelEx1, "Termino Hora de Registro de Entrada");
                        frm.balloonTip1.SetBalloonText(frm.panelEx1, per.Nombre + " " + per.Apellido + "\n" + per.Cedula);
                        frm.balloonTip1.CaptionImage = null;
                        frm.balloonTip1.ShowBalloon(frm.panelEx1);
                    }
                    else 
                    {
                        asistencia.InsertarAsistencia(temp);
                        onePing(0);
                        listBox1.Items.Add("---Registrando Entrada con Exito");
                        Personal per = personal.getPersonalByced(cedula);
                        frm.balloonTip1.SetBalloonCaption(frm.panelEx1,"Entrada Registrada con Exito");
                        frm.balloonTip1.SetBalloonText(frm.panelEx1,per.Nombre+" "+per.Apellido+"\n"+per.Cedula);
                        frm.balloonTip1.CaptionImage = null;
                        frm.balloonTip1.ShowBalloon(frm.panelEx1);
                    }
                }
                else
                {
                    //AutoClosingMessageBox.Show("Existe un Imprevisto en esta Fecha\nRevise Administracion de Imprevistos", "Administrar Asistencia", 2000);
                    onePing(1);
                    listBox1.Items.Add("---Existe un Imprevisto en esta Fecha");
                    listBox1.Items.Add("---Revise Administración de Imprevistos");
                    Personal per = personal.getPersonalByced(cedula);
                    frm.balloonTip1.SetBalloonCaption(frm.panelEx1, "Existe un Imprevisto en esta Fecha\nRevise Administración de Imprevistos");
                    frm.balloonTip1.SetBalloonText(frm.panelEx1, per.Nombre + " " + per.Apellido + "\n" + per.Cedula);
                    frm.balloonTip1.CaptionImage = null;
                    frm.balloonTip1.ShowBalloon(frm.panelEx1);
                }
            }

            }
            catch(Exception)
            {
            }
            
            MostrarPersonalDia(idcalendario, DateTime.Now);
            try 
            {
                var cont = faltas.ContarFaltaPersonalDia(cedula, DateTime.Now, idcalendario);
                if (cont > 0)
                    faltas.ELiminarFaltaPersonalDia(idcalendario, DateTime.Now, cedula);
                pictureBox4.Image = CapaInterfaz.Properties.Resources.images;
                Thread.Sleep(2000);
                pictureBox4.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Este: "+ex.Message + ex.StackTrace);
            }
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
                        //listBox1.Items.Add("::. Event Finger Placed");
                        pictureBox3.Image = CapaInterfaz.Properties.Resources.buttonwait;
                        pictureBox3.Refresh();
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
                                        listBox1.Items.Add(temp.NOMBRE+" "+temp.APELLIDO+" - "+DateTime.Now.ToShortTimeString());
                                        pictureBox4.Image = Utilities.convertByteToImage(temp.DATAFOTO.ToArray());
                                        pictureBox4.Refresh();
                                        pictureBox3.Image = CapaInterfaz.Properties.Resources.buttonsucess;
                                        pictureBox3.Refresh();
                                        AsistenciaperReader(temp.CEDULA);
                                        break;
                                    }
                                }
                            }
                            if (matched == false)
                            {
                                //AutoClosingMessageBox.Show("Huella No Encontrada", "Administracion de Huellas", 1000);
                                onePing(1);
                                listBox1.Items.Add("::.Huella no Encontrada");
                                pictureBox3.Image = CapaInterfaz.Properties.Resources.buttonfailed;
                                pictureBox3.Refresh();
                            }
                        }
                        //AutoClosingMessageBox.Show("Dedo Aqui :)","Hehehe",100);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Seleccione un Calendario.."+ex.Message+ex.StackTrace);
                    }
                }
                else if (message.WParam.ToInt32() == (Int32)SGFPMAutoOnEvent.FINGER_OFF)
                {
                    //StatusBar.Text = "Device Message: Finger Off";
                    //MessageBox.Show("Here");
                    //AutoClosingMessageBox.Show("Dedo se fue :(", "Hehehe", 100);
                    //listBox1.Items.Add("::. Event Finger Removed");
                    pictureBox3.Image = CapaInterfaz.Properties.Resources.buttonstart;
                    pictureBox3.Refresh();
                    this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
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
            SGFPMSecurityLevel secu_level = SGFPMSecurityLevel.NORMAL; // Adjust this value according to application type
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
            dataGridViewX1.DataSource = asistencia.ListarAsistenciaPersonal(idcalendario, fecha,"");
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

        public void DesactivarAsistencia() 
        {
            m_FPM.EnableAutoOnEvent(true,0);
            m_FPM.CloseDevice();
        }

        public void ActivarAsistencia()
        {
            //Escoge el Puerto en el que se ejecuta el dispositivo
            Int32 port_addr = (Int32)SGFPMPortAddr.USB_AUTO_DETECT;
            Int32 iError = m_FPM.OpenDevice(port_addr);
            m_FPM.EnableAutoOnEvent(true,(int)this.Handle);
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
            m_FPM.CloseDevice();
            if (cmbcalendario.SelectedIndex >= 0)
            {
                sp_ListarCalendarioResult temp = calendario.ListarCalendario()[cmbcalendario.SelectedIndex];
                idcalendario = temp.IDCALENDARIO;
                CargarPersonalporCalendario(idcalendario);
                MostrarPersonalDia(idcalendario, DateTime.Now);
                da = (from lt in diasadic.ListarDiasAdicionales() where lt.IDCALENDARIO == idcalendario select lt).ToList();
                dnl = (from lt in diasnolab.ListarDiasNoLaborables() where lt.IDCALENDARIO == idcalendario select lt).ToList();
            }
            else
                MessageBoxEx.Show("Por favor escoja un Calendario");
            
            if (CompararFechaPlus(DateTime.Now) == false)
            {
                //Tipo de Secugen Fingerprint reader utilizado 
                SGFPMDeviceName device_name = SGFPMDeviceName.DEV_FDU05;
                //Inicializar SGFingerPrintManager para que cargue el driver del dispositivo utilizado
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
        }

        private void CargarPersonalporCalendario(string idcalendario)
        {
            try 
            {
                personalporc = calendario.PersonalporCalendario(idcalendario);
                foreach(sp_PersonalporCalendarioResult temp in personalporc)
                {
                    if (asistencia.ContarAsistenciaPersonal(temp.CEDULA, DateTime.Now, idcalendario) == 0) 
                    {
                        if (imprevistos.ContarImprevisto(temp.CEDULA, DateTime.Now, idcalendario) == 0)
                        {
                            if (faltas.ContarFaltaPersonalDia(temp.CEDULA, DateTime.Now, idcalendario) == 0)
                            {
                                Faltas falt = new Faltas();
                                string id;
                                do
                                {
                                    id = GenerarIdAsistencia();
                                    falt.IdFaltas = id;
                                }
                                while (faltas.ExisteFalta(id));
                                falt.Cedula = temp.CEDULA;
                                falt.Fecha = DateTime.Now;
                                falt.IdCalendario = idcalendario;
                                falt.Justificacion = false;
                                faltas.InsertarFaltas(falt);
                            }
                        }
                        else 
                        {
                            if (faltas.ContarFaltaPersonalDia(temp.CEDULA, DateTime.Now, idcalendario) == 0)
                            {
                                Faltas falt = new Faltas();
                                string id;
                                do
                                {
                                    id = GenerarIdAsistencia();
                                    falt.IdFaltas = id;
                                }
                                while (faltas.ExisteFalta(id));
                                falt.Cedula = temp.CEDULA;
                                falt.Fecha = DateTime.Now;
                                falt.IdCalendario = idcalendario;
                                falt.Justificacion = true;
                                faltas.InsertarFaltas(falt);
                            }
                            else 
                            {
                                Faltas falt = new Faltas();
                                FALTAS f = faltas.ObtenerFaltaPersonalDia(temp.CEDULA,DateTime.Now,idcalendario)[0];
                                falt.IdFaltas = f.IDFALTA;
                                falt.IdCalendario = f.IDCALENDARIO;
                                falt.Fecha = f.FECHA;
                                falt.Cedula = f.CEDULA;
                                falt.Justificacion = true;
                                faltas.ModificarFaltasJustificacion(falt);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBoxEx.Show(ex.Message + ex.StackTrace);
            }
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

        public void Return(string command) 
        {
            if (command == "EXIT")
            {
                this.Show();
                txtLogin.Focus();
            }
            if (command == "LOGOUT")
            {
                panelEx1.Controls.RemoveByKey("fh");
                Discovered();
                panelEx1.Refresh();
                this.Show();
            }
        }

        private string GenerarIdImprevisto()
        {
            Random ran = new Random();
            int num = ran.Next(0000, 1000);
            int num2 = ran.Next(000, 100);
            return "I" + num.ToString() + num2.ToString();
        }

        private string GenerarIdFalta()
        {
            Random ran = new Random();
            int num = ran.Next(0000, 1000);
            int num2 = ran.Next(000, 100);
            return "F" + num.ToString() + num2.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelX2.Text = DateTime.Now.ToLongDateString(); 
        }

        private bool CompararDia(DateTime dia)
        {
            if (da == null || dnl == null)
            {
                return false;
            }
            else
            {
                var linq = (from lt in da where lt.FECHA == dia select lt).Count();
                var linq2 = (from lt in dnl where lt.FECHA == dia select lt).Count();
                if (linq == 0 || linq2 != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private bool CompararFechaPlus(DateTime day)
        {
            if ((day.Date.DayOfWeek == DayOfWeek.Saturday || day.Date.DayOfWeek == DayOfWeek.Sunday))
            {
                if (CompararDia(day.Date) == true)
                {
                    return true;
                }
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

    }
}

