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
using CapaEntidades.GestionSeguridad;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Media;

namespace CapaInterfaz.ci_GestionAsistencia.frmDNBAsistencia
{
    public partial class frmDNBAdministrarAsistencia : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDNBAdministrarAsistencia()
        {
            InitializeComponent();
            if(CompararFechaPlus(DateTime.Now)==false)
            {
            //Tipo de Secugen Fingerprint reader utilizado 
            SGFPMDeviceName device_name = SGFPMDeviceName.DEV_FDU05;
            //Inicializar SGFingerPrintManager para que cargue el driver del dispositivo utilizado
            m_FPM = new SGFingerPrintManager();
            m_FPM.Init(device_name);
            //Escoge el Puerto en el que se ejecuta el dispositivo
            Int32 port_addr = (Int32)SGFPMPortAddr.USB_AUTO_DETECT;
            Int32 iError = m_FPM.OpenDevice(port_addr);
            m_FPM.EnableAutoOnEvent(true, (int)this.Handle);
            }
        }

        AsistenciaLN asistencia = new AsistenciaLN();
        CalendarioLN calendario = new CalendarioLN();
        private String[] Meses;
        FaltasLN faltas = new FaltasLN();
        PersonalLN personal = new PersonalLN();
        ImprevistoLN imprevistos = new ImprevistoLN();
        DiasAdicionalesLN diasadic = new DiasAdicionalesLN();
        DiaNoLAborableLN diasnolab = new DiaNoLAborableLN();
        List<sp_ListarDiaAdicionalResult> da;
        List<sp_ListarDiaNoLaborablesResult> dnl;
        
        HuellaLN huella = new HuellaLN();
        private SGFingerPrintManager m_FPM;
        private int m_ImageWidth;
        private int m_ImageHeight;
        private Byte[] arrayHuella1;
        List<sp_PersonalporCalendarioResult> personalporc;
        private string idcalendario;

        public void setUser(Usuarios s, Permisos per)
        {
            user = s;
            permiso = per;
        }

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
            idcalendario = linq[0].IDCALENDARIO;
            dtidia.Value = DateTime.Now;
            CargarPersonalporCalendario(idcalendario);

            MostrarPersonalDia(idcalendario,DateTime.Now);

            Meses = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            int cuentameses = Math.Abs((linq[0].FECHAINICIO.Month - linq[0].FECHAFIN.Month) + 12 * (linq[0].FECHAINICIO.Year - linq[0].FECHAFIN.Year));
            cmbmes.Items.Clear();
            for (int i = 0; i <= cuentameses; i++)
            {
                DateTime currentfecha = linq[0].FECHAINICIO.AddMonths(i);
                cmbmes.Items.Add(Meses[currentfecha.Month - 1] + " " + currentfecha.Year);
            }
            da = (from lt in diasadic.ListarDiasAdicionales() where lt.IDCALENDARIO == idcalendario select lt).ToList();
            dnl = (from lt in diasnolab.ListarDiasNoLaborables() where lt.IDCALENDARIO == idcalendario select lt).ToList();
            
            if (!permiso.Escritura) { toolStrip1.Items.Remove(toolnuevo); }
            if (!permiso.Eliminacion) { toolStrip1.Items.Remove(tooleliminar); }

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
                    bool matched = false;
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
                        AutoClosingMessageBox.Show("Huella No Encontrada", "Administracion de Huellas", 1000);                       
                    }
                      
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
                    AutoClosingMessageBox.Show("Ya se ha Ingresado Asistencia","Administrar Asistencia",700);
                }
            }
            else 
            {
                //Imgresar FAlta Normal
                if (imprevistos.ContarImprevisto(cedula, DateTime.Now, idcalendario) == 0)
                {
                    asistencia.InsertarAsistencia(temp);
                    onePing();
                }                
                else
                {
                AutoClosingMessageBox.Show("Existe un Imprevisto en esta Fecha\nRevise Administracion de Imprevistos","Administrar Asistencia",2000);
                }   
                 
            }
            
            MostrarPersonalDia(idcalendario, DateTime.Now);
            var cont = faltas.ContarFaltaPersonalDia(cedula, DateTime.Now, idcalendario);
            if (cont > 0)
                faltas.ELiminarFaltaPersonalDia(idcalendario, DateTime.Now, cedula);
            
        }

        private void MostrarAsistenciaMes(string idcalendario, DateTime fecha)
        {
            dgvasistenciames.DataSource = asistencia.ListarAsistenciasPersonalMes(idcalendario, fecha);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmDNBEditAsistencia frmasis = new frmDNBEditAsistencia(idcalendario);
            frmasis.ShowDialog();       
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (toolStripcmbcalendario.SelectedIndex == -1 || dataGridViewX1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("Escoja un Calendario");
            }
            else 
            {
                DialogResult dialogResult = MessageBox.Show("Deseea Eliminar la Asistencia\n", "Administración de Asistencias", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    Asistencia temp = new Asistencia();
                    temp.IdAsistencia = dataGridViewX1.CurrentRow.Cells[7].Value.ToString();
                    asistencia.EliminarAsistencia(temp);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                    return;
                }
            }
        }

        private void toolStripcmbcalendario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripcmbcalendario.SelectedIndex >= 0)
            {
                sp_ListarCalendarioResult temp = calendario.ListarCalendario()[toolStripcmbcalendario.SelectedIndex];
                idcalendario = temp.IDCALENDARIO;
                CargarPersonalporCalendario(idcalendario);
                dtidia.Value = DateTime.Now;
                MostrarPersonalDia(idcalendario, dtidia.Value);
                Meses = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
                int cuentameses = Math.Abs((temp.FECHAINICIO.Month - temp.FECHAFIN.Month) + 12 * (temp.FECHAINICIO.Year - temp.FECHAFIN.Year));
                cmbmes.Items.Clear();
                for (int i = 0; i <= cuentameses; i++)
                {
                    DateTime currentfecha = temp.FECHAINICIO.AddMonths(i);
                    cmbmes.Items.Add(Meses[currentfecha.Month - 1] + " " + currentfecha.Year);
                }
                da = (from lt in diasadic.ListarDiasAdicionales() where lt.IDCALENDARIO == idcalendario select lt).ToList();
                dnl = (from lt in diasnolab.ListarDiasNoLaborables() where lt.IDCALENDARIO == idcalendario select lt).ToList();
            }
            else
                MessageBoxEx.Show("Por favor escoja un Calendario");
        }

        private void dtidia_ValueChanged(object sender, EventArgs e)
        {
            MostrarPersonalDia(idcalendario,dtidia.Value);
        }

        private string GenerarIdAsistencia()
        {
            Random ran = new Random();
            int num = ran.Next(0000, 1000);
            int num2 = ran.Next(000, 100);

            string idhuella = "A" + num.ToString() + num2.ToString();
            return idhuella;
        }

        private bool MatchTemplate(byte[] m_RegMin1, byte[] m_RegMin2)
        {
            Int32 iError;// = m_FPM.OpenDevice(port_addr);
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
            Int32 timeout = 1300;
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
                AutoClosingMessageBox.Show("Error: " + iError.ToString(),"Secugen U20",800);
                return false;
            }
        }

        private void MostrarPersonalDia(string calendario, DateTime fecha)
        {
            dataGridViewX1.Columns.Clear();
            dataGridViewX1.DataSource = asistencia.ListarAsistenciaPersonal(idcalendario, fecha);
            dataGridViewX1.Columns[4].Visible = false;
            dataGridViewX1.Columns[5].Visible = false;
            dataGridViewX1.Columns[6].Visible = false;
            dataGridViewX1.Columns[7].Visible = false;
            dataGridViewX1.Columns[8].Visible = false;
        }

        private void MostrarPersonalAsistenciaRango(string idcalendario, DateTime fechainicio, DateTime fechafin)
        {
            dgvasistenciarango.DataSource = asistencia.ListarAsistenciasPersonalRango(idcalendario, fechainicio, fechafin);
        }

        private void CargarPersonalporCalendario(string idcalendario)
        {
            personalporc = calendario.PersonalporCalendario(idcalendario);
        }

        public Usuarios user { get; set; }

        public Permisos permiso { get; set; }

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

        private void dtidia_MonthCalendar_PaintLabel(object sender, DevComponents.Editors.DateTimeAdv.DayPaintEventArgs e)
        {
            DevComponents.Editors.DateTimeAdv.DayLabel day = sender as DevComponents.Editors.DateTimeAdv.DayLabel;
            if (day == null || day.Date == DateTime.MinValue) return;

            // Cross all weekend days and disable selection for them...
            if ((day.Date.DayOfWeek == DayOfWeek.Saturday || day.Date.DayOfWeek == DayOfWeek.Sunday))
            {
                if (CompararDia(day.Date) == true)
                {
                    day.Selectable = false; // Mark label as not selectable...
                    day.TrackMouse = false; // Do not track mouse movement...
                    e.PaintBackground();
                    e.PaintText();
                    Rectangle r = day.Bounds;
                    r.Inflate(-2, -2);
                    SmoothingMode sm = e.Graphics.SmoothingMode;
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawLine(Pens.Red, r.X, r.Y, r.Right, r.Bottom);
                    e.Graphics.DrawLine(Pens.Red, r.Right, r.Y, r.X, r.Bottom);
                    e.Graphics.SmoothingMode = sm;
                    // Ensure that no part is rendered internally by control...
                    e.RenderParts = DevComponents.Editors.DateTimeAdv.eDayPaintParts.None;
                }
            }
        }

        private void dateTimeInput2_MonthCalendar_PaintLabel(object sender, DevComponents.Editors.DateTimeAdv.DayPaintEventArgs e)
        {
            DevComponents.Editors.DateTimeAdv.DayLabel day = sender as DevComponents.Editors.DateTimeAdv.DayLabel;
            if (day == null || day.Date == DateTime.MinValue) return;

            // Cross all weekend days and disable selection for them...
            if ((day.Date.DayOfWeek == DayOfWeek.Saturday || day.Date.DayOfWeek == DayOfWeek.Sunday))
            {
                if (CompararDia(day.Date) == true)
                {
                    day.Selectable = false; // Mark label as not selectable...
                    day.TrackMouse = false; // Do not track mouse movement...
                    e.PaintBackground();
                    e.PaintText();
                    Rectangle r = day.Bounds;
                    r.Inflate(-2, -2);
                    SmoothingMode sm = e.Graphics.SmoothingMode;
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawLine(Pens.Red, r.X, r.Y, r.Right, r.Bottom);
                    e.Graphics.DrawLine(Pens.Red, r.Right, r.Y, r.X, r.Bottom);
                    e.Graphics.SmoothingMode = sm;
                    // Ensure that no part is rendered internally by control...
                    e.RenderParts = DevComponents.Editors.DateTimeAdv.eDayPaintParts.None;
                }
            }
        }

        private void dateTimeInput1_MonthCalendar_PaintLabel(object sender, DevComponents.Editors.DateTimeAdv.DayPaintEventArgs e)
        {
            DevComponents.Editors.DateTimeAdv.DayLabel day = sender as DevComponents.Editors.DateTimeAdv.DayLabel;
            if (day == null || day.Date == DateTime.MinValue) return;

            // Cross all weekend days and disable selection for them...
            if ((day.Date.DayOfWeek == DayOfWeek.Saturday || day.Date.DayOfWeek == DayOfWeek.Sunday))
            {
                if (CompararDia(day.Date) == true)
                {
                    day.Selectable = false; // Mark label as not selectable...
                    day.TrackMouse = false; // Do not track mouse movement...
                    e.PaintBackground();
                    e.PaintText();
                    Rectangle r = day.Bounds;
                    r.Inflate(-2, -2);
                    SmoothingMode sm = e.Graphics.SmoothingMode;
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawLine(Pens.Red, r.X, r.Y, r.Right, r.Bottom);
                    e.Graphics.DrawLine(Pens.Red, r.Right, r.Y, r.X, r.Bottom);
                    e.Graphics.SmoothingMode = sm;
                    // Ensure that no part is rendered internally by control...
                    e.RenderParts = DevComponents.Editors.DateTimeAdv.eDayPaintParts.None;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {}

        public void onePing()
        {
            SystemSounds.Exclamation.Play();
        }

        private void cmbmes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripcmbcalendario.SelectedIndex >= 0)
            {
                char[] delimiterChar = { ' ' };
                string[] words = cmbmes.SelectedItem.ToString().Split(delimiterChar);
                int index = 0;
                foreach (var temp in Meses)
                {
                    index++;
                    if (words[0].Equals(temp))
                        break;
                }
                DateTime date = Convert.ToDateTime("1" + "/" + index.ToString() + "/" + words[1]);
                MostrarAsistenciaMes(idcalendario, date);
            }
            else
            {
                MessageBoxEx.Show("Por favor escoja un Calendario");
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (toolStripcmbcalendario.SelectedIndex < 0)
                MessageBoxEx.Show("Por favor escoja un Calendario..");
            else
            {
                if (dtiinicio.IsEmpty || dtifin.IsEmpty)
                    MessageBoxEx.Show("Seleccione un Rango de Fechas");
                else
                {
                    MostrarPersonalAsistenciaRango(idcalendario, dtiinicio.Value, dtifin.Value);
                }
            }
        }
    }
}

    public class AutoClosingMessageBox
    {
        System.Threading.Timer _timeoutTimer;
        string _caption;
        AutoClosingMessageBox(string text, string caption, int timeout)
        {
            _caption = caption;
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
            MessageBoxEx.Show(text, caption);
        }
        public static void Show(string text, string caption, int timeout)
        {
            new AutoClosingMessageBox(text, caption, timeout);
        }
        void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = FindWindow(null, _caption);
            if (mbWnd != IntPtr.Zero)
                SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            _timeoutTimer.Dispose();
        }
        const int WM_CLOSE = 0x0010;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    }