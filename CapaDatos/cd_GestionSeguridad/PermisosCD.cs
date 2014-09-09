using CapaEntidades.GestionSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.cd_GestionSeguridad
{
    public class PermisosCD
    {
        public static Permisos getPermisoBycednommbremodulo(string Cedula, string NombreModulo)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    pa_ObtenerPermisosByCedNombreModResult permisosgeneral= DB.pa_ObtenerPermisosByCedNombreMod(Cedula,NombreModulo).Single();
                    Permisos per = new Permisos();
                    per.IdPermiso = permisosgeneral.IDPERMISO;
                    per.IdRol = permisosgeneral.IDROL;
                    per.IdRecurso = permisosgeneral.IDRECURSO;
                    per.Estado = permisosgeneral.ESTADO;
                    per.Lectura = permisosgeneral.LECTURA;
                    per.Escritura = permisosgeneral.ESCRITURA;
                    per.Eliminacion = permisosgeneral.ELIMINACION;
                    per.Modificacion = permisosgeneral.MODIFICACION;
                    per.Busqueda = permisosgeneral.BUSQUEDA;
                   
                    return per;
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Buscar Codigo del Producto.", ex);
            }
            finally
            {
                DB = null;
            }
        }

      


        public static List<pa_ObtenerrecursosypermisosbynombreroResult> Obtenerrecursosypermisosbynombrerol(string nombrerol)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    List<pa_ObtenerrecursosypermisosbynombreroResult> L=DB.pa_Obtenerrecursosypermisosbynombrero(nombrerol).ToList();
                    return L;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar Categorias.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<pa_ObtenerArbolbyNombreRolResult> getarbolbyNombreRol(string nombrerol)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.pa_ObtenerArbolbyNombreRol(nombrerol).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Listar Categorias.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static bool modificar(Permisos per)
        {

            
            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {
                    bd.pa_Modificar_Permiso(per.IdPermiso,per.IdRol,per.IdRecurso,per.Estado,per.Lectura,per.Escritura,per.Eliminacion,per.Modificacion,per.Busqueda);
            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al  Insertar Producto.", ex);
            }
            finally
            {
                bd = null;
            }
            return true;
        }

        public static string getidmodbynombremod(string nombremod)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {

                    
                    var sql = (from i in DB.MODULOS
                              where i.NOMBRE == nombremod
                              select i.IDMODULO);

                    var y = sql.Count();

                    return sql.Single();
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Buscar Codigo del Producto.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void insertarPermiso(Permisos per)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {

                bd.pa_InsertarPermiso(per.IdPermiso,per.IdRol,per.IdRecurso,per.Estado,per.Lectura,per.Escritura,per.Eliminacion,per.Modificacion,per.Busqueda );
                bd.SubmitChanges();
            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al  Insertar Producto.", ex);
            }
            finally
            {
                bd = null;
            }

        }

        public static int count()
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {


                    return DB.PERMISOS.ToList().Count;
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Buscar Codigo del Producto.", ex);
            }
            finally
            {
                DB = null;
            }
        }

    }
}
