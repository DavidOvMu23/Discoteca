using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class AlquileresController
    {
        private AlquileresModel _model;

        public AlquileresController()
        {
            _model = new AlquileresModel();
        }

        //Listar Alquileres
        public DataTable ObtenerListado()
        {
            return _model.ListarAlquileres();
        }

        //Crear alquiler
        public bool CrearAlquiler(int idUsuario, int idVinilo, DateTime fechaSalida, DateTime fechaEntregaPrevista)
        {
            if (fechaSalida > fechaEntregaPrevista)
            {
                throw new Exception("La fecha de salida no puede ser posterior a la fecha de entrega prevista");
            }

            _model.InsertarAlquiler(idUsuario, idVinilo, fechaSalida, fechaEntregaPrevista);
            return true;
        }

        //Editar alquiler
        public bool EditarAlquiler(int idAlquiler, int idUsuario, int idVinilo, DateTime fechaSalida, DateTime fechaEntregaPrevista, DateTime? fechaDevolucionReal)
        {
            if (fechaSalida > fechaEntregaPrevista)
            {
                throw new Exception("La fecha de salida no puede ser posterior a la fecha de entrega prevista");
            }

            _model.ActualizarAlquiler(idAlquiler, idUsuario, idVinilo, fechaSalida, fechaEntregaPrevista, fechaDevolucionReal);
            return true;
        }
        
        //Eliminar alquiler
        public bool EliminarALquiler(int idAlquiler)
        {
            _model.EliminarAlquiler(idAlquiler);
            return true;
        }
    }
}
