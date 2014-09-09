using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos.cd_GestionSeguridad;
using System.Windows.Forms;
using CapaDatos;

using System.Data;
namespace CapaLogicaNegocio
{
    public class Sistema
    {
        private  string nick;

        public string Nick
        {
            get { return nick; }
            set { nick = value; }
        }
        private  string clave;

        public  string Clave
        {
            get { return clave; }
            set { clave = value; }
        }
        private  string cedula;

        public  string Cedula
        {
            get { return cedula; }
            set { cedula = value; }
        }
        private DataSet dataSetArbol;
        public Sistema()
        {

        }
        Cifrado md5 = new Cifrado();
        public bool Login(string nick,string clave)
        {
            string claveencriptada = md5.Encriptar(clave);
            if(UsuarioCD.Login(nick,claveencriptada)){
                this.nick = nick;
                this.clave = clave;
                cedula = UsuarioCD.getcedulabynickclave(nick,claveencriptada);
                return true;
            }else{
                return false;
            }
            
        }
        public void SetArbol(TreeView arbol){
            CrearDataSet();
            CrearNodosDelPadre("MD0", null, arbol);
        }
        private void CrearDataSet()
        {
            dataSetArbol = new DataSet("DataSetArbol");

            DataTable tablaArbol = dataSetArbol.Tables.Add("MODULOS");
            tablaArbol.Columns.Add("IDMODULO", typeof(string));
            tablaArbol.Columns.Add("MOD_IDMODULO", typeof(string));
            tablaArbol.Columns.Add("NOMBRE", typeof(string));

            List<pa_ObtenerArbolResult> ar = SistemaCD.getarbol(nick,clave);
            foreach (pa_ObtenerArbolResult item in ar)
            {
                InsertarDataRow(item.IDMODULO, item.MOD_IDMODULO, item.NOMBRE);
            }

        }

        private void InsertarDataRow(string column1, string column2, string column3)
        {
            try
            {
                DataRow nuevaFila = dataSetArbol.Tables["MODULOS"].NewRow();
                //int H = 0;
                nuevaFila["IDMODULO"] = column1;
                nuevaFila["MOD_IDMODULO"] = column2;
                nuevaFila["NOMBRE"] = column3;
                dataSetArbol.Tables["MODULOS"].Rows.Add(nuevaFila);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

        }


        private void CrearNodosDelPadre(string indicePadre, TreeNode nodePadre, TreeView tree)
        {         
         try
            {
                // Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
                DataView dataViewHijos = new DataView(dataSetArbol.Tables["MODULOS"]);
                dataViewHijos.RowFilter = dataSetArbol.Tables["MODULOS"].Columns["MOD_IDMODULO"].ColumnName + " = '" + indicePadre+"'";
            
                // Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
                foreach (DataRowView dataRowCurrent in dataViewHijos)
                {
                    TreeNode nuevoNodo = new TreeNode();
                    
                    nuevoNodo.Text = dataRowCurrent["NOMBRE"].ToString().Trim();
                    // si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
                    // del primer nivel que no dependen de otro nodo.
                    if (nodePadre == null)
                    {
                        tree.Nodes.Add(nuevoNodo);
                    }
                    // se añade el nuevo nodo al nodo padre.
                    else
                    {
                        nodePadre.Nodes.Add(nuevoNodo);
                    }

                    // Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.

                    CrearNodosDelPadre((dataRowCurrent["IDMODULO"].ToString()), nuevoNodo, tree);
                }
            }
            catch (Exception E)
            {
                
                MessageBox.Show(E.Message);
            }
          
        
        
        
        }




        public List<pa_ObtenerArbolResult> getArbol(string nick, string clave)
        {

            return SistemaCD.getArbolbynickclave(nick,md5.Encriptar(clave));
        }
    }
}
