using System.Windows.Controls;
using System.Linq;
using Treasury7MD.ViewModels;

namespace Treasury7MD.Views
{
    /// <summary>
    /// Interaction logic for SessionMenu.xaml
    /// </summary>
    public partial class SessionMenu : UserControl
    {
        public SessionMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ProfilesOverviewView pow = new ProfilesOverviewView();
            pow.ShowDialog();
            var r = pow.DataContext as ProfileOverviewViewModel;
            ((Form7MDViewModel)DataContext).Territory = r.List[0].Territory;
        }
    }
}
