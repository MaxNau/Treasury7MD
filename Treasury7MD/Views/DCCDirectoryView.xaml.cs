using System.Windows;

namespace Treasury7MD.Views
{
    /// <summary>
    /// Interaction logic for DCCDirectoryView.xaml
    /// </summary>
    public partial class DCCDirectoryView : Window
    {
        public DCCDirectoryView()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var item = comboBox.SelectedItem;
            //(DataContext as TreasuryViewModel).AddDCC((DB.DepartmentalClassification)item, FundіReciverCodeTb.Text);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //if (listView.SelectedItem != null)
               // (DataContext as TreasuryViewModel).RemoveDCC((DB.UserDepartmentalClassification)listView.SelectedItem);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           // (DataContext as TreasuryViewModel).UpdateDCC((DB.UserDepartmentalClassification)listView.SelectedItem, EditFundsReciverCodeTb.Text);
            popUp.IsOpen = false;
        }

        private void MenuItem2_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
                popUp.IsOpen = true;
        }
    }
}
