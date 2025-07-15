using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_final
{
    public abstract class Personaje : IJugador
    {

        public event Action<Personaje, int>? AtaqueLanzado;

        public event Action<Personaje, int>? AtaqueRecibido;

        public int Atacar()
        {

            int esperaMilisegundos = _random.Next(1000, 5001);
            Thread.Sleep(esperaMilisegundos); // Solo al final del método

            int porcentaje = _random.Next(10, 101);
            int puntosDeAtaque = (this.puntosDePoder * porcentaje) / 100;

            AtaqueLanzado?.Invoke(this, puntosDeAtaque);

            this.RecibirAtaque(puntosDeAtaque);
            return puntosDeAtaque;
        }


        public void RecibirAtaque(int danio)
        {
            int porcentaje = _random.Next(10, 101);
            int defensaAplicada = (this.puntosDeDefensa * porcentaje) / 100;

            int danioFinal = danio - defensaAplicada;
            if (danioFinal < 0) danioFinal = 0;

            this.puntosDeVida -= danioFinal;
            if (this.puntosDeVida < 0)
                this.puntosDeVida = 0;

            AtaqueRecibido?.Invoke(this, danioFinal);
        }


        private decimal _id;
        private short _nivel;
        private string _nombre;
        protected int puntosDeDefensa;
        protected int puntosDePoder;
        protected int puntosDeVida;
        private static Random _random;
        private string _titulo;
        private const int _maximoDeNivel = 100;
        private const int _minimoDeNivel = 1;

        public string Titulo
        {
            set { _titulo = value; }
        }
        public short Nivel { get; }
        public int PuntosDeVida { get; }
        public int PuntosDeDefensa
        { 
            set { puntosDeDefensa = value; }
            get { return puntosDeDefensa; }
        }

        protected virtual void AplicarBeneficiosDeClase()
        {

        }

        public override bool Equals(object? obj)
        {
            // Si es null o no es del tipo Personaje, devuelve false
            if (obj is not Personaje otroPersonaje)
                return false;

            // Compara por _id
            return this._id == otroPersonaje._id;
        }

        public override int GetHashCode()
        {
            // Usa _id como base para el hash (es lo que define la identidad)
            return _id.GetHashCode();
        }

        public static bool operator ==(Personaje? personaje1, Personaje? personaje2)
        {
            // Si ambos son null, son iguales
            if (ReferenceEquals(personaje1, personaje2))
                return true;

            // Si uno solo es null, son distintos
            if (personaje1 is null || personaje2 is null)
                return false;

            // Compara por _id
            return personaje1._id == personaje2._id;
        }

        public static bool operator !=(Personaje? personaje1, Personaje? personaje2)
        {
            return !(personaje1 == personaje2);
        }

        private Personaje()
        {
            _random = new Random();
        }

        public Personaje(decimal id, string nombre)
        {
            this._nivel = 1;
            this._id = id;

            try
            {
                // Elimina espacios al inicio y al final
                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    this._nombre = nombre.Trim();
                }
                else
                {
                    throw new ArgumentNullException(nameof(nombre), "El nombre no puede ser nulo, vacío o contener solo espacios.");
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }

        }

        public Personaje(decimal id, string nombre, short nivel)
            : this(id, nombre) // llama al constructor de 2 parámetros
        {
            this.puntosDeDefensa = 100;
            try
            {
                if (nivel <= _maximoDeNivel && nivel >= _minimoDeNivel)
                {
                    this._nivel = nivel;
                    this.puntosDePoder = 100 * nivel;
                    this.puntosDeVida = 500 * nivel;
                }
                else
                {
                    throw new BusinessException("El nivel no puede ser menor que 1 o mayor a 100.");
                }
            }
            catch (BusinessException ex)
            {
                Console.WriteLine(ex.Message);
                Logger logger = new Logger("log.txt");
                logger.GuardarLog($"BusinessException: {ex.Message}, StackTrace: {ex.StackTrace}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Logger logger = new Logger("log.txt");
                logger.GuardarLog($"ArgumentOutOfRangeException: {ex.Message}, StackTrace: {ex.StackTrace}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger logger = new Logger("log.txt");
                logger.GuardarLog($"Exception: {ex.Message}, StackTrace: {ex.StackTrace}");
            }

        }

        static Personaje()
        {
            _random = new Random();
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(_titulo))
                return _nombre;
            else
                return $"{_nombre}, {_titulo}";
        }
    }
}
