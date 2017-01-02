using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Treasury7MD.Model;
using Treasury7MD.Utilities;
using Treasury7MD.ViewModels;

namespace Treasury7MD.Views
{
    /// <summary>
    /// Interaction logic for ProfilesOverviewView.xaml
    /// </summary>
    public partial class ProfilesOverviewView : Window
    {
        public ProfilesOverviewView()
        {
            InitializeComponent();
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                var a = item.Content as Form7MDOrganizationInfo;
                ((Form7MDViewModel)DataContext).Territory = a.Territory;
            }
            Messenger.Default.Send(item.Content as Form7MDOrganizationInfo);
        }
    }
}
