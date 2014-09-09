using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

using CapaEntidades;
using CapaDatos.cd_GestionSeguridad;
using CapaDatos.cd_GestionPlanificacion;
using CapaEntidades.GestionPlanificacion;




namespace CapaLogicaNegocio.cln_GestionPlanificacion
{
    public class CalendarioLN
    {
        //metodo para listar los calendario
        public List<sp_ListarCalendarioResult> ListarCalendario()
        {
            return CalendarioCD.ObtenerCalendario();
        }

        //metodo para insertar calendario laboral
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

        public List<sp_PersonalporCalendarioResult> PersonalporCalendario(string idcalendario)
        {
            return CalendarioCD.PersonalporCalendario(idcalendario);
        }

        public List<sp_PersonalporCalendarioResult> IngresarPersonalDet(List<sp_PersonalporCalendarioResult> temp, string idcalendario, string idimprevisto)
        {
            return CalendarioCD.IngresarPersonal(temp, idcalendario, idimprevisto);
        }

        public void EliminarDetallePersonal(string idcalendario, string idimprevisto)
        {
            CalendarioCD.Eliminar_Personal_Detalle(idcalendario, idimprevisto);
        }


        public string GenerarIdCalendario()
        {
            Random ran = new Random();
            int num = ran.Next(11, 22);
            int num2 = ran.Next(33, 44);

            string idCalendario = "C" + num.ToString() + num2.ToString();
            return idCalendario;
        }

        //metodo para listar los detalleCalendarioPersonal
        public List<sp_ListarDetallePersonalCalendarioResult> ListarDetalleCalendarioPersnal(string ced)
        {
            return CalendarioCD.ObtenerDetalleCalendarioPersonal(ced);
        }
    }
}
