using CapaDatos;
using CapaEntidades.GestionSeguridad;
using CapaLogicaNegocio;
using CapaLogicaNegocio.cln_GestionSeguridad;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents;
using DevComponents.DotNetBar.Controls;
using SecuGen.FDxSDKPro.Windows;
using System.IO;
using System.Diagnostics;

namespace CapaInterfaz.ci_GestionSeguridad
{
    public partial class frmSICAP2014 : DevComponents.DotNetBar.Metro.MetroAppForm
    {
        private Form owner;

        public Form Owner1
        {
            get { return owner; }
            set { owner = value; }
        }
        UsuariosLN USLN = new UsuariosLN();
        RecursoLN RCLN = new RecursoLN();
        public Usuarios user = new Usuarios();
        Sistema si = new Sistema();
        Validaciones val = new Validaciones();
        RolesLN OPRLN = new RolesLN();
        public string OPTION = "";

        public frmSICAP2014(Form owner)
        {
            InitializeComponent();
            Owner1 = owner;
            frmLog_In princp = (frmLog_In)Owner1;
            princp.Children = this;
        }

        public void addPanel(object form)
        {
            if (this.panelEx1.Controls.Count > 0)
                this.panelEx1.Controls.RemoveAt(0);
            Form fh = form as Form;
           
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelEx1.Controls.Add(fh);
            this.panelEx1.Tag = fh;
            fh.Show();
        }

