using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Model
{
    /// <summary>
    /// Acceso a datos de vinilos.
    /// </summary>
    public class VinilosModel
    {
        // Configuramos la cadena de conexión a la base de datos MySQL de AZURE
        private string cadena = ConfigurationManager.ConnectionStrings["Model.Properties.Settings.CadenaDiscoteca"].ConnectionString;

        
        /// <summary>
        /// Obtiene todos los vinilos registrados.
        /// </summary>
        /// <returns>Tabla con los vinilos.</returns>
        public DataTable ListarVinilos()
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                // No me funcionaba la conexión con azure por que hace falta una conexión con certificado y esta es la solución (me lo ha hecho el chat)
                System.Net.ServicePointManager.ServerCertificateValidationCallback = (s, c, h, e) => true;

                string sql = "SELECT * FROM VINILOS";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        
        /// <summary>
        /// Inserta un vinilo nuevo.
        /// </summary>
        /// <param name="titulo">Título del vinilo.</param>
        /// <param name="anio">Año de lanzamiento.</param>
        /// <param name="estado">Estado del vinilo.</param>
        /// <param name="idArtista">Id del artista.</param>
        /// <param name="idGenero">Id del género.</param>
        public void InsertarVinilo(string titulo, int anio, string estado, int idArtista, int idGenero)
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "INSERT INTO VINILOS (titulo, anio_lanzamiento, estado, id_artista, id_genero) VALUES (@titulo, @anio, @estado, @idArtista, @idGenero)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@titulo", titulo);
                cmd.Parameters.AddWithValue("@anio", anio);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@idArtista", idArtista);
                cmd.Parameters.AddWithValue("@idGenero", idGenero);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        
        /// <summary>
        /// Actualiza los datos de un vinilo existente.
        /// </summary>
        /// <param name="id">Id del vinilo.</param>
        /// <param name="titulo">Título del vinilo.</param>
        /// <param name="anio">Año de lanzamiento.</param>
        /// <param name="estado">Estado del vinilo.</param>
        /// <param name="idArtista">Id del artista.</param>
        /// <param name="idGenero">Id del género.</param>
        public void ActualizarVinilo(int id, string titulo, int anio, string estado, int idArtista, int idGenero)
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "UPDATE VINILOS SET titulo = @titulo, anio_lanzamiento = @anio, estado = @estado, id_artista = @idArtista, id_genero = @idGenero WHERE id_vinilo = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@titulo", titulo);
                cmd.Parameters.AddWithValue("@anio", anio);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@idArtista", idArtista);
                cmd.Parameters.AddWithValue("@idGenero", idGenero);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        
        /// <summary>
        /// Elimina un vinilo por id.
        /// </summary>
        /// <param name="id">Id del vinilo.</param>
        public void EliminarVinilo(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = "DELETE FROM VINILOS WHERE id_vinilo = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        
        /// <summary>
        /// Obtiene datos de vinilos para el informe principal.
        /// </summary>
        /// <returns>Tabla con la información del informe.</returns>
        public DataTable ListarVinilosInforme()
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = @"
            SELECT v.titulo, 
                   v.anio_lanzamiento, 
                   v.estado, 
                   a.nombre_artista, 
                   g.nombre_genero
            FROM VINILOS v
            INNER JOIN ARTISTAS a ON v.id_artista = a.id_artista
            INNER JOIN GENEROS g ON v.id_genero = g.id_genero";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Obtiene datos de vinilos y artistas para informe.
        /// </summary>
        /// <returns>Tabla con la información del informe.</returns>
        public DataTable ListarVinilosArtistaInforme()
        {
            using (MySqlConnection conn = new MySqlConnection(cadena))
            {
                string sql = @"
            SELECT v.titulo AS Titulo, 
                   v.anio_lanzamiento, 
                   v.estado, 
                   a.nombre_artista
            FROM VINILOS v
            INNER JOIN ARTISTAS a ON v.id_artista = a.id_artista";


                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}