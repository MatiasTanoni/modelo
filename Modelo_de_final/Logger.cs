using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_final
{
    public class Logger
    {
        private string _ruta;

        public Logger(string ruta)
        {
            _ruta = ruta;
        }

        public void GuardarLog(string texto)
        {
            try
            {
                // Agrega el texto al archivo, creando el archivo si no existe.
                using (StreamWriter writer = new StreamWriter(_ruta, append: true))
                {
                    writer.WriteLine(texto);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar el log: " + ex.Message);
            }
        }
    }

}
