using Controller;
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
    /// Vista de gestión de géneros.
    /// </summary>
    public partial class GenerosView : Window
    {
        private GenerosController _controller;
        /// <summary>
        /// Inicializa la vista de géneros.
        /// </summary>
        public GenerosView()
        {
            InitializeComponent();
            _controller = new GenerosController();
            CargarGeneros();

        }
        /// <summary>
        /// Carga los géneros en el grid.
        /// </summary>
        private void CargarGeneros()
        {
            DataTable dt = _controller.ObtenerListadoGeneros();
            datagrid_generos.ItemsSource = dt.DefaultView;
        }

        /// <summary>
        /// Elimina el género seleccionado.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_eliminarGenero_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = datagrid_generos.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = (int)row["id_genero"];
                if (_controller.EliminarGenero(id))
                {
                    MessageBox.Show("Género eliminado correctamente.");
                    CargarGeneros();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el género.");
                }
            }
        }
        /// <summary>
        /// Abre el formulario para editar un género.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_editarGenero_Click(object sender, RoutedEventArgs e)
        {
            DataRowView row = datagrid_generos.SelectedItem as DataRowView;
            if (row != null)
            {
                int id = (int)row["id_genero"];
                string nombre = row["nombre_genero"].ToString();
                GenerosForm form = new GenerosForm(id, nombre);
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un género para editar.");
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
        /// Abre el formulario para crear un género.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void button_nuevoGenero_Click(object sender, RoutedEventArgs e)
        {
            GenerosForm generosForm = new GenerosForm();
            generosForm.Show();
            this.Close();
        }
    }
}
