using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.cd_GestionAsistencia
{
    public class ImprevistoCD
    {
        public static bool Existe(string id)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var query = (from prov in DB.IMPREVISTOS where prov.IDIMPREVISTO == id select prov).Count();
                    if (query == 0)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Buscar el Id de Imprevisto.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<sp_ImprevistosporCalendarioResult> ObtenerImprevistos(string idcalendario) 
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var query = from prov in DB.sp_ImprevistosporCalendario(idcalendario) select prov;
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Buscar el Id de Imprevisto.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        
    }
}
