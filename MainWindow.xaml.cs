using System.Windows;
using Tarea_3_CrearOtroRegistroEnWpf.UI.Registros;
using Tarea_3_CrearOtroRegistroEnWpf.UI.Consultas;

namespace Tarea_3_CrearOtroRegistroEnWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistroUsuarioMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios rUsuarios = new rUsuarios();
            rUsuarios.Show();
        }

        private void ConsultaUsuarioMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cUsuarios cUsuarios = new cUsuarios();
            cUsuarios.Show();
        }
    }
}
