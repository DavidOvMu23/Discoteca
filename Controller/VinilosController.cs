using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    /// <summary>
    /// Lógica de negocio para vinilos.
    /// </summary>
    public class VinilosController
    {
        private VinilosModel _model;

        /// <summary>
        /// Inicializa el controlador de vinilos.
        /// </summary>
        public VinilosController()
        {
            _model = new VinilosModel();
        }

        
        /// <summary>
        /// Obtiene el listado de vinilos.
        /// </summary>
        /// <returns>Tabla con los vinilos.</returns>
        public DataTable ObtenerListadoVinilos()
        {
            return _model.ListarVinilos();
        }

        
        /// <summary>
        /// Crea un vinilo nuevo.
        /// </summary>
        /// <param name="titulo">Título del vinilo.</param>
        /// <param name="anio">Año de lanzamiento.</param>
        /// <param name="estado">Estado del vinilo.</param>
        /// <param name="idArtista">Id del artista.</param>
        /// <param name="idGenero">Id del género.</param>
        /// <returns><c>true</c> si se crea correctamente.</returns>
        public bool CrearVinilo(string titulo, int anio, string estado, int idArtista, int idGenero)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                throw new Exception("El título es obligatorio");
            }

            if (anio <= 0)
            {
                throw new Exception("El año no es válido");
            }

            _model.InsertarVinilo(titulo, anio, estado, idArtista, idGenero);
            return true;
        }

        
        /// <summary>
        /// Edita un vinilo existente.
        /// </summary>
        /// <param name="id">Id del vinilo.</param>
        /// <param name="titulo">Título del vinilo.</param>
        /// <param name="anio">Año de lanzamiento.</param>
        /// <param name="estado">Estado del vinilo.</param>
        /// <param name="idArtista">Id del artista.</param>
        /// <param name="idGenero">Id del género.</param>
        /// <returns><c>true</c> si se actualiza correctamente.</returns>
        public bool EditarVinilo(int id, string titulo, int anio, string estado, int idArtista, int idGenero)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                throw new Exception("El titulo es obligatorio");
            }

            if (anio <= 0)
            {
                throw new Exception("El año no es válido");
            }

            _model.ActualizarVinilo(id, titulo, anio, estado, idArtista, idGenero);
            return true;
        }

        
        /// <summary>
        /// Elimina un vinilo por id.
        /// </summary>
        /// <param name="id">Id del vinilo.</param>
        /// <returns><c>true</c> si se elimina correctamente.</returns>
        public bool EliminarVinilo(int id)
        {
            _model.EliminarVinilo(id);
            return true;
        }
    }
}
