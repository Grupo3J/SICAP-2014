using CapaDatos;
using CapaDatos.cd_GestionAsistencia;
using CapaEntidades.GestionAsistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.cln_GestionAsistencia
{
    public class AsistenciaLN
    {
        public bool existeAsistencia(string id)
        {
            return AsistenciaCD.ExisteAsistencia(id);
        }

        public List<PersonalporAsistencia> ListarAsistenciaPersonal(string IdCalendario,DateTime Fecha) 
        {
            return AsistenciaCD.ObtenerPersonalporDia(IdCalendario,Fecha);
        }

        public bool InsertarAsistencia(Asistencia p)
        {
            if (AsistenciaCD.ExisteAsistencia(p.IdAsistencia))
                return true;
            else
            {
                AsistenciaCD.Create(p);
                return false;
            }

        }

        public int ContarAsistenciaPersonal(string cedula,DateTime fecha,string idcalendario) 
        {
            return AsistenciaCD.ContarAsistenciaPersonalDia(cedula,fecha,idcalendario);
        }
    }
}