        private void frmSICAP2014_Load(object sender, EventArgs e)
        {
            timer1.Start();           

            groupPanel1.BackColor = System.Drawing.Color.White;
            Sistema sist = new Sistema();
            
            eMetroTileColor[] colores =new  eMetroTileColor[9];
            colores[0] = eMetroTileColor.Orange;
            colores[1] = eMetroTileColor.Magenta;
            colores[2] = eMetroTileColor.Blue;
            colores[3] = eMetroTileColor.Teal;
            colores[4] = eMetroTileColor.Yellowish;
            colores[5] = eMetroTileColor.Gray;
            colores[6] = eMetroTileColor.DarkGreen;
            colores[7] = eMetroTileColor.DarkBlue;
            colores[8] = eMetroTileColor.PlumWashed;
            if (sist.Login(user.Nick, user.Clave))
            {

                addPanel(new frmHome());
                user = USLN.getUserbyced(sist.Cedula);

                cargarUsuario();
                
                List<sp_ObtenerArbolResult>   g=sist.getArbol(user.Nick, user.Clave);

                

                var modulospri = from i in g
                                 where i.MOD_IDMODULO == "MD0"
                                 select i;
                // var y = sql.Count();
                int y = 0;

                foreach (var item in modulospri)
                {
                    
                    y++;


                    //metrotabitem
                    MetroTabItem metroTabItemjh = new MetroTabItem();
                    metroTabItemjh.Name = item.NOMBRE;// "Mimetrotabjh";

                    metroTabItemjh.Text = item.NOMBRE;// "mimetrotab";

                   

                    // 
                    // metroTabPanel2
                    // 
                    MetroTabPanel metroTabPaneljh = new MetroTabPanel();
                    metroTabPaneljh.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
                    metroTabPaneljh.Dock = System.Windows.Forms.DockStyle.Fill;
                    metroTabPaneljh.Location = new System.Drawing.Point(0, 51);
                    metroTabPaneljh.Name = "metroTabPaneljh" + item.NOMBRE;
                    metroTabPaneljh.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
                    metroTabPaneljh.Size = new System.Drawing.Size(544, 103);
                    // 
                    // 
                    // 
                    metroTabPaneljh.Style.Class = "";
                    metroTabPaneljh.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                    // 
                    // 
                    // 
                    metroTabPaneljh.StyleMouseDown.Class = "";
                    metroTabPaneljh.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;



                    //itempanel
                    ItemPanel itemPaneljh = new ItemPanel();

                    itemPaneljh.BackgroundStyle.Class = "ItemPanel";
                    itemPaneljh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
                    itemPaneljh.ContainerControlProcessDialogKey = true;
                    itemPaneljh.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
                    itemPaneljh.Location = new System.Drawing.Point(0, 0);
                    itemPaneljh.Name = "itemPaneljh" + item.NOMBRE;
                    itemPaneljh.Size = new System.Drawing.Size(700, 103);
                    itemPaneljh.TabIndex = 0;
                    itemPaneljh.Text = "itemPanel1";

                    //itemcontainer
                    ItemContainer itemContainerjh = new ItemContainer();
                    itemContainerjh.BackgroundStyle.Class = "";
                    itemContainerjh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
                    itemContainerjh.Name = "itemContainerjh" + item.NOMBRE;


                    var submo = from iss in g
                                where iss.MOD_IDMODULO == item.IDMODULO
                                select iss;
                    int con = 0;
                    foreach (var subm in submo)
                    {
                        MetroTileItem metroTileItemjh = new DevComponents.DotNetBar.Metro.MetroTileItem();

                        // 
                        // metroTileItem1
                        // 
                        metroTileItemjh.Name = subm.IDMODULO;// "metroTileItem2  jh";
                        
                        metroTileItemjh.TitleText = subm.IDMODULO;// "Texto de titulo";
                       // metroTileItemjh.Image = global::dedonetbar.Properties.Resources.IMG00244;
                        metroTileItemjh.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
                        metroTileItemjh.TileColor = colores[con];//.DotNetBar.Metro.eMetroTileColor.Default;
                        metroTileItemjh.TileSize= new System.Drawing.Size(140, 90);
                        metroTileItemjh.Text = "<h5>" + subm.NOMBRE + "</h5>";// "metroTileItem2";
                        
                        con++;
                        metroTileItemjh.Click += new System.EventHandler(this.itemPanel1_ItemClick);
                        itemContainerjh.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            metroTileItemjh});
                    }


                    //Agrego metrotabitem a metroshell
                    this.metroShell1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
                    
            metroTabItemjh});
                    //agrego metrotabpanel
                    this.metroShell1.Controls.Add(metroTabPaneljh);
                    //agrego metrotabpanel al metrotabitem
                    metroTabItemjh.Panel = metroTabPaneljh;
                    //  agrego itempanel as metrotabpanel
                    metroTabPaneljh.Controls.Add(itemPaneljh);
                    //Agrego itemcontainer al itempanel
                    itemPaneljh.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            itemContainerjh});
                    //Agrego itemtile a itemcontainer



                }

            }

            
          //  = si.getArbol()("secretariacool", "secre").ToList();

            
        }

        private void cargarUsuario()
        {
            try
            {

                lblnameuser.Text =  user.Nombre;
                lblrol.Text = OPRLN.getNombrerolByIdRol(user.IdRol);
                //lbluser.Text = user.Nombre + " " + user.Apellido + " (" + OPRLN.getNombrerolByIdRol(user.IdRol) + ")";
                byte[] imageData = user.DataFoto.ToArray();
                Image newImage;
                using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length))
                {
                    ms.Write(imageData, 0, imageData.Length);
                    newImage = Image.FromStream(ms, true);
                }
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = newImage;
                
                

            }
            catch (Exception)
            {

            }
        }


        private void itemPanel1_ItemClick(object sender, EventArgs e)
        {
            //MessageBox.Show(((MetroTileItem)sender).Text);

            string op = ((MetroTileItem)sender).Text.Substring(4, ((MetroTileItem)sender).Text.Length-9);
               
            try
            {
                string url = RCLN.geturlrecurso_by_nombremod(op);
                Type objectType = Type.GetType(url);
                Form myObject = (Form)Activator.CreateInstance(objectType);
                MethodInfo methodInfo = objectType.GetMethod("setUser");

                PermisosLN PERLN = new PermisosLN();//En todos los formularios
                methodInfo.Invoke(myObject, new Object[] { (user), PERLN.getPermisoBycednommbremodulo(user.Cedula, op) });
                addPanel(myObject);
                groupPanel1.Text = op;
                groupPanel1.BackColor = System.Drawing.Color.White;
                groupPanel1.ColorTable = (ePanelColorTable)((MetroTileItem)sender).TileColor;
                // MessageBox.Show(RCLN.geturlrecurso_by_nombremod(op));

            }
            catch (Exception)
            {
                DevComponents.DotNetBar.MessageBoxEx.Show(this, "No se ha podido mostra la ventana es posible que no se haya especificiado bien la url del formulario o el metodo(setuser)", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
          
            }
            


        }

        private void btnNombre_Click(object sender, EventArgs e)
        {

        }

        private void btnmiperfl_Click(object sender, EventArgs e)
        {
            
        }

        private void btncerrarsesion_Click(object sender, EventArgs e)
        {
            
        }

        private void eventoticktimer(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToLongTimeString(); 
        }

        private void metroShell1_Click(object sender, EventArgs e)
        {
           
        }

        private void helbuttonclick(object sender, EventArgs e)
        {

            ci_GestionAyuda.frmAyuda ayuda = new ci_GestionAyuda.frmAyuda();
            addPanel(ayuda);
            groupPanel1.Text = "Ayuda de Sicap";

            //CapaInterfaz.Properties.Resources.
           // global::.Properties.Resources.IMG00244
            //Process.Start("C:\\Users\\HERNAN\\SkyDrive\\UNIVERSIDAD\\MODULOS\\REDACCION DE INFORMES\\portafolio\\chm.chm");
            string ruta = Application.StartupPath.Replace("bin\\Debug", "Resources\\SICAP.chm");
           
            Process.Start(ruta);
        }

        private void settingsbuttonclick(object sender, EventArgs e)
        {
            addPanel(new frmHome());
            groupPanel1.Text = "SICAP Sistema de control de asistencia de Personal";
        }

        private void radialMenu1_ItemClick(object sender, EventArgs e)
        {
            try
            {
                RadialMenuItem j = ((RadialMenuItem)sender);
                if (j == radialhome)
                {
                    addPanel(new frmHome());
                    groupPanel1.Text = "SICAP Sistema de control de asistencia de Personal";
                }
                if (j == radialcerrarsesion)
                {
                    OPTION = "LOGOUT";
                    this.Close();
                }
                if (j == radialacercade)
                {
                    ci_GestionAyuda.frmAcercaDe acercade = new ci_GestionAyuda.frmAcercaDe();
                    groupPanel1.Text = "Acerca de";
                    addPanel(acercade);
                }
                if (j == radialmiperfil)
                {
                    frmMiPerfil perfil = new frmMiPerfil();
                    perfil.llenaruser(user);
                    addPanel(perfil);
                    groupPanel1.Text = "Mi Perfil ";
                }
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        private void frmSICAP2014_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (OPTION == "LOGOUT")
            {
                frmLog_In fo = (frmLog_In)owner;
                fo.Return("LOGOUT");            
            }
            else 
            {
                e.Cancel = true;
                OPTION = "EXIT";
                this.Hide();
                frmLog_In fo = (frmLog_In)owner;
                fo.Return("EXIT");      
            }
        }


        
    }
}
