using System;
using System.Windows;
using System.Windows.Input;
using Treasury7MD.Commands;
using Treasury7MD.DAL;
using Treasury7MD.Model;

namespace Treasury7MD.ViewModels
{
    public class CreateOrganizationProfileViewModel
    {
        public Form7MDOrganizationInfo OrganizationInfo { get; set; }
        ITreasuryRepository repository = new TreasuryRepository();
        public ICommand SaveOrgInfoCommand { get; set; }

        public CreateOrganizationProfileViewModel()
        {
            OrganizationInfo = new Form7MDOrganizationInfo();
            SaveOrgInfoCommand = new RelayCommand(SaveOrgInfo);
        }

        private void SaveOrgInfo(object obj)
        {
            repository.SaveOrgInfo(OrganizationInfo);
        }

        public double OrganizationInfoViewWidth
        {
            get { return SystemParameters.PrimaryScreenWidth * 0.8 + 40; }
        }

        public Form7MDOrganizationInfo OrgInfo
        {
            get { return OrganizationInfo; }
        }
    }
}
