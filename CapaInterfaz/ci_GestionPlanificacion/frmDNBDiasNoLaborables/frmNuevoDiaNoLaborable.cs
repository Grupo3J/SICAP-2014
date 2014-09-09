using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
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
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            int datico = comboIdCalendario.SelectedIndex;

            string fech = (dateTimePicker1.Value).ToString();

            if (DALN.ExisteNoLaboralEnAdicional((fech.Substring(0, 2) + fech.Substring(3, 2) + fech.Substring(6, 4)), lista[datico]))
            {
                DialogResult dialo = MessageBox.Show("La Fecha seleccionada esta registrada como Día Adicional. Si desea continuar con la operación vaya a la Administración de Días Adicionales y Elimmínela", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DiasNoLaborables dnl = new DiasNoLaborables();

                dnl.IdDiasNoLaborables = DNLLN.GenerarIdDiasNoLaborables();
                dnl.IdCalendario = lista[datico];
                dnl.Fecha = dateTimePicker1.Value;
                dnl.Descripcion = textDescripcion.Text;

                if(DNLLN.InsertarDiasNoLaborables(dnl)){
                    MessageBox.Show("Ya existe ede dia no lab");
                }
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
    }
}