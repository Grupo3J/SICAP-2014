using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaDatos.cd_GestionPersonal;
using CapaEntidades.GestionPersonal;

namespace CapaLogicaNegocio.cln_GestionPersonal
{
    public class HuellaLN
    {
        //metodo para listar las huellas de una persona
        public List<pa_ListarHuellaCedulaResult> ListarHuella(string cedula)
        {
            return HuellaCD.ObtenerHuella(cedula);
        }

        //metodo para insertar huella
        public bool InsertarHuella(Huella p)
        {
            if (HuellaCD.ExisteHuella(p.IdHuella))
                return true;
            else
            {
                HuellaCD.Create(p);
                return false;
            }

        }

        public bool ModificarHuellaIdHuella(Huella hue)
        {
            HuellaCD.ModificarHuellaIdHuella(hue);
            return false;


        }

        public bool EliminarHuellaIdHuella(String idHuella)
        {
            HuellaCD.EliminarHuellaIdHuella(idHuella);
            return false;


        }



        public string GenerarIdHuella()
        {
            Random ran = new Random();
            int num = ran.Next(0000, 1000);
            int num2 = ran.Next(000, 100);

            string idhuella = "I" + num.ToString() + num2.ToString();
            return idhuella;
        }
    }
}
