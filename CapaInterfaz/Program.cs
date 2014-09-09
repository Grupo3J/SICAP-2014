using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaInterfaz.ci_GestionSeguridad;
namespace CapaInterfaz
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
            //Application.Run(new CapaInterfaz.ci_GestionPersonal.frmDNBPersonal.frmAdministrarPersonal());
            Application.Run(new CapaInterfaz.ci_GestionAsistencia.frmDNBFaltas.frmDNBAdministrarFaltas());
            //Application.Run(new CapaInterfaz.ci_GestionAsistencia.frmDNBImprevistos.frmDNBAdministrarImprevistos());
            //Application.Run(new CapaInterfaz.ci_GestionSeguridad.frmLog_In());
        }
    }
}
