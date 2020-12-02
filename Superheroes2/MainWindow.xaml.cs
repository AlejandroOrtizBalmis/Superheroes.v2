using System.Collections.Generic;
using System.Windows;

namespace Superheroes2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Superheroe> superheroes = Superheroe.GetSamples();

        int cont = 0;
        public MainWindow()
        {
            InitializeComponent();
            mainGrid.DataContext = superheroes[0];
            contador.Text = cont + 1 + "/" + superheroes.Count;

        }

        private void LimpiarButton_Click(object sender, RoutedEventArgs e)
        {
            Resources.Remove("nuevo");
            Resources.Add("nuevo", new Superheroe { Heroe = true });
        }

        private void CrearButton_Click(object sender, RoutedEventArgs e)
        {
            Superheroe superheroe = (Resources["nuevo"] as Superheroe);
            superheroes.Add(superheroe);
            Resources.Remove("nuevo");
            Resources.Add("nuevo", new Superheroe { Heroe = true });
            MessageBox.Show("Heroe añadido con exito", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            actualizarVentana();

        }

        private void derechaImage_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            cont++;
            if (cont > superheroes.Count - 1)
            {
                cont = 0;
                actualizarVentana();
            }
            else actualizarVentana();
        }

        private void izquierdaImage_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            cont--;
            if (cont < 0)
            {
                cont = superheroes.Count - 1;
                actualizarVentana();
            }
            else actualizarVentana();
        }
        private void actualizarVentana()
        {
            mainGrid.DataContext = superheroes[cont];
            contador.Text = cont + 1 + "/" + superheroes.Count;
        }


    }
}
