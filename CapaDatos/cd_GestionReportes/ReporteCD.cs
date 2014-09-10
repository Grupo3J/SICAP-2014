using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
namespace CapaDatos.cd_GestionReportes
{
    public class ReporteCD
    {

        public static List<VistaReporteUsers> ReporteUsers()
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.VistaReporteUsers.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Listar Personal", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<sp_ReportePersonalResult> filtrarPersonalbyTipo(string tipo)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.sp_ReportePersonal(tipo).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Listar Personal", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
