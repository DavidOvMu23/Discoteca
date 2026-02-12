using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Model
{
    public class UsuariosModel
    {
        // Configuramos la cadena de conexión a la base de datos MySQL
        private string cadena = ConfigurationManager.ConnectionStrings["View.Properties.Settings.CadenaDiscoteca"].ConnectionString;

        // Listar usuarios
        public DataTable ListarUsuarios()
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "SELECT * FROM USUARIOS";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        
        /// <summary>
        /// Inserta un usuario nuevo.
        /// </summary>
        /// <param name="nombre">Nombre del usuario.</param>
        /// <param name="email">Correo del usuario.</param>
        /// <param name="telefono">Teléfono del usuario.</param>
        /// <param name="fechaRegistro">Fecha de registro.</param>
        public void InsertarUsuario(string nombre, string email, string telefono, DateTime fechaRegistro)
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "INSERT INTO USUARIOS (nombre, email, telefono, fecha_registro) VALUES (@nombre, @email, @telefono, @fecha)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@fecha", fechaRegistro);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        
        /// <summary>
        /// Actualiza los datos de un usuario.
        /// </summary>
        /// <param name="id">Id del usuario.</param>
        /// <param name="nombre">Nombre del usuario.</param>
        /// <param name="email">Correo del usuario.</param>
        /// <param name="telefono">Teléfono del usuario.</param>
        public void ActualizarUsuario(int id, string nombre, string email, string telefono)
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "UPDATE USUARIOS SET nombre = @nombre, email = @email, telefono = @telefono WHERE id_usuario = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

       
        /// <summary>
        /// Elimina un usuario por id.
        /// </summary>
        /// <param name="id">Id del usuario.</param>
        public void EliminarUsuario(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "DELETE FROM USUARIOS WHERE id_usuario = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
