using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevComponents.DotNetBar;
using CapaLogicaNegocio;
using CapaLogicaNegocio.cln_GestionPlanificacion;
using CapaDatos.cd_GestionPlanificacion;
using CapaEntidades.GestionPlanificacion;


namespace CapaInterfaz.ci_GestionPlanificacion.frmDNBDiasAdicionales
{
    public partial class frmNuevoDiaAdicional : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmNuevoDiaAdicional()
        {
            InitializeComponent();
        }
        DiasAdicionalesLN DALN = new DiasAdicionalesLN();
        DiaNoLAborableLN DNLBLN = new DiaNoLAborableLN();
        CalendarioLN CLN = new CalendarioLN();
        Validaciones VAL = new Validaciones();
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            this.errorProvider1.Clear();
            if (this.textDescripcion.Text == "") { errorProvider1.SetError(textDescripcion, "Ingrese descripción"); return; }
            if (this.comboIdCalendario.SelectedIndex == -1) { errorProvider1.SetError(comboIdCalendario, "Seleccione un calendario laboral"); return; }


            try{
               string iddiaa =  DALN.GenerarIdDiasAdicionales();
            int datico = comboIdCalendario.SelectedIndex;

            string fech = (dateTimePicker1.Value).ToString();

            if (DNLBLN.ExisteAdicionalEnNoLaboral((fech.Substring(0, 2) + fech.Substring(3, 2) + fech.Substring(6, 4)), lista[datico]))
            {
                DialogResult dialo = MessageBox.Show("La fecha seleccionada esta registrada como Día No Laborable. Si desea continuar con la operación vaya a la Administracion de Días No Laborables y elimmínelo", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (DALN.ExisteAdicionalFecha(((fech.Substring(0, 2) + fech.Substring(3, 2) + fech.Substring(6, 4))), iddiaa, lista[datico]))
                {
                    MessageBoxEx.Show("La fecha seleccionada ya esta registrada como Día Adicional");
                }
                else {
                    DiasAdicionales da = new DiasAdicionales();

                    if (comprobarFechas(lista[datico]))
                    {
                        da.IdCalendario = lista[datico];
                        da.Fecha = dateTimePicker1.Value;
                        da.IdDiasAdcionales = iddiaa;
                        da.Descripcion = textDescripcion.Text;

                        DALN.InsertarDiasAdicionalesVoid(da);
                        MessageBoxEx.Show("Día adicional registrado exitosamente");
                    }
                    else
                    {
                        MessageBox.Show("La fecha debe estar entre:   " + DateTime.Now + "  y: " + ffin.ToString());

                    }
            
                }

                
                limpiarFormulario();
            }
            }
            catch (Exception er)
            {
                MessageBoxEx.Show(er.Message);
            }


        }

        DateTime fini;
        DateTime ffin;
        DateTime fpiker;
        private bool comprobarFechas(string d) { 
        var sql = (from p in CLN.ListarCalendario() select p).ToList();
            for (int f = 0; f < sql.Count;f++ ) {
                if ((sql[f].IDCALENDARIO).Equals(d)) {
                    fini = sql[f].FECHAINICIO;
                    ffin = sql[f].FECHAFIN;
                    
                }
            }
            fpiker = dateTimePicker1.Value;
            TimeSpan r = dateTimePicker1.Value - DateTime.Now;
            int re = (int)r.TotalDays;

            TimeSpan r2 = ffin - dateTimePicker1.Value;
            int re2 = (int)r2.TotalDays;


            if ((re < 0) || (re2 <= 0))
            {
                return false;
            }
            else {
                return true;
            }
        }

        private void limpiarFormulario() {
            comboIdCalendario.SelectedItem = null;
            dateTimePicker1.Text = null;
            textDescripcion.Text = null;
        }



        List<string> lista;
        private void frmNuevoDiaAdicional_Load(object sender, EventArgs e)
        {
       
            lista = new List<string>();
            var sql = (from p in CLN.ListarCalendario() select p).ToList();
            for (int f = 0; f < sql.Count;f++ ) {
                lista.Add(sql[f].IDCALENDARIO);
                comboIdCalendario.Items.Add(sql[f].NOMBRE+","+f);    
            } 
        
        }
        
        private void textDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            VAL.Letras(e);
            VAL.Enter(e, textDescripcion);
        }
    }
}