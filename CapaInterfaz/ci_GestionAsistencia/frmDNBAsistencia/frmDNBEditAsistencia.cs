using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevComponents.DotNetBar;
using CapaLogicaNegocio.cln_GestionPersonal;
using CapaLogicaNegocio.cln_GestionAsistencia;
using CapaDatos;
using CapaEntidades.GestionAsistencia;
using CapaLogicaNegocio.cln_GestionPlanificacion;

namespace CapaInterfaz.ci_GestionAsistencia.frmDNBAsistencia
{
    public partial class frmDNBEditAsistencia : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDNBEditAsistencia(string IdCalendario)
        {
            InitializeComponent();
            frmDNBEditAsistencia.IdCalendario = IdCalendario;
        }
        public static string Cedula;
        public static string IdCalendario;
        PersonalLN personal = new PersonalLN();
        AsistenciaLN asistencia = new AsistenciaLN();
        CalendarioLN calendario = new CalendarioLN();
        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBoxEx.Show("Por favor Escoja un Tipo de Personal..");
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

        private void frmDNBEditAsistencia_Load(object sender, EventArgs e)
        {
            dtihoraentrada.ShowUpDown = true;
            dtihorasalida.ShowUpDown = true;
            var linq = (from p in personal.ListarPersonal("")
                        select p).Distinct();
            foreach (sp_FiltrarPersonalValoresResult temp in linq.ToList())
            {
                if (!cmbTipo.Items.Contains(temp.TIPO))
                    cmbTipo.Items.Add(temp.TIPO);
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

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Asistencia temp = new Asistencia();
            if (string.IsNullOrEmpty(txtcedula.Text) || dtifecha.IsEmpty || dtihoraentrada.IsEmpty || dtihorasalida.IsEmpty )
            {
                MessageBoxEx.Show("Ingrese los valores correspondientes...");
            }
            else
            {
                string id;
                do
                {
                    id = GenerarIdAsistencia();
                    temp.IdAsistencia = id;
                }
                while (asistencia.existeAsistencia(id));
                temp.IdCalendario = IdCalendario;
                temp.Cedula = txtcedula.Text;
                temp.FechaHoraEntrada = Convert.ToDateTime(dtifecha.Value.Date + dtihoraentrada.Value.TimeOfDay);
                temp.FechaHoraSalida = Convert.ToDateTime(dtifecha.Value.Date + dtihorasalida.Value.TimeOfDay);
                temp.HoraMostrada = Convert.ToDateTime(dtifecha.Value.Date + dtihorasalida.Value.TimeOfDay);

                var linq = (from lt in calendario.ListarCalendario() where lt.IDCALENDARIO == IdCalendario
                               select lt).ToList();
                if (dtihoraentrada.Value.TimeOfDay > linq[0].FECHAINICIO.AddMinutes(linq[0].RETRASO.Value).TimeOfDay) 
                {
                    MessageBoxEx.Show("La Fecha de Entrada Tiene que ser Menor a " + linq[0].FECHAINICIO.AddMinutes(linq[0].RETRASO.Value).TimeOfDay.ToString());
                }
                else if (dtihorasalida.Value.TimeOfDay > linq[0].FECHAFIN.TimeOfDay)
                {
                    temp.FechaHoraSalida = Convert.ToDateTime(dtifecha.Value.Date + linq[0].FECHAFIN.TimeOfDay);
                    asistencia.InsertarAsistencia(temp);
                    MessageBoxEx.Show("Asistencia Ingresada");
                }
                else if (dtihoraentrada.Value.TimeOfDay > dtihorasalida.Value.TimeOfDay)
                {
                    MessageBoxEx.Show("La Hora de Entrada debe ser menor a la de Salida");
                }
                else 
                {    
                    asistencia.InsertarAsistencia(temp);
                    MessageBoxEx.Show("Asistencia Ingresada");
                }
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            var linq = (from lt in personal.ListarPersonal("")
                        where lt.CEDULA.Equals(txtcedula.Text)
                        select lt).ToList();
            if (linq.Count == 0)
                MessageBoxEx.Show("Ingrese una Cedula Válida");
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


    }
}