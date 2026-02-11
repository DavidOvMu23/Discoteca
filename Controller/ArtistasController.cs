using Model;
using System;
using System.Data;
using System.Reflection;

namespace Controller
{
    public class ArtistasController
    {
        private ArtistasModel _model;

        public ArtistasController()
        {
            _model = new ArtistasModel();
        }

        // Listar Artistas
        public DataTable ObtenerListadoArtistas()
        {
            return _model.ListarArtistas();
        }

        // Crear Artista
        public bool CrearArtista(string nombre, string nacionalidad)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                // lo tengo que hacer así en vez de usar un meesage box por que esta capa del programa no tiene acceso a la view
                throw new Exception("El nombre es obligatorio");
            }

            var artistas = _model.ListarArtistas();
            if (!NombreArtistaDisponible(artistas, nombre))
            {
                throw new Exception("Ya existe un artista con ese nombre");
            }

            _model.InsertarArtista(nombre, nacionalidad);
            return true;
        }

        // Editar Artista
        public bool EditarArtista(int id, string nombre, string nacionalidad)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("El nombre es obligatorio");
            }

            _model.ActualizarArtista(id, nombre, nacionalidad);
            return true;
        }

        // Eliminar Artista
        public bool EliminarArtista(int id)
        {
            _model.EliminarArtista(id);
            return true;
        }

        // Metodo para comprobar que no se repitan artistas
        // usado también en el proyecto de prueba unitaria
        public bool NombreArtistaDisponible(DataTable artistas, string nombre)
        {
            if (artistas == null)
            {
                throw new ArgumentNullException(nameof(artistas));
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("El nombre es obligatorio");
            }

            string nombreNormalizado = nombre.Trim();

            foreach (DataRow row in artistas.Rows)
            {
                string existente = row["nombre_artista"]?.ToString()?.Trim() ?? string.Empty;
                if (string.Equals(existente, nombreNormalizado, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }
    }
}