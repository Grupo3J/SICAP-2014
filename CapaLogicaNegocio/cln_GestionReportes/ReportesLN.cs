using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaDatos.cd_GestionReportes;
namespace CapaLogicaNegocio.cln_GestionReportes
{
    public class ReportesLN
    {
        public List<VistaReporteUsers> ReportesUsuarios()
        {
            return ReporteCD.ReporteUsers();
        }

        public List<sp_ReportePersonalResult> filtrarPersonalbyTipo(string tipo)
        {
            return ReporteCD.filtrarPersonalbyTipo(tipo);
        }

        public List<sp_PersonalporAsistenciaDiaResult> PersonalporAsistenciaDia(string idcalendario,DateTime fecha) 
        {
            return ReporteCD.PersonalporAsistenciaDia(idcalendario,fecha);
        }

        public List<sp_PersonalporAsistenciaMesResult> PersonalporAsistenciaMes(string idcalendario,DateTime fechames) 
        {
            return ReporteCD.PersonalporAsistenciaMes(idcalendario,fechames);
        }

        public List<sp_PersonalporAsistenciaRangoResult> PersonalporAsistenciaRango(string idcalendario,DateTime fechainicio,DateTime fechafin) 
        {
            return ReporteCD.PersonalporAsistenciaRango(idcalendario,fechainicio,fechafin);
        }

        public List<sp_PersonalporFaltaDiaResult> PersonalporFaltaDia(string idcalendario, DateTime fecha)
        {
            return ReporteCD.PersonalporFaltaDia(idcalendario, fecha);
        }

        public List<sp_PersonalporFaltaMesResult> PersonalporFaltaMes(string idcalendario, DateTime fechames)
        {
            return ReporteCD.PersonalporFaltaMes(idcalendario, fechames);
        }

        public List<sp_PersonalporFaltaRangoResult> PersonalporFaltaRango(string idcalendario, DateTime fechainicio, DateTime fechafin)
        {
            return ReporteCD.PersonalporFaltaRango(idcalendario, fechainicio, fechafin);
        }

    }
}
