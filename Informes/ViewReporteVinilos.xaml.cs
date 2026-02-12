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
    public partial class ViewReporteVinilos : Window
    {
        private VinilosModel _model;
        /// <summary>
        /// Inicializa la vista del reporte de vinilos.
        /// </summary>
        public ViewReporteVinilos()
        {
            InitializeComponent();
            CargarListadoVinilos();
            reportViewer.Owner = this;
        }

        /// <summary>
        /// Carga los datos y configura el reporte.
        /// </summary>
        private void CargarListadoVinilos()
        {
            try
            {
                // Traer los datos
                VinilosModel modelo = new VinilosModel();
                DataTable datosAzure = modelo.ListarVinilosInforme();

                // Crear el reporte
                ReporteVinilos reporte = new ReporteVinilos();

                // Llenarlo
                reporte.Database.Tables["dtVinilos"].SetDataSource(datosAzure);
                reportViewer.ViewerCore.ReportSource = reporte;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
