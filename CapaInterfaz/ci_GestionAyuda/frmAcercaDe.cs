using CapaEntidades.GestionSeguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaInterfaz.ci_GestionAyuda
{
    public partial class frmAcercaDe : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmAcercaDe()
        {
            InitializeComponent();
        }

        private void frmAcercaDe_Load(object sender, EventArgs e)
        {

        }
        public void setUser(Usuarios s, Permisos per)
        {
            user = s;
            permiso = per;
        }

        public Usuarios user { get; set; }

        public Permisos permiso { get; set; }
    }
}
