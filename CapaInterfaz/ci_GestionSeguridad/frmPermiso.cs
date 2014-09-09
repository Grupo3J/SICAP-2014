using CapaEntidades.GestionSeguridad;
using CapaLogicaNegocio;
using CapaLogicaNegocio.cln_GestionSeguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaInterfaz.ci_GestionSeguridad
{
    public partial class frmPermiso : DevComponents.DotNetBar.Metro.MetroForm
    {
        Usuarios user = new Usuarios();//En todos los formularios       
        Permisos permiso = new Permisos();//En todos los formularios
        PermisosLN PELN = new PermisosLN();
       
        RolesLN rLN = new RolesLN();
        public frmPermiso()
        {
            InitializeComponent();
        }

        private void frmPermiso_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = rLN.getnombRoles();
        }
        public void setUser(Usuarios s, Permisos per)
        {
            user = s;
            permiso = per;
        }
        private void beforecheck(object sender, TreeViewCancelEventArgs e)
        {
           
            
        }

        private void aftercheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                
                foreach (TreeNode item in e.Node.Nodes){
                    Permisos pertem = PELN.getPermisoByidmodNombreRol(PELN.getidmodbynombremod(item.Text), comboBox1.SelectedItem.ToString());
                    pertem.Estado = e.Node.Checked;
                    item.Checked = e.Node.Checked;
                    PELN.modificar(pertem);
                }
            }
            if (e.Node.Level == 1) {
                Permisos pertem = PELN.getPermisoByidmodNombreRol(PELN.getidmodbynombremod(e.Node.Text), comboBox1.SelectedItem.ToString());
                pertem.Estado = e.Node.Checked;
                PELN.modificar(pertem);
            }
            if (e.Node.Level == 2)
            {
                string modidmodulo = e.Node.Name;
                TreeNode tem = e.Node.Parent;

                //Permisos per = new Permisos();
                //per.Lectura = tem.Nodes[0].Checked;
                //per. Escritura = tem.Nodes[1].Checked;
                //per.Eliminacion = tem.Nodes[2].Checked;
                //per.Modificacion = tem.Nodes[3].Checked;
                //per.Busqueda = tem.Nodes[4].Checked;
                Permisos pertem = PELN.getPermisoByidmodNombreRol(modidmodulo, comboBox1.SelectedItem.ToString());
                pertem.Lectura = tem.Nodes[0].Checked;
                pertem.Escritura = tem.Nodes[1].Checked;
                pertem.Eliminacion = tem.Nodes[2].Checked;
                pertem.Modificacion = tem.Nodes[3].Checked;
                pertem.Busqueda = tem.Nodes[4].Checked;
                PELN.modificar(pertem);

            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

          
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeView1.CheckBoxes = true;
            treeView1.Nodes.Clear();
            PELN.SetArbol(treeView1, comboBox1.SelectedItem.ToString());
            
        }
    }
}
