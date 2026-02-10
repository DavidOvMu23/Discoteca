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
    public partial class usuariosForm : Window
    {
        public usuariosForm()
        {
            InitializeComponent();
        }

        private void button_reservas_Click(object sender, RoutedEventArgs e)
        {
            reservas reservas = new reservas();
            reservas.Show();
            this.Close();
        }

        private void button_artistas_Click(object sender, RoutedEventArgs e)
        {
            artistas artistas = new artistas();
            artistas.Show();
            this.Close();
        }

        private void button_generos_Click(object sender, RoutedEventArgs e)
        {
            generos generos = new generos();
            generos.Show();
            this.Close();
        }

        private void button_vinilos_Click(object sender, RoutedEventArgs e)
        {
            Vinilos vinilos = new Vinilos();
            vinilos.Show();
            this.Close();
        }

        private void button_cancelar_Click(object sender, RoutedEventArgs e)
        {
            usuarios usuarios = new usuarios();
            usuarios.Show();
            this.Close();
        }
    }
}
