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
    public partial class frmReporteAsistencia : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmReporteAsistencia()
        {
            InitializeComponent();
        }

        public void setUser(Usuarios s, Permisos per)
        {
            user = s;
            permiso = per;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmReporteAsistenciaDias frm = new CapaInterfaz.ci_GestionReportes.frmReporteAsistenciaDias();
            frm.Show();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            frmReporteAsistenciaMes frm = new CapaInterfaz.ci_GestionReportes.frmReporteAsistenciaMes();
            frm.Show();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            frmReporteAsistenciaRango frm = new CapaInterfaz.ci_GestionReportes.frmReporteAsistenciaRango();
            frm.Show();
        }

        public Usuarios user { get; set; }

        public Permisos permiso { get; set; }
    }
}