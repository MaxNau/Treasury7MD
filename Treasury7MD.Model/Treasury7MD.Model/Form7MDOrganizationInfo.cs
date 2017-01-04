
namespace Treasury7MD.Model
{
    public class Form7MDOrganizationInfo : PropertyChangedObserver
    {
        public int Id { get; set; }
        private string organizationName;
        private string territory;
        private string _EDRPOU;
        private string _KOATUU;
        private string _OPFG;
        private string _KOPFG;
        private string _VKVKDBCode;
        private string _VKVKDBName;
        private string _PKVKDBCode;
        private string _PKVKDBName;
        private string _TVKVKMBCode;
        private string _TVKVKMBName;
        private string _PKVKMBCode;
        private string _PKVKMBName;
        private string _OPFGName;

        public string Territory
        {
            get { return territory; }
            set
            {
                territory = value;
                OnPropertyChanged("Territory");
            }
        }

        public string OrganizationName
        {
            get { return organizationName; }
            set
            {
                organizationName = value;
                OnPropertyChanged("OrganizationName");
            }
        }

        public string EDRPOU
        {
            get { return _EDRPOU; }
            set
            {
                _EDRPOU = value;
                OnPropertyChanged("EDRPOU");
            }
        }

        public string KOATUU
        {
            get { return _KOATUU; }
            set
            {
                _KOATUU = value;
                OnPropertyChanged("KOATUU");
            }
        }

        public string OPFG
        {
            get { return _OPFG; }
            set
            {
                _OPFG = value;
                OnPropertyChanged("OPFG");
            }
        }

        public string KOPFG
        {
            get { return _KOPFG; }
            set
            {
                _KOPFG = value;
                OnPropertyChanged("KOPFG");
            }
        }

        public string VKVKDBCode
        {
            get { return _VKVKDBCode; }
            set
            {
                _VKVKDBCode = value;
                OnPropertyChanged("VKVKDBCode");
            }
        }

        public string VKVKDBName
        {
            get { return _VKVKDBName; }
            set
            {
                _VKVKDBName = value;
                OnPropertyChanged("VKVKDBName");
            }
        }

        public string PKVKDBCode
        {
            get { return _PKVKDBCode; }
            set
            {
                _PKVKDBCode = value;
                OnPropertyChanged("PKVKDBCode");
            }
        }

        public string PKVKDBName
        {
            get { return _PKVKDBName; }
            set
            {
                _PKVKDBName = value;
                OnPropertyChanged("PKVKDBName");
            }
        }

        public string TVKVKMBCode
        {
            get { return _TVKVKMBCode; }
            set
            {
                _TVKVKMBCode = value;
                OnPropertyChanged("TVKVKMBCode");
            }
        }

        public string TVKVKMBName
        {
            get { return _TVKVKMBName; }
            set
            {
                _TVKVKMBName = value;
                OnPropertyChanged("TVKVKMBName");
            }
        }

        public string PKVKMBCode
        {
            get { return _PKVKDBName; }
            set
            {
                _PKVKDBName = value;
                OnPropertyChanged("PKVKMBCode");
            }
        }

        public string PKVKMBName
        {
            get { return _PKVKMBName; }
            set
            {
                _PKVKMBName = value;
                OnPropertyChanged("PKVKMBName");
            }
        }
    }
}
