﻿using CapaDatos;
using CapaDatos.cd_GestionAsistencia;
using CapaEntidades.GestionAsistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.cln_GestionAsistencia
{
    public class AsistenciaLN
    {
        public bool existeAsistencia(string id)
        {
            return AsistenciaCD.ExisteAsistencia(id);
        }

        public List<sp_PersonalporAsistenciaDiaResult> ListarAsistenciaPersonal(string IdCalendario,DateTime Fecha,string valor) 
        {
            return AsistenciaCD.ObtenerPersonalporDia(IdCalendario,Fecha,valor);
        }

        public bool InsertarAsistencia(Asistencia p)
        {
            if (AsistenciaCD.ExisteAsistencia(p.IdAsistencia))
                return true;
            else
            {
                AsistenciaCD.Create(p);
                return false;
            }

        }

        public void ModificarAsistenciaPersonal(Asistencia p) 
        {
            AsistenciaCD.Modify(p);
        }

        public void EliminarAsistencia(Asistencia not) 
        {
            AsistenciaCD.eliminar(not);
        }

        public int ContarAsistenciaPersonal(string cedula,DateTime fecha,string idcalendario) 
        {
            return AsistenciaCD.ContarAsistenciaPersonalDia(cedula,fecha,idcalendario);
        }

        public PersonalporAsistencia AsistenciaPersonalDia(string cedula, DateTime fecha, string idcalendario)
        {
            return AsistenciaCD.AsistenciaPersonalDia(cedula,fecha,idcalendario); 
        }

        public List<sp_PersonalporAsistenciaMesResult> ListarAsistenciasPersonalMes(string IdCalendario, DateTime Fecha,string valor)
        {
            return AsistenciaCD.ObtenerPersonalporMes(IdCalendario, Fecha,valor);
        }

        public List<sp_PersonalporAsistenciaRangoResult> ListarAsistenciasPersonalRango(string IdCalendario, DateTime Fechainicio,DateTime Fechafin,string valor)
        {
            return AsistenciaCD.ObtenerPersonalporRango(IdCalendario, Fechainicio,Fechafin,valor);
        }
    }
}
