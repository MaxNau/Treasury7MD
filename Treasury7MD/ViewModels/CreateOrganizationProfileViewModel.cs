using System;
using System.Windows;
using System.Windows.Input;
using Treasury7MD.Commands;
using Treasury7MD.DAL;
using Treasury7MD.Model;

namespace Treasury7MD.ViewModels
{
    public class CreateOrganizationProfileViewModel : PropertyChangedObserver
    {
        Form7MDOrganizationInfo orgInfo;
        ITreasuryRepository repository = new TreasuryRepository();
        public ICommand SaveOrgInfoCommand { get; set; }

        public CreateOrganizationProfileViewModel()
        {
            orgInfo = new Form7MDOrganizationInfo();
            SaveOrgInfoCommand = new RelayCommand(SaveOrgInfo);
        }

        private void SaveOrgInfo(object obj)
        {
            repository.SaveOrgInfo(orgInfo);
        }

        public string Territory
        {
            get { return orgInfo.Territory; }
            set {
                orgInfo.Territory = value;
                OnPropertyChanged("Territory");
            }
        }

        public string OrganizationName
        {
            get { return orgInfo.OrganizationName; }
            set
            {
                orgInfo.OrganizationName = value;
                OnPropertyChanged("OrganizationName");
            }
        }

        public string EDRPOU
        {
            get { return orgInfo.EDRPOU; }
            set
            {
                orgInfo.EDRPOU = value;
                OnPropertyChanged("EDRPOU");
            }
        }

        public string KOATUU
        {
            get { return orgInfo.KOATUU; }
            set
            {
                orgInfo.KOATUU = value;
                OnPropertyChanged("KOATUU");
            }
        }

        public string OPFG
        {
            get { return orgInfo.OPFG; }
            set
            {
                orgInfo.OPFG = value;
                OnPropertyChanged("OPFG");
            }
        }

        public string KOPFG
        {
            get { return orgInfo.KOPFG; }
            set
            {
                orgInfo.KOPFG = value;
                OnPropertyChanged("KOPFG");
            }
        }

        public string VKVKDBCode
        {
            get { return orgInfo.VKVKDBCode; }
            set
            {
                orgInfo.VKVKDBCode = value;
                OnPropertyChanged("VKVKDBCode");
            }
        }

        public string VKVKDBName
        {
            get { return orgInfo.VKVKDBName; }
            set
            {
                orgInfo.VKVKDBName = value;
                OnPropertyChanged("VKVKDBName");
            }
        }

        public string PKVKDBCode
        {
            get { return orgInfo.PKVKDBCode; }
            set
            {
                orgInfo.PKVKDBCode = value;
                OnPropertyChanged("PKVKDBCode");
            }
        }

        public string PKVKDBName
        {
            get { return orgInfo.PKVKDBName; }
            set
            {
                orgInfo.PKVKDBName = value;
                OnPropertyChanged("PKVKDBName");
            }
        }

        public string TVKVKMBCode
        {
            get { return orgInfo.TVKVKMBCode; }
            set
            {
                orgInfo.TVKVKMBCode = value;
                OnPropertyChanged("TVKVKMBCode");
            }
        }

        public string TVKVKMBName
        {
            get { return orgInfo.TVKVKMBName; }
            set
            {
                orgInfo.TVKVKMBName = value;
                OnPropertyChanged("TVKVKMBName");
            }
        }

        public string PKVKMBCode
        {
            get { return orgInfo.PKVKDBName; }
            set
            {
                orgInfo.PKVKDBName = value;
                OnPropertyChanged("PKVKMBCode");
            }
        }

        public string PKVKMBName
        {
            get { return orgInfo.PKVKMBName; }
            set
            {
                orgInfo.PKVKMBName = value;
                OnPropertyChanged("PKVKMBName");
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
