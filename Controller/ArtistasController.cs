using Model;
using System;
using System.Data;
using System.Reflection;

namespace Controller
{
    /// <summary>
    /// Lógica de negocio para artistas.
    /// </summary>
    public class ArtistasController
    {
        private ArtistasModel _model;

        /// <summary>
        /// Inicializa el controlador de artistas.
        /// </summary>
        public ArtistasController()
        {
            _model = new ArtistasModel();
        }

       
        /// <summary>
        /// Obtiene el listado de artistas.
        /// </summary>
        /// <returns>Tabla con los artistas.</returns>
        public DataTable ObtenerListadoArtistas()
        {
            return _model.ListarArtistas();
        }

        
        /// <summary>
        /// Crea un artista nuevo.
        /// </summary>
        /// <param name="nombre">Nombre del artista.</param>
        /// <param name="nacionalidad">Nacionalidad del artista.</param>
        /// <returns><c>true</c> si se crea correctamente.</returns>
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

        
        /// <summary>
        /// Edita un artista existente.
        /// </summary>
        /// <param name="id">Id del artista.</param>
        /// <param name="nombre">Nombre del artista.</param>
        /// <param name="nacionalidad">Nacionalidad del artista.</param>
        /// <returns><c>true</c> si se actualiza correctamente.</returns>
        public bool EditarArtista(int id, string nombre, string nacionalidad)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("El nombre es obligatorio");
            }

            _model.ActualizarArtista(id, nombre, nacionalidad);
            return true;
        }

        
        /// <summary>
        /// Elimina un artista por id.
        /// </summary>
        /// <param name="id">Id del artista.</param>
        /// <returns><c>true</c> si se elimina correctamente.</returns>
        public bool EliminarArtista(int id)
        {
            _model.EliminarArtista(id);
            return true;
        }


        /// <summary>
        /// Comprueba si el nombre del artista está disponible.
        /// en uso tambien en el proyecti de la prueba unitaria
        /// </summary>
        /// <param name="artistas">Tabla de artistas.</param>
        /// <param name="nombre">Nombre a validar.</param>
        /// <returns><c>true</c> si el nombre no existe.</returns>
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

            string nombreBuscado = nombre.ToLower();

            foreach (DataRow row in artistas.Rows)
            {
                string existente = row["nombre_artista"].ToString().ToLower();
                if (existente == nombreBuscado)
                {
                    return false;
                }
            }

            return true;
        }
    }
}