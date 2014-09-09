using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.cd_GestionSeguridad
{
    public class RecursoCD
    {
        public static string geturlrecurso_by_nombremod(string nombremodulo)
        {
             CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var sql = from i in DB.pa_GetUrlRecursoByNombreModulo(nombremodulo)                             
                              select i;
                    return sql.Single().URLRECURSO;
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

        public static List<RECURSOS> getRecursos()
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {

                    return DB.RECURSOS.ToList(); ;

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
