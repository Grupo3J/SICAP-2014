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
    public partial class frmReportePersonal : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmReportePersonal()
        {
            InitializeComponent();
        }
        DSSeguridad ds = new DSSeguridad();
        ReportesLN reportes = new ReportesLN(); 
        CRPersonal rpt = new CRPersonal();
        public void setUser(Usuarios s, Permisos per)
        {
            user = s;
            permiso = per;
        }
        private void frmReportePersonal_Load(object sender, EventArgs e)
        {
            
            try
            {
                List<CapaDatos.sp_ReportePersonalResult> lp = reportes.filtrarPersonalbyTipo(""+cmbtipopersonal.SelectedItem);
                //MessageBox.Show(""+lp.Count);
                foreach (CapaDatos.sp_ReportePersonalResult p in lp)
                {
                    ds.sp_ReportePersonal.Addsp_ReportePersonalRow(p.CEDULA, p.NOMBRE, p.APELLIDO, p.CARGO, p.TITULO, p.CORREO,""+p.SEXO,p.CIUDAD,p.DIRECCION,p.TELEFONO,p.TIPO);
                }

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

        
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmReportePersonal K = new frmReportePersonal();
            K.button1.Visible = false;
            K.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            K.Show();
        }

        private void cmbtipopersonal_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                List<CapaDatos.sp_ReportePersonalResult> lp = reportes.filtrarPersonalbyTipo(cmbtipopersonal.SelectedItem.ToString());
                //MessageBox.Show(""+lp.Count);
                ds.sp_ReportePersonal.Clear();
                foreach (CapaDatos.sp_ReportePersonalResult p in lp)
                {

                    ds.sp_ReportePersonal.Addsp_ReportePersonalRow(p.CEDULA, p.NOMBRE, p.APELLIDO, p.CARGO, p.TITULO, p.CORREO, "" + p.SEXO, p.CIUDAD, p.DIRECCION, p.TELEFONO, p.TIPO);
                }

                rpt.SetDataSource(ds);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception men)
            {
                MessageBox.Show(men.ToString());
            }
        }
    }
}
