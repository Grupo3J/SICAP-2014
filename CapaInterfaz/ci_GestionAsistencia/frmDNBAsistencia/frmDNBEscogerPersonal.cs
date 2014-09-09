using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CapaDatos;
using CapaLogicaNegocio.cln_GestionPersonal;
using CapaInterfaz.ci_GestionAsistencia.frmDNBFaltas;

namespace CapaInterfaz.ci_GestionAsistencia.frmDNBAsistencia
{
    public partial class frmDNBEscogerPersonal : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDNBEscogerPersonal(string tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }
        private string tipo;
        PersonalLN personal = new PersonalLN();

        private void frmBNBEscogerPersonal_Load(object sender, EventArgs e)
        {
            List<string> cedulasaencontrar = new List<string>();
            using (CapaDatosDataContext DB = new CapaDatosDataContext())
            {
                var l = (from dt in DB.DETALLE_PERSONAL_CALENDARIO
                         where dt.IDCALENDARIO == frmDNBEditAsistencia.IdCalendario || dt.IDCALENDARIO == frmDNBEditFalta.IdCalendario
                         select dt).ToList();
                foreach (DETALLE_PERSONAL_CALENDARIO temp in l)
                {
                    cedulasaencontrar.Add(temp.CEDULA);
                }
            }

            var linq = from p in personal.ListarPersonal("")
                       where p.TIPO == tipo
                       join pet in cedulasaencontrar
                       on p.CEDULA equals pet
                       select p;

            dataGridViewX1.DataSource = linq.ToList();
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmDNBEditAsistencia.Cedula = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            frmDNBEditFalta.Cedula = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            Dispose();
        }
    }
}