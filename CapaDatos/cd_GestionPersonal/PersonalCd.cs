using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using CapaEntidades.GestionPersonal;
using System.IO;
namespace CapaDatos.cd_GestionPersonal
{
    public class PersonalCd
    {
        public static bool Existe(string ced)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var query = (from prov in DB.PERSONAL where prov.CEDULA == ced select prov).Count();
                    if (query == 0)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Buscar la Cedula del Personal.", ex);
            }
            finally
            {
                DB = null;
            }

        }

        public static List<sp_FiltrarPersonalValoresResult> ObtenerPresonal(string valor)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    return DB.sp_FiltrarPersonalValores(valor).ToList();
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
      
         public static void CreatePersonalCalendario(string ced, string idcal)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
           try
            {
                bd.sp_RegistrarPersonalCalendario(idcal, ced);
                bd.SubmitChanges();


            }
           catch (CapaDatosExcepciones ex)
           {
               throw new CapaDatosExcepciones("Error al  Insertar Personal En Calendario Laboral", ex);
           }
           finally
           {
               bd = null;
           }
        }
           
        public static Personal Create(Personal not)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
           try
            {

                Personal p = new Personal();
                p.Cedula = not.Cedula;
                p.Nombre = not.Nombre;
                p.Apellido = not.Apellido;
                p.Cargo = not.Cargo;
                p.Titulo = not.Titulo;
                p.Correo = not.Correo;
                p.Sexo = not.Sexo;
                p.Ciudad = not.Ciudad;
                p.Direccion = not.Direccion;
                p.Telefono = not.Telefono;
                p.Tipo = not.Tipo;
                p.DataFoto = not.DataFoto;
               string datos = Convert.ToString(p.DataFoto);
                //MessageBox.Show("p.datica:   " + "" +datos);
                bd.sp_RegistrarPersonal(p.Cedula, p.Nombre, p.Apellido, p.Cargo, p.Titulo, p.Correo, p.Sexo, p.Ciudad, p.Direccion, p.Telefono, p.Tipo, p.DataFoto);
                bd.SubmitChanges();


               }
           catch (CapaDatosExcepciones ex)
           {
               throw new CapaDatosExcepciones("Error al  Insertar Personal.", ex);
           }
           finally
           {
               bd = null;
           }
            
            return not;
        }

        public static void EliminarPersonalCedula(string cedula)
        {
            CapaDatosDataContext DB = new CapaDatosDataContext();
           try
            {
                DB.sp_EliminarPersonalCedula(cedula);
                DB.SubmitChanges();


               }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Eliminar Personal", ex.GetBaseException());
            }
            finally
            {
                DB = null;
            }
        }
  
    /////////////////////////////////////////////////////////modificar personal
        public static Personal ModificarPersonalCedula(Personal per, int v)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
            //CapaDatosDataContext bd2 = new CapaDatosDataContext();

            try
            {
                Personal p = new Personal();
                p.Cedula = per.Cedula;
                p.Nombre = per.Nombre;
                p.Apellido = per.Apellido;
                p.Cargo = per.Cargo;
                p.Titulo = per.Titulo;
                p.Correo = per.Correo;
                p.Sexo = per.Sexo;
                p.Ciudad = per.Ciudad;
                p.Direccion = per.Direccion;
                p.Telefono = per.Telefono;
                p.Tipo = per.Tipo;
                p.DataFoto = per.DataFoto;

                if (v == 1)
                {
                    bd.sp_ModificarPersonalCedula(p.Cedula, p.Nombre, p.Apellido, p.Cargo, p.Titulo, p.Correo, p.Sexo, p.Ciudad, p.Direccion, p.Telefono, p.Tipo);
                    bd.SubmitChanges();
                }
                if(v == 2){
                    bd.sp_ModificarPersonalCedula(p.Cedula, p.Nombre, p.Apellido, p.Cargo, p.Titulo, p.Correo, p.Sexo, p.Ciudad, p.Direccion, p.Telefono, p.Tipo);
                    bd.sp_ModificarPersonalSinFoto(p.Cedula, p.DataFoto);
                    bd.SubmitChanges();
                }

            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al Modificar Personal.", ex.GetBaseException());
            }
            finally
            {
                bd = null;
            }

            return per;
        }
        ///// <summary>
        ///// ////////////////////////////////////////////
        ///// 
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        ///////////////////////////////////////////////////////////modificar personal
        public static void ModificarDetallePersonalCalendario(string idcal, string ced)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {
                bd.sp_ModificarDetallePersonalCalendario(idcal, ced);
                bd.SubmitChanges();
            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al Modificar Detalle Personal Calendario", ex.GetBaseException());
            }
            finally
            {
                bd = null;
            }


        }
        

        public static byte[] getImageById(string id)
        {

            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {
                PERSONAL j = (from usu in bd.PERSONAL where usu.CEDULA == id select usu).Single();
                if (j.DATAFOTO != null)
                {
                    return j.DATAFOTO.ToArray();
                }
                else
                {
                    return null;
                }

            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al  Recuperar Foto.", ex);
            }
            finally
            {
                bd = null;
            }
        }

        //metodo
        public static bool ExistePersonalEnCalendario(string ced)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var query = (from prov in DB.DETALLE_PERSONAL_CALENDARIO where prov.CEDULA == ced select prov).Count();
                    if (query == 0)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Buscar la Cedula del Personal en Calendario.", ex);
            }
            finally
            {
                DB = null;
            }

        }

       //metodo para extraer el calendario con la cedula
        public static string ExtraerNombreCalendario(string ced)
        {
            string c = null;
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                   // var query = (from prov in DB.DETALLE_PERSONAL_CALENDARIO where prov.CEDULA == ced select prov.CEDULA, c = prov.CED).Count();
                        
                        return c;
                    
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Buscar la Cedula del Personal.", ex);
            }
            finally
            {
                DB = null;
            }

        }




        ///////////////////////////////////////////////////////modificar personal
        public static Personal ModificarPersonalCedula(Personal per)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {
                Personal p = new Personal();
                p.Cedula = per.Cedula;
                p.Nombre = per.Nombre;
                p.Apellido = per.Apellido;
                p.Cargo = per.Cargo;
                p.Titulo = per.Titulo;
                p.Correo = per.Correo;
                p.Sexo = per.Sexo;
                p.Ciudad = per.Ciudad;
                p.Direccion = per.Direccion;
                p.Telefono = per.Telefono;
                p.Tipo = per.Tipo;
                p.DataFoto = per.DataFoto;
                //HABILITAR
                bd.pa_ModificarPersonalCedula(p.Cedula, p.Nombre, p.Apellido, p.Cargo, p.Titulo, p.Correo, p.Sexo, p.Ciudad, p.Direccion, p.Telefono, p.Tipo, p.DataFoto);
                bd.SubmitChanges();

            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al Modificar Personal.", ex);
            }
            finally
            {
                bd = null;
            }

            return per;
        }

        public static Personal getPersonalByced(string cedula)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {


                    PERSONAL perdb = (from personal in DB.PERSONAL where personal.CEDULA == cedula select personal).Single();

                    Personal per = new Personal();
                    per.Cedula = perdb.CEDULA;
                    per.Nombre = perdb.NOMBRE;
                    per.Apellido = perdb.APELLIDO;
                    per.Cargo = perdb.CARGO;
                    per.Titulo = perdb.TITULO;
                    per.Correo = perdb.CORREO;
                    per.Sexo = perdb.SEXO.ToString().ToUpper() == "M" ? 'M' : 'F';
                    per.Ciudad = perdb.CIUDAD;
                    per.Direccion = perdb.DIRECCION;
                    per.Telefono = perdb.TELEFONO;
                    per.Tipo = perdb.TIPO;
                    if (perdb.DATAFOTO == null)
                    {
                        per.DataFoto = null;
                    }
                    else
                    {
                        per.DataFoto = perdb.DATAFOTO.ToArray();

                    }


                    return per;
                }
            }
            catch (Exception ex)
            {
                throw new CapaDatosExcepciones("Error al Buscar Codigo del Producto.", ex);
            }
            finally
            {
                DB = null;
            }
        }

    }
}


