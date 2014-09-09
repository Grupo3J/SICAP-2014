using CapaEntidades.GestionSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.cd_GestionSeguridad
{
    public class UsuarioCD
    {
        public UsuarioCD()
        {

        }
        public static bool Existe(string cedula)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var query = (from prod in DB.USUARIO where prod.CEDULA == cedula select prod).Count();
                    if (query == 0)
                        return false;
                    else
                        return true;
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
        public static bool Login(string nick, string clave)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var query = (from usuario in DB.USUARIO where usuario.NICK == nick && usuario.CLAVE==clave  select usuario).Count();
                    if (query == 0)
                        return false;
                    else
                        return true;
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
        public static string getcedulabynickclave(string nick,string clave){

            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    USUARIO query = (from usuario in DB.USUARIO where usuario.NICK == nick && usuario.CLAVE == clave select usuario).Single();
                    return query.CEDULA;
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
        public static Usuarios getUserbyced(string cedula)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    
                    USUARIO usrdb = (from usuario in DB.USUARIO where usuario.CEDULA==cedula select usuario).Single();
                    PERSONAL perdb = (from personal in DB.PERSONAL where personal.CEDULA == cedula select personal).Single();
                    
                    Usuarios usr = new Usuarios();
                    usr.Cedula = perdb.CEDULA;
                    usr.Nombre = perdb.NOMBRE;
                    usr.Apellido = perdb.APELLIDO;
                    usr.Cargo = perdb.CARGO;
                    usr.Titulo = perdb.TITULO;
                    usr.Correo = perdb.CORREO;
                    usr.Sexo = perdb.SEXO.ToString() == "M" ? 'M' : 'F';
                    usr.Ciudad = perdb.CIUDAD;
                    usr.Direccion = perdb.DIRECCION;
                    usr.Telefono = perdb.TELEFONO;
                    usr.Tipo = perdb.TIPO;
                    if (perdb.DATAFOTO == null)
                    {
                        usr.DataFoto = null;
                    }
                    else
                    { 
                        usr.DataFoto = perdb.DATAFOTO.ToArray();

                    }
                   
                    usr.IdRol = usrdb.IDROL;
                    usr.Nick = usrdb.NICK;
                    usr.Clave = usrdb.CLAVE;
                    return usr;
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



        public static void insertaruser(Usuarios usr)
        {

            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {
                
                bd.pa_InsertarUsuario(
                    usr.Cedula,usr.IdRol,usr.Nick,usr.Clave
                    );
                bd.SubmitChanges();
            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al  Insertar Producto.", ex);
            }
            finally
            {
                bd = null;
            }


        }

        public static List<pa_FiltrarUsuariosResult> getUsersfiltrado(string valor)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    
                                      
                    return DB.pa_FiltrarUsuarios(valor).ToList();
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

        public static void ModificarUser(Usuarios usr)
        {

            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {
               
                //HABILITAR
                bd.pa_ModificarUser(usr.Cedula,usr.IdRol,usr.Nick,usr.Clave);
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

           
        }

        public static void Eliminar(string cedula)
        {
            CapaDatosDataContext bd = new CapaDatosDataContext();
            try
            {
                
                bd.sp_EliminarUser(cedula);
                bd.SubmitChanges();
            }
            catch (CapaDatosExcepciones ex)
            {
                throw new CapaDatosExcepciones("Error al  Eliminar Producto.", ex);
            }
            finally
            {
                bd = null;
            }

        }

        public static bool existelogin(string login)
        {
            CapaDatosDataContext DB;
            try
            {
                using (DB = new CapaDatosDataContext())
                {
                    var query = (from prod in DB.USUARIO where prod.NICK == login select prod).Count();
                    if (query == 0)
                        return false;
                    else
                        return true;
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
