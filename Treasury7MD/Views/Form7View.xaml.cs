using System;
using System.Windows;
using System.Windows.Controls;
using Treasury7MD.ViewModels;

namespace Treasury7MD.Views
{
    /// <summary>
    /// Interaction logic for Form7View.xaml
    /// </summary>
    public partial class Form7View : UserControl
    {
        public Form7View()
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
            //((Form7MDViewModel)DataContext).SaveForm();
        }

        private void TextBlock_LayoutUpdated(object sender, EventArgs e)
        {
            double d = z.ActualWidth;
        }
    }
}
