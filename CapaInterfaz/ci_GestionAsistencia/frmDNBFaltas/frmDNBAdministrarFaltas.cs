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
using System.Drawing.Drawing2D;
using CapaEntidades.GestionSeguridad;

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
        ImprevistoLN imprevistos = new ImprevistoLN();
        DiasAdicionalesLN diasadic = new DiasAdicionalesLN();
        DiaNoLAborableLN diasnolab = new DiaNoLAborableLN();
        List<sp_ListarDiaAdicionalResult> da;
        List<sp_ListarDiaNoLaborablesResult> dnl;
        public void setUser(Usuarios s, Permisos per)
        {
            user = s;
            permiso = per;
        }

        private void superTabControl1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            if (superTabControl1.SelectedTabIndex != 0)
            {
                toolnuevo.Visible = false;
                tooleliminar.Visible = false;
                toolmodificar.Visible = false;
            }
            else
            {
                toolnuevo.Visible = true;
                tooleliminar.Visible = true;
                toolmodificar.Visible = true;
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
            if (!permiso.Escritura) { toolStrip1.Items.Remove(toolnuevo); }
            if (!permiso.Eliminacion) { toolStrip1.Items.Remove(tooleliminar); }
            if (!permiso.Modificacion) { toolStrip1.Items.Remove(toolmodificar); }
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
                da = (from lt in diasadic.ListarDiasAdicionales() where lt.IDCALENDARIO==idcalendario select lt).ToList();
                dnl = (from lt in diasnolab.ListarDiasNoLaborables() where lt.IDCALENDARIO == idcalendario select lt).ToList();
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
                    string id;
                    do
                    {
                        id = GenerarIdFalta();
                        falta.IdFaltas = id;
                    }
                    while (faltas.ExisteFalta(id));
                        
                    falta.Fecha  = impr.dtifecha.Value;
                    falta.Cedula = impr.txtcedula.Text;
                    falta.IdCalendario = idcalendario;
                    falta.Justificacion = impr.checkBoxX1.Checked == true?true:false;
                    
                    int num = imprevistos.ContarImprevisto(falta.Cedula, falta.Fecha, falta.IdCalendario);
                    AsistenciaLN asistencia = new AsistenciaLN();

                    if (num == 0)
                    {
                        if (asistencia.ContarAsistenciaPersonal(falta.Cedula, falta.Fecha, falta.IdCalendario) == 0)
                        {
                            var linq = (from lt in calendario.ListarCalendario()
                                           where lt.IDCALENDARIO == falta.IdCalendario
                                           select lt).ToList();
                            if (falta.Fecha >= linq[0].FECHAINICIO && falta.Fecha < linq[0].FECHAFIN)
                            {
                                var imprev = (from lt in faltas.ListarFaltasPersonalDia(idcalendario,falta.Fecha)
                                              where lt.CEDULA == falta.Cedula && lt.FECHA.Day == falta.Fecha.Day && lt.FECHA.Month == falta.Fecha.Month && lt.FECHA.Year == falta.Fecha.Year
                                              select lt).Count();
                                if (imprev == 0)
                                    faltas.InsertarFaltas(falta);    
                                else
                                    MessageBoxEx.Show(this, "Ya Existe un Falta en esa Fecha", "Administración de Faltas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else 
                            {
                                MessageBoxEx.Show(this,"La Fecha Establecida no esta en el Rango del Calendario","Administrar Faltas",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            DialogResult dialogResult = MessageBoxEx.Show("Ya Existe una Asistencia en esa Fecha\nDeseea Ingresar la Falta de Todos Modos\nEsta Operacion Borrar el Registro de Asistencia", "Administración de Faltas", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                //do something
                                faltas.EliminarAsistenciainterfFalta(impr.txtcedula.Text, impr.dtifecha.Value, idcalendario);
                                faltas.InsertarFaltas(falta);
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                //do something else
                                return;
                            }
                        }
                    }
                    else
                        MessageBoxEx.Show("El personal seleccionado posee un Imprevisto en esa fecha\nNo se puede agregar la falta");

                    MostrarFaltasDia(idcalendario, dtidia.Value);
                    
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
            if (toolStripcmbcalendario.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Por favor Seleccione un Calendario");
            }
            else 
            {
                frmDNBEditFalta impr = new frmDNBEditFalta(idcalendario);
                var linq = personal.getPersonalByced(dgvfaltasdia.CurrentRow.Cells[6].Value.ToString());
                impr.cmbTipo.SelectedText = linq.Tipo;
                impr.buttonX3.Enabled = false;
                impr.buttonX4.Enabled = false;
                impr.txtcedula.Text = linq.Cedula;
                impr.txtcedula.ReadOnly = true;
                impr.txtnombre.Text = linq.Nombre;
                impr.txtnombre.ReadOnly = true;
                impr.txtcargo.Text = linq.Cargo;
                impr.txtcargo.ReadOnly = true;
                impr.dtifecha.Value = Convert.ToDateTime(dgvfaltasdia.CurrentRow.Cells[3].Value.ToString());
                impr.dtifecha.ButtonDropDown.Enabled = false;
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

        private void dtidia_MonthCalendar_PaintLabel(object sender, DevComponents.Editors.DateTimeAdv.DayPaintEventArgs e)
        {
            
            DevComponents.Editors.DateTimeAdv.DayLabel day = sender as DevComponents.Editors.DateTimeAdv.DayLabel;
            if (day == null || day.Date == DateTime.MinValue) return;

            // Cross all weekend days and disable selection for them...
            if ((day.Date.DayOfWeek == DayOfWeek.Saturday || day.Date.DayOfWeek == DayOfWeek.Sunday))
            {
                if (CompararDia(day.Date)==true)
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


        private void dtiinicio_MonthCalendar_PaintLabel(object sender, DevComponents.Editors.DateTimeAdv.DayPaintEventArgs e)
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

        private void dtifin_MonthCalendar_PaintLabel(object sender, DevComponents.Editors.DateTimeAdv.DayPaintEventArgs e)
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

        public Usuarios user { get; set; }

        public Permisos permiso { get; set; }
    }
}