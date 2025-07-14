using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_final
{
    public interface IJugador
    {
        public short Nivel { get;}
        public int PuntosDeVida { get; }

        public int Atacar();
        public void RecibirAtaque(int puntosDeAtaque);
    }
}
