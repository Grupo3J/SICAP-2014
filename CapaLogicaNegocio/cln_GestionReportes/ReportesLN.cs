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
    }
}
