using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace CapaInterfaz.ci_GestionAsistencia.frmDNBImprevistos
{
    public partial class frmDNBDescripcion : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDNBDescripcion(string descrip)
        {
            InitializeComponent();
            this.descrip = descrip;
        }
        private string descrip;

        private void frmDNBDescripcion_Load(object sender, EventArgs e)
        {
            textBoxX1.Text = descrip;
        }


    }
}