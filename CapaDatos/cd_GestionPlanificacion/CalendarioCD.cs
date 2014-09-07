using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades.GestionPlanificacion;

namespace CapaDatos.cd_GestionPlanificacion
{
    public class CalendarioCD
    {
        public static Calendario Create(Calendario cal)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {

                Calendario c = new Calendario();
                c.IdCalendario = cal.IdCalendario;
                c.Nombre = cal.Nombre;
                c.Descripcion = cal.Descripcion;
                c.FechaInicio = cal.FechaInicio;
                c.FechaFin = cal.FechaFin;
                bd.sp_RegistrarCalendario(c.IdCalendario, c.Nombre, c.Descripcion, c.FechaInicio, c.FechaFin);
                bd.SubmitChanges();
            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al  Insertar Calendario Laboral", ex);
            }
            finally
            {
                bd = null;
            }

            return cal;
        }

        public static List<sp_ListarCalendarioResult> ObtenerCalendario()
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.sp_ListarCalendario().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Listar Calendario Laboral", ex);
            }
            finally
            {
                DB = null;
            }
        }

        public static bool ExisteCalendario(string idCalendario)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var query = (from cal in DB.CALENDARIO where cal.IDCALENDARIO == idCalendario select cal).Count();
                    if (query == 0)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Buscar id del Calendario Laboral", ex);
            }
            finally
            {
                DB = null;
            }

        }

        public static void EliminarCalendario(string idCaledario)
        {
            CapaDatosDataContext DB = new CapaDatosDataContext();
            try
            {

                DB.sp_EliminarCalendario(idCaledario);
                DB.SubmitChanges();


            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Eliminar Calendario Laboral", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //metodo para modificar calendario
        public static Calendario ModificarCalendario(Calendario cal)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {
                Calendario c = new Calendario();

                c.IdCalendario = cal.IdCalendario;
                c.Nombre = cal.Nombre;
                c.Descripcion = cal.Descripcion;
                c.FechaInicio = cal.FechaInicio;
                c.FechaFin = cal.FechaFin;

                bd.sp_ModificarCalendario(c.IdCalendario, c.Nombre, c.Descripcion, c.FechaInicio, c.FechaFin);
                bd.SubmitChanges();

            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al Modificar Caledario Laboral", ex);
            }
            finally
            {
                bd = null;
            }

            return cal;
        }

        //obtener personal por calendario
        public static List<sp_PersonalporCalendarioResult> PersonalporCalendario(string idcalendario) 
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.sp_PersonalporCalendario(idcalendario).ToList();
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

        //guardar personal en detalle_personal_calendario
        public static List<sp_PersonalporCalendarioResult> IngresarPersonal(List<sp_PersonalporCalendarioResult> temp,string idcalendario,string idimprevisto) 
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    foreach (sp_PersonalporCalendarioResult t in temp)
                    {
                        DETALLE_IMPREVISTO_CALENDARIO detpc = new DETALLE_IMPREVISTO_CALENDARIO
                        {
                            IDCALENDARIO = idcalendario,
                            CEDULA = t.CEDULA,
                            IDIMPREVISTO = idimprevisto
                        };
                        DB.DETALLE_IMPREVISTO_CALENDARIO.InsertOnSubmit(detpc);
                    }
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Insertar el Imprevisto", ex);
            }
            finally 
            {
                DB = null;
            }
            return temp;
        }

        public static void Eliminar_Personal_Detalle(string idcalendario,string idimprevisto) 
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
 
                    DB.sp_Eliminar_Detalle_Imprevisto_Calendario(idcalendario,idimprevisto);
                    DB.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Eliminar el Personal de Imprevisto", ex);
            }
            finally
            {
                DB = null;
            }
        }
    }
}
