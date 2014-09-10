using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CapaLogicaNegocio.cln_GestionPersonal;
using CapaDatos;
using System.Linq;
using System.Drawing.Drawing2D;
using CapaLogicaNegocio.cln_GestionPlanificacion;

namespace CapaInterfaz.ci_GestionAsistencia.frmDNBImprevistos
{
    public partial class frmDNBEditImprevisto : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDNBEditImprevisto(string idcalendario)
        {
            frmDNBEditImprevisto.idcalendario = idcalendario;
            InitializeComponent();
        }
        public string OPTION = "";
        public bool tipo = true;
        private PersonalLN personal = new PersonalLN();
        public static string idcalendario;
        public List<sp_PersonalporCalendarioResult> listader= new List<sp_PersonalporCalendarioResult>();
        public List<sp_PersonalporCalendarioResult> listaizq = new List<sp_PersonalporCalendarioResult>();
        DiasAdicionalesLN diasadic = new DiasAdicionalesLN();
        DiaNoLAborableLN diasnolab = new DiaNoLAborableLN();
        List<sp_ListarDiaAdicionalResult> da;
        List<sp_ListarDiaNoLaborablesResult> dnl;

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text == "" || dataGridViewX2.Rows.Count == 0 || dtifechainicio.IsEmpty == true || dtihorafin.IsEmpty == true)
            {
                MessageBox.Show("Ingrese los campos obligatorios","Alerta",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else 
            {
                OPTION = "OK";
                this.Close();
            }
        }

        private void frmDNBEditImprevisto_Load(object sender, EventArgs e)
        {
            da = (from lt in diasadic.ListarDiasAdicionales() where lt.IDCALENDARIO == idcalendario select lt).ToList();
            dnl = (from lt in diasnolab.ListarDiasNoLaborables() where lt.IDCALENDARIO == idcalendario select lt).ToList();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count > 0)
            {
                foreach(sp_PersonalporCalendarioResult temp in listaizq)
                {
                    if (temp.CEDULA == dataGridViewX1.CurrentRow.Cells[0].Value.ToString()) 
                    {
                        listader.Add(temp);
                        listaizq.Remove(temp);
                        dataGridViewX1.DataSource = listaizq.ToArray();
                        dataGridViewX2.DataSource = listader.ToArray();
                        break;
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.Rows.Count > 0) 
            {
                foreach(sp_PersonalporCalendarioResult temp in listader)
                {
                    if (temp.CEDULA == dataGridViewX2.CurrentRow.Cells[0].Value.ToString()) 
                    {
                        listaizq.Add(temp);
                        listader.Remove(temp);
                        dataGridViewX1.DataSource = listaizq.ToArray();
                        dataGridViewX2.DataSource = listader.ToArray();
                        break;
                    }
                }
            }
        }

        private void btnAgregarTodos_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count > 0) 
            {
                foreach(sp_PersonalporCalendarioResult temp in listaizq)
                    listader.Add(temp); 
                
                listaizq.Clear();
                dataGridViewX1.DataSource = listaizq.ToArray();
                dataGridViewX2.DataSource = listader.ToArray();
            }
        }

        private void btnEliminarTodos_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.Rows.Count > 0) 
            {
                foreach (sp_PersonalporCalendarioResult temp in listader)
                    listaizq.Add(temp);
                
                listader.Clear();
                dataGridViewX1.DataSource = listaizq.ToArray();
                dataGridViewX2.DataSource = listader.ToArray();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dtifechainicio_MonthCalendar_PaintLabel(object sender, DevComponents.Editors.DateTimeAdv.DayPaintEventArgs e)
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

    }
}