using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CapaEntidades.GestionPersonal;
using CapaLogicaNegocio.cln_GestionPersonal;
using CapaLogicaNegocio.cln_GestionPlanificacion;
using SecuGen.FDxSDKPro.Windows;
using CapaDatos.cd_GestionPlanificacion;
using CapaLogicaNegocio;


using CapaDatos.cd_GestionPersonal;


namespace CapaInterfaz.ci_GestionPersonal.frmDNBPersonal
{
    public partial class frmNuevoPersonal : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmNuevoPersonal()
        {
            InitializeComponent();
        }

        private SGFingerPrintManager m_FPM;
        private int m_ImageWidth;
        private int m_ImageHeight;
        private Byte[] arrayHuella1;
        private Byte[] arrayHuella2;

        PersonalLN PLN = new PersonalLN();
        HuellaLN HLN = new HuellaLN();

        private void labelX8_Click(object sender, EventArgs e)
        {

        }
        List<string> lista;
        CalendarioLN CLN = new CalendarioLN();
        Validaciones VAL = new Validaciones();

        private void frmNuevoPersonal_Load(object sender, EventArgs e)
        {
            lista = new List<string>();
            var sql = (from p in CLN.ListarCalendario() select p).ToList();
            for (int f = 0; f < sql.Count;f++ ) {
                lista.Add(sql[f].IDCALENDARIO);
                comboCalendario.Items.Add(sql[f].NOMBRE+","+f);    
            } 
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();


            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        Bitmap picture;
        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.errorProvider1.Clear();
            bool mistmatch = false;
            for(int i=0;i<textCedula.Text.Length;i++)
            {
                if(i>0 && textCedula.Text[i]!=textCedula.Text[i-1])
                    mistmatch=true;
            }
            if (this.textCedula.Text == "" || mistmatch==false) { errorProvider1.SetError(textCedula, "Ingrese cédula"); return; }
            if (this.textNombres.Text == "") { errorProvider1.SetError(textNombres, "Ingrese nombres"); return; }
            if (this.textApellidos.Text == "") { errorProvider1.SetError(textApellidos, "Ingrese apellidos"); return; }
            if (this.textTitulo.Text == "") { errorProvider1.SetError(textTitulo, "Ingrese título"); return; }
            if (this.textCargo.Text == "") { errorProvider1.SetError(textCargo, "Ingrese cargo"); return; }
            if (this.textTelefono.Text == "") { errorProvider1.SetError(textTelefono, "Ingrese teléfono"); return; }
            if (this.textCorreo.Text == "") { errorProvider1.SetError(textCorreo, "Ingrese correo"); return; }
            if (this.textCiudad.Text == "") { errorProvider1.SetError(textCiudad, "Ingrese ciudad"); return; }
            if (this.textDireccion.Text == "") { errorProvider1.SetError(textDireccion, "Ingrese dirección"); return; }

            if (this.comboCalendario.SelectedIndex == -1) { errorProvider1.SetError(comboCalendario, "Seleccione un calendario laboral"); return; }
            if (this.comboSexo.SelectedIndex == -1) { errorProvider1.SetError(comboSexo, "Seleccione sexo"); return; }
            if (this.comboNombresDedos.SelectedIndex == -1) { errorProvider1.SetError(comboNombresDedos, "Seleccione nombre para la huella"); return; }
            if (this.comboTipo.SelectedIndex == -1) { errorProvider1.SetError(comboTipo, "Seleccione el tipo"); return; }


            try
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

                Huella h = new Huella();

                if (selacthuella == false)
                {
                    MessageBoxEx.Show("Cargue una huella");
                }
                else {
                    h.IdHuella = HLN.GenerarIdHuella();
                    h.DataHuella1 = arrayHuella1;
                    h.DataHuella2 = arrayHuella2;
                    h.Cedula = textCedula.Text;
                    h.Nombre = comboNombresDedos.SelectedItem.ToString();
                    h.Imagen = ImageToByte(pictureFoto.Image);
                    PLN.InsertarPersonalVoid(p);
                    HLN.InsertarHuellaSinReturn(h);
                    PLN.InsertarPersonalCalendarioVoid(textCedula.Text, lista[datico]);

                    MessageBoxEx.Show("Persona registrada con éxito");
                }
               

                
                
            }
            catch (Exception er){
                MessageBox.Show(er.Message);
            }
           LimpiarCajasTexto();

        }

        private void LimpiarCajasTexto() {
            textCedula.Text = null;
            textNombres.Text = null;
            textApellidos.Text = null;
            textCargo.Text = null;
            textCiudad.Text = null;
            textCorreo.Text = null;
            textDireccion.Text = null;
            textTelefono.Text = null;
            comboNombresDedos.SelectedItem = null;
            comboCalendario.SelectedItem = null;
            comboSexo.SelectedItem = null;
            comboTipo.SelectedItem = null;
            textTitulo.Text = null;
            pictureFoto.Image = null;
            pictureHuella.Image = null;
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

        //private void buttonX1_Click(object sender, EventArgs e)
        //{

        //    OpenFileDialog Abrir = new OpenFileDialog();
        //    Abrir.Filter = "Archivos JPEG(*.JPG) |*.jpg";
        //    Abrir.InitialDirectory = "C:/gerson";
        //    if (Abrir.ShowDialog() == DialogResult.OK)
        //    {
        //        string Dir = Abrir.FileName;
        //        picture = new Bitmap(Dir);
        //        pictureFoto.Image = (Image)picture;

        //    }
        //}



        private void buttonX2_Click(object sender, EventArgs e)
        {
            
        }

        //metodo para capturar huella
        bool selacthuella;
        public void Inicializar()
        {
            try
            {
                selacthuella = false;
                //Tipo de Secugen Fingerprint reader utilizado 
                SGFPMDeviceName device_name = SGFPMDeviceName.DEV_FDU05;
                //Inicializar SGFingerPrintManager para que cargue el driver del dispositivo utilizado
                m_FPM = new SGFingerPrintManager();
                m_FPM.Init(device_name);
                //Escoge el Puerto en el que se ejecuta el dispositivo
                Int32 port_addr = (Int32)SGFPMPortAddr.USB_AUTO_DETECT;
                Int32 iError = m_FPM.OpenDevice(port_addr);
                if (iError == (Int32)SGFPMError.ERROR_NONE)
                    //toolStrip1.Text = "Initialization Success";
                    MessageBox.Show("Por favor coloque su dedo en el lector de huellas");
                else
                    MessageBox.Show("Error al inicializar Lector de Huellas");

                //toolStrip1.Text = "OpenDevice() Error : " + iError;
                //Obtener Informacion del dispositivo inicializado
                SGFPMDeviceInfoParam pInfo = new SGFPMDeviceInfoParam();
                iError = m_FPM.GetDeviceInfo(pInfo);
                if (iError == (Int32)SGFPMError.ERROR_NONE)
                {
                    // This should be done GetDeviceInfo();
                    m_ImageWidth = pInfo.ImageWidth;
                    m_ImageHeight = pInfo.ImageHeight;
                }                
                Byte[] fp_image = new Byte[m_ImageWidth * m_ImageHeight];
                SGFPMSecurityLevel secu_level = SGFPMSecurityLevel.NORMAL; // Adjust this value according to application type
                //Convierte el huella en una imagen y la presenta en un picturebox
                iError = m_FPM.GetImage(fp_image);
                if (iError == (Int32)SGFPMError.ERROR_NONE)
                {
                    DrawImage(fp_image, pictureHuella);
                }
                Int32 max_template_size = 0;
                //Obtiene el maximo tamaño que posee el buffer.
                m_FPM.GetMaxTemplateSize(ref max_template_size);
                arrayHuella1 = new Byte[max_template_size];
                arrayHuella2 = new Byte[max_template_size];
                //Crea un formato(minucia) a partir de la imagen
                m_FPM.CreateTemplate(fp_image, arrayHuella1);
                iError = m_FPM.GetImage(fp_image);
                if (iError == (Int32)SGFPMError.ERROR_NONE)
                {
                    DrawImage(fp_image, pictureHuella);
                }
                m_FPM.CreateTemplate(fp_image, arrayHuella2);
                // Match for registration
                bool matched = false;
                iError = m_FPM.MatchTemplate(arrayHuella1, arrayHuella2, secu_level, ref matched);
                string er = iError.ToString();

                if (er.Equals("0"))
                {
                    MessageBox.Show("Lectura de huella exitosa");
                    selacthuella = true;
                }
                else
                {
                    MessageBox.Show("Error en la lectura de su huella....Por favor inténtelo otras vez");
                }
                m_FPM.CloseDevice();
            }
            catch (Exception)
            {
                MessageBoxEx.Show("No se encuentra el dispositivo bómétrico...Por favor verifique su conexión.");
            }

        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click_2(object sender, EventArgs e)
        {
            try
            {


                Inicializar();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error, no se ha encontrado el disposito biométrico.");
            }
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            VAL.numeros(e);
            VAL.Enter(e, textNombres);
        }

        private void textNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            VAL.Letras(e);
            VAL.Enter(e, textApellidos);
        }

        private void textApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            VAL.Letras(e);
            VAL.Enter(e, comboSexo);

        }

        private void textTitulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            VAL.Letras(e);
            VAL.Enter(e, comboTipo);
        }

        private void textCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            VAL.Letras(e);
            VAL.Enter(e, textTelefono);
        }

        private void textTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            VAL.numeros(e);
            VAL.Enter(e, textCorreo);
        }

        private void textCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            VAL.Enter(e, textCiudad);

        }

        private void textCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            VAL.Letras(e);
            VAL.Enter(e, textDireccion);
        }

        private void textDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            VAL.Letras(e);
            VAL.Enter(e, comboCalendario);
        }

        private void textCorreo_Validated(object sender, EventArgs e)
        {
            if (textCorreo.Text != "")
            {
                if (VAL.email_bien_escrito(textCorreo.Text) == false)
                {
                    errorProvider1.SetError(textCorreo, "Correo no Válido");
                    textCorreo.Focus();
                }
                else
                    errorProvider1.Clear();
            }
        }

        private void textCedula_Validated(object sender, EventArgs e)
        {
            bool mistmatch = false;
            for (int i = 0; i < textCedula.Text.Length; i++)
            {
                if (i>0 && textCedula.Text[i] != textCedula.Text[i - 1])
                    mistmatch = true;
            }
            if (textCedula.Text != "" )
            {
                if (!VAL.esCedulaValida(textCedula.Text) || mistmatch==false)
                {
                    errorProvider1.SetError(textCedula, "Cedula no Valida");
                    textCedula.Focus();
                }
                else
                    errorProvider1.Clear();
            }
           // VAL.Enter(e, textCedula);
        }

        private void DrawImage(Byte[] imgData, PictureBox picBox)
        {
            int colorval;
            Bitmap bmp = new Bitmap(m_ImageWidth, m_ImageHeight);
            picBox.Image = (Image)bmp;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    colorval = (int)imgData[(j * m_ImageWidth) + i];
                    bmp.SetPixel(i, j, Color.FromArgb(colorval, colorval, colorval));
                }
            }
            picBox.Refresh();
        }
    }
}