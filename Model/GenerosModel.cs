using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Model
{
    public class GenerosModel
    {
        // Configuramos la cadena de conexión a la base de datos MySQL
        private string cadena = ConfigurationManager.ConnectionStrings["View.Properties.Settings.CadenaDiscoteca"].ConnectionString;

        // Listar géneros musicales
        public DataTable ListarGeneros()
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "SELECT * FROM GENEROS";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Crear genero
        public void InsertarGenero(string nombre)
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "INSERT INTO GENEROS (nombre_genero) VALUES (@nombre)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@nombre", nombre);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Actualizar genero
        public void ActualizarGenero(int id, string nombre)
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "UPDATE GENEROS SET nombre_genero = @nombre WHERE id_genero = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Eliminar genero
        public void EliminarGenero(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "DELETE FROM GENEROS WHERE id_genero = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
