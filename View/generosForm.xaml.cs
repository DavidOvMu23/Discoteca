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
    public partial class GenerosForm : Window
    {
        private GenerosController _controller;
        private int? idGenero = null; //lo del ? es para que pueda ser null, porque al crear un nuevo género no tenemos id
        
        /// <summary>
        /// Inicializa el formulario para crear un género.
        /// </summary>
        public GenerosForm()
        {
            InitializeComponent();
            _controller = new GenerosController();
            idGenero = null;

            label_tituloPagina.Content = "Nuevo Género";
        }

        /// <summary>
        /// Inicializa el formulario para editar un género.
        /// </summary>
        /// <param name="id">Id del género.</param>
        /// <param name="nombre">Nombre del género.</param>
        public GenerosForm(int id, string nombre)
        {
            InitializeComponent();
            _controller = new GenerosController();
            idGenero = id;
            textbox_nombre.Text = nombre;

            label_tituloPagina.Content = "Editar Género";
        }

        /// <summary>
        /// Guarda los cambios del género.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_guardar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = textbox_nombre.Text;

            if(idGenero == null)
            {
                // Crear
                _controller.CrearGenero(nombre);
                MessageBox.Show("Género creado correctamente.");
                
                GenerosView generosView = new GenerosView();
                generosView.Show();
                this.Close();
            }
            else
            {
                // Editar
                _controller.EditarGenero(idGenero.Value, nombre);
                MessageBox.Show("Género editado correctamente.");
                
                GenerosView generosView = new GenerosView();
                generosView.Show();
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
        /// Cancela y vuelve al listado de géneros.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_cancelar_Click(object sender, RoutedEventArgs e)
        {
            GenerosView generos = new GenerosView();
            generos.Show();
            this.Close();
        }
    }
}
