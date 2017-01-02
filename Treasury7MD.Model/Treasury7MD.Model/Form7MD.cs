using System.Collections.ObjectModel;


namespace Treasury7MD.Model
{
    public class Form7MD
    {
        public int Form7MDId { get; set; }
        public string ReportMonth { get; set; }
        public string ReportYear { get; set; }
        public virtual Form7MDOrganizationInfo OrganizationInfo { get; set; }
        public virtual ObservableCollection<KEKV> KEKVs { get; set; }

        public Form7MD()
        {
            KEKVs = new ObservableCollection<KEKV>();
            OrganizationInfo = new Form7MDOrganizationInfo();
        }
    }
}
