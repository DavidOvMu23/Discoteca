using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    internal class VinilosController
    {
        private VinilosModel _model;

        public VinilosController()
        {
            _model = new VinilosModel();
        }

        //Listar usuarios
        public DataTable ObtenerListadoVinilos()
        {
            return _model.ListarVinilos();
        }

        //Crear vinilo
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

        //Editar vinilo
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

        //Eliminar vinilo
        public bool EliminarVinilo(int id)
        {
            _model.EliminarVinilo(id);
            return true;
        }
    }
}
