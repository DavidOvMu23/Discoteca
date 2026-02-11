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
