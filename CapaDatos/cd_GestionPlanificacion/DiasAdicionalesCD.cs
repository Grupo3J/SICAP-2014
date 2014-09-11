using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades.GestionPlanificacion;

namespace CapaDatos.cd_GestionPlanificacion
{
    public class DiasAdicionalesCD
    {
        //registrr dias adicionales
        public static DiasAdicionales Create(DiasAdicionales dad)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {

                DiasAdicionales da = new DiasAdicionales();
                da.IdDiasAdcionales = dad.IdDiasAdcionales;
                da.IdCalendario = dad.IdCalendario;
                da.Fecha = dad.Fecha;
                da.Descripcion = dad.Descripcion;


                bd.sp_RegistrarDiaAdicional(da.IdDiasAdcionales, da.IdCalendario, da.Fecha, da.Descripcion);
                bd.SubmitChanges();

            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al  Registrar Día Adicional ", ex);
            }
            finally
            {
                bd = null;
            }

            return dad;
        }


        //listar dias adicionales
        public static List<sp_ListarDiaAdicionalResult> ObtenerDiasAdicionales()
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.sp_ListarDiaAdicional().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Listar Dias Adicionales", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //metodo para ver si ya existe ese dia adicional
        public static bool ExisteDiaAdicional(string idDiasAdicional)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var query = (from cal in DB.DIASADICIONALES where cal.IDDIASADICIONALES == idDiasAdicional select cal).Count();
                    if (query == 0)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Buscar id de Dia Adicional", ex);
            }
            finally
            {
                DB = null;
            }

        }



        public static bool ExisteAdicionalFecha(string fecha, string idDiasAdicional, string idCal)
        {
            string dia = fecha.Substring(0, 2);
            string mes = fecha.Substring(2, 2);
            string anio = fecha.Substring(4, 4);
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var query = (from cal in DB.DIASADICIONALES
                                 where (cal.IDDIASADICIONALES.Equals(idDiasAdicional)) ||
                                          ((cal.IDCALENDARIO.Equals(idCal) && cal.FECHA.Day.Equals(dia) && cal.FECHA.Month.Equals(mes)
                                          && cal.FECHA.Year.Equals(anio)))
                                 select cal).Count();
                    if (query == 0)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Buscar id de Dia Adicional", ex);
            }
            finally
            {
                DB = null;
            }

        }




        //metodo para eliminar dias adicionales
        public static void EliminarDiaAdicional(string idDiaAdicional)
        {
            CapaDatosDataContext DB = new CapaDatosDataContext();
            try
            {

                DB.sp_EliminarDiasAdicionales(idDiaAdicional);
                DB.SubmitChanges();


            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Eliminar Dia Adicional", ex);
            }
            finally
            {
                DB = null;
            }
        }

        //metodo para modificar dias adicionales
        public static DiasAdicionales ModificarDiaAdicional(DiasAdicionales cal)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {
                DiasAdicionales c = new DiasAdicionales();
                c.IdDiasAdcionales = cal.IdDiasAdcionales;
                c.IdCalendario = cal.IdCalendario;
                c.Descripcion = cal.Descripcion;
                c.Fecha = cal.Fecha;

                bd.sp_ModificarDiaAdicional(c.IdDiasAdcionales, c.IdCalendario, c.Fecha, c.Descripcion);
                bd.SubmitChanges();

            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al Modificar Dia Adicional", ex);
            }
            finally
            {
                bd = null;
            }

            return cal;
        }

        public static bool ExisteDiaNoLaborableEnAdicional(string fecha, string idCalendario)
        {
            string dia = fecha.Substring(0, 2);
            string mes = fecha.Substring(2, 2);
            string anio = fecha.Substring(4, 4);
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {

                    var query = (from cal in DB.DIASADICIONALES
                                 where (cal.IDCALENDARIO.Equals(idCalendario)
                                     && cal.FECHA.Day.Equals(dia) && cal.FECHA.Month.Equals(mes)
                                     && cal.FECHA.Year.Equals(anio))
                                 select cal).Count();

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
