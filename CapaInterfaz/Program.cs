using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaInterfaz.ci_GestionPersonal.frmPersonal;
using CapaInterfaz.ci_GestionSeguridad;
using CapaInterfaz.ci_GestionPersonal;
using CapaInterfaz.ci_GestionPlanificacion.frmCalendarioLaboral;
using CapaInterfaz.ci_GestionAsistencia.frmAsistencia;
namespace CapaInterfaz.ci_GestionSeguridad
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new frmVentanaPrimaria());
            Application.Run(new frmAdministracionCalendarioLaboral());
            //Application.Run(new frmAdministrarAsistencia());
            //  Application.Run(new frmLogin());
            //Application.Run(new frmAdministrarPersonal());

        }
    }
}
