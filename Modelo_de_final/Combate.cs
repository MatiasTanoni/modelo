using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace Modelo_de_final
{
    public class Combate
    {
        public event Action<IJugador, IJugador>? RondaIniciada;
        public event Action<IJugador>? CombateFinalizado;

        private IJugador _atacado;
        private IJugador _atacante;
        private static Random _random;

        static Combate()
        {
        }
        private Combate()
        {
            _random = new Random();
        }
        public Combate(IJugador jugador1, IJugador jugador2)
        {
            _atacante = SeleccionarPrimerAtacante(jugador1, jugador2);
            _atacado = _atacante == jugador1 ? jugador2 : jugador1;
        }


        private void Combatir()
        {
            Personaje? perdedor = null;
            Personaje? ganador = null;

            while (ganador == null)
            {
                IniciarRonda();
                ganador = (Personaje)EvaluarGanador();

                if (ganador ==(Personaje)_atacado)
                {
                    perdedor =(Personaje)_atacante;
                }
                else
                {
                    perdedor =(Personaje)_atacado;
                }
            }

            CombateFinalizado?.Invoke(ganador);

            DateTime fecha = DateTime.Now;

            var resultado = new ResultadoCombate(
                fecha,
                ganador.ToString(),
                perdedor.ToString()
            );

            // SERIALIZAR A JSON
            string json = JsonSerializer.Serialize(resultado, new JsonSerializerOptions { WriteIndented = true });

            // Guardar el JSON en un archivo
            string ruta = "resultadoCombate.json";
            File.WriteAllText(ruta, json);

            // Mostrar ruta completa
            Console.WriteLine("✅ JSON generado en: " + Path.GetFullPath(ruta));
        }



        private IJugador EvaluarGanador()
        {
            if (_atacado.PuntosDeVida == 0)
            {
                return _atacante;
            }
            else
            {
                if (_atacado.PuntosDeVida >= 0)
                {
                    IJugador temp = _atacante;
                    _atacante = _atacado;
                    _atacado = temp;
                    return null;
                }
                return null;
            }
        }
        public Task IniciarCombate()
        {
            return Task.Run(() => Combatir());
        }

        private void IniciarRonda()
        {
            RondaIniciada?.Invoke(_atacante, _atacado);
            _atacante.Atacar();
        }

        private IJugador SeleccionarJugadorAleatoriamente(IJugador jugador1, IJugador jugador2)
        {
            var resultado = (LadosMoneda)Aleatorio.TirarUnaMoneda();

            if (resultado == LadosMoneda.Cara)
                return jugador1;
            else
                return jugador2;
        }

        private IJugador SeleccionarPrimerAtacante(IJugador jugador1, IJugador jugador2)
        {
            if (jugador1.Nivel != jugador2.Nivel)
            {
                if (jugador1.Nivel > jugador2.Nivel)
                {
                    return jugador2;
                }
                else
                {
                    return jugador1;
                }
            }
            else
            {
                return SeleccionarJugadorAleatoriamente(jugador1, jugador2);
            }
        }


    }
}
