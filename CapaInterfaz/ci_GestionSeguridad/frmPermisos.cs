using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaInterfaz.ci_GestionSeguridad
{
    public partial class frmPermisos : Form
    {
        public frmPermisos()
        {
            InitializeComponent();
        }

        private void tool_editar_Click(object sender, EventArgs e)
        {
            this.bntnguardar.Visible = true;
        }

        private void bntnguardar_Click(object sender, EventArgs e)
        {
            this.bntnguardar.Visible = false;
        }

        private void frmPermisos_Load(object sender, EventArgs e)
        {

        }
    }
}
