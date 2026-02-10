using Controller;
using System.Data;
using System.Windows;


namespace View
{
    public partial class ArtistasView : Window
    {
        private ArtistasController _controller;
        public ArtistasView()
        {
            InitializeComponent();
            _controller = new ArtistasController();
            CargarArtistas();
        }

        private void CargarArtistas()
        {
            DataTable dt = _controller.ObtenerListadoArtistas();
            datagrid_artistas.ItemsSource = dt.DefaultView;
        }

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

        private void button_reservas_Click(object sender, RoutedEventArgs e)
        {
            ReservasView reservas = new ReservasView();
            reservas.Show();
            this.Close();
        }

        private void button_vinilos_Click(object sender, RoutedEventArgs e)
        {
            VinilosView vinilos = new VinilosView();
            vinilos.Show();
            this.Close();
        }

        private void button_generos_Click(object sender, RoutedEventArgs e)
        {
            GenerosView generos = new GenerosView();
            generos.Show();
            this.Close();
        }

        private void button_usuarios_Click(object sender, RoutedEventArgs e)
        {
            UsuariosView usuarios = new UsuariosView();
            usuarios.Show();
            this.Close();
        }

        private void button_nuevoArtista_Click(object sender, RoutedEventArgs e)
        {
            ArtistasForm artistasForm = new ArtistasForm();
            artistasForm.Show();
            this.Close();
        }

        private void datagrid_artistas_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
