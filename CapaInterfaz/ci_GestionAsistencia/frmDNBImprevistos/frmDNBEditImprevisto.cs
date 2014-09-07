using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CapaLogicaNegocio.cln_GestionPersonal;
using CapaDatos;

namespace CapaInterfaz.ci_GestionAsistencia.frmDNBImprevistos
{
    public partial class frmDNBEditImprevisto : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmDNBEditImprevisto()
        {
            InitializeComponent();
        }
        public string OPTION = "";
        public bool tipo = true;
        private PersonalLN personal = new PersonalLN();
        public List<sp_PersonalporCalendarioResult> listader= new List<sp_PersonalporCalendarioResult>();
        public List<sp_PersonalporCalendarioResult> listaizq = new List<sp_PersonalporCalendarioResult>();
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (textBoxX1.Text == "" || dataGridViewX2.Rows.Count == 0 || dtifechainicio.IsEmpty == true || dtifechafin.IsEmpty == true)
            {
                MessageBox.Show("Ingrese los campos obligatorios","Alerta",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else 
            {
                OPTION = "OK";
                this.Close();
            }
        }

        private void frmDNBEditImprevisto_Load(object sender, EventArgs e)
        {
            
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count > 0)
            {
                foreach(sp_PersonalporCalendarioResult temp in listaizq)
                {
                    if (temp.CEDULA == dataGridViewX1.CurrentRow.Cells[0].Value.ToString()) 
                    {
                        listader.Add(temp);
                        listaizq.Remove(temp);
                        dataGridViewX1.DataSource = listaizq.ToArray();
                        dataGridViewX2.DataSource = listader.ToArray();
                        break;
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.Rows.Count > 0) 
            {
                foreach(sp_PersonalporCalendarioResult temp in listader)
                {
                    if (temp.CEDULA == dataGridViewX2.CurrentRow.Cells[0].Value.ToString()) 
                    {
                        listaizq.Add(temp);
                        listader.Remove(temp);
                        dataGridViewX1.DataSource = listaizq.ToArray();
                        dataGridViewX2.DataSource = listader.ToArray();
                        break;
                    }
                }
            }
        }

        private void btnAgregarTodos_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count > 0) 
            {
                foreach(sp_PersonalporCalendarioResult temp in listaizq)
                    listader.Add(temp); 
                
                listaizq.Clear();
                dataGridViewX1.DataSource = listaizq.ToArray();
                dataGridViewX2.DataSource = listader.ToArray();
            }
        }

        private void btnEliminarTodos_Click(object sender, EventArgs e)
        {
            if (dataGridViewX2.Rows.Count > 0) 
            {
                foreach (sp_PersonalporCalendarioResult temp in listader)
                    listaizq.Add(temp);
                
                listader.Clear();
                dataGridViewX1.DataSource = listaizq.ToArray();
                dataGridViewX2.DataSource = listader.ToArray();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Dispose();
        }




    }
}