using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades.GestionPlanificacion;
using System.Windows.Forms;


namespace CapaDatos.cd_GestionPlanificacion
{
    public class DiasNoLaborablesCD
    {
        public static DiasNoLaborables Create(DiasNoLaborables dad)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {

                DiasNoLaborables da = new DiasNoLaborables();
                da.IdDiasNoLaborables = dad.IdDiasNoLaborables;
                da.IdCalendario = dad.IdCalendario;
                da.Fecha = dad.Fecha;
                da.Descripcion = dad.Descripcion;


                bd.sp_RegistrarDiaNoLab(da.IdDiasNoLaborables, da.IdCalendario, da.Fecha, da.Descripcion);
                bd.SubmitChanges();

            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al  Registrar Día No Laborable ", ex);
            }
            finally
            {
                bd = null;
            }

            return dad;
        }

        public static List<sp_ListarDiaNoLaborablesResult> ObtenerDiasNoLaborable()
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.sp_ListarDiaNoLaborables().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Listar Dias No Laborables", ex);
            }
            finally
            {
                DB = null;
            }
        }



        public static bool ExisteDiaNoLaborable(string idDiasNoLab)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var query = (from cal in DB.DIASNOLABORABLES where cal.IDDIASNOLABORABLES == idDiasNoLab select cal).Count();
                    if (query == 0)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Buscar id de Dia No Laborable", ex);
            }
            finally
            {
                DB = null;
            }
        }

             public static void EliminarDiaNoLaborable(string idDiaNoLab)
                {
            CapaDatosDataContext DB = new CapaDatosDataContext();
            try
            {

                DB.sp_EliminarDiasNoLaborables(idDiaNoLab);
                DB.SubmitChanges();


            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Eliminar Dia No Laborable", ex);
            }
            finally
            {
                DB = null;
            }
        }

             public static DiasNoLaborables ModificarDiaNoLaborable(DiasNoLaborables cal)
             {
                 CapaDatosDataContext bd = new CapaDatosDataContext();
                 try
                 {
                     DiasNoLaborables c = new DiasNoLaborables();
                     c.IdDiasNoLaborables = cal.IdDiasNoLaborables;
                     c.IdCalendario = cal.IdCalendario;
                     c.Descripcion = cal.Descripcion;
                     c.Fecha = cal.Fecha;

                     bd.sp_ModificarDiaAdicional(c.IdDiasNoLaborables, c.IdCalendario, c.Fecha, c.Descripcion);
                     bd.SubmitChanges();

                 }
                 catch (CapaDatosExcepciones ex)
                 {
                     throw new CapaDatosExcepciones("Error al Modificar Dia No Laborable", ex);
                 }
                 finally
                 {
                     bd = null;
                 }

                 return cal;
             }
        //metodo para saber si exixte un dia adicional en la tabla de dias no laborables
             public static bool ExisteDiaAdicionalEnNoLaboral(string fecha, string idCalendario)
             {
                 string dia = fecha.Substring(0,2); 
                 string mes = fecha.Substring(2,2); 
                 string anio = fecha.Substring(4,4);
                 CapaDatosDataContext DB;
                 try
                 {
                     using (DB = new CapaDatosDataContext())
                     {

                         var query = (from cal in DB.DIASNOLABORABLES where (cal.IDCALENDARIO.Equals(idCalendario)
                                          && cal.FECHA.Day.Equals(dia) && cal.FECHA.Month.Equals(mes)
                                          && cal.FECHA.Year.Equals(anio)) select cal).Count();
                            
                         if (query == 0)
                             return false;
                         else

                             return true;
                     }
                 }
                 catch (Exception ex)
                 {
                     throw new CapaDatosExcepciones("Error al Buscar id de Dia No Laborable", ex);
                 }
                 finally
                 {
                     DB = null;
                 }
             }



    }
}
