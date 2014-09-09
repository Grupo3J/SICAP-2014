using CapaDatos;
using CapaDatos.cd_GestionSeguridad;
using CapaEntidades.GestionSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CapaLogicaNegocio
{
    public class RolesLN
    {

        public void insertarRol(Roles rol)
        {
            RolesCD.insertarRol(rol);
            int j = PermisosCD.count();
            foreach (RECURSOS item in RecursoCD.getRecursos())
            {
                j++;
                Permisos tem = new Permisos();
                tem.IdPermiso="P"+j;
                tem.IdRol=rol.IdRol;
                tem.IdRecurso=item.IDRECURSO;
                tem.Estado=false;
                tem.Lectura=false;
                tem.Escritura=false;
                tem.Eliminacion=false;
                tem.Modificacion=false;
                tem.Busqueda = false;
               

                PermisosCD.insertarPermiso(tem);
            }
        }
        public void modificarRol(Roles rol)
        {
            RolesCD.modificarRol(rol);
        }

        public List<ROLES> getRoles()
        {
            return RolesCD.getRoles();
        }
        public List<string> getnombRoles()
        {
            return RolesCD.getnombRoles();
        }
        public string getIdRolByNombrRol(string nombrerol)
        {
            return RolesCD.getIdRolByNombrRol(nombrerol);
        }

        public string getNombrerolByIdRol(string idrol)
        {
            return RolesCD.getNombrerolByIdRol(idrol);
        }

        public string getNextIdRol()
        {
            
            var sql = (from j in getRoles()
                       orderby int.Parse(j.IDROL.Substring(2))
                       select j.IDROL      ).Last();
            return "RL"+(int.Parse(sql.Substring(2))+1);
        }

        public object getRoles(string valordebusqueda)
        {
            return RolesCD.getRoles(valordebusqueda);
        }

        public void eliminarRol(string idrol)
        {

            RolesCD.EliminarRol(idrol);

        }
    }
}
