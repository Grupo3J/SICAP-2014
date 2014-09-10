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

        public bool InsertarImprevisto(Imprevistos p)
        {
            if (ImprevistoCD.Existe(p.IdImprevisto))
                return true;
            else
            {
                ImprevistoCD.Create(p);
                return false;
            }
        }

        public bool ModificarImprevisto(Imprevistos p) 
        {
            ImprevistoCD.ModificarImprevisto(p);
            return false;
        }

        public void EliminarImprevisto(string idimprevisto) 
        {
            ImprevistoCD.EliminarImprevisto(idimprevisto);
        }

        public int ContarImprevisto(string cedula,DateTime fecha,string idcalendario) 
        {
            return ImprevistoCD.contarImprevisto(cedula,fecha,idcalendario);
        }
    }
}
