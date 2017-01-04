using System.Windows;
using Treasury7MD.Model;

namespace Treasury7MD.ViewModels
{
    public class CreateOrganizationProfileViewModel : PropertyChangedObserver
    {
        Form7MDOrganizationInfo orgInfo;

        public CreateOrganizationProfileViewModel()
        {
            orgInfo = new Form7MDOrganizationInfo();
        }

        public string Territory
        {
            get { return orgInfo.Territory; }
            set {
                orgInfo.Territory = value;
                OnPropertyChanged("Territory");
            }
        }

        public double OrganizationInfoViewWidth
        {
            get { return SystemParameters.PrimaryScreenWidth * 0.8 + 40; }
        }

        public Form7MDOrganizationInfo OrgInfo
        {
            get { return orgInfo; }
        }
    }
}
