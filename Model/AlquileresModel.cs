using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Model
{
    public class AlquileresModel
    {
        // Configuramos la cadena de conexión a la base de datos MySQL
        private string cadena = ConfigurationManager.ConnectionStrings["View.Properties.Settings.CadenaDiscoteca"].ConnectionString;

        // Listar alquileres
        public DataTable ListarAlquileres()
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "SELECT * FROM ALQUILERES";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Insertar alquiler
        public void InsertarAlquiler(int idUsuario, int idVinilo, DateTime fechaSalida, DateTime fechaEntregaPrevista)
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "INSERT INTO ALQUILERES (id_usuario, id_vinilo, fecha_salida, fecha_entrega_prevista) VALUES (@idUsuario, @idVinilo, @fechaSalida, @fechaEntregaPrevista)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@idVinilo", idVinilo);
                cmd.Parameters.AddWithValue("@fechaSalida", fechaSalida.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@fechaEntregaPrevista", fechaEntregaPrevista.ToString("yyyy-MM-dd"));
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Actualizar alquiler
        public void ActualizarAlquiler(int id, int idUsuario, int idVinilo, DateTime fechaSalida, DateTime fechaEntregaPrevista, DateTime? fechaDevolucionReal)
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "UPDATE ALQUILERES SET id_usuario = @idUsuario, id_vinilo = @idVinilo, fecha_salida = @fechaSalida, fecha_entrega_prevista = @fechaEntregaPrevista, fecha_devolucion_real = @fechaDevolucion WHERE id_alquiler = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@idVinilo", idVinilo);
                cmd.Parameters.AddWithValue("@fechaSalida", fechaSalida.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@fechaEntregaPrevista", fechaEntregaPrevista.ToString("yyyy-MM-dd"));
                if (fechaDevolucionReal.HasValue)
                    cmd.Parameters.AddWithValue("@fechaDevolucion", fechaDevolucionReal.Value.ToString("yyyy-MM-dd"));
                else
                    cmd.Parameters.AddWithValue("@fechaDevolucion", DBNull.Value);

                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Eliminar alquiler
        public void EliminarAlquiler(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "DELETE FROM ALQUILERES WHERE id_alquiler = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
