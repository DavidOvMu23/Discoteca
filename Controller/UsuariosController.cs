using Model;
using System;
using System.Data;
using System.Globalization;


namespace Controller
{
    public class UsuariosController
    {
        private UsuariosModel _model;

        public UsuariosController()
        {
            _model = new UsuariosModel();
        }

        //Listar usuarios
        public DataTable ObtenerListadoUsuarios()
        {
            return _model.ListarUsuarios();
        }

        // Crear usuario
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

        // Editar usuario
        public bool EditarUsuario(int id, string nombre, string email, string telefono)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new Exception("El nombre es obligaotio");
            }

            _model.ActualizarUsuario(id, nombre, email, telefono);
            return true ;
        }

        // Eliminar usuario
        public bool EliminarUsuario(int id)
        {
            _model.EliminarUsuario(id);
            return true;
        }
    }
}
