using CapaEntidades.GestionSeguridad;
using CapaLogicaNegocio.cln_GestionReportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaInterfaz.ci_GestionReportes
{
    public partial class frmReporteUsers : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmReporteUsers()
        {
             InitializeComponent();
        }
        public void setUser(Usuarios s, Permisos per)
        {
            user = s;
            permiso = per;
        }
        private void frmReporteUsers_Load(object sender, EventArgs e)
        {
            
            ReportesLN OP = new ReportesLN();
            DSSeguridad ds = new DSSeguridad();
            try
            {
                List<CapaDatos.VistaReporteUsers> lp = OP.ReportesUsuarios();
                foreach (CapaDatos.VistaReporteUsers p in lp)
                {

                    ds.VistaReporteUsers.AddVistaReporteUsersRow(p.CEDULA,p.NOMBRE,p.APELLIDO,p.TELEFONO,p.DIRECCION,p.CORREO,p.ROL,p.NICK);
                }
                CRUsers rpt = new CRUsers();
                rpt.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception men)
            {
                MessageBox.Show(men.ToString());
            }
        }

        public Usuarios user { get; set; }

        public Permisos permiso { get; set; }

        private void btnpantallacompleta_Click(object sender, EventArgs e)
        {
            frmReporteUsers a= new frmReporteUsers();
            a.btnpantallacompleta.Visible = false;
            a.WindowState = FormWindowState.Maximized;
            a.Show();
        }
    }
}
