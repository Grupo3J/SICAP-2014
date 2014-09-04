using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.cd_GestionPlanificacion;
using CapaLogicaNegocio.cln_GestionPlanificacion;
using CapaEntidades.GestionPlanificacion;

namespace CapaInterfaz.ci_GestionPlanificacion.frmDiasNoLaborables
{
    public partial class frmRegistrarDiasNoLaborables : Form
    {
        public frmRegistrarDiasNoLaborables()
        {
            InitializeComponent();
        }
        List<string> lista;
        DiaNoLAborableLN DNLLN = new DiaNoLAborableLN();
        DiasAdicionalesLN DALN = new DiasAdicionalesLN();
        CalendarioLN CLN = new CalendarioLN();

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            int datico = comboIdCalendario.SelectedIndex;

            string fech = (dateTimePicker1.Value).ToString();

            if (DALN.ExisteNoLaboralEnAdicional((fech.Substring(0, 2) + fech.Substring(3, 2) + fech.Substring(6, 4)), lista[datico]))
            {
                DialogResult dialo = MessageBox.Show("EL Fecha seleccionada esta registrada como Día Adicional. Si desea continuar con la operación vaya a la Administración de Días Adicionales y Elimmínela", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DiasNoLaborables dnl = new DiasNoLaborables();

                dnl.IdDiasNoLaborables = DNLLN.GenerarIdDiasNoLaborables();
                dnl.IdCalendario = lista[datico];
                dnl.Fecha = dateTimePicker1.Value;
                dnl.Descripcion = textDescripcion.Text;

                DNLLN.InsertarDiasNoLaborables(dnl);
            }


















        }

        private void frmRegistrarDiasNoLaborables_Load(object sender, EventArgs e)
        {
            lista = new List<string>();
            var sql = (from p in CLN.ListarCalendario() select p).ToList();
            for (int f = 0; f < sql.Count; f++)
            {
                lista.Add(sql[f].IDCALENDARIO);
                comboIdCalendario.Items.Add(sql[f].NOMBRE + "," + f);
            } 
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
