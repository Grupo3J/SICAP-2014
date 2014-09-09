using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.cd_GestionSeguridad
{
    public class SistemaCD
    {
        public static List<pa_ObtenerArbolResult> getarbol(string nick,string clave)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.pa_ObtenerArbol(nick, clave).ToList();
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

        public static List<pa_ObtenerArbolResult>  getArbolbynickclave(string nick, string clave)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.pa_ObtenerArbol(nick, clave).ToList();
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
    }
}
