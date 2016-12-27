
using System.Windows;
using Treasury7MD.Views;



namespace Treasury7MD
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DCCDirectoryView _DCCDirectoryView = new DCCDirectoryView();
            _DCCDirectoryView.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           /* if (g.RowDefinitions[1].Height.Value != 0)
            {
                g.RowDefinitions[1].Height = new GridLength(0);
                z.Height = 0;
            }
            else
            {
                g.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
                z.Height = 350;
            }
            var t = this;*/
        }
    }
}
