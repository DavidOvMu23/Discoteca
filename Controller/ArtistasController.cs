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
            if (string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre es obligatorio");

            _model.InsertarArtista(nombre, nacionalidad);
            return true;
        }

        // Editar Artista
        public bool EditarArtista(int id, string nombre, string nacionalidad)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre es obligatorio");

            _model.ActualizarArtista(id, nombre, nacionalidad);
            return true;
        }

        // Eliminar Artista
        public bool EliminarArtista(int id)
        {
            _model.EliminarArtista(id);
            return true;
        }
    }
}