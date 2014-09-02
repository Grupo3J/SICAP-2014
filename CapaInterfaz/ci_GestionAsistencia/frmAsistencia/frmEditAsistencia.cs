using CapaDatos;
using CapaEntidades.GestionAsistencia;
using CapaLogicaNegocio.cln_GestionAsistencia;
using CapaLogicaNegocio.cln_GestionPersonal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaInterfaz.ci_GestionAsistencia.frmAsistencia
{
    public partial class frmEditAsistencia : Form
    {
        public frmEditAsistencia(string IdCalendario)
        {
            InitializeComponent();
            frmEditAsistencia.IdCalendario = IdCalendario;

        }
        public static string Cedula;
        public static string IdCalendario;
        PersonalLN personal = new PersonalLN();
        AsistenciaLN asistencia = new AsistenciaLN();

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor Escoja un Tipo de Personal..");
            }
            else 
            {
                frmEscogerPersonal frmPersonal = new frmEscogerPersonal(cmbTipo.SelectedItem.ToString());
                frmPersonal.ShowDialog();
                if (!string.IsNullOrEmpty(Cedula)) 
                {
                    var linq = from p in personal.ListarPersonal("")
                               where p.CEDULA == Cedula
                               select p;
                    foreach(pa_FiltrarPersonalValoresResult temp in linq.ToList())
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

        private void frmEditAsistencia_Load(object sender, EventArgs e)
        {
            dtphoraentrada.ShowUpDown = true;
            dtphorasalida.ShowUpDown = true;
            var linq = (from p in personal.ListarPersonal("")
                       select p).Distinct();
            foreach (pa_FiltrarPersonalValoresResult temp in linq.ToList())
            {
                if(!cmbTipo.Items.Contains(temp.TIPO))
                cmbTipo.Items.Add(temp.TIPO);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) 
                dtphorasalida.Enabled = true;

            if (checkBox1.Checked == false) 
                dtphorasalida.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Asistencia temp = new Asistencia();
            if (string.IsNullOrEmpty(txtcedula.Text) && string.IsNullOrEmpty(dtphorasalida.Text))
            {
                MessageBox.Show("Ingrese los valores correspondientes...");
            }
            else 
            {
                temp.IdAsistencia = GenerarIdAsistencia();
                temp.IdCalendario = IdCalendario;
                temp.Cedula = txtcedula.Text;
                temp.FechaHoraEntrada = Convert.ToDateTime(dateTimePicker1.Value.Date + dtphoraentrada.Value.TimeOfDay);
                if (dtphorasalida.Enabled == true)
                    temp.FechaHoraSalida = Convert.ToDateTime(dateTimePicker1.Value.Date + dtphorasalida.Value.TimeOfDay);
                else 
                    temp.FechaHoraSalida = Convert.ToDateTime(dateTimePicker1.Value.Date + dtphoraentrada.Value.TimeOfDay);
                asistencia.InsertarAsistencia(temp);
                MessageBox.Show("Asistencia Ingresada");
            }
        }

        private string GenerarIdAsistencia()
        {
            Random ran = new Random();
            int num = ran.Next(0000, 1000);
            int num2 = ran.Next(000, 100);

            string idhuella = "A" + num.ToString() + num2.ToString();
            return idhuella;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
