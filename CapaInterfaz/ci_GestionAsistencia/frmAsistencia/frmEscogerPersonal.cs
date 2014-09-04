using CapaDatos;
using CapaInterfaz.ci_GestionAsistencia.frmAsistencia;
using CapaLogicaNegocio.cln_GestionPersonal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaInterfaz.ci_GestionAsistencia
{
    public partial class frmEscogerPersonal : Form
    {
        public frmEscogerPersonal(string tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }
        private string tipo;
        PersonalLN personal = new PersonalLN();

        private void frmEscogerPersonal_Load(object sender, EventArgs e)
        {
            List<string> cedulasaencontrar = new List<string>();
            using(CapaDatosDataContext DB = new CapaDatosDataContext())
            {
                var l = (from dt in DB.DETALLE_PERSONAL_CALENDARIO 
                    where dt.IDCALENDARIO == frmEditAsistencia.IdCalendario
                    select dt).ToList();
                foreach(DETALLE_PERSONAL_CALENDARIO temp in l)
                {
                    cedulasaencontrar.Add(temp.CEDULA);
                }
            }
            
            var linq = from p in personal.ListarPersonal("")
                        where p.TIPO == tipo
                        join pet in cedulasaencontrar
                        on p.CEDULA equals pet 
                        select p;

            dataGridView1.DataSource = linq.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmEditAsistencia.Cedula = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Dispose();
        }


    }
}
