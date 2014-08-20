using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaInterfaz.ci_GestionPersonal.frmPersonal
{
    public partial class frmRegistrarPersonal : Form
    {
        public frmRegistrarPersonal()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog Abrir = new OpenFileDialog();
            Abrir.Filter = "Archivos JPEG(*.JPG) |*.jpg";
            Abrir.InitialDirectory = "C:/gerson";
            if (Abrir.ShowDialog() == DialogResult.OK)
            {
                string Dir = Abrir.FileName;
                Bitmap picture = new Bitmap(Dir);
                pictureBox1.Image = (Image)picture;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog Abrir2 = new OpenFileDialog();
            Abrir2.Filter = "Archivos JPEG(*.JPG) |*.jpg";
            Abrir2.InitialDirectory = "C:/gerson";
            if (Abrir2.ShowDialog() == DialogResult.OK)
            {
                string Dir = Abrir2.FileName;
                Bitmap picture2 = new Bitmap(Dir);
                pictureBox2.Image = (Image)picture2;

            }
        }
    }
}
