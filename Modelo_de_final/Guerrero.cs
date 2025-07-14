using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_final
{
    public class Guerrero : Personaje
    {
        protected override void AplicarBeneficiosDeClase()
        {
            // Calculamos el 10% de puntosDeDefensa (descartando decimales)
            int bonificacion = (puntosDeDefensa * 10) / 100;

            // Aplicamos la bonificación
            puntosDeDefensa += bonificacion;        
        }

        public Guerrero(decimal id, string nombre, short nivel)
            : base(id, nombre,nivel)
        {
            // Aplicamos los beneficios de la clase Guerrero
            AplicarBeneficiosDeClase();
        }
    }

}
