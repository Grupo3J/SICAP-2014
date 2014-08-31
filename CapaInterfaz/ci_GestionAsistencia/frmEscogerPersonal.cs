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
            var linq = from p in personal.ListarPersonal("")
                        where p.TIPO == tipo
                        select p;
            dataGridView1.DataSource = linq.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmInsertarGuia.IdLocal = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Dispose();
        }


    }
}
