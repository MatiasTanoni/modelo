namespace Modelo_de_final
{
    public static class Aleatorio
    {
        public static Enum TirarUnaMoneda()
        {
            Random random = new Random();
            LadosMoneda resultado = (LadosMoneda)random.Next(0, 2);
            return resultado;
        }
    }
}
 