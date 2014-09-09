using CapaEntidades.GestionSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.cd_GestionSeguridad
{
    public class RolesCD
    {
        public static List<string> getnombRoles()
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var roles = from i in DB.ROLES
                              select i.NOMBRE;
                    return roles.ToList();

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

        public static string getIdRolByNombrRol(string nombrerol)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var roles = from i in DB.ROLES
                                where i.NOMBRE==nombrerol
                                select i.IDROL;
                    return roles.Single();

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

        public static string getNombrerolByIdRol(string idrol)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var roles = from i in DB.ROLES
                                where i.IDROL == idrol
                                select i.NOMBRE;
                    return roles.Single();

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

        public static List<pa_ObtenerArbolbyNombreRolResult> getarbol(string nombrerol)
        {
            throw new NotImplementedException();
        }

        public static List<ROLES> getRoles()
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {

                    return DB.ROLES.ToList(); ;

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

        public static void insertarRol(Roles rol)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {

                bd.pa_InsertarRol(rol.IdRol,rol.Nombre,rol.Descripcion,true);
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

        public static List<pa_FiltrarRolesResult> getRoles(string valordebusqueda)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {

                    return DB.pa_FiltrarRoles(valordebusqueda).ToList(); ;

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

        public static void EliminarRol(string idrol)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {
                
                bd.sp_EliminarRol(idrol);
                bd.SubmitChanges();
            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al  Eliminar Producto.", ex);
            }
            finally
            {
                bd = null;
            }

        }

        public static void modificarRol(Roles rol)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {

                //HABILITAR
                bd.sp_ModificarRol(rol.IdRol,rol.Nombre,rol.Descripcion,rol.Estado);
                bd.SubmitChanges();

            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al Modificar Personal.", ex);
            }
            finally
            {
                bd = null;
            }

        }
    }
}
