using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Treasury7MD.ViewModels;

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
