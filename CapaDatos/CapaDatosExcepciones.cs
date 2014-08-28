using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CapaDatosExcepciones:ApplicationException
    {
        /// Construye una instancia en base a un mensaje de error y la una excepción original.
        /// <param name="mensaje">El mensaje de error.</param>
        /// <param name="original">La excepción original.</param>
        public CapaDatosExcepciones(string mensaje, Exception original)
            : base(mensaje, original)
        {
        }

        /// Construye una instancia en base a un mensaje de error.
        /// <param name="mensaje">El mensaje de error.</param>
        public CapaDatosExcepciones(string mensaje)
            : base(mensaje)
        {
        }
    
    }
    
}
