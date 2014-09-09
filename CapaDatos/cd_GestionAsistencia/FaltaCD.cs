﻿using CapaEntidades.GestionAsistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.cd_GestionAsistencia
{
    public class FaltaCD
    {
        public static bool Existe(string id)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var query = (from prov in DB.FALTAS where prov.IDFALTA == id select prov).Count();
                    if (query == 0)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Buscar el Id de Falta.", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static Faltas Create(Faltas not) 
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {
                Faltas p = new Faltas();
                p.IdFaltas = not.IdFaltas;
                p.IdCalendario = not.IdCalendario;
                p.Justificacion = not.Justificacion;
                p.Fecha = not.Fecha;
                p.Cedula = not.Cedula;
                bd.sp_RegistrarFalta(p.IdFaltas, p.IdCalendario, p.Cedula, p.Fecha, p.Justificacion);
                bd.SubmitChanges();
            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al  Insertar Faltas", ex);
            }
            finally
            {
                bd = null;
            }

            return not;
        }

        public static List<PersonalporFaltaDia> ObtenerPersonalporFaltaDia(string IdCalendario,DateTime Fecha) 
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var linq = (from pa in DB.PersonalporFaltaDia
                                where pa.IDCALENDARIO == IdCalendario
                                    && (pa.FECHA.Month == Fecha.Month)
                                    && (pa.FECHA.Year == Fecha.Year)
                                    && (pa.FECHA.Day == Fecha.Day)
                                select pa).ToList();
                    return linq;
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Listar Faltas por Dia", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<sp_PersonalporFaltaMesResult> ObtenerPersonalFaltaMes(string IdCalendario,DateTime Fecha) 
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.sp_PersonalporFaltaMes(IdCalendario,Fecha).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Listar Faltas por Mes", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static List<sp_PersonalporFaltaRangoResult> ObtenerPersonalFaltaRango(string IdCalendario,DateTime Fechainicio,DateTime Fechafin) 
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.sp_PersonalporFaltaRango(IdCalendario, Fechainicio,Fechafin).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Listar Faltas por Rango de Fechas", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static void EliminarAsistenciainterfFalta(string cedula,DateTime fecha,string idcalendario)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    DB.sp_EliminarAsistenciainterfFalta(cedula, fecha,idcalendario);
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error Eliminar Asistencia Interfiere Fecha", ex);
            }
            finally
            {
                DB = null;
            }
        }

    }
}
