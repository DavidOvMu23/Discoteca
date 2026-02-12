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
    /// Lógica de negocio para alquileres.
    /// </summary>
    public class AlquileresController
    {
        private AlquileresModel _model;

        /// <summary>
        /// Inicializa el controlador de alquileres.
        /// </summary>
        public AlquileresController()
        {
            _model = new AlquileresModel();
        }

        
        /// <summary>
        /// Obtiene el listado de alquileres.
        /// </summary>
        /// <returns>Tabla con los alquileres.</returns>
        public DataTable ObtenerListado()
        {
            return _model.ListarAlquileres();
        }

        
        /// <summary>
        /// Crea un alquiler nuevo.
        /// </summary>
        /// <param name="idUsuario">Id del usuario.</param>
        /// <param name="idVinilo">Id del vinilo.</param>
        /// <param name="fechaSalida">Fecha de salida.</param>
        /// <param name="fechaEntregaPrevista">Fecha de entrega prevista.</param>
        /// <returns><c>true</c> si se crea correctamente.</returns>
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

        
        /// <summary>
        /// Edita un alquiler existente.
        /// </summary>
        /// <param name="idAlquiler">Id del alquiler.</param>
        /// <param name="idUsuario">Id del usuario.</param>
        /// <param name="idVinilo">Id del vinilo.</param>
        /// <param name="fechaSalida">Fecha de salida.</param>
        /// <param name="fechaEntregaPrevista">Fecha de entrega prevista.</param>
        /// <param name="fechaDevolucionReal">Fecha real de devolución.</param>
        /// <returns><c>true</c> si se actualiza correctamente.</returns>
        public bool EditarAlquiler(int idAlquiler, int idUsuario, int idVinilo, DateTime fechaSalida, DateTime fechaEntregaPrevista, DateTime? fechaDevolucionReal)
        {
            if (fechaSalida > fechaEntregaPrevista)
            {
                throw new Exception("La fecha de salida no puede ser posterior a la fecha de entrega prevista");
            }

            _model.ActualizarAlquiler(idAlquiler, idUsuario, idVinilo, fechaSalida, fechaEntregaPrevista, fechaDevolucionReal);
            return true;
        }
        
        
        /// <summary>
        /// Elimina un alquiler por id.
        /// </summary>
        /// <param name="idAlquiler">Id del alquiler.</param>
        /// <returns><c>true</c> si se elimina correctamente.</returns>
        public bool EliminarALquiler(int idAlquiler)
        {
            _model.EliminarAlquiler(idAlquiler);
            return true;
        }

        /// <summary>
        /// Comprueba si un vinilo está disponible según los alquileres abiertos.
        /// en uso tambien para la prueba unitaria
        /// </summary>
        /// <param name="alquileres">Tabla de alquileres.</param>
        /// <param name="idVinilo">Id del vinilo.</param>
        /// <returns><c>true</c> si está disponible.</returns>
        public bool ViniloDisponible(DataTable alquileres, int idVinilo)
        {
            if (alquileres == null)
            {
                throw new ArgumentNullException(nameof(alquileres));
            }

            foreach (DataRow row in alquileres.Rows)
            {
                if ((int)row["id_vinilo"] == idVinilo && row["fecha_devolucion_real"] == DBNull.Value)
                {
                    return false;
                }
            }

            return true;
        }

       
        /// <summary>
        /// Obtiene alquileres filtrados por usuario para el informe.
        /// lo ponemos aqui para que así el informe no tenga acceso al 
        /// model y se mantenga la separación de proyectos
        /// </summary>
        /// <param name="idUsuario">Id del usuario.</param>
        /// <returns>Tabla con los alquileres del usuario.</returns>
        public DataTable ObtenerAlquileresPorUsuario(int idUsuario)
        {
            return _model.ListarAlquileresUsuarioInforme(idUsuario);
        }
    }
}
