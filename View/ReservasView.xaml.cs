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
    public partial class ReservasView : Window
    {
        private AlquileresController _controller;
        /// <summary>
        /// Inicializa la vista de reservas.
        /// </summary>
        public ReservasView()
        {
            InitializeComponent();
            _controller = new AlquileresController();
            CargarReservas();
        }

        /// <summary>
        /// Elimina la reserva seleccionada.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_eliminarReserva_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = datagrid_reservas.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = (int)row["id_alquiler"];
                if (_controller.EliminarALquiler(id))
                {
                    MessageBox.Show("Reserva eliminada correctamente");
                    CargarReservas();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la reserva");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una reserva para eliminar.");
            }
        }

        /// <summary>
        /// Abre el formulario para editar una reserva.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_editarReserva_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = datagrid_reservas.SelectedItem as DataRowView;
            if (row != null)
            {
                if (row["fecha_devolucion_real"] != DBNull.Value) // esto me lo ha hecho el chat por que no sabía como hacerlo
                {
                    MessageBox.Show("Esta reserva ya fue entregada y no se puede editar.");
                    return;
                }

                int id = (int)row["id_alquiler"];
                int idUsuario = (int)row["id_usuario"];
                int idVinilo = (int)row["id_vinilo"];
                DateTime fechaSalida = (DateTime)row["fecha_salida"];
                DateTime fechaEntregaPrevista = (DateTime)row["fecha_entrega_prevista"];

                ReservasForm reservasForm = new ReservasForm(id, idUsuario, idVinilo, fechaSalida, fechaEntregaPrevista);
                reservasForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una reserva para editar.");
            }
        }

        /// <summary>
        /// Carga las reservas en el grid.
        /// </summary>
        private void CargarReservas()
        {
            DataTable dt = _controller.ObtenerListado();
            datagrid_reservas.ItemsSource = dt.DefaultView;
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
        /// Abre el formulario para crear una reserva.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_nuevaReserva_Click(object sender, RoutedEventArgs e)
        {
            ReservasForm reservasForm = new ReservasForm();
            reservasForm.Show();
            this.Close();
        }

        /// <summary>
        /// Abre la vista para generar el informe por usuario.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_generarInforme_Click(object sender, RoutedEventArgs e)
        {
            ReservasUsuariosInforme reservasUsuariosInforme = new ReservasUsuariosInforme(); 
            reservasUsuariosInforme.Show();
            this.Close();
        }
    }
}
