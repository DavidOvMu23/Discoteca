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
    /// Vista del reporte de reservas por usuario.
    /// </summary>
    public partial class ViewReporteReservaUsuario : Window
    {
        private VinilosModel _model;
        /// <summary>
        /// Inicializa la vista del reporte de reservas por usuario.
        /// </summary>
        public ViewReporteReservaUsuario()
        {
            InitializeComponent();
            reportViewer.Owner = this;
        }

        /// <summary>
        /// Muestra el reporte con los datos indicados.
        /// </summary>
        /// <param name="datos">Datos de reservas a mostrar.</param>
        public void ShowReport(System.Data.DataTable datos)
        {
            try
            {
                // Instanciamos el reporte de reservas por usuario
                ReporteReservasUsuario reporte = new ReporteReservasUsuario();

                // Conectamos los datos al reporte
                reporte.SetDataSource(datos);

                // Asignamos al viewer
                reportViewer.ViewerCore.ReportSource = reporte;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
