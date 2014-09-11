using CapaDatos;
using CapaEntidades.GestionSeguridad;
using CapaLogicaNegocio.cln_GestionAsistencia;
using CapaLogicaNegocio.cln_GestionPlanificacion;
using CapaLogicaNegocio.cln_GestionReportes;
using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaInterfaz.ci_GestionReportes
{
    public partial class frmReporteAsistenciaDias : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmReporteAsistenciaDias()
        {
            InitializeComponent();
        }
        private string idcalendario;
        CalendarioLN calendario = new CalendarioLN();
        FaltasLN faltas = new FaltasLN();
        ReportesLN reportes = new ReportesLN();
        DSSeguridad ds = new DSSeguridad();
        CRAsistenciaporDia rpt = new CRAsistenciaporDia();
        public void setUser(Usuarios s, Permisos per)
        {
            user = s;
            permiso = per;
        }
        private void frmReporteAsistencia_Load(object sender, EventArgs e)
        {
            //Cargar calendarios en combo
            var linq = (from lp in calendario.ListarCalendario() select lp).ToList();
            foreach (sp_ListarCalendarioResult temp in linq)
            {
                if (!cmbcalendario.Items.Contains(temp.NOMBRE))
                    cmbcalendario.Items.Add(temp.NOMBRE);
            }
        }

        public Usuarios user { get; set; }

        public Permisos permiso { get; set; }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbcalendario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcalendario.SelectedIndex >= 0)
            {
                sp_ListarCalendarioResult temp = calendario.ListarCalendario()[cmbcalendario.SelectedIndex];
                idcalendario = temp.IDCALENDARIO;
                dtidia.Value = DateTime.Now;
            }
            else
                MessageBoxEx.Show("Por favor escoja un Calendario");
        }

        private void dtidia_ValueChanged(object sender, EventArgs e)
        {
            if (cmbcalendario.SelectedIndex >= 0)
            {
                //MostrarFaltasDia(idcalendario, dtidia.Value);
                try
                {
                    List<sp_PersonalporAsistenciaDiaResult> lp = reportes.PersonalporAsistenciaDia(idcalendario, dtidia.Value);
                    //MessageBox.Show(""+lp.Count);
                    ds.Clear();
                    foreach (sp_PersonalporAsistenciaDiaResult p in lp)
                    {
                        ds.sp_PersonalporAsistenciaDia.Addsp_PersonalporAsistenciaDiaRow(p.Nombre,p.HoraEntrada,p.HoraSalida,p.Tiempo.Value,p.FECHAHORAENTRADA,p.FECHAHORASALIDA.Value,p.CEDULA,p.IDCALENDARIO,p.IDASISTENCIA);
                    }
                    rpt.SetDataSource(ds);

                    crystalReportViewer1.ReportSource = rpt;
                }
                catch (Exception men)
                {
                    MessageBox.Show(men.ToString());
                }
            }
            else
            {
                MessageBoxEx.Show("Por favor escoja un Calendario");
            }
        }
    }
}
