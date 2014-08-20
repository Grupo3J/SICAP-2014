///////////////////////////////////////////////////////////
//  Usuarios.cs
//  Implementation of the Class Usuarios
//  Generated by Enterprise Architect
//  Created on:      16-ago-2014 2:45:24
//  Original author: Intel
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades.GestionPersonal;

namespace CapaEntidades.GestionSeguridad
{



    public class Usuarios : Personal
    {

        private string clave;
        private string idRol;

        ~Usuarios()
        {

        }

        public override void Dispose()
        {

        }

        public Usuarios()
        {

        }

        /// 
        /// <param name="clave"></param>
        public Usuarios(string clave, string idRol, string cedula):base()
        {
            Clave = clave;
            IdRol = idRol;
            base.Cedula = cedula;
        }

        public string Clave
        {
            get
            {
                return clave;
            }
            set
            {
                clave = value;
            }
        }
        public string IdRol
        {
            get { return idRol; }
            set { idRol = value; }
        }
    }
}//end Usuarios