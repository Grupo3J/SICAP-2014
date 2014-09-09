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
using CapaInterfaz.ci_GestionAsistencia.frmDNBAsistencia;

namespace CapaInterfaz.ci_GestionAsistencia.frmDNBFaltas
{
    public partial class frmDNBEditFalta : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDNBEditFalta(string IdCalendario)
        {
            InitializeComponent();
            frmDNBEditFalta.IdCalendario = IdCalendario;
        }

        public string OPTION = "";
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
            dtifecha.AllowEmptyState = true;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor Escoja un Tipo de Personal..");
            }
            else
            {
                frmDNBEscogerPersonal frmPersonal = new frmDNBEscogerPersonal(cmbTipo.SelectedItem.ToString());
                frmPersonal.ShowDialog();
                if (!string.IsNullOrEmpty(Cedula))
                {
                    var linq = from p in personal.ListarPersonal("")
                               where p.CEDULA == Cedula
                               select p;
                    foreach (sp_FiltrarPersonalValoresResult temp in linq.ToList())
                    {
                        txtcedula.Text = temp.CEDULA;
                        txtcargo.Text = temp.CARGO;
                        txtnombre.Text = temp.NOMBRE;
                        cmbTipo.Text = temp.TIPO;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.Image = Utilities.convertByteToImage(temp.DATAFOTO.ToArray());
                        pictureBox1.Refresh();
                    }
                }
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            var linq = (from lt in personal.ListarPersonal("")
                        where lt.CEDULA.Equals(txtcedula.Text)
                        select lt).ToList();
            if (linq.Count == 0)
                MessageBox.Show("Ingrese una Cedula Válida");
            else
            {
                txtcedula.Text = linq[0].CEDULA;
                txtcargo.Text = linq[0].CARGO;
                txtnombre.Text = linq[0].NOMBRE;
                cmbTipo.Text = linq[0].TIPO;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = Utilities.convertByteToImage(linq[0].DATAFOTO.ToArray());
                pictureBox1.Refresh();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == -1 || txtcedula.Text == "" || dtifecha.IsEmpty == true)
            {
                MessageBoxEx.Show("Ingrese los campos obligatorios", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                OPTION = "OK";
                this.Close();
            }
        }

    }
}