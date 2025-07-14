using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_final
{
    public class BusinessException : Exception
    {
        // Constructor que solo recibe el mensaje
        public BusinessException(string mensaje)
            : base(mensaje)
        {
        }

        // Constructor que recibe mensaje e InnerException
        public BusinessException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {
        }
    }
}