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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Treasury7MD.ViewModels;
using System.Windows.Interactivity;
using Microsoft.Expression.Interactivity;

namespace Treasury7MD.Views
{
    /// <summary>
    /// Interaction logic for Form7MDTableHeadeView.xaml
    /// </summary>
    public partial class Form7MDTableHeadeView : UserControl
    {
        public Form7MDTableHeadeView()
        {
            InitializeComponent();

            
            /*  using (var context = new DB.TreasuryDBEntities1())
              {
                  var query = from u in context.DepartmentalClassifications
                              join p in context.KEKVs on u.Code equals p.Id into gj
                              from p in gj.DefaultIfEmpty()
                              select new
                              {
                                  UsergroupID = u.Code,
                                  UsergroupName = u.Name,
                                  p.Name
                              };
                  dg.ItemsSource = query.ToList();
              }*/

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int c = ((Form7MDViewModel)DataContext).Form.KEKVs.Count;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ((Form7MDViewModel)DataContext).SaveForm();
        }
    }
}
