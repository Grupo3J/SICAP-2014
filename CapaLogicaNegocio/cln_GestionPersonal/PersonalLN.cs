using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.cd_GestionPersonal;
using CapaEntidades.GestionPersonal;

namespace CapaLogicaNegocio.cln_GestionPersonal
{
    public class PersonalLN
    {
        public List<pa_FiltrarPersonalValoresResult> ListarPersonal(string val)
        {
            return PersonalCd.ObtenerPresonal(val);
        }

        public bool existePersonal(string id)
        {
            return PersonalCd.Existe(id);
        }

        public bool InsertarPersonal(Personal p)
        {
            if (PersonalCd.Existe(p.Cedula))
                return true;
            else
            {
                PersonalCd.Create(p);
                return false;
            }

        }

        public bool ModificarPersonal(Personal p)
        {
            PersonalCd.ModificarPersonalCedula(p);
            return false;


        }

        public bool EliminarPresonal(String cedula)
        {
            PersonalCd.EliminarPersonalCedula(cedula);
            return false;


        }
    }
}
