using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CapaLogicaNegocio;
using CapaLogicaNegocio.cln_GestionPlanificacion;
using CapaEntidades.GestionPlanificacion;

namespace CapaInterfaz.ci_GestionPlanificacion.frmDNBACalendarioLaboral
{
    public partial class frmNuevoCalendarioLaboral : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmNuevoCalendarioLaboral()
        {
            InitializeComponent();
        }

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
                    if (this.comboNombre.SelectedIndex == -1) { errorProvider1.SetError(comboNombre, "Seleccione un nombre de calendario laboral"); return; }
            
            try
            {
                Calendario c = new Calendario();
                c.IdCalendario = CLN.GenerarIdCalendario();
                c.Nombre = comboNombre.SelectedItem.ToString();
                c.Descripcion = textDescripcion.Text;
                c.FechaInicio = dateTimePInicio.Value;
                c.FechaFin = dateTimePFin.Value;

                DateTime ini = dateTimePInicio.Value;
                DateTime fin = dateTimePFin.Value;
                DateTime now = DateTime.Now;
                TimeSpan ts = (fin - ini);

                TimeSpan resulIniNow = DateTime.Now - dateTimePInicio.Value;
                int ts2 = resulIniNow.Days;

                // Difference in days.
                int differenceInDays = ts.Days;

                if ((ts2 > 0) || (differenceInDays <= 365))
                {
                    DialogResult dialog;
                    dialog = MessageBox.Show("La Fecha Inicio debe ser mayor a la Fecha Actual " + "\n" + "y la Fecha Final debe ser mayor a la Fecha Inicio con un año mínimo", "Informacion del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    CLN.InsertarCalendario(c);
                    MessageBoxEx.Show("Calendario insertado correctamente");

                }
            }
            catch (Exception er) {
                MessageBoxEx.Show(er.Message);

            }
            LimpiarFormulario();

        }

        //metodo para limpiar los controladores del formulario
        private void LimpiarFormulario() {
            comboNombre.SelectedItem = null;
            textDescripcion.Text = null;
            dateTimePInicio.Text = null;
            dateTimePFin.Text = null;
        }

        private void frmNuevoCalendarioLaboral_Load(object sender, EventArgs e)
        {
            
        }

        private void textDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            VAL.Letras(e);
            VAL.Enter(e, textDescripcion);
        }
    }
}