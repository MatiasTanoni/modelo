using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Modelo_de_final
{
    public static class PersonajeDAO
    {
        public static Personaje? ObtenerPersonajePorId(decimal id)
        {
            string cadenaConexion = "Server=localhost\\SQLEXPRESS;Database=COMBATE_DB;Trusted_Connection=True;";
               
            string query = "SELECT id, nombre, nivel, clase FROM Personajes WHERE id = @id";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@id", id);
                conexion.Open();

                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    if (lector.Read())
                    {
                        int clase = lector.GetInt16(3);
                        decimal idBD = lector.GetInt32(0);
                        string nombre = lector.GetString(1);
                        short nivel = lector.GetInt16(2);

                        return clase switch
                        {
                            1 => new Guerrero(idBD, nombre, nivel),
                            2 => new Hechicero(idBD, nombre, nivel),
                            _ => null
                        };
                    }
                }
            }

            return null;
        }

    }
}
