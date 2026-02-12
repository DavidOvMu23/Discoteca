using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Model
{
    public class VinilosModel
    {
        // Configuramos la cadena de conexión a la base de datos MySQL de AZURE
        private string cadena = ConfigurationManager.ConnectionStrings["Model.Properties.Settings.CadenaDiscoteca"].ConnectionString;

        // Listar vinilos
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

        // Insertar vinilo
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

        // Actualizar vinilo
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

        // Eliminar vinilo
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

        // Consulta para report
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