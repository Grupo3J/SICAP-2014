using CapaDatos;
using CapaLogicaNegocio.cln_GestionAsistencia;
using CapaLogicaNegocio.cln_GestionPlanificacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SecuGen.FDxSDKPro.Windows;
using CapaLogicaNegocio.cln_GestionPersonal;
using CapaEntidades.GestionAsistencia;

namespace CapaInterfaz.ci_GestionAsistencia.frmAsistencia
{
    public partial class frmAdministrarAsistencia : Form
    {
        public frmAdministrarAsistencia()
        {
            InitializeComponent();
            secugen.Inicializar();
            secugen.AutoOn(true,(int)this.Handle);
        }
        Secugen secugen = new Secugen();
        AsistenciaLN asistencia = new AsistenciaLN();
        CalendarioLN calendario = new CalendarioLN();

        private void frmAdministrarAsistencia_Load(object sender, EventArgs e)
        {
            //Cargar calendarios en combo
            var linq = (from lp in calendario.ListarCalendario() select lp).ToList();
            foreach(pa_ListarCalendarioResult temp in linq)
            {
                if (!toolStripcmbCalendario.Items.Contains(temp.NOMBRE))
                    toolStripcmbCalendario.Items.Add(temp.NOMBRE);
            }

            toolStripcmbCalendario.SelectedIndex = 0;
            toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripcmbTipo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            label2.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();

            dataGridView1.DataSource = asistencia.ListarAsistenciaPersonal(linq[0].IDCALENDARIO,DateTime.Now);
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
        }


        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString(); 
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var linq = (from lp in calendario.ListarCalendario() select lp).ToList();
            frmEditAsistencia frmasis = new frmEditAsistencia(linq[toolStripcmbCalendario.SelectedIndex].IDCALENDARIO);
            frmasis.ShowDialog();           
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
                    using(CapaDatosDataContext DB = new CapaDatosDataContext())
                    {
                        var linq = (from lq in DB.PERSONAL select lq.CEDULA).ToList();
                        foreach(string temp in linq)
                        {
                            if (matched == true)
                                break;
                            List<pa_ListarHuellaCedulaResult> list = huella.ListarHuella(temp);
                            foreach(pa_ListarHuellaCedulaResult huell in list)
                            {
                                if (secugen.MatchTemplate(huell.DATAHUELLA1.ToArray(), huell.DATAHUELLA2.ToArray())) 
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
                    MessageBox.Show("Here");
                }
            }
            base.WndProc(ref message);
        }

        private void AsistenciaperReader(string cedula) 
        {
            AsistenciaLN asistencia = new AsistenciaLN();
            var linq = (from lp in calendario.ListarCalendario() select lp).ToList();
            Asistencia temp = new Asistencia();
            temp.IdAsistencia = GenerarIdAsistencia();
            temp.FechaHoraEntrada = DateTime.Now;
            temp.FechaHoraSalida = DateTime.Now;
            temp.IdCalendario = linq[toolStripcmbCalendario.SelectedIndex].IDCALENDARIO;
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
        
    }
}
