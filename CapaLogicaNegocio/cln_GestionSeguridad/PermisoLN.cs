using CapaDatos;
using CapaEntidades.GestionSeguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.cd_GestionSeguridad;
namespace CapaLogicaNegocio.cln_GestionSeguridad
{
    public class PermisosLN
    {
        DataSet dataSetArbol;
        List<pa_ObtenerrecursosypermisosbynombreroResult> listare;
        public PermisosLN() { }
        public Permisos getPermisoBycednommbremodulo(string Cedula,string NombreModulo)
        {
            return PermisosCD.getPermisoBycednommbremodulo(Cedula,NombreModulo);

        }
        public bool modificar(Permisos per)
        {
            return PermisosCD.modificar(per);
        }


        public Permisos getPermisoByidmodNombreRol(string idmod,string nombrerol)
        {
           // List<pa_ObtenerrecursosypermisosbynombrerolResult> lisrec=Obtenerrecursosypermisosbynombrerol(nombrerol);
            try
            {
                var sql = (from i in listare
                           where i.IDMODULO == idmod
                           select i).Single();
                Permisos p = new Permisos();
                p.IdPermiso = sql.IDPERMISO;
                p.IdRol = sql.IDROL;

                p.IdRecurso = sql.IDRECURSO;
                p.Estado = sql.ESTADO;
                p.Lectura = sql.LECTURA;
                p.Escritura = sql.ESCRITURA;
                p.Eliminacion = sql.ELIMINACION;
                p.Modificacion = sql.MODIFICACION;
                p.Busqueda = sql.BUSQUEDA;

                return p;
            }
            catch (Exception)
            {

                return null;
            }
           
        }
        public void SetArbol(TreeView arbol,string nombrerol)
        {
            listare = Obtenerrecursosypermisosbynombrerol(nombrerol);           
            CrearDataSet(nombrerol);
            CrearNodosDelPadre("MD0", null, arbol,nombrerol);
        }
        private void CrearDataSet(string nombrerol)
        {
            dataSetArbol = new DataSet("DataSetArbol");

            DataTable tablaArbol = dataSetArbol.Tables.Add("MODULOS");
            tablaArbol.Columns.Add("IDMODULO", typeof(string));
            tablaArbol.Columns.Add("MOD_IDMODULO", typeof(string));
            tablaArbol.Columns.Add("NOMBRE", typeof(string));

            List<pa_ObtenerArbolbyNombreRolResult> ar = getarbolbyNombreRol(nombrerol);
            foreach (pa_ObtenerArbolbyNombreRolResult item in ar)
            {
                InsertarDataRow(item.IDMODULO, item.MOD_IDMODULO, item.NOMBRE);

                
                try
                {

                    var sql = (from i in listare
                               where i.IDMODULO == item.IDMODULO
                               select i).Single();

                    //InsertarDataRow(sql.IDMODULO + "1", item.IDMODULO, "LECTURA");
                    //InsertarDataRow(item.IDMODULO + "2", item.IDMODULO, "INSERTAR");
                    //InsertarDataRow(item.IDMODULO + "3", item.IDMODULO, "ELIMINAR");
                    //InsertarDataRow(sql.IDMODULO + "4", item.IDMODULO, "EDITAR");
                    //InsertarDataRow(item.IDMODULO + "5", item.IDMODULO, "BUSCAR");

                    
                    InsertarDataRow(sql.IDMODULO + "B", item.IDMODULO, "INSERTAR");
                    InsertarDataRow(sql.IDMODULO + "C", item.IDMODULO, "EDITAR");
                    InsertarDataRow(sql.IDMODULO + "D", item.IDMODULO, "ELIMINAR");
                    
                    
                }
                catch (Exception)
                {

                    
                    //throw;
                }

            }

        }

        public List<pa_ObtenerrecursosypermisosbynombreroResult> Obtenerrecursosypermisosbynombrerol(string nombrerol)
        {
            return  PermisosCD.Obtenerrecursosypermisosbynombrerol(nombrerol);
        }
        private  List<pa_ObtenerArbolbyNombreRolResult> getarbolbyNombreRol(string nombrerol)
        {
            return PermisosCD.getarbolbyNombreRol(nombrerol);
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
            catch (Exception )
            {
               
            }

        }


        private void CrearNodosDelPadre(string indicePadre, TreeNode nodePadre, TreeView tree,string nombrerol)
        {
            try
            {
                // Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
                DataView dataViewHijos = new DataView(dataSetArbol.Tables["MODULOS"]);
                dataViewHijos.RowFilter = dataSetArbol.Tables["MODULOS"].Columns["MOD_IDMODULO"].ColumnName + " = '" + indicePadre + "'";

                // Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
                foreach (DataRowView dataRowCurrent in dataViewHijos)
                {
                    TreeNode nuevoNodo = new TreeNode();
                    string idmod = dataRowCurrent["IDMODULO"].ToString().Trim();//mi parte
                    string modidmod = dataRowCurrent["MOD_IDMODULO"].ToString().Trim();//mi parte
                    string nomb = dataRowCurrent["NOMBRE"].ToString().Trim();
                    nuevoNodo.Name = modidmod;
                    if (nodePadre == null)
                    {

                    }
                    else
                    {
                        if (nodePadre.Level == 0)
                        {
                            try
                            {
                                var sql = (from i in listare
                                   where i.IDMODULO == idmod
                                   select i).Single();
                                nuevoNodo.Checked = sql.ESTADO;
                            }
                            catch (Exception)
                            {
                               
                                //throw;
                            }
                        }
                    }
                    //if(modidmod=="MD0")
                    try
                    {
                        
                       // List<pa_ObtenerrecursosypermisosbynombrerolResult>listarec=Obtenerrecursosypermisosbynombrerol(nombrerol);


                        var sqli = (from i in listare
                                   where i.IDMODULO == modidmod
                                   select i);
                        if (sqli.Count() > 0)
                        {
                            var sql = sqli.Single();
                           

                            if (nomb == "INSERTAR")
                            {
                                nuevoNodo.Checked = sql.ESCRITURA;
                            }
                            if (nomb == "ELIMINAR")
                            {
                                nuevoNodo.Checked = sql.ELIMINACION;
                            }
                            if (nomb == "EDITAR")
                            {
                                nuevoNodo.Checked = sql.MODIFICACION;
                            }
                           
                        
                        }
                        
                        
                    }
                    catch (Exception e)
                    {

                        string h = e.Message;
                    }
                    
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

                    CrearNodosDelPadre((dataRowCurrent["IDMODULO"].ToString()), nuevoNodo, tree,nombrerol);
                }
            }
            catch (Exception)
            {

                
            }

        }



        public string getidmodbynombremod(string nombremod)
        {
            return PermisosCD.getidmodbynombremod(nombremod);
        }
        public void insertarPermiso(Permisos per)
        {

            PermisosCD.insertarPermiso(per);
        }
    }
}
