using CapaEntidades.GestionAsistencia;
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

        public static List<sp_Obtener_Personas_ImprevistoResult> ObtenerPersonasporImprevisto(string idcalendario,string idimprevisto)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var query = from prov in DB.sp_Obtener_Personas_Imprevisto(idcalendario,idimprevisto) select prov;
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

        //metodo para insertar una nueva asistencia
        public static Imprevistos Create(Imprevistos not)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {
                Imprevistos p = new Imprevistos();
                p.IdImprevisto = not.IdImprevisto;
                p.FechaInicio = not.FechaInicio;
                p.FechaFinal = not.FechaFinal;
                p.Descripcion = not.Descripcion;
                bd.sp_RegistrarImprevistos(p.IdImprevisto, p.FechaInicio, p.FechaFinal, p.Descripcion);
                bd.SubmitChanges();
            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al  Insertar Imprevisto", ex);
            }
            finally
            {
                bd = null;
            }

            return not;
        }

        public static Imprevistos ModificarImprevisto(Imprevistos cal)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {
                Imprevistos c = new Imprevistos();

                c.IdImprevisto = cal.IdImprevisto;
                c.Descripcion = cal.Descripcion;
                c.FechaInicio = cal.FechaInicio;
                c.FechaFinal = cal.FechaFinal;
                bd.sp_ModificarImprevistoId(c.IdImprevisto, c.FechaInicio, c.FechaFinal, c.Descripcion);
                bd.SubmitChanges();

            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al Modificar Imprevistos", ex);
            }
            finally
            {
                bd = null;
            }

            return cal;
        }

        public static void EliminarImprevisto(string idimprevisto)
        {
            CapaDatosDataContext DB = new CapaDatosDataContext();
            try
            {
                DB.sp_EliminarImprevistoId(idimprevisto);
                DB.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Eliminar Imprevisto", ex.GetBaseException());
            }
            finally
            {
                DB = null;
            }
        }

        
    }
}
