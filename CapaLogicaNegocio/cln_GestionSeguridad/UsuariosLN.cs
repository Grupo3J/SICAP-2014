using CapaDatos.cd_GestionSeguridad;
using CapaDatos.cd_GestionPersonal;
using CapaEntidades.GestionSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades.GestionPersonal;

namespace CapaLogicaNegocio.cln_GestionSeguridad
{
    public class UsuariosLN
    {


        public bool existe(string cedula)
        {
            return UsuarioCD.Existe(cedula);
        }
        public string getcedulabynickclave(string nick, string clave)
        {
            if (UsuarioCD.Login(nick, clave))
            {
               return  UsuarioCD.getcedulabynickclave(nick, clave);
            }
            else{
                return null;
            }
        }
        Cifrado md5 = new Cifrado();
        public Usuarios getUserbyced(string cedula)
        {
            Usuarios te=UsuarioCD.getUserbyced(cedula);
            te.Clave = md5.Desencriptar(te.Clave);
            return te;
        }

        public void insertaruser(Usuarios usr)
        {
            usr.Clave = md5.Encriptar(usr.Clave);
            UsuarioCD.insertaruser(usr);
            
        }

        public void insertaruser(Usuarios usr,Personal per)
        {
            usr.Clave = md5.Encriptar(usr.Clave);
            PersonalCd.Create((Personal)usr);
            UsuarioCD.insertaruser(usr);

        }
        public void modificaruser(Usuarios usr)
        {
            usr.Clave = md5.Encriptar(usr.Clave);
            PersonalCd.ModificarPersonalCedula((Personal)usr);
            UsuarioCD.ModificarUser(usr);
            
        }


        public object getUsersfiltrado(string p)
        {
            return UsuarioCD.getUsersfiltrado(p);
        }

        public void eliminarUser(string cedula)
        {

            UsuarioCD.Eliminar(cedula);
        }

        public bool existelogin(string login)
        {
            return UsuarioCD.existelogin(login);
        }
    }
}
