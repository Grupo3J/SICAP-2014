using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaDatos.cd_GestionAsistencia;
using CapaEntidades.GestionAsistencia;


namespace CapaLogicaNegocio.cln_GestionAsistencia
{
    public class FaltasLN
    {
        public bool ExisteFalta(string id) 
        {
            return FaltaCD.Existe(id);
        }

        public bool InsertarFaltas(Faltas p)
        {
            if (FaltaCD.Existe(p.IdFaltas))
                return true;
            else
            {
                FaltaCD.Create(p);
                return false;
            }
        }

        public List<PersonalporFaltaDia> ListarFaltasPersonalDia(string IdCalendario, DateTime Fecha)
        {
            return FaltaCD.ObtenerPersonalporFaltaDia(IdCalendario, Fecha);
        }

        public List<sp_PersonalporFaltaMesResult> ListarFaltasPersonalMes(string IdCalendario,DateTime Fecha) 
        {
            return FaltaCD.ObtenerPersonalFaltaMes(IdCalendario, Fecha);
        }

        public List<sp_PersonalporFaltaRangoResult> ListarFaltasPersonalRango(string IdCalendario,DateTime fechainicio,DateTime fechafin) 
        {
            return FaltaCD.ObtenerPersonalFaltaRango(IdCalendario,fechainicio,fechafin);
        }

        public void EliminarAsistenciainterfFalta(string cedula,DateTime fecha,string idcalendario) 
        {
            FaltaCD.EliminarAsistenciainterfFalta(cedula,fecha,idcalendario);
        }
    }
}
