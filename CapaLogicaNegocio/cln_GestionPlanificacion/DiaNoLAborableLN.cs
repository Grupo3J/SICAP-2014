using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

using CapaEntidades.GestionPlanificacion;
using CapaDatos.cd_GestionPlanificacion;


namespace CapaLogicaNegocio.cln_GestionPlanificacion
{
    public class DiaNoLAborableLN
    {
        public List<sp_ListarDiaNoLaborablesResult> ListarDiasNoLaborables()
        {
            return DiasNoLaborablesCD.ObtenerDiasNoLaborable();
        }

        public bool InsertarDiasNoLaborables(DiasNoLaborables p)
        {
            if (DiasNoLaborablesCD.ExisteDiaNoLaborable(p.IdDiasNoLaborables))
                return true;
            else
            {
                DiasNoLaborablesCD.Create(p);
                return false;
            }

        }

       

        public bool ModificarDiaNoLaborable(DiasNoLaborables cal)
        {
            DiasNoLaborablesCD.ModificarDiaNoLaborable(cal);
            return false;


        }

        public bool EliminarDiaNoLaborable(String idDiaNoLab)
        {

            DiasNoLaborablesCD.EliminarDiaNoLaborable(idDiaNoLab);
            return false;


        }



        public string GenerarIdDiasNoLaborables()
        {
            Random ran = new Random();
            int num = ran.Next(111, 222);
            int num2 = ran.Next(33, 44);
            string idCalendario = "DN" + num.ToString() + num2.ToString();
            return idCalendario;
        }


        //metodo para saber si ExisteAdicionalEnNoLaboral(

        public bool ExisteAdicionalEnNoLaboral(string fecha, string idCalendario)
        {
            if (DiasNoLaborablesCD.ExisteDiaAdicionalEnNoLaboral(fecha, idCalendario))
                return true;
            else
            {
                return false;
            }
        }

        public bool ExisteNoLaborableFecha(string fecha, string idDiasAdicional, string idCal)
        {
            if (DiasNoLaborablesCD.ExisteNoLaborableFecha(fecha, idDiasAdicional, idCal))
                return true;
            else
            {
                return false;
            }
        }

    }
}
