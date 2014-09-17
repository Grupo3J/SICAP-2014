using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CapaLogicaNegocio.cln_GestionPersonal;
using CapaDatos.cd_GestionPersonal;
using CapaInterfaz.ci_GestionPersonal.frmDNBHuella;
using CapaInterfaz.ci_GestionPersonal.frmDNBPersonal;
using CapaEntidades.GestionPersonal;
using CapaLogicaNegocio.cln_GestionPlanificacion;
using System.IO;
using CapaEntidades.GestionSeguridad;

namespace CapaInterfaz.ci_GestionPersonal.frmDNBPersonal
{
    public partial class frmAdministrarPersonal : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmAdministrarPersonal()
        {
            InitializeComponent();
        }

        PersonalLN PLN = new PersonalLN();
        CalendarioLN CLN = new CalendarioLN();
        private Form owner = new Form();

        public Form Owner1
        {
            get { return owner; }
            set { owner = value; }
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {

        }
        public void setUser(Usuarios s, Permisos per)
        {
            user = s;
            permiso = per;
        }
        private void frmAdministrarPersonal_Load(object sender, EventArgs e)
        {
            if (!permiso.Escritura) { toolStrip1.Items.Remove(toolnuevo); }
            if (!permiso.Eliminacion) { toolStrip1.Items.Remove(tooleliminar); }
            if (!permiso.Modificacion) { toolStrip1.Items.Remove(toolmodificar); }
            
            dataGridViewX1.DataSource = PLN.ListarPersonal("");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmNuevoPersonal FRMNP = new frmNuevoPersonal(this);
            FRMNP.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = PLN.ListarPersonal("");
        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = PLN.ListarPersonal(textBuscar.Text);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            string cedula = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();

            try
            {

                if (PLN.ExistePersonalCalendario(cedula))
                {
                    MessageBoxEx.Show("La persona esta registrada en un calendario, por tal no se puede eliminar");
                }
                else {
                    dialog = MessageBox.Show("¿Está seguro que desea eliminar la persona?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialog == DialogResult.Yes)
                    {
                        cedula = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                        PLN.EliminarPresonal(cedula);
                        MessageBoxEx.Show("Persona eliminada con éxito");
                        dataGridViewX1.DataSource = PLN.ListarPersonal("");
                    }
                }


            }
            catch (Exception er) { 
            
            }
            
            
            
        }


        private void dataGridViewX1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    labelXDatos.Text = (dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            //    presentarImagenEnPictureBox(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value.ToString());

            //}
            //catch (Exception)
            //{


            //}
        }



        private void presentarImagenEnPictureBox(string id)
        {
           
                byte[] imageData;
                imageData = PersonalCd.getImageById(dataGridViewX1.CurrentRow.Cells[0].Value.ToString());

                //byte[] imageData = foto.ToArray();

                Image newImage;
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);
                    newImage = Image.FromStream(ms, true);
                }
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = newImage;
            
           
        }

        private void labelXDatos_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewX1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                labelXDatos.Text = (dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                presentarImagenEnPictureBox(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value.ToString());

            }
            catch (Exception)
            {


            }
        }

        private void textBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridViewX1.DataSource = PLN.ListarPersonal(textBuscar.Text);
        }

        private void frmAdministrarPersonal_MouseEnter(object sender, EventArgs e)
        {
            //dataGridViewX1.DataSource = PLN.ListarPersonal("");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            string cedula = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            frmAdministrarHuella FRMAH = new frmAdministrarHuella(cedula,this);
            FRMAH.Show();
        }

        

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            Personal p = new Personal();
            p.Cedula = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
            p.Nombre = dataGridViewX1.CurrentRow.Cells[1].Value.ToString();
            p.Apellido = dataGridViewX1.CurrentRow.Cells[2].Value.ToString();
            p.Cargo = dataGridViewX1.CurrentRow.Cells[3].Value.ToString();
            p.Titulo = dataGridViewX1.CurrentRow.Cells[4].Value.ToString();
            p.Correo = dataGridViewX1.CurrentRow.Cells[5].Value.ToString();
            p.Sexo = (char)dataGridViewX1.CurrentRow.Cells[6].Value;
            p.Ciudad = dataGridViewX1.CurrentRow.Cells[7].Value.ToString();
            p.Direccion = dataGridViewX1.CurrentRow.Cells[8].Value.ToString();
            p.Telefono = dataGridViewX1.CurrentRow.Cells[9].Value.ToString();
            p.Tipo = dataGridViewX1.CurrentRow.Cells[10].Value.ToString();
            p.DataFoto = PersonalCd.getImageById(dataGridViewX1.CurrentRow.Cells[0].Value.ToString());

            //string calendario = PLN.ExtraerNombreCalendarioCedula(p.Cedula);
            //MessageBox.Show("calendario: "+calendario);

            frmActualizarPersonal FRMAP = new frmActualizarPersonal(p);
            FRMAP.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }




        public Usuarios user { get; set; }

        public Permisos permiso { get; set; }

        
    }
}