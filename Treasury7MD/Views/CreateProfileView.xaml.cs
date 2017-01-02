using System;
using System.Windows;
using Treasury7MD.DAL;
using Treasury7MD.ViewModels;

namespace Treasury7MD.Views
{
    /// <summary>
    /// Interaction logic for CreateProfileView.xaml
    /// </summary>
    public partial class CreateProfileView : Window
    {
        public CreateProfileView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new TreasuryEntity())
                {
                    context.Profiles.Add(((CreateOrganizationProfileViewModel)DataContext).OrgInfo);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
