using CapaDatos;
using CapaDatos.cd_GestionAsistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.cln_GestionAsistencia
{
    public class ImprevistoLN
    {
        public bool ExisteImprevisto(string IdImprevisto) 
        {
            return ImprevistoCD.Existe(IdImprevisto);
        }

        public List<sp_ImprevistosporCalendarioResult> ListarImprevistoporCalendario(string idcalendario) 
        {
            return ImprevistoCD.ObtenerImprevistos(idcalendario);
        }
        public List<sp_Obtener_Personas_ImprevistoResult> ListarPersonasporImprevisto(string idcalendario,string idimprevisto)
        {
            return ImprevistoCD.ObtenerPersonasporImprevisto(idcalendario,idimprevisto);
        }



    }
}
