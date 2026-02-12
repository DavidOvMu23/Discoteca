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
                {
                    cmd.Parameters.AddWithValue("@fechaDevolucion", fechaDevolucionReal.Value.ToString("yyyy-MM-dd"));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@fechaDevolucion", DBNull.Value);
                }

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

        // Metodo para la prueba de integración de conexión a la base de datos
        public bool PruebaConexion()
        {
            try
            {
                var conn = new MySqlConnection(cadena);
                conn.Open();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Método para listar alquileres de un usuario especifico
        // para el informe
        public DataTable ListarAlquileresUsuarioInforme(int idUsuarioSeleccionado)
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = @"
            SELECT v.titulo AS nombre_vinilo, 
                   a.fecha_salida, 
                   a.fecha_entrega_prevista, 
                   a.fecha_devolucion_real,
                   u.nombre AS NombreUsuario
            FROM ALQUILERES a
            INNER JOIN USUARIOS u ON a.id_usuario = u.id_usuario
            INNER JOIN VINILOS v ON a.id_vinilo = v.id_vinilo
            WHERE u.id_usuario = @idUsuario
            ORDER BY a.fecha_salida";

                // Preparamos el comando
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                // Pasamos la ID del ComboBox
                cmd.Parameters.AddWithValue("@idUsuario", idUsuarioSeleccionado);

                // Llenamos la tabla
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
