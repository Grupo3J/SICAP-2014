using CapaEntidades.GestionSeguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaInterfaz.ci_GestionAyuda
{
    public partial class frmAyuda : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmAyuda()
        {
            InitializeComponent();
        }

        private void frmAyuda_Load(object sender, EventArgs e)
        {
            
            webBrowser1.AllowWebBrowserDrop = false;
            //webBrowser1.Url=new Uri("file:///C:/Users/HERNAN/Desktop/manual/index.htm");
            //webBrowser1.Url = new Uri("httcom/"); para web
           // webBrowser1.Url = new Uri("C:\\Users\\HERNAN\\SkyDrive\\UNIVERSIDAD\\MODULOS\\REDACCION DE INFORMES\\portafolio\\manual de usuario.pdf");
      
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
        public void setUser(Usuarios s, Permisos per)
        {
            user = s;
            permiso = per;
        }

        public Usuarios user { get; set; }

        public Permisos permiso { get; set; }
    }
}
