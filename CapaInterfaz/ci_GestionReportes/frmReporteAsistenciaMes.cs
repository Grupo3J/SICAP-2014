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
using CapaLogicaNegocio.cln_GestionReportes;
using CapaDatos;
using System.Globalization;

namespace CapaInterfaz.ci_GestionReportes
{
    public partial class frmReporteAsistenciaMes : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmReporteAsistenciaMes()
        {
            InitializeComponent();
        }
        private string idcalendario;
        private String[] Meses;
        CalendarioLN calendario = new CalendarioLN();
        FaltasLN faltas = new FaltasLN();
        ReportesLN reportes = new ReportesLN();
        DSSeguridad ds = new DSSeguridad();
        CRAsistenciaporMes rpt = new CRAsistenciaporMes();

        private void cmbcalendario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcalendario.SelectedIndex >= 0 && cmbmes.SelectedIndex != -1)
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

        private void cmbmes_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarAsistenciaporMes("");
        }

        private void FiltrarAsistenciaporMes(string valor) 
        {
            if (cmbcalendario.SelectedIndex >= 0 && cmbmes.SelectedIndex != -1)
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
                    List<sp_PersonalporAsistenciaMesResult> lp = reportes.PersonalporAsistenciaMes(idcalendario, date,valor);
                    //MessageBox.Show(""+lp.Count);
                    ds.Clear();
                    foreach (sp_PersonalporAsistenciaMesResult p in lp)
                    {
                        ds.sp_PersonalporAsistenciaMes.Addsp_PersonalporAsistenciaMesRow(p.CEDULA, p.NOMBRE, p.TOTAL_ASISTENCIAS.Value, p.TOTAL_HORAS.Value);
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

        private void frmReporteAsistenciaMes_Load(object sender, EventArgs e)
        {
            //Cargar calendarios en combo
            var linq = (from lp in calendario.ListarCalendario() select lp).ToList();

            foreach (sp_ListarCalendarioResult temp in linq)
            {
                if (!cmbcalendario.Items.Contains(temp.NOMBRE))
                    cmbcalendario.Items.Add(temp.NOMBRE);
            }
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarAsistenciaporMes(txtbuscar.Text);
        }

    }
}