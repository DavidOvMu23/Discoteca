using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Controller;

namespace View
{
    /// <summary>
    /// Lógica de interacción para reservas.xaml
    /// </summary>
    public partial class UsuariosView : Window
    {
        private UsuariosController _controller;
        /// <summary>
        /// Inicializa la vista de usuarios.
        /// </summary>
        public UsuariosView()
        {
            InitializeComponent();
            _controller = new UsuariosController();
            CargarUsuarios();
        }

        /// <summary>
        /// Carga los usuarios en el grid.
        /// </summary>
        private void CargarUsuarios()
        {
            DataTable db = _controller.ObtenerListadoUsuarios();
            datagrid_usuarios.ItemsSource = db.DefaultView;
        }

        /// <summary>
        /// Elimina el usuario seleccionado.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_eliminarUsuario_Click_1(object sender, RoutedEventArgs e)
        {
            DataRowView row = datagrid_usuarios.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = (int)row["id_usuario"];
                if (_controller.EliminarUsuario(id))
                {
                    MessageBox.Show("Usuario eliminado correctamente.");
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el usuario.");
                }
            }
        }

        /// <summary>
        /// Abre el formulario para editar un usuario.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_editarUsuario_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = datagrid_usuarios.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = (int)row["id_usuario"];
                string nombre = row["nombre"].ToString();
                string email = row["email"].ToString();
                string telefono = row["telefono"].ToString();
                UsuariosForm form = new UsuariosForm(id, nombre, email, telefono);
                form.Show();
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para editar.");
            }
        }

        /// <summary>
        /// Abre la vista de reservas.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_reservas_Click(object sender, RoutedEventArgs e)
        {
            ReservasView reservas = new ReservasView();
            reservas.Show();
            this.Close();
        }

        /// <summary>
        /// Abre la vista de artistas.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_artistas_Click(object sender, RoutedEventArgs e)
        {
            ArtistasView artistas = new ArtistasView();
            artistas.Show();
            this.Close();
        }

        /// <summary>
        /// Abre la vista de géneros.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_generos_Click(object sender, RoutedEventArgs e)
        {
            GenerosView generos = new GenerosView();
            generos.Show();
            this.Close();
        }

        /// <summary>
        /// Abre la vista de vinilos.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_vinilos_Click(object sender, RoutedEventArgs e)
        {
            VinilosView vinilos = new VinilosView();
            vinilos.Show();
            this.Close();
        }

        /// <summary>
        /// Abre el formulario para crear un usuario.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_nuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            UsuariosForm usuariosForm = new UsuariosForm();
            usuariosForm.Show();
            this.Close();
        }
    }
}
