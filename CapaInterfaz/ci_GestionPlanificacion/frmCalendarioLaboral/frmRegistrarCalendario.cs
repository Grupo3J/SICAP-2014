using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades.GestionPlanificacion;
using CapaLogicaNegocio.cln_GestionPlanificacion;


namespace CapaInterfaz.ci_GestionPlanificacion.frmCalendarioLaboral
{
    public partial class frmRegistrarCalendario : Form
    {
        CalendarioLN CLN= new CalendarioLN();

        public frmRegistrarCalendario()
        {
            InitializeComponent();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Calendario c = new Calendario();
            c.IdCalendario = CLN.GenerarIdCalendario();
            c.Nombre = textNombre.Text;
            c.Descripcion = textDescripcion.Text;
            c.FechaInicio = dateTimePInicio.Value;
            c.FechaFin = dateTimePFin.Value;

            CLN.InsertarCalendario(c);
                
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
