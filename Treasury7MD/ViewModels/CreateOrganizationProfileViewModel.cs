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

        public Form7MDOrganizationInfo OrgInfo
        {
            get { return orgInfo; }
        }
    }
}
