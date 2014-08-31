using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.cd_GestionPersonal;
using CapaInterfaz.ci_GestionPersonal.frmPersonal;
using CapaLogicaNegocio.cln_GestionPersonal;
using System.IO;
namespace CapaInterfaz.ci_GestionPersonal.frmPersonal
{
    public partial class frmAdministrarPersonal : Form
    {
        public frmAdministrarPersonal()
        {
            InitializeComponent();
        }
   
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistrarPersonal frmrp = new frmRegistrarPersonal();
            frmrp.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
           
        PersonalLN PLN = new PersonalLN();
        private void frmAdministrarPersonal_Load(object sender, EventArgs e)
        {
           

           Image im = (Image)pictureBox1.Image;
            pictureBox1.Image = im;
            dataGridView1.DataSource = PLN.ListarPersonal("");
           
        }
        

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PLN.ListarPersonal(textBuscar.Text);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("¿Está seguro que desea eliminar la persona?", "Información del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(dialog == DialogResult.Yes){
                string cedula = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                PLN.EliminarPresonal(cedula);
                //PersonalCd.EliminarPersonalCedula(cedula);

                dataGridView1.DataSource = PLN.ListarPersonal("");
                //dataGridView1.DataSource = PersonalCd.ObtenerPresonal("");           
            }
            
        }
        //PersonalCd pcd = new PersonalCd();
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            byte[] foto;
            

            string cedula = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string apellidos = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string cargo = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string titulo = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string correo = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            string sexo = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            string ciudad = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            string direccion = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            string telefono = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            string tipo = dataGridView1.CurrentRow.Cells[10].Value.ToString();

            ///agragar primero a LN
            foto = PersonalCd.getImageById(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            
            
            frmModificarPersonal frmdp = new frmModificarPersonal(cedula, nombre, apellidos,cargo,titulo, correo,
            sexo, ciudad, direccion, telefono, tipo, foto);
            frmdp.Show();






        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = PersonalCd.ObtenerPresonal("");  
            dataGridView1.DataSource = PLN.ListarPersonal("");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // presentarImagenEnPictureBox();
        }

        private void administrarHuellaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cedula = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            
            frmAdministrarHuella frmah = new frmAdministrarHuella(cedula);
            frmah.Show();
        }

        private void presentarImagenEnPictureBox(string id)
        {
            byte[] foto;
           // foto = PersonalCd.getImageById(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            foto = PersonalCd.getImageById(id);

            byte[] imageData = foto.ToArray();

            Image newImage;
            using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
            {
                ms.Write(imageData, 0, imageData.Length);
                newImage = Image.FromStream(ms, true);
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = newImage;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            //presentarImagenEnPictureBox();

        }

        

        private void frmAdministrarPersonal_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            //presentarImagenEnPictureBox();

        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            //presentarImagenEnPictureBox();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void down(object sender, MouseEventArgs e)
        {
            
        }

        private void hover(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label2.Text = (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                presentarImagenEnPictureBox(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            }
            catch (Exception)
            {


            }
        }

        private void downcell(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        
        }

        private void leavecell(object sender, DataGridViewCellEventArgs e)
        {
            
            }

        private void mouseup(object sender, DataGridViewCellMouseEventArgs e)
        {

        }


    }
    }