using Model;
using SAPBusinessObjects.WPF.Viewer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Informes
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ViewReporteVinilosArtista : Window
    {
        private VinilosModel _model;
        public ViewReporteVinilosArtista()
        {
            InitializeComponent();
            CargarListadoVinilosArtista();
            reportViewer.Owner = this;
        }

        private void CargarListadoVinilosArtista()
        {
            try
            {
                // 1. Reusamos el MISMO método de datos (ya trae Artista y Género)
                VinilosModel modelo = new VinilosModel();
                DataTable datos = modelo.ListarVinilosArtistaInforme();

                // 2. Instanciamos el NUEVO reporte
                ReporteVinilosArtista reporte = new ReporteVinilosArtista();

                // 3. Conectamos los datos a la tabla 'dtVinilos'
                reporte.Database.Tables["dtVinilos"].SetDataSource(datos);
                reportViewer.ViewerCore.ReportSource = reporte;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
