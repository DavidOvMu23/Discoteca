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
    /// Lógica de negocio para géneros.
    /// </summary>
    public class GenerosController
    {
        private GenerosModel _model;

        /// <summary>
        /// Inicializa el controlador de géneros.
        /// </summary>
        public GenerosController()
        {
            _model = new GenerosModel();
        }

        
        /// <summary>
        /// Obtiene el listado de géneros.
        /// </summary>
        /// <returns>Tabla con los géneros.</returns>
        public DataTable ObtenerListadoGeneros()
        {
            return _model.ListarGeneros();
        }

        
        /// <summary>
        /// Crea un género nuevo.
        /// </summary>
        /// <param name="nombre">Nombre del género.</param>
        /// <returns><c>true</c> si se crea correctamente.</returns>
        public bool CrearGenero(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("El nombre es obligatorio");
            }

            _model.InsertarGenero(nombre);
            return true;
        }

       
        /// <summary>
        /// Edita un género existente.
        /// </summary>
        /// <param name="id">Id del género.</param>
        /// <param name="nombre">Nombre del género.</param>
        /// <returns><c>true</c> si se actualiza correctamente.</returns>
        public bool EditarGenero(int id, string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("El nombre es obligatorio");
            }

            _model.ActualizarGenero(id, nombre);
            return true;
        }

        
        /// <summary>
        /// Elimina un género por id.
        /// </summary>
        /// <param name="id">Id del género.</param>
        /// <returns><c>true</c> si se elimina correctamente.</returns>
        public bool EliminarGenero(int id)
        {
            _model.EliminarGenero(id);
            return true;
        }
    }
}
