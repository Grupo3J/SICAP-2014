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

        public static List<sp_PersonalporAsistenciaDiaResult> PersonalporAsistenciaDia(string idcalendario,DateTime fecha,string valor) 
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.sp_PersonalporAsistenciaDia(idcalendario,fecha,valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Listar Personal por Asistencia Dia", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<sp_PersonalporAsistenciaMesResult> PersonalporAsistenciaMes(string idcalendario, DateTime fechames,string valor)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.sp_PersonalporAsistenciaMes(idcalendario, fechames,valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Listar Personal por Asistencia Mes", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<sp_PersonalporAsistenciaRangoResult> PersonalporAsistenciaRango(string idcalendario, DateTime fechainicio,DateTime fechafin,string valor)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.sp_PersonalporAsistenciaRango(idcalendario, fechainicio,fechafin,valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Listar Personal por Asistencia Rango", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<sp_PersonalporFaltaDiaResult> PersonalporFaltaDia(string idcalendario, DateTime fecha,string valor)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.sp_PersonalporFaltaDia(idcalendario, fecha,valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Listar Personal por Falta Dia", ex);
            }
            finally
            {
                DB = null;
            }
        }
        
        public static List<sp_PersonalporFaltaMesResult> PersonalporFaltaMes(string idcalendario, DateTime fechames,string valor)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.sp_PersonalporFaltaMes(idcalendario, fechames,valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Listar Personal por Falta Mes", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<sp_PersonalporFaltaRangoResult> PersonalporFaltaRango(string idcalendario, DateTime fechainicio, DateTime fechafin,string valor)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.sp_PersonalporFaltaRango(idcalendario, fechainicio, fechafin,valor).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Listar Personal por Falta Rango", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
