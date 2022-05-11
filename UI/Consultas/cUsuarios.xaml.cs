using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Tarea_3_CrearOtroRegistroEnWpf.BLL;
using Tarea_3_CrearOtroRegistroEnWpf.Entidades;

namespace Tarea_3_CrearOtroRegistroEnWpf.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cUsuarios.xaml
    /// </summary>
    public partial class cUsuarios : Window
    {
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Usuarios>();

            if (!string.IsNullOrWhiteSpace(CriterioTextBox.Text))
            {
                switch (FiltroComboBox.SelectedIndex)
                {

                    case 0: //todo
                        listado = UsuariosBLL.GetList(u => true);
                        break;

                    case 1: //Id
                        listado = UsuariosBLL.GetList(u => u.UsuarioId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 2: //Nombre                      
                        listado = UsuariosBLL.GetList(u => u.Nombres.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                MessageBox.Show("Debe Guardar Información En La Base De Datos.", "Consultando", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if(DesdeDatePicker.SelectedDate != null && HastaDatePicker.SelectedDate != null)
            listado = UsuariosBLL.GetList(u => u.FechaIngreso.Date > DesdeDatePicker.SelectedDate && u.FechaIngreso.Date < HastaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
