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
    public partial class ReservasForm : Window
    {
        private AlquileresController _controller;
        private UsuariosController _usuariosController;
        private VinilosController _vinilosController;
        private int? idReserva = null;
        private DateTime _fechaSalida;

        /// <summary>
        /// Inicializa el formulario para crear un alquiler.
        /// </summary>
        public ReservasForm()
        {
            InitializeComponent();
            _controller = new AlquileresController();
            _usuariosController = new UsuariosController();
            _vinilosController = new VinilosController();

            checkbox_entregado.Visibility = Visibility.Collapsed;
            idReserva = null;

            label_tituloPagina.Content = "Nuevo alquiler";
            _fechaSalida = DateTime.Now;
            datepicker_fechaLanzamiento_Copiar.SelectedDate = DateTime.Now;

            CargarCombos();
        }

        /// <summary>
        /// Inicializa el formulario para editar un alquiler.
        /// </summary>
        /// <param name="id">Id del alquiler.</param>
        /// <param name="idUsuario">Id del usuario.</param>
        /// <param name="idVinilo">Id del vinilo.</param>
        /// <param name="fechaSalida">Fecha de salida.</param>
        /// <param name="fechaEntregaPrevista">Fecha prevista de entrega.</param>
        public ReservasForm(int id, int idUsuario, int idVinilo, DateTime fechaSalida, DateTime fechaEntregaPrevista)
        {
            InitializeComponent();
            _controller = new AlquileresController();
            _usuariosController = new UsuariosController();
            _vinilosController = new VinilosController();

            checkbox_entregado.Visibility = Visibility.Visible;
            idReserva = id;
            label_tituloPagina.Content = "Editar alquiler";

            _fechaSalida = fechaSalida;

            CargarCombos();

            combobox_usuario.SelectedValue = idUsuario;
            combobox_vinilo.SelectedValue = idVinilo;
            datepicker_fechaLanzamiento_Copiar.SelectedDate = fechaEntregaPrevista;

            datepicker_fechaLanzamiento_Copiar.IsEnabled = false;
        }

        /// <summary>
        /// Carga los combos de usuarios y vinilos.
        /// </summary>
        private void CargarCombos()
        {
            var dtUsuarios = _usuariosController.ObtenerListadoUsuarios();
            combobox_usuario.ItemsSource = dtUsuarios.DefaultView;
            combobox_usuario.DisplayMemberPath = "nombre"; // si no pongo esto no sale el nombre si no que muestra algo como System.Data.DataRowView
            combobox_usuario.SelectedValuePath = "id_usuario"; // si no pongo esto da error

            var dtVinilos = _vinilosController.ObtenerListadoVinilos();
            combobox_vinilo.ItemsSource = dtVinilos.DefaultView;
            combobox_vinilo.DisplayMemberPath = "titulo";
            combobox_vinilo.SelectedValuePath = "id_vinilo";
        }

        /// <summary>
        /// Guarda los cambios del alquiler.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_guardar_Click(object sender, RoutedEventArgs e)
        {
            if (combobox_usuario.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un usuario.");
                return;
            }

            if (combobox_vinilo.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un vinilo.");
                return;
            }

            if (!datepicker_fechaLanzamiento_Copiar.SelectedDate.HasValue)
            {
                MessageBox.Show("Seleccione la fecha de entrega prevista.");
                return;
            }

            int.TryParse(combobox_usuario.SelectedValue.ToString(), out int idUsuario);
            int.TryParse(combobox_vinilo.SelectedValue.ToString(), out int idVinilo);
            DateTime fechaEntregaPrevista = datepicker_fechaLanzamiento_Copiar.SelectedDate.Value;

            try
            {
                if (idReserva == null)
                {
                    _controller.CrearAlquiler(idUsuario, idVinilo, _fechaSalida, fechaEntregaPrevista);
                    MessageBox.Show("Alquiler creado correctamente.");
                }
                else
                {
                    DateTime? fechaDevolucionReal = checkbox_entregado.IsChecked == true ? DateTime.Now : (DateTime?)null;
                    _controller.EditarAlquiler(idReserva.Value, idUsuario, idVinilo, _fechaSalida, fechaEntregaPrevista, fechaDevolucionReal);
                    MessageBox.Show("Alquiler editado correctamente.");
                }

                ReservasView reservas = new ReservasView();
                reservas.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
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
        /// Cancela y vuelve a la vista de reservas.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_eliminarReserva_Click(object sender, RoutedEventArgs e)
        {
            ReservasView reservas = new ReservasView();
            reservas.Show();
            this.Close();
        }

        /// <summary>
        /// Maneja el cambio del checkbox de entrega.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
