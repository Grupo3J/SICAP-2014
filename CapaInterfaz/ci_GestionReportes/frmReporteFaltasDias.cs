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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaInterfaz.ci_GestionReportes
{
    public partial class frmReporteFaltasDias : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmReporteFaltasDias()
        {
            InitializeComponent();
        }
        private string idcalendario;
        CalendarioLN calendario = new CalendarioLN();
        FaltasLN faltas = new FaltasLN();
        ReportesLN reportes = new ReportesLN();
        DSSeguridad ds = new DSSeguridad();
        CRFaltasporDia rpt = new CRFaltasporDia();
        public void setUser(Usuarios s, Permisos per)
        {
            user = s;
            permiso = per;
        }
        private void frmReporteFaltas_Load(object sender, EventArgs e)
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
                    List<sp_PersonalporFaltaDiaResult> lp = reportes.PersonalporFaltaDia(idcalendario,dtidia.Value);
                    //MessageBox.Show(""+lp.Count);
                    ds.Clear();
                    foreach (sp_PersonalporFaltaDiaResult p in lp)
                    {
                        ds.sp_PersonalporFaltaDia.Addsp_PersonalporFaltaDiaRow(p.IDFALTA,p.NOMBRE, p.APELLIDO,p.FECHA,p.JUSTIFICACION,p.IDCALENDARIO,p.CEDULA);
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
