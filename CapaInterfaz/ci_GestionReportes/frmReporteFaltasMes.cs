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
    public partial class frmReporteFaltasMes : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmReporteFaltasMes()
        {
            InitializeComponent();
        }

        private string idcalendario;
        private String[] Meses;
        CalendarioLN calendario = new CalendarioLN();
        FaltasLN faltas = new FaltasLN();
        ReportesLN reportes = new ReportesLN();
        DSSeguridad ds = new DSSeguridad();
        CRFaltasporMes rpt = new CRFaltasporMes();
        public void setUser(Usuarios s, Permisos per)
        {
            user = s;
            permiso = per;
        }
        private void frmReporteImprevistos_Load(object sender, EventArgs e)
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

        private void cmbmes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcalendario.SelectedIndex >= 0)
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
                try
                {
                    List<sp_PersonalporFaltaMesResult> lp = reportes.PersonalporFaltaMes(idcalendario,date);
                    //MessageBox.Show(""+lp.Count);
                    ds.Clear();
                    foreach (sp_PersonalporFaltaMesResult p in lp)
                    {
                        ds.sp_PersonalporFaltaMes.Addsp_PersonalporFaltaMesRow(p.CEDULA, p.NOMBRE, p.APELLIDO, p.TOTAL_FALTAS.Value, p.JUSTIFICADAS.Value, p.NO_JUSTIFICADAS.Value);
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

        private void cmbcalendario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcalendario.SelectedIndex >= 0)
            {
                sp_ListarCalendarioResult temp = calendario.ListarCalendario()[cmbcalendario.SelectedIndex];
                idcalendario = temp.IDCALENDARIO;
                Meses = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
                int cuentameses = Math.Abs((temp.FECHAINICIO.Month - temp.FECHAFIN.Month) + 12 * (temp.FECHAINICIO.Year - temp.FECHAFIN.Year));
                cmbmes.Items.Clear();
                for (int i = 0; i <= cuentameses; i++)
                {
                    DateTime currentfecha = temp.FECHAINICIO.AddMonths(i);
                    cmbmes.Items.Add(Meses[currentfecha.Month - 1] + " " + currentfecha.Year);
                }
                cmbmes.SelectedIndex = 0;
            }
            else
                MessageBoxEx.Show("Por favor escoja un Calendario");
        }
    }
}
