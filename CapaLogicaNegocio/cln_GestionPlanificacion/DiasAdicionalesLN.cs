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
    public class DiasAdicionalesLN
    {
        public List<sp_ListarDiaAdicionalResult> ListarDiasAdicionales()
        {
            return DiasAdicionalesCD.ObtenerDiasAdicionales();
        }

        public bool InsertarDiasAdicionales(DiasAdicionales p)
        {
            if (DiasAdicionalesCD.ExisteDiaAdicional(p.IdDiasAdcionales))
                return true;
            else
            {
                DiasAdicionalesCD.Create(p);
                return false;
            }

        }

        public void InsertarDiasAdicionalesVoid(DiasAdicionales p)
        {
            if (DiasAdicionalesCD.ExisteDiaAdicional(p.IdDiasAdcionales))
                throw new Exception("Error al insertar día a dicional.....Por favor cierre el programa y vuelva a intentarlo");
            else
            {
                DiasAdicionalesCD.Create(p);
            }

        }

        public bool ModificarDiaAdicional(DiasAdicionales cal)
        {
            DiasAdicionalesCD.ModificarDiaAdicional(cal);
            return false;


        }

        public bool EliminarDiaAdicional(String idDiaAdicional)
        {

            DiasAdicionalesCD.EliminarDiaAdicional(idDiaAdicional);
            return false;


        }



        public string GenerarIdDiasAdicionales()
        {
            Random ran = new Random();
            int num = ran.Next(111, 222);
            int num2 = ran.Next(33, 44);

            string idCalendario = "DA" + num.ToString() + num2.ToString();
            return idCalendario;
        }

        public bool ExisteNoLaboralEnAdicional(string fecha, string idCalendario)
        {
            if (DiasAdicionalesCD.ExisteDiaNoLaborableEnAdicional(fecha, idCalendario))
                return true;
            else
            {
                return false;
            }
        }

        public bool ExisteAdicionalFecha(string fecha, string idDiasAdicional, string idCal)
        {
            if (DiasAdicionalesCD.ExisteAdicionalFecha(fecha, idDiasAdicional, idCal))
                return true;
            else
            {
                return false;
            }
        }
    }
}
