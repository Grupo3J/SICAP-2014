using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Linq;
using CapaLogicaNegocio.cln_GestionPlanificacion;
using CapaLogicaNegocio.cln_GestionAsistencia;
using CapaLogicaNegocio.cln_GestionReportes;
using CapaDatos;

namespace CapaInterfaz.ci_GestionReportes
{
    public partial class frmReporteFaltasRango : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmReporteFaltasRango()
        {
            InitializeComponent();
        }
        private string idcalendario;
        CalendarioLN calendario = new CalendarioLN();
        FaltasLN faltas = new FaltasLN();
        ReportesLN reportes = new ReportesLN();
        DSSeguridad ds = new DSSeguridad();
        CRFaltasporRango rpt = new CRFaltasporRango();
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            //Cargar calendarios en combo
            var linq = (from lp in calendario.ListarCalendario() select lp).ToList();

            foreach (sp_ListarCalendarioResult temp in linq)
            {
                if (!cmbcalendario.Items.Contains(temp.NOMBRE))
                    cmbcalendario.Items.Add(temp.NOMBRE);
            }
        }

        private void cmbcalendario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbcalendario.SelectedIndex >= 0)
            {
                sp_ListarCalendarioResult temp = calendario.ListarCalendario()[cmbcalendario.SelectedIndex];
                idcalendario = temp.IDCALENDARIO;
            }
            else
                MessageBoxEx.Show("Por favor escoja un Calendario");
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (cmbcalendario.SelectedIndex < 0)
                MessageBoxEx.Show("Por favor escoja un Calendario..");
            else
            {
                if (dtiinicio.IsEmpty || dtifin.IsEmpty)
                    MessageBoxEx.Show("Seleccione un Rango de Fechas");
                else
                {
                    //MostrarPersonalFaltasRango(idcalendario, dtiinicio.Value, dtifin.Value);
                    try
                    {
                        List<sp_PersonalporFaltaRangoResult> lp = reportes.PersonalporFaltaRango(idcalendario, dtiinicio.Value,dtifin.Value);
                        //MessageBox.Show(""+lp.Count);
                        ds.Clear();
                        foreach (sp_PersonalporFaltaRangoResult p in lp)
                        {
                            ds.sp_PersonalporFaltaRango.Addsp_PersonalporFaltaRangoRow(p.CEDULA, p.NOMBRE, p.APELLIDO, p.TOTAL_FALTAS.Value, p.JUSTIFICADAS.Value, p.NO_JUSTIFICADAS.Value);
                        }

                        rpt.SetDataSource(ds);

                        crystalReportViewer1.ReportSource = rpt;
                    }
                    catch (Exception men)
                    {
                        MessageBox.Show(men.ToString());
                    }
                }
            }
        }
    }
}