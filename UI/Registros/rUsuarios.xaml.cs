using System;
using System.Windows;
using Tarea_3_CrearOtroRegistroEnWpf.BLL;
using Tarea_3_CrearOtroRegistroEnWpf.Entidades;

namespace Tarea_3_CrearOtroRegistroEnWpf.UI.Registros
{
    /// <summary>
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        private Usuarios Usuario = new Usuarios();

        public rUsuarios()
        {
            InitializeComponent();

            //Indicar la fuente de datos para el BINDING
            this.DataContext = Usuario;

            //Cargar los roles al ComboBox
            RolesComboBox.ItemsSource = RolesBLL.GetRoles();
            RolesComboBox.SelectedValuePath = "RollId";
            RolesComboBox.DisplayMemberPath = "Descripcion";
        }

        private void Limpiar()
        {
            this.Usuario = new Usuarios();
            this.DataContext = Usuario;
        }

        private bool Validar()
        {
            bool esValido = true;

            string MensajeValidacion = "Validación";

            if (string.IsNullOrWhiteSpace(AliasTextBox.Text))
            {
                MessageBox.Show("El Campo Alias No Puede Estar Vacío.", MensajeValidacion, MessageBoxButton.OK, MessageBoxImage.Warning);
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(NombresTextBox.Text))
            {
                MessageBox.Show("El Campo Nombre No Puede Estar Vacío.", MensajeValidacion, MessageBoxButton.OK, MessageBoxImage.Warning);
                esValido = false;
            }

            if (ClavePasswordBox.Password.Length == 0)
            {
                MessageBox.Show("El Campo Clave No Puede Estar Vacío.", MensajeValidacion, MessageBoxButton.OK, MessageBoxImage.Warning);
                esValido = false;
            }

            if (ConfirmarClavePasswordBox.Password.Length == 0)
            {
                MessageBox.Show("El Campo Confirmar No Puede Estar Clave Vacío.", MensajeValidacion, MessageBoxButton.OK, MessageBoxImage.Warning);
                esValido = false;
            }

            if (ClavePasswordBox.Password != ConfirmarClavePasswordBox.Password)
            {
                MessageBox.Show("Las Contraseñas No Coinciden.", MensajeValidacion, MessageBoxButton.OK, MessageBoxImage.Warning);
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("El Campo Email No Puede Estar Vacío.", MensajeValidacion, MessageBoxButton.OK, MessageBoxImage.Warning);
                esValido = false;
            }
            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var buscado = UsuariosBLL.Buscar(Utilidades.ToInt(UsuarioIdTextBox.Text));

            if (buscado != null)
            {
                this.Usuario = buscado;
                MessageBox.Show("Campos Encontrado");
            }
            else
            {
                this.Usuario = new Usuarios();
                MessageBox.Show("Campos No Encontrado");
            }
            this.DataContext = this.Usuario;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            FechaIngresoDataPicker.SelectedDate = DateTime.Now;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            bool Guardo = UsuariosBLL.Guardar(Usuario);

            if (Guardo)
            {
                Limpiar();
                MessageBox.Show("Transacción Exitosa!", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transacción Fallida!", "Fallo.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(Utilidades.ToInt(UsuarioIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Regitro Eliminado!", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Eliminación Fallida!", "Fallo.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
