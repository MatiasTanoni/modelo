using Modelo_de_final;

class Program
{
    static void Main(string[] args)
    {
        Personaje personaje1 = PersonajeDAO.ObtenerPersonajePorId(6);
        Personaje personaje2 = PersonajeDAO.ObtenerPersonajePorId(7);
        Console.WriteLine($"Personaje 1: {personaje1} + Personaje 2: {personaje2}");
        Combate combate = new Combate(personaje1, personaje2);

        combate.RondaIniciada += IniciarRonda;
        combate.CombateFinalizado += FinalizarCombate;
        personaje1.AtaqueLanzado += MostrarAtaqueLanzado;
        personaje2.AtaqueLanzado += MostrarAtaqueLanzado;
        personaje1.AtaqueRecibido += MostrarAtaqueRecibido;
        personaje2.AtaqueRecibido += MostrarAtaqueRecibido;

        Console.WriteLine("¡FIGHT!");
        combate.IniciarCombate().Wait();
    }

    static void IniciarRonda(IJugador atacante, IJugador atacado)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\n--------------------------------");
        Console.WriteLine($"¡{atacante} ataca a {atacado}!");
    }

    static void FinalizarCombate(IJugador ganador)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("\n--------------------------------");
        Console.WriteLine($"Combate finalizado. El ganador es {ganador}.");
    }

    static void MostrarAtaqueLanzado(Personaje personaje, int puntosDeAtaque)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{personaje} lanzó un ataque de {puntosDeAtaque} puntos.");
    }

    static void MostrarAtaqueRecibido(Personaje personaje, int puntosDeAtaque)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{personaje} recibió un ataque por {puntosDeAtaque} puntos. Le quedan {personaje.PuntosDeVida} puntos de vida.");
    }
}
