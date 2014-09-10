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
using CapaEntidades.GestionAsistencia;
using CapaLogicaNegocio.cln_GestionPersonal;

namespace CapaInterfaz.ci_GestionAsistencia.frmDNBFaltas
{
    public partial class frmDNBAdministrarFaltas : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDNBAdministrarFaltas()
        {
            InitializeComponent();
        }
        private string idcalendario;
        private String[] Meses;
        CalendarioLN calendario = new CalendarioLN();
        FaltasLN faltas = new FaltasLN();
        Faltas falta = new Faltas();
        PersonalLN personal = new PersonalLN();

        private void superTabControl1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            if (superTabControl1.SelectedTabIndex != 0)
            {
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton3.Visible = false;
            }
            else
            {
                toolStripButton1.Visible = true;
                toolStripButton2.Visible = true;
                toolStripButton3.Visible = true;
            }
        }

        private void frmDNBAdministrarFaltas_Load(object sender, EventArgs e)
        {
            toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripcmbcalendario.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;

            //Cargar calendarios en combo
            var linq = (from lp in calendario.ListarCalendario() select lp).ToList();
            dtiinicio.AllowEmptyState = true;
            dtifin.AllowEmptyState = true;
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
                MostrarFaltasDia(idcalendario, dtidia.Value);
                Meses = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
                int cuentameses = Math.Abs((temp.FECHAINICIO.Month - temp.FECHAFIN.Month) + 12 * (temp.FECHAINICIO.Year - temp.FECHAFIN.Year));
                cmbmes.Items.Clear();
                for (int i = 0; i <= cuentameses; i++)
                {
                    DateTime currentfecha = temp.FECHAINICIO.AddMonths(i);
                    cmbmes.Items.Add(Meses[currentfecha.Month - 1] + " " + currentfecha.Year);
                }
            }
            else 
                MessageBoxEx.Show("Por favor escoja un Calendario");
        }

        private void dtidia_ValueChanged(object sender, EventArgs e)
        {
            if (toolStripcmbcalendario.SelectedIndex >= 0)
            {
                MostrarFaltasDia(idcalendario, dtidia.Value);
            }
            else 
            {
                MessageBoxEx.Show("Por favor escoja un Calendario");
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

        private void MostrarFaltasMes(string idcalendario,DateTime fecha) 
        {
            dgvfaltasmes.DataSource = faltas.ListarFaltasPersonalMes(idcalendario,fecha);
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
                MostrarFaltasMes(idcalendario, date);
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
                    MostrarPersonalFaltasRango(idcalendario, dtiinicio.Value, dtifin.Value);
                }

            }
        }

        private void MostrarPersonalFaltasRango(string idcalendario,DateTime fechainicio,DateTime fechafin) 
        {
            dgvfaltasrango.DataSource = faltas.ListarFaltasPersonalRango(idcalendario,fechainicio,fechafin);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmDNBEditFalta impr = new frmDNBEditFalta(idcalendario);
            impr.ShowDialog();
            if (impr.OPTION == "OK" && toolStripcmbcalendario.SelectedIndex >= 0)
            {
                try
                {
                    falta.IdFaltas= GenerarIdFalta();
                    falta.Fecha  = impr.dtifecha.Value;
                    falta.Cedula = impr.txtcedula.Text;
                    falta.IdCalendario = idcalendario;
                    falta.Justificacion = impr.checkBoxX1.Checked == true?true:false;
                    faltas.InsertarFaltas(falta);
                    faltas.EliminarAsistenciainterfFalta(impr.txtcedula.Text,impr.dtifecha.Value,idcalendario);
                    MostrarFaltasDia(idcalendario,dtidia.Value);
                }
                catch (Exception mes)
                {
                    MessageBox.Show(mes.Message);
                }
            }
        }

        private string GenerarIdFalta()
        {
            Random ran = new Random();
            int num = ran.Next(0000, 1000);
            int num2 = ran.Next(000, 100);
            return "I" + num.ToString() + num2.ToString();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmDNBEditFalta impr = new frmDNBEditFalta(idcalendario);
            var linq = personal.getPersonalByced(dgvfaltasdia.CurrentRow.Cells[6].Value.ToString());
            impr.cmbTipo.SelectedText = linq.Tipo;
            impr.txtcedula.Text = linq.Cedula;
            impr.txtcedula.ReadOnly = true;
            impr.txtnombre.Text = linq.Nombre;
            impr.txtnombre.ReadOnly = true;
            impr.txtcargo.Text = linq.Cargo;
            impr.txtcargo.ReadOnly = true;
            impr.dtifecha.Value = Convert.ToDateTime(dgvfaltasdia.CurrentRow.Cells[3].Value.ToString());
            impr.dtifecha.IsInputReadOnly = true;
            impr.checkBoxX1.Checked = dgvfaltasdia.CurrentRow.Cells[4].Value.ToString().ToLower() == "false" ? false : true;
            impr.pictureBox1.Image = Utilities.convertByteToImage(linq.DataFoto.ToArray());
            impr.ShowDialog();
            if (impr.OPTION == "OK" && toolStripcmbcalendario.SelectedIndex >= 0)
            {
                try
                {
                    falta.IdFaltas = dgvfaltasdia.CurrentRow.Cells[0].Value.ToString();
                    falta.Fecha = impr.dtifecha.Value;
                    falta.Cedula = impr.txtcedula.Text;
                    falta.IdCalendario = idcalendario;
                    falta.Justificacion = impr.checkBoxX1.Checked == false ? false : true;
                    faltas.ModificarFaltasJustificacion(falta);
                    MostrarFaltasDia(idcalendario, dtidia.Value);
                }
                catch (Exception mes)
                {
                    MessageBox.Show(mes.Message);
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dgvfaltasdia.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Deseea Eliminar la Falta\n", "Administración de Faltas", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                    faltas.EliminarFaltaId(dgvfaltasdia.CurrentRow.Cells[0].Value.ToString());
                    MostrarFaltasDia(idcalendario,dtidia.Value);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                    return;
                }

            }
        }

    }
}