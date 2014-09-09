using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CapaLogicaNegocio.cln_GestionPlanificacion;
using CapaDatos;
using System.Linq;
using CapaLogicaNegocio.cln_GestionAsistencia;
using System.Globalization;

namespace CapaInterfaz.ci_GestionAsistencia.frmDNBFaltas
{
    public partial class frmDNBAdministrarFaltas : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDNBAdministrarFaltas()
        {
            InitializeComponent();
        }
        private string idcalendario;
        CalendarioLN calendario = new CalendarioLN();
        FaltasLN faltas = new FaltasLN();
        private void superTabControl1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {

        }

        private void frmDNBAdministrarFaltas_Load(object sender, EventArgs e)
        {
            toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripcmbcalendario.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;

            //Cargar calendarios en combo
            var linq = (from lp in calendario.ListarCalendario() select lp).ToList();
            foreach (sp_ListarCalendarioResult temp in linq)
            {
                if (!toolStripcmbcalendario.Items.Contains(temp.NOMBRE))
                    toolStripcmbcalendario.Items.Add(temp.NOMBRE);
            }

        }

        private void toolStripcmbcalendario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripcmbcalendario.SelectedIndex >= 0)
            {
                sp_ListarCalendarioResult temp = calendario.ListarCalendario()[toolStripcmbcalendario.SelectedIndex]; 
                idcalendario = temp.IDCALENDARIO;
                dtidia.Value = DateTime.Now;
                MostrarFaltasDia(idcalendario,dtidia.Value);
                String[] Meses = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
                int cuentameses = Math.Abs((temp.FECHAINICIO.Month - temp.FECHAFIN.Month) + 12 * (temp.FECHAINICIO.Year - temp.FECHAFIN.Year));
                for(int i=0;i <= cuentameses ;i++)
                {
                    DateTime currentfecha = temp.FECHAINICIO.AddMonths(i);
                    cmbmes.Items.Add(Meses[currentfecha.Month-1]+" "+currentfecha.Year);
                }
            }
        }

        private void dtidia_ValueChanged(object sender, EventArgs e)
        {
            if (!idcalendario.Equals(null)) 
            {
                MostrarFaltasDia(idcalendario, dtidia.Value);
            }
        }

        private void MostrarFaltasDia(string idcalendario,DateTime fecha)
        {
            //dataGridViewX1.DataSource = null;
            dgvfaltasdia.Columns.Clear();
            dgvfaltasdia.DataSource = faltas.ListarFaltasPersonalDia(idcalendario,fecha);
            dgvfaltasdia.Columns[5].Visible = false;
            dgvfaltasdia.Columns[6].Visible = false;
        }

        private void MostrarFaltasMes(string idcalendario,DateTime fechainicio,DateTime fechafin) 
        {
            dgvfaltasmes.Columns.Clear();
            //dgvfaltasmes.DataSource = fa
        }

        private void superTabControlPanel3_Click(object sender, EventArgs e)
        {

        }


        private void frmDNBAdministrarFaltas_Shown(object sender, EventArgs e)
        {
            // SuperTooltipInfo type describes Super-Tooltip
            //SuperTooltipInfo superTooltip = new SuperTooltipInfo();
            //superTooltip.HeaderText = "Header text";
            //superTooltip.BodyText = "Body text with <strong>text-markup</strong> support. Header and footer support text-markup too.";
            //superTooltip.FooterText = "My footer text";
            System.Windows.Forms.ToolTip men = new System.Windows.Forms.ToolTip();
            men.IsBalloon = true;
            men.Show("Para empezar Seleccione un Calendario...",dtidia,3000);
            //superTooltip1.SetSuperTooltip(toolStripcmbcalendario, superTooltip);
        }

        private void cmbmes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}