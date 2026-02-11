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
using Controller;

namespace View
{
    /// <summary>
    /// Lógica de interacción para reservas.xaml
    /// </summary>
    public partial class UsuariosForm : Window
    {
        private UsuariosController _controller;
        private int? idUsuario = null; //lo del ? es para que pueda ser null, porque al crear un nuevo usuario no tenemos id

        public UsuariosForm()
        {
            InitializeComponent();
            _controller = new UsuariosController();
            idUsuario = null;

            label_tituloPagina.Content = "Nuevo Usuario";
        }

        public UsuariosForm(int id, string nombre, string email, string telefono)
        {
            InitializeComponent();
            _controller = new UsuariosController();
            idUsuario = id;
            textbox_nombre.Text = nombre;
            textbox_email.Text = email;
            textbox_telefono.Text = telefono;

            label_tituloPagina.Content = "Editar Usuario";
        }

        private void button_guardar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = textbox_nombre.Text;
            string email = textbox_email.Text;
            string telefono = textbox_telefono.Text;

            if (idUsuario == null)
            {
                // Crear
                _controller.CrearUsuario(nombre, email, telefono);
                MessageBox.Show("Usuario creado correctamente.");
                
                UsuariosView usuariosView = new UsuariosView();
                usuariosView.Show();
                this.Close();
            }
            else
            {
                // Editar
                _controller.EditarUsuario(idUsuario.Value, nombre, email, telefono);
                MessageBox.Show("Usuario editado correctamente.");
                
                UsuariosView usuariosView = new UsuariosView();
                usuariosView.Show();
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

        private void button_vinilos_Click(object sender, RoutedEventArgs e)
        {
            VinilosView vinilos = new VinilosView();
            vinilos.Show();
            this.Close();
        }

        private void button_cancelar_Click(object sender, RoutedEventArgs e)
        {
            UsuariosView usuarios = new UsuariosView();
            usuarios.Show();
            this.Close();
        }
    }
}
