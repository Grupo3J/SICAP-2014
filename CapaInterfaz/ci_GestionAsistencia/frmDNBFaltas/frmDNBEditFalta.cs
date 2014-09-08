using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevComponents.DotNetBar;
using CapaLogicaNegocio.cln_GestionAsistencia;
using CapaLogicaNegocio.cln_GestionPersonal;
using CapaDatos;

namespace CapaInterfaz.ci_GestionAsistencia.frmDNBFaltas
{
    public partial class frmDNBEditFalta : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDNBEditFalta()
        {
            InitializeComponent();
        }
        public static string Cedula;
        public static string IdCalendario;
        PersonalLN personal = new PersonalLN();
        FaltasLN faltas = new FaltasLN();

        private void frmDNBEditFalta_Load(object sender, EventArgs e)
        {
            var linq = (from p in personal.ListarPersonal("")
                        select p).Distinct();
            foreach (sp_FiltrarPersonalValoresResult temp in linq.ToList())
            {
                if (!cmbTipo.Items.Contains(temp.TIPO))
                    cmbTipo.Items.Add(temp.TIPO);
            }
        }
    }
}