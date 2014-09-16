using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevComponents.DotNetBar;
using CapaLogicaNegocio.cln_GestionReportes;
using CapaLogicaNegocio.cln_GestionAsistencia;
using CapaLogicaNegocio.cln_GestionPlanificacion;
using CapaDatos;

namespace CapaInterfaz.ci_GestionReportes
{
    public partial class frmReporteAsistenciaRango : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmReporteAsistenciaRango()
        {
            InitializeComponent();
        }
        private string idcalendario;
        CalendarioLN calendario = new CalendarioLN();
        FaltasLN faltas = new FaltasLN();
        ReportesLN reportes = new ReportesLN();
        DSSeguridad ds = new DSSeguridad();
        CRAsistenciaporRango rpt = new CRAsistenciaporRango();
        
        private void buttonX1_Click(object sender, EventArgs e)
        {
            FiltrarAsistenciaRango("");
        }

        private void FiltrarAsistenciaRango(string valor) 
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
                        List<sp_PersonalporAsistenciaRangoResult> lp = reportes.PersonalporAsistenciaRango(idcalendario, dtiinicio.Value, dtifin.Value,valor);
                        //MessageBox.Show(""+lp.Count);
                        ds.Clear();
                        foreach (sp_PersonalporAsistenciaRangoResult p in lp)
                        {
                            ds.sp_PersonalporAsistenciaRango.Addsp_PersonalporAsistenciaRangoRow(p.CEDULA, p.NOMBRE,p.TOTAL_ASISTENCIAS.Value,p.TOTAL_HORAS.Value);
                        }

                        rpt.SetDataSource(ds);
                        crystalReportViewer1.ReportSource = rpt;
                        txtbuscar.Focus();
                    }
                    catch (Exception men)
                    {
                        MessageBox.Show(men.ToString());
                    }
                }
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

        private void frmReporteAsistenciaRango_Load(object sender, EventArgs e)
        {
            //Cargar calendarios en combo
            var linq = (from lp in calendario.ListarCalendario() select lp).ToList();

            foreach (sp_ListarCalendarioResult temp in linq)
            {
                if (!cmbcalendario.Items.Contains(temp.NOMBRE))
                    cmbcalendario.Items.Add(temp.NOMBRE);
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarAsistenciaRango(txtbuscar.Text);
            txtbuscar.Focus();
        }
    }
}