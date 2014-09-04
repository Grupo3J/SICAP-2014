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

namespace CapaInterfaz.ci_GestionPlanificacion.frmDiasAdicionales
{
    public partial class frmRegistrarDiasAdicionales : Form
    {
        public frmRegistrarDiasAdicionales()
        {
            InitializeComponent();
        }

        DiasAdicionalesLN DALN = new DiasAdicionalesLN();
        DiaNoLAborableLN DNLBLN = new DiaNoLAborableLN();
        CalendarioLN CLN = new CalendarioLN();

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int datico = comboIdCalendario.SelectedIndex;

            string fech = (dateTimePicker1.Value).ToString();

            if (DNLBLN.ExisteAdicionalEnNoLaboral((fech.Substring(0, 2) + fech.Substring(3, 2) + fech.Substring(6, 4)), lista[datico]))
            {
                DialogResult dialo = MessageBox.Show("EL Fecha seleccionada esta registrada como Día No Laborable. Si desea continuar con la operación vaya a la Administracion de Días No Laborables y elimmínelo", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else{
                DiasAdicionales da = new DiasAdicionales();


                da.IdCalendario = lista[datico];
                da.Fecha = dateTimePicker1.Value;
                da.IdDiasAdcionales = DALN.GenerarIdDiasAdicionales();
                da.Descripcion = textDescripcion.Text;

                DALN.InsertarDiasAdicionales(da);
            }



        }

        List<string> lista;
        private void frmRegistrarDiasAdicionales_Load(object sender, EventArgs e)
        {
            lista = new List<string>();
            var sql = (from p in CLN.ListarCalendario() select p).ToList();
            for (int f = 0; f < sql.Count;f++ ) {
                lista.Add(sql[f].IDCALENDARIO);
                comboIdCalendario.Items.Add(sql[f].NOMBRE+","+f);    
            } 
        }
    }
}
