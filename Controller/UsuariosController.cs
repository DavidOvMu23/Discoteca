using Model;
using System;
using System.Data;
using System.Globalization;


namespace Controller
{
    /// <summary>
    /// Lógica de negocio para usuarios.
    /// </summary>
    public class UsuariosController
    {
        private UsuariosModel _model;

        /// <summary>
        /// Inicializa el controlador de usuarios.
        /// </summary>
        public UsuariosController()
        {
            _model = new UsuariosModel();
        }

        
        /// <summary>
        /// Obtiene el listado de usuarios.
        /// </summary>
        /// <returns>Tabla con los usuarios.</returns>
        public DataTable ObtenerListadoUsuarios()
        {
            return _model.ListarUsuarios();
        }

       
        /// <summary>
        /// Crea un usuario nuevo.
        /// </summary>
        /// <param name="nombre">Nombre del usuario.</param>
        /// <param name="email">Correo del usuario.</param>
        /// <param name="telefono">Teléfono del usuario.</param>
        /// <returns><c>true</c> si se crea correctamente.</returns>
        public bool CrearUsuario(string nombre, string email, string telefono)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("El nombre es obligatorio");
            }

            DateTime fechaRegistro = DateTime.Now;
            _model.InsertarUsuario(nombre, email, telefono, fechaRegistro);
            return true;
        }

        ç
        /// <summary>
        /// Edita un usuario existente.
        /// </summary>
        /// <param name="id">Id del usuario.</param>
        /// <param name="nombre">Nombre del usuario.</param>
        /// <param name="email">Correo del usuario.</param>
        /// <param name="telefono">Teléfono del usuario.</param>
        /// <returns><c>true</c> si se actualiza correctamente.</returns>
        public bool EditarUsuario(int id, string nombre, string email, string telefono)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("El nombre es obligaotio");
            }

            _model.ActualizarUsuario(id, nombre, email, telefono);
            return true ;
        }

        
        /// <summary>
        /// Elimina un usuario por id.
        /// </summary>
        /// <param name="id">Id del usuario.</param>
        /// <returns><c>true</c> si se elimina correctamente.</returns>
        public bool EliminarUsuario(int id)
        {
            _model.EliminarUsuario(id);
            return true;
        }
    }
}
