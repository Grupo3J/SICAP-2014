using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaInterfaz.ci_GestionPersonal.frmPersonal;
using CapaInterfaz.ci_GestionSeguridad;
using CapaInterfaz.ci_GestionPersonal;

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
            Application.Run(new frmVentanaPrimaria());
           
        }
    }
}
