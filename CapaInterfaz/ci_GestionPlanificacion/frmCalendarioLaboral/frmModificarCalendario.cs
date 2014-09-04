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
    public partial class frmModificarCalendario : Form
    {
        string id;
        string nom;
        string desc;
        DateTime fechI;
        DateTime fechF;

        public frmModificarCalendario(String idCalendario, string descripcion, string nombre, DateTime fechIni, DateTime fechFin)
        {
            id = idCalendario;
            nom = nombre;
            desc = descripcion;
            fechI = fechIni;
            fechF = fechFin;

            InitializeComponent();
        }


        CalendarioLN CLN = new CalendarioLN();


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Calendario c = new Calendario();
            c.IdCalendario = id;
            c.Nombre = textNombre.Text;
            c.Descripcion = textDescripcion.Text;
            c.FechaInicio = dateTimePInicio.Value;
            c.FechaFin = dateTimePFin.Value;

            CLN.ModificarCalendario(c);

        }

        private void frmModificarCalendario_Load(object sender, EventArgs e)
        {
            MessageBox.Show("nom: "+nom);
            textNombre.Text = nom;
            textDescripcion.Text = desc;
            dateTimePInicio.Value = fechI;
            dateTimePFin.Value = fechF;

            //textNombre.Text = idcalendl;

        }
    }
}
