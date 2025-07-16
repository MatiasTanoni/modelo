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

        public DateTime Fecha
        {
            get { return _fechaCombate; }
            set { _fechaCombate = value; }
        }

        public string Ganador
        {
            get { return _nombreGanador; }
            set { _nombreGanador = value; }
        }

        public string Perdedor
        {
            get { return _nombrePerdedor; }
            set { _nombrePerdedor = value; }
        }

        public ResultadoCombate(DateTime fecha, string ganador, string perdedor)
        {
            _fechaCombate = fecha;
            _nombreGanador = ganador;
            _nombrePerdedor = perdedor;
        }
    }

}
