using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CapaLogicaNegocio.cln_GestionAsistencia;

namespace CapaInterfaz.ci_GestionAsistencia.frmDNBImprevistos
{
    public partial class frmDNBVerPersonal : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDNBVerPersonal(string idcalendario,string idimprevisto)
        {
            InitializeComponent();
            this.idcalendario = idcalendario;
            this.idimprevisto = idimprevisto;
        }
        private ImprevistoLN imprevisto = new ImprevistoLN();
        private string idcalendario;
        private string idimprevisto;
        private void frmDNBVerPersonal_Load(object sender, EventArgs e)
        {
            var linq = imprevisto.ListarPersonasporImprevisto(idcalendario, idimprevisto);
            dataGridViewX1.DataSource = linq;
        }
        
    }
}