using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //metodo para modificar huella
        //public bool ModificarHuellaIdHuella(Huella hue)
        //{
        //    HuellaCD.ModificarHuellaIdHuella(hue);
        //    return false;


        //}

        //metodo para eliminar huella
        //public bool EliminarHuellaIdHuella(String idHuella)
        //{
        //    HuellaCD.EliminarHuellaIdHuella(idHuella);
        //    return false;


        //}
        


    }
}
