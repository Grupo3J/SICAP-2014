using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.IO;
using CapaEntidades.GestionPersonal;
using CapaLogicaNegocio.cln_GestionPlanificacion;
using System.Linq;
using CapaLogicaNegocio.cln_GestionPersonal;

namespace CapaInterfaz.ci_GestionPersonal.frmDNBPersonal
{
    public partial class frmActualizarPersonal : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmActualizarPersonal(Personal p)
        {           
            ced = p.Cedula;
            nom = p.Nombre;
            ape = p.Apellido;
            car = p.Cargo;
            tit = p.Titulo;
            corr = p.Correo;
            sex = (p.Sexo);
            ciu = p.Ciudad;
            dir = p.Direccion;
            tel = p.Telefono;
            tip = p.Tipo;
            fot = p.DataFoto;

            InitializeComponent();
        }

        //private SGFingerPrintManager m_FPM;
        //private int m_ImageWidth;
        //private int m_ImageHeight;
        //private Byte[] arrayHuella1;
        //private Byte[] arrayHuella2;

        int v;
        

        public string ced;
        public string nom;
        public string ape;
        public string car;
        public string tit;
        public string corr;
        public char sex;
        public string ciu;
        public string dir;
        public string tel;
        public string tip;
        public byte[] fot;

        Bitmap picture;
        //Bitmap picture2;


        List<string> lista;
        List<string> lista2;
        List<string> lista3;
        CalendarioLN CLN = new CalendarioLN();
        PersonalLN PLN = new PersonalLN();
        HuellaLN HLN = new HuellaLN();


        private void cargarComboCalendario()
        {
            
            lista = new List<string>();
            lista3 = new List<string>();
            var sql = (from p in CLN.ListarCalendario() select p).ToList();
            var sql2 = (from p in CLN.ListarCalendario() select p).ToList();
            for (int f = 0; f < sql.Count; f++)
            {

                lista.Add(sql[f].IDCALENDARIO);

                comboCalendario.Items.Add(sql[f].NOMBRE + "," + f);
            }

            for (int d = 0; d < sql2.Count; d++)
            {
                if (lista2[0].Equals(sql2[d].IDCALENDARIO)) {
                    v = d;
                    dati = sql2[d].NOMBRE;
                }

            }
            comboCalendario.Text = dati + "," + v;



        }
        string dati;
        private void SelecccionarItemmComboCalendario()
        {
            lista2 = new List<string>();
            var sql = (from p in CLN.ListarDetalleCalendarioPersnal(ced) select p).ToList();
            for (int f = 0; f < sql.Count; f++)
            {
                lista2.Add(sql[f].IDCALENDARIO);
            }
            cargarComboCalendario();

        }

        private void frmActualizarPersonal_Load(object sender, EventArgs e)
        {

            SelecccionarItemmComboCalendario();

            
            textCedula.Text = ced;
            textNombres.Text = nom;
            textApellidos.Text = ape;
            textCargo.Text = car;
            textTitulo.Text = tit;
            textCorreo.Text = corr;
            if ((sex.Equals('H')) || (sex.Equals('h')))
            {
                comboSexo.Text = "Hombre";
            }
            else {
                if ((sex.Equals('M')) || (sex.Equals('m')))
                {
                    comboSexo.Text = "Mujer";
                }
            }
            textCiudad.Text = ciu;
            textDireccion.Text = dir;
            textTelefono.Text = tel;
            comboTipo.Text = tip;
            presentarImagenEnPictureBox(fot);


        }
        private void presentarImagenEnPictureBox(byte[]DataPhoto)
        {
            try
            {
                Image newImage;
                using (MemoryStream ms = new MemoryStream(DataPhoto, 0, DataPhoto.Length))
                {
                    ms.Write(DataPhoto, 0, DataPhoto.Length);
                    newImage = Image.FromStream(ms, true);
                }
                pictureFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureFoto.Image = newImage;
            }
            catch (Exception)
            {
                //MessageBox.Show("Error en foto: " + error.GetBaseException());
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

            OpenFileDialog Abrir = new OpenFileDialog();
            Abrir.Filter = "Archivos JPEG(*.JPG) |*.jpg";
            Abrir.InitialDirectory = "C:/gerson";
            if (Abrir.ShowDialog() == DialogResult.OK)
            {
                string Dir = Abrir.FileName;
                picture = new Bitmap(Dir);
                pictureFoto.Image = (Image)picture;

            }
        }
        int valor = 0;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
    
            int datico = comboCalendario.SelectedIndex;
                string sex = "" + comboSexo.SelectedItem;

                Personal p = new Personal();
                p.Cedula = textCedula.Text;
                p.Nombre = textNombres.Text;
                p.Apellido = textApellidos.Text;
                p.Cargo = textCargo.Text;
                p.Titulo = textTitulo.Text;
                p.Correo = textCorreo.Text;
                p.Sexo = sex[0];
                p.Ciudad = textCiudad.Text;
                p.Direccion = textDireccion.Text;
                p.Telefono = textTelefono.Text;
                p.Tipo = Convert.ToString(comboTipo.SelectedItem);
                p.DataFoto = ImageToByte(picture);

                if (picture == null)
                {
                    valor = 1;
                    PLN.ModificarPersonal(p, valor);

                }
                else
                {
                    valor = 2;
                    PLN.ModificarPersonal(p, valor);

                }
                MessageBox.Show("ced. " + textCedula.Text + " idcal: " + lista[datico]);
                        
               //PLN.ModificarDetallePersonalCalendario(textCedula.Text, lista[datico]);


            

            

            LimpiarCajasTexto();

        }

        private void LimpiarCajasTexto()
        {
            textCedula.Text = null;
            textNombres.Text = null;
            textApellidos.Text = null;
            textCargo.Text = null;
            textCiudad.Text = null;
            textCorreo.Text = null;
            textDireccion.Text = null;
            textTelefono.Text = null;
            comboCalendario.SelectedItem = null;
            comboSexo.SelectedItem = null;
            comboTipo.SelectedItem = null;
            textTitulo.Text = null;
            pictureFoto.Image = null;
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();


            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}