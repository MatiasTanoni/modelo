using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_final
{
    public class Hechicero : Personaje
    {
        protected override void AplicarBeneficiosDeClase()
        {
            int bonificacion = (puntosDePoder * 10) / 100;

            puntosDePoder += bonificacion;
        }
        public Hechicero(decimal id, string nombre, short nivel)
            :base(id, nombre, nivel)
        {
            // Aplicamos los beneficios de la clase Guerrero
            AplicarBeneficiosDeClase();
        }
    }
}
