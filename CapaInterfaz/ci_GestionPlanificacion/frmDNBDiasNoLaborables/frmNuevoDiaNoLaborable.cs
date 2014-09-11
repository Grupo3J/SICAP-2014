using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using CapaLogicaNegocio;
using DevComponents.DotNetBar;
using CapaEntidades.GestionPlanificacion;
using CapaLogicaNegocio.cln_GestionPlanificacion;

namespace CapaInterfaz.ci_GestionPlanificacion.frmDNBDiasNoLaborables
{
    public partial class frmNuevoDiaNoLaborable : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmNuevoDiaNoLaborable()
        {
            InitializeComponent();
        }
        List<string> lista;
        DiaNoLAborableLN DNLLN = new DiaNoLAborableLN();
        DiasAdicionalesLN DALN = new DiasAdicionalesLN();
        CalendarioLN CLN = new CalendarioLN();
        Validaciones VAL = new Validaciones();
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
            if (this.textDescripcion.Text == "") { errorProvider1.SetError(textDescripcion, "Ingrese descripción"); return; }
            if (this.comboIdCalendario.SelectedIndex == -1) { errorProvider1.SetError(comboIdCalendario, "Seleccione un calendario laboral"); return; }
            try{
            string iddian = DNLLN.GenerarIdDiasNoLaborables();
            int datico = comboIdCalendario.SelectedIndex;

            string fech = (dateTimePicker1.Value).ToString();

            if (DALN.ExisteNoLaboralEnAdicional((fech.Substring(0, 2) + fech.Substring(3, 2) + fech.Substring(6, 4)), lista[datico]))
            {
                DialogResult dialo = MessageBox.Show("La Fecha seleccionada esta registrada como Día Adicional. Si desea continuar con la operación vaya a la Administración de Días Adicionales y Elimmínela", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (DNLLN.ExisteNoLaborableFecha((fech.Substring(0, 2) + fech.Substring(3, 2) + fech.Substring(6, 4)), iddian, lista[datico]))
                {
                    MessageBoxEx.Show("La fecha seleccionada ya está registrada como Día No Laborable");
                }
                else {
                    DiasNoLaborables dnl = new DiasNoLaborables();

                    if (comprobarFechas(lista[datico]))
                    {
                        dnl.IdDiasNoLaborables = iddian;
                        dnl.IdCalendario = lista[datico];
                        dnl.Fecha = dateTimePicker1.Value;
                        dnl.Descripcion = textDescripcion.Text;

                        DNLLN.InsertarDiasNoLaborables(dnl);
                        MessageBoxEx.Show("Día No Laborable registrado exitosamente");
                    }
                    else
                    {

                        MessageBox.Show("La fecha debe estar entre:   " + DateTime.Now + "   y: " + ffin.ToString());
                    }
                }
                

                }
             }
             catch (Exception er)
             {
                 MessageBoxEx.Show(er.Message);
             }
            limpiarFormulario();
            
        }

        //metod para limpiar el formulario
        private void limpiarFormulario()
        {
            comboIdCalendario.SelectedItem = null;
            dateTimePicker1.Text = null;
            textDescripcion.Text = null;
        }

        DateTime fini;
        DateTime ffin;
        DateTime fpiker;
        private bool comprobarFechas(string d)
        {
            var sql = (from p in CLN.ListarCalendario() select p).ToList();
            for (int f = 0; f < sql.Count; f++)
            {
                if ((sql[f].IDCALENDARIO).Equals(d))
                {
                    fini = sql[f].FECHAINICIO;
                    ffin = sql[f].FECHAFIN;

                }
            }
            fpiker = dateTimePicker1.Value;
            TimeSpan r = dateTimePicker1.Value - DateTime.Now;
            int re = (int)r.TotalDays;

            TimeSpan r2 = ffin - dateTimePicker1.Value;
            int re2 = (int)r2.TotalDays;


            if ((re < 0) || (re2 <= 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void frmNuevoDiaNoLaborable_Load(object sender, EventArgs e)
        {
            DNLLN.ListarDiasNoLaborables();
            
            lista = new List<string>();
            var sql = (from p in CLN.ListarCalendario() select p).ToList();
            for (int f = 0; f < sql.Count; f++)
            {
                lista.Add(sql[f].IDCALENDARIO);
                comboIdCalendario.Items.Add(sql[f].NOMBRE + "," + f);
            } 
        }

        private void textDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            VAL.Letras(e);
            VAL.Enter(e, textDescripcion);
        }
    }
}