using Controller;
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
    public partial class ArtistasForm : Window
    {
        private ArtistasController _controller;
        private int? idArtista = null; //lo del ? es para que pueda ser null, porque al crear un nuevo artista no tenemos id


        /// <summary>
        /// Inicializa el formulario para crear un artista.
        /// </summary>
        public ArtistasForm()
        {
            InitializeComponent();
            _controller = new ArtistasController();
            idArtista = null;

            label_tituloPagina.Content = "Nuevo Artista";
        }

        /// <summary>
        /// Inicializa el formulario para editar un artista.
        /// </summary>
        /// <param name="id">Id del artista.</param>
        /// <param name="nombre">Nombre del artista.</param>
        /// <param name="nacionalidad">Nacionalidad del artista.</param>
        public ArtistasForm(int id, string nombre, string nacionalidad)
        {
            InitializeComponent();
            _controller = new ArtistasController();
            idArtista = id;
            textbox_nombre.Text = nombre;
            textbox_nacionalidad.Text = nacionalidad;

            label_tituloPagina.Content = "Editar Artista";
        }

        /// <summary>
        /// Guarda los cambios del artista.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_guardar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = textbox_nombre.Text;
            string nac = textbox_nacionalidad.Text;

            if (idArtista == null)
            {
                // Crear
                _controller.CrearArtista(nombre, nac);
                MessageBox.Show("Artista creado correctamente.");
                
                ArtistasView artistasView = new ArtistasView();
                artistasView.Show();
                this.Close();
            }
            else
            {
                // Editar
                _controller.EditarArtista(idArtista.Value, nombre, nac);
                MessageBox.Show("Artista actualizado correctamente.");

                ArtistasView artistasView = new ArtistasView();
                artistasView.Show();
                this.Close();
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
        /// Cancela y vuelve al listado de artistas.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_cancelar_Click(object sender, RoutedEventArgs e)
        {
            ArtistasView artistas = new ArtistasView();
            artistas.Show();
            this.Close();
        }
    }
}
