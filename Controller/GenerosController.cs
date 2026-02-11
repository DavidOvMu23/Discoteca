using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class GenerosController
    {
        private GenerosModel _model;

        public GenerosController()
        {
            _model = new GenerosModel();
        }

        // Listar Generos
        public DataTable ObtenerListadoGeneros()
        {
            return _model.ListarGeneros();
        }

        // Crear Genero
        public bool CrearGenero(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("El nombre es obligatorio");
            }

            _model.InsertarGenero(nombre);
            return true;
        }

        // Editar Genero
        public bool EditarGenero(int id, string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("El nombre es obligatorio");
            }

            _model.ActualizarGenero(id, nombre);
            return true;
        }

        // Eliminar Genero
        public bool EliminarGenero(int id)
        {
            _model.EliminarGenero(id);
            return true;
        }
    }
}
