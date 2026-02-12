using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Model
{
    public class ArtistasModel
    {
        // Configuramos la cadena de conexión a la base de datos MySQL
        private string cadena = ConfigurationManager.ConnectionStrings["View.Properties.Settings.CadenaDiscoteca"].ConnectionString;

        // Listar artistas
        public DataTable ListarArtistas()
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "SELECT * FROM ARTISTAS";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        
        /// <summary>
        /// Inserta un artista nuevo.
        /// </summary>
        /// <param name="nombre">Nombre del artista.</param>
        /// <param name="nacionalidad">Nacionalidad del artista.</param>
        public void InsertarArtista(string nombre, string nacionalidad)
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "INSERT INTO ARTISTAS (nombre_artista, nacionalidad) VALUES (@nombre, @nacionalidad)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@nacionalidad", nacionalidad);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        
        /// <summary>
        /// Actualiza los datos de un artista.
        /// </summary>
        /// <param name="id">Id del artista.</param>
        /// <param name="nombre">Nombre del artista.</param>
        /// <param name="nacionalidad">Nacionalidad del artista.</param>
        public void ActualizarArtista(int id, string nombre, string nacionalidad)
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "UPDATE ARTISTAS SET nombre_artista = @nombre, nacionalidad = @nacionalidad WHERE id_artista = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        
        /// <summary>
        /// Elimina un artista por id.
        /// </summary>
        /// <param name="id">Id del artista.</param>
        public void EliminarArtista(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "DELETE FROM ARTISTAS WHERE id_artista = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
