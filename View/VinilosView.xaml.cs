using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
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
    public partial class VinilosView : Window
    {
        private VinilosController _controller;
        public VinilosView()
        {
            InitializeComponent();
            _controller = new VinilosController();
            CargarVinilos();
        }

        private void CargarVinilos()
        {
            DataTable dt = _controller.ObtenerListadoVinilos();
            datagrid_vinilo.ItemsSource = dt.DefaultView;
        }

        private void button_eliminarVinilo_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = datagrid_vinilo.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = (int)row["id_vinilo"];
                if (_controller.EliminarVinilo(id))
                {
                    MessageBox.Show("Vinilo eliminado correctamente.");
                    CargarVinilos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el vinilo.");
                }
            }
        }

        private void button_editarVinilo_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = datagrid_vinilo.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = (int)row["id_vinilo"];
                string titulo = row["titulo"].ToString();
                int anio = (int)row["anio_lanzamiento"];
                string estado = row["estado"].ToString();
                int idArtista = (int)row["id_artista"];
                int idGenero = (int)row["id_genero"];
                VinilosForm vinilosForm = new VinilosForm(id, titulo, anio, estado, idArtista, idGenero);
                vinilosForm.Show();
                this.Close();
            }
        }
        private void button_reservas_Click(object sender, RoutedEventArgs e)
        {
            ReservasView reservas = new ReservasView();
            reservas.Show();
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

        private void button_nuevoVinilo_Click(object sender, RoutedEventArgs e)
        {
            VinilosForm vinilosForm = new VinilosForm();
            vinilosForm.Show();
            this.Close();
        }
    }
}
