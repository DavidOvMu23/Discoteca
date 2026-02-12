using Controller;
using Informes;
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

namespace View
{
    /// <summary>
    /// Lógica de interacción para reservas.xaml
    /// </summary>
    public partial class ReservasUsuariosInforme : Window
    {
        private UsuariosController _usuariosController;
        private AlquileresController _alquileresController;

        /// <summary>
        /// Inicializa la vista de informe de reservas por usuario.
        /// </summary>
        public ReservasUsuariosInforme()
        {
            InitializeComponent();
            _usuariosController = new UsuariosController();
            _alquileresController = new AlquileresController();
            CargarUsuarios();
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
        /// Cancela y vuelve a la vista de reservas.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_cancelar_Click(object sender, RoutedEventArgs e)
        {
            ReservasView reservas = new ReservasView(); 
            reservas.Show(); 
            this.Close();
        }

        /// <summary>
        /// Genera el informe para el usuario seleccionado.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_guardar_Click(object sender, RoutedEventArgs e)
        {
            // 1. Validar que haya un usuario seleccionado
            if (combobox_usuario.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona un usuario primero.");
                return;
            }

            try
            {
                //Cogemos la id del combobox
                int idUsuario = (int)combobox_usuario.SelectedValue;

                //Llamamos al controlador para obtener los alquileres de ese usuario
                DataTable datosFiltrados = _alquileresController.ObtenerAlquileresPorUsuario(idUsuario);

                // verificar si hay datos
                if (datosFiltrados.Rows.Count == 0)
                {
                    MessageBox.Show("Este usuario no tiene reservas.");
                    return;
                }

                // mostramos el informe con los datos filtrados
                Informes.ViewReporteReservaUsuario ventanaReporte = new Informes.ViewReporteReservaUsuario();
                ventanaReporte.ShowReport(datosFiltrados);
                ventanaReporte.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        /// <summary>
        /// Carga los usuarios en el combo.
        /// </summary>
        private void CargarUsuarios()
        {
            try
            {
                var dtUsuarios = _usuariosController.ObtenerListadoUsuarios();
                combobox_usuario.ItemsSource = dtUsuarios.DefaultView;
                combobox_usuario.DisplayMemberPath = "nombre";
                combobox_usuario.SelectedValuePath = "id_usuario";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando usuarios: " + ex.Message);
            }
        }
    }
}
