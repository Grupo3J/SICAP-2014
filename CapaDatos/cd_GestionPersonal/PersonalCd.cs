using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using CapaEntidades.GestionPersonal;
namespace CapaDatos.cd_GestionPersonal
{
    public class PersonalCd
    {
        public static bool Existe(string ced)
        {
            CapaDatos.cd_GestionPersonal.ConexionBDDataContext DB;
            try
            {
                using (DB = new ConexionBDDataContext())
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

        // public static List<pa_> ObtenerProveedores(string valor)
        //{
        //    DatosDataContext DB;
        //    try
        //    {
        //        using (DB = new DatosDataContext())
        //        {
        //            return DB.cp_ListaProveedoresFiltro(valor).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new CapaDatosExcepciones("Error al Listar Proveedor.", ex);
        //    }
        //    finally
        //    {
        //        DB = null;
        //    }
        //}
      
        public static Personal Create(Personal not)
        {
            ConexionBDDataContext bd = new ConexionBDDataContext();
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
                bd.pa_RegistrarPersonal(p.Cedula, p.Nombre, p.Apellido, p.Cargo, p.Titulo, p.Correo, p.Sexo, p.Ciudad, p.Direccion, p.Telefono, p.Tipo, p.DataFoto);
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

          
    
    }
}


