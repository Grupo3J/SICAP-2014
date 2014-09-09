using CapaDatos.cd_GestionSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio.cln_GestionSeguridad
{
    public class RecursoLN
    {
        public string geturlrecurso_by_nombremod( string nombremodulo){
            return RecursoCD.geturlrecurso_by_nombremod( nombremodulo);
        }
    }
}
