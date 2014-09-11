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
    public class PersonalLN
    {
        public List<sp_FiltrarPersonalValoresResult> ListarPersonal(string val)
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

        public void InsertarPersonalVoid(Personal p)
        {
            if (PersonalCd.Existe(p.Cedula))
                throw new Exception("Ya existe una persona con esa cédula");
            else
            {
                PersonalCd.Create(p);
            }

        }

        public bool InsertarPersonalCalendario(string ced, string idcal)
        {
            if (PersonalCd.ExistePersonalEnCalendario(ced))
                return true;
            else
            {
                PersonalCd.CreatePersonalCalendario(ced, idcal);
                return false;
            }

        }

        public bool ExistePersonalCalendario(string ced)
        {
            if (PersonalCd.ExistePersonalEnCalendario(ced))
                return true;
            else
            {
                return false;
            }

        }

        public void InsertarPersonalCalendarioVoid(string ced, string idcal)
        {
            if (PersonalCd.ExistePersonalEnCalendario(ced))
                throw new Exception("La cédula: " + ced + "ya esta registrada en ese calendario");
            else
            {
                PersonalCd.CreatePersonalCalendario(ced, idcal);
            }

        }

        public bool ModificarPersonal(Personal p, int v)
        {
            PersonalCd.ModificarPersonalCedula(p, v);
            return false;


        }
        public void ModificarPersonalVoid(Personal p, int v)
        {
            PersonalCd.ModificarPersonalCedula(p, v);

        }
        //public bool ModificarPersonalSinFoto(Personal p)
        //{
        //    PersonalCd.ModificarPersonalSinFoto(p);
        //    return false;


        //}

        public bool ModificarDetallePersonalCalendario(string idcal, string ced)
        {
            PersonalCd.ModificarDetallePersonalCalendario(idcal, ced);
            return false;


        }


        public bool EliminarPresonal(String cedula)
        {
            PersonalCd.EliminarPersonalCedula(cedula);
            return false;
        }

        public Personal getPersonalByced(string cedula)
        {
            return PersonalCd.getPersonalByced(cedula);
        }
        public bool ModificarPersonal(Personal p)
        {
            PersonalCd.ModificarPersonalCedula(p);
            return false;


        }

    }
}