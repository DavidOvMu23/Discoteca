using System;
using System.Collections.Generic;
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

namespace View
{
    /// <summary>
    /// Lógica de interacción para reservas.xaml
    /// </summary>
    public partial class ReservasForm : Window
    {
        public ReservasForm()
        {
            InitializeComponent();
        }

        private void button_vinilos_Click(object sender, RoutedEventArgs e)
        {
            VinilosView vinilos = new VinilosView();
            vinilos.Show();
            this.Close();
        }

        private void button_artistas_Click(object sender, RoutedEventArgs e)
        {
            ArtistasView artistas = new ArtistasView();
            artistas.Show();
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

        private void button_eliminarReserva_Click(object sender, RoutedEventArgs e)
        {
            ReservasView reservas = new ReservasView();
            reservas.Show();
            this.Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
