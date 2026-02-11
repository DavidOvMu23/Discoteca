using System;
using System.Collections.Generic;
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
    public partial class VinilosForm : Window
    {

        private VinilosController _controller;
        private ArtistasController _artistasController;
        private GenerosController _generosController;
        private int? idVinilo = null; //lo del ? es para que pueda ser null, porque al crear un nuevo vinilo no tenemos id

        public VinilosForm()
        {
            InitializeComponent();
            _controller = new VinilosController();
            _artistasController = new ArtistasController();
            _generosController = new GenerosController();
            idVinilo = null;

            label_tituloPagina.Content = "Nuevo Vinilo";
            CargarCombos();
        }

        public VinilosForm(int id, string titulo, int anio, string estado, int idArtista, int idGenero)
        {
            InitializeComponent();
            _controller = new VinilosController();
            _artistasController = new ArtistasController();
            _generosController = new GenerosController();

            idVinilo = id;
            textbox_titulo.Text = titulo;
            datepicker_fechaLanzamiento.SelectedDate = new DateTime(anio, 1, 1);
            textbox_estado.Text = estado;

            CargarCombos();
            combobox_artista.SelectedValue = idArtista;
            combobox_genero.SelectedValue = idGenero;

            label_tituloPagina.Content = "Editar Vinilo";
        }

        private void CargarCombos()
        {
            var dtArtistas = _artistasController.ObtenerListadoArtistas();
            combobox_artista.ItemsSource = dtArtistas.DefaultView;
            combobox_artista.DisplayMemberPath = "nombre_artista";
            combobox_artista.SelectedValuePath = "id_artista";

            var dtGeneros = _generosController.ObtenerListadoGeneros();
            combobox_genero.ItemsSource = dtGeneros.DefaultView;
            combobox_genero.DisplayMemberPath = "nombre_genero";
            combobox_genero.SelectedValuePath = "id_genero";
        }

        private void button_guardar_Click(object sender, RoutedEventArgs e)
        {
            string titulo = textbox_titulo.Text;
            string estado = textbox_estado.Text;

            if (string.IsNullOrWhiteSpace(titulo))
            {
                throw new Exception("El título es obligatorio.");
            }

            if (!datepicker_fechaLanzamiento.SelectedDate.HasValue)
            {
                throw new Exception("Seleccione la fecha de lanzamiento.");
            }

            int anio = datepicker_fechaLanzamiento.SelectedDate.Value.Year;

            if (combobox_artista.SelectedValue == null)
            {
                throw new Exception("Seleccione un artista.");
            }

            if (combobox_genero.SelectedValue == null)
            {
                throw new Exception("Seleccione un género.");
            }

            int.TryParse(combobox_artista.SelectedValue.ToString(), out int idArtista);
            int.TryParse(combobox_genero.SelectedValue.ToString(), out int idGenero);

            if (idVinilo == null)
            {
                _controller.CrearVinilo(titulo, anio, estado, idArtista, idGenero);
                MessageBox.Show("Vinilo creado correctamente.");
            }
            else
            {
                _controller.EditarVinilo(idVinilo.Value, titulo, anio, estado, idArtista, idGenero);
                MessageBox.Show("Vinilo editado correctamente.");
            }

            VinilosView vinilos = new VinilosView();
            vinilos.Show();
            this.Close();
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

        private void button_cancelar_Click(object sender, RoutedEventArgs e)
        {
            VinilosView vinilos = new VinilosView();
            vinilos.Show();
            this.Close();
        }
    }
}
