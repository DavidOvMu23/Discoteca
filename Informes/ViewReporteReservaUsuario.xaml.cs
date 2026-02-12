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

    public partial class ViewReporteReservaUsuario : Window
    {
        private VinilosModel _model;
        public ViewReporteReservaUsuario()
        {
            InitializeComponent();
            reportViewer.Owner = this;
        }

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
