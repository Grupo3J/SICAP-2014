using CapaEntidades.GestionAsistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.cd_GestionAsistencia
{
    public class AsistenciaCD
    {
        public static bool ExisteAsistencia(string ced)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var query = (from prov in DB.ASISTENCIA where prov.IDASISTENCIA == ced select prov).Count();
                    if (query == 0)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Buscar el Id de Asistencia.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //metodo para insertar una nueva asistencia
        public static Asistencia Create(Asistencia not)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {
                Asistencia p = new Asistencia();
                p.IdAsistencia = not.IdAsistencia;
                p.Cedula = not.Cedula;
                p.IdCalendario = not.IdCalendario;
                p.FechaHoraEntrada = not.FechaHoraEntrada;
                p.FechaHoraSalida = not.FechaHoraSalida;
                bd.sp_RegistrarAsistencia(p.IdAsistencia, p.Cedula, p.IdCalendario, p.FechaHoraEntrada,p.FechaHoraSalida);
                bd.SubmitChanges();
            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al  Insertar Asistencia", ex);
            }
            finally
            {
                bd = null;
            }

            return not;
        }

        public static List<PersonalporAsistencia> ObtenerPersonalporDia(string IdCalendario,DateTime Fecha)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var linq = (from pa in DB.PersonalporAsistencia
                                                        where pa.IDCALENDARIO == IdCalendario
                                                            && (pa.FECHAHORAENTRADA.Month == Fecha.Month)
                                                            && (pa.FECHAHORAENTRADA.Year == Fecha.Year)
                                                            && (pa.FECHAHORAENTRADA.Day == Fecha.Day)
                                                        select pa).ToList();
                    return linq; 
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Listar Personal por Dia", ex);
            }
            finally
            {
                DB = null;
            }
        }


    }
}
