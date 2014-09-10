using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocio.cln_GestionSeguridad;
using CapaEntidades.GestionSeguridad;
using System.Reflection;

namespace CapaInterfaz.ci_GestionSeguridad
{
    public partial class frmSICAP : Form
    {
       // public string nick;
       // public string clave;
        UsuariosLN USLN = new UsuariosLN();
        RecursoLN RCLN = new RecursoLN();
        public Usuarios user = new Usuarios();
        public frmSICAP()
        {
            InitializeComponent();        
           

        }
       

        private void addPanel(object form)
        {
            if (this.panelCentral.Controls.Count > 0)
                this.panelCentral.Controls.RemoveAt(0);
            Form fh = form as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelCentral.Controls.Add(fh);
            this.panelCentral.Tag = fh;
            fh.Show();
        }

        private void administrarPersonalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string op = treeView1.SelectedNode.Text;
            
            try
            {
                
               //CapaInterfaz.Seguridad
                
                Type objectType = Type.GetType(RCLN.geturlrecurso_by_nombremod(op));
                Form myObject = (Form)Activator.CreateInstance(objectType);
                MethodInfo methodInfo = objectType.GetMethod("setUser");

                PermisosLN PERLN = new PermisosLN();//En todos los formularios
                methodInfo.Invoke(myObject, new Object[] { (user) ,PERLN.getPermisoBycednommbremodulo(user.Cedula,op)});
                addPanel(myObject);
               // MessageBox.Show(RCLN.geturlrecurso_by_nombremod(op));
           
            }
            catch (Exception)
            {
               
            }
            
            
        }

        private void frmSICAP_Load(object sender, EventArgs e)
        {
            Sistema sist = new Sistema();
            if (sist.Login(user.Nick, user.Clave))
            {
                
               // sist.SetArbol(this.treeView1);
                user = USLN.getUserbyced(sist.Cedula);
               
            }
                
          
            
        }

        private void beforecheck(object sender, TreeViewCancelEventArgs e)
        {
            MessageBox.Show("" + !e.Node.Checked);
        }
    }
}
