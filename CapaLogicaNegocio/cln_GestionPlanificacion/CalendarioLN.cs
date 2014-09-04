using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaDatos.cd_GestionPlanificacion;
using CapaEntidades;
using CapaEntidades.GestionPlanificacion;



namespace CapaLogicaNegocio.cln_GestionPlanificacion
{
    public class CalendarioLN
    {
        //metodo para listar las huellas de una persona
        public List<sp_ListarCalendarioResult> ListarCalendario()
        {
            return CalendarioCD.ObtenerCalendario();
        }

        //metodo para insertar huella
        public bool InsertarCalendario(Calendario p)
        {
            if (CalendarioCD.ExisteCalendario(p.IdCalendario))
                return true;
            else
            {
                CalendarioCD.Create(p);
                return false;
            }

        }

        public bool ModificarCalendario(Calendario cal)
        {
            CalendarioCD.ModificarCalendario(cal);
            return false;


        }

        public bool EliminarCalendario(String idCalendario)
        {
            CalendarioCD.EliminarCalendario(idCalendario);
            return false;


        }



        public string GenerarIdCalendario()
        {
            Random ran = new Random();
            int num = ran.Next(11, 22);
            int num2 = ran.Next(33, 44);

            string idCalendario = "C" + num.ToString() + num2.ToString();
            return idCalendario;
        }
    }
}
