using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CapaEntidades.GestionSeguridad;

namespace CapaInterfaz.ci_GestionReportes
{
    public partial class frmReporteFalta : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmReporteFalta()
        {
            InitializeComponent();
        }

        public void setUser(Usuarios s, Permisos per)
        {
            user = s;
            permiso = per;
        }

        public Usuarios user { get; set; }

        public Permisos permiso { get; set; }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmReporteFaltasDias frm = new frmReporteFaltasDias();
            frm.Show();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            frmReporteFaltasMes frm = new frmReporteFaltasMes();
            frm.Show();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            frmReporteFaltasRango frm = new frmReporteFaltasRango();
            frm.Show();
        }

    }
}