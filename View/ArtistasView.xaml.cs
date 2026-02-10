using System.Windows;


namespace View
{
    public partial class ArtistasView : Window
    {
        public ArtistasView()
        {
            InitializeComponent();
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
    }
}
