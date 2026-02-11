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

            var alquileres = _model.ListarAlquileres();
            if (!ViniloDisponible(alquileres, idVinilo))
            {
                throw new Exception("El vinilo no está disponible porque aún no ha sido devuelto");
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

        //Comprobar si el vinilo está disponible para poder alquilarlo
        //en uso también por la prueba unitaria de solapamiento de alquileres
        public bool ViniloDisponible(DataTable alquileres, int idVinilo)
        {
            if (alquileres == null)
            {
                throw new ArgumentNullException(nameof(alquileres));
            }

            foreach (DataRow row in alquileres.Rows)
            {
                if (Convert.ToInt32(row["id_vinilo"]) == idVinilo &&
                    (row["fecha_devolucion_real"] == DBNull.Value || row["fecha_devolucion_real"] == null))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
