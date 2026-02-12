using Controller;
using System.Data;
using System.Windows;


namespace View
{
    /// <summary>
    /// Vista de gestión de artistas.
    /// </summary>
    public partial class ArtistasView : Window
    {
        private ArtistasController _controller;
        /// <summary>
        /// Inicializa la vista de artistas.
        /// </summary>
        public ArtistasView()
        {
            InitializeComponent();
            _controller = new ArtistasController();
            CargarArtistas();
        }

        /// <summary>
        /// Carga los artistas en el grid.
        /// </summary>
        private void CargarArtistas()
        {
            DataTable dt = _controller.ObtenerListadoArtistas();
            datagrid_artistas.ItemsSource = dt.DefaultView;
        }

        /// <summary>
        /// Elimina el artista seleccionado.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_eliminarArtista_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = datagrid_artistas.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = (int)row["id_artista"];
                if (_controller.EliminarArtista(id))
                {
                    MessageBox.Show("Artista eliminado correctamente.");
                    CargarArtistas();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el artista.");
                }
            }
        }

        /// <summary>
        /// Abre el formulario para editar un artista.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_editarArtista_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = datagrid_artistas.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = (int)row["id_artista"];
                string nombre = row["nombre_artista"].ToString();
                string nacionalidad = row["nacionalidad"].ToString();
                ArtistasForm form = new ArtistasForm(id, nombre, nacionalidad);
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un artista para editar.");
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
        /// Abre la vista de usuarios.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_usuarios_Click(object sender, RoutedEventArgs e)
        {
            UsuariosView usuarios = new UsuariosView();
            usuarios.Show();
            this.Close();
        }

        /// <summary>
        /// Abre el formulario para crear un artista.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_nuevoArtista_Click(object sender, RoutedEventArgs e)
        {
            ArtistasForm artistasForm = new ArtistasForm();
            artistasForm.Show();
            this.Close();
        }
    }
}
