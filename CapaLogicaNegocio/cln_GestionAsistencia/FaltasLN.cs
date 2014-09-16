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

        public void ModificarFaltasJustificacion(Faltas p) 
        {
            FaltaCD.Modificar(p);
        }

        public void EliminarFaltaId(string idfalta) 
        {
            FaltaCD.Eliminar(idfalta);
        }

        public List<sp_PersonalporFaltaDiaResult> ListarFaltasPersonalDia(string IdCalendario, DateTime Fecha,string valor)
        {
            return FaltaCD.ObtenerPersonalporFaltaDia(IdCalendario, Fecha,valor);
        }

        public List<sp_PersonalporFaltaMesResult> ListarFaltasPersonalMes(string IdCalendario,DateTime Fecha,string valor) 
        {
            return FaltaCD.ObtenerPersonalFaltaMes(IdCalendario, Fecha,valor);
        }

        public List<sp_PersonalporFaltaRangoResult> ListarFaltasPersonalRango(string IdCalendario,DateTime fechainicio,DateTime fechafin,string valor) 
        {
            return FaltaCD.ObtenerPersonalFaltaRango(IdCalendario,fechainicio,fechafin,valor);
        }

        public void EliminarAsistenciainterfFalta(string cedula,DateTime fecha,string idcalendario) 
        {
            FaltaCD.EliminarAsistenciainterfFalta(cedula,fecha,idcalendario);
        }

        public int ContarFaltaPersonalDia(string cedula,DateTime fecha,string idcalendario) 
        {
            return FaltaCD.ContarFaltaPersonalDia(cedula,fecha,idcalendario); 
        }

        public List<FALTAS> ObtenerFaltaPersonalDia(string cedula, DateTime fecha, string idcalendario)
        {
            return FaltaCD.ObtenerFaltaPersonalDia(cedula, fecha, idcalendario);
        }

        public void ELiminarFaltaPersonalDia(string idcalendario,DateTime fecha,string cedula)
        {
            FaltaCD.EliminarFaltaPersonalDia(idcalendario,fecha,cedula);
        }

    }
}
