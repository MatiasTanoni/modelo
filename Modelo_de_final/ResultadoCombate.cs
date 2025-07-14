using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_final
{
    public class ResultadoCombate
    {
        private DateTime _fechaCombate;
        private string _nombreGanador;
        private string _nombrePerdedor;

        public DateTime Fecha { get; set; }
        public string Ganador { get; set; }
        public string Perdedor { get; set; }

        public ResultadoCombate(DateTime fecha, string ganador, string perdedor)
        {
            _fechaCombate = fecha;
            _nombreGanador = ganador;
            _nombrePerdedor = perdedor;
        }
    }
}
