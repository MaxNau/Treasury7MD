
namespace Treasury7MD.Models
{
    public abstract class Debt : PropertyChangedObserver
    {
        public delegate void KEKVStateHandler();
        public static event KEKVStateHandler Changed;
        public static event KEKVStateHandler Changed9;

        private double atTheBeginingOfTheYear; // деб/кред заборг. на початок року
        private double atTheEndOfTheReportingPeriod; // деб/кред заборг на кінецеь звітного періоду
        private double overdueAtTheEndOfTheReportingPeriod; // прострочена заборгованість на кінець звітного періоду
        private double writtenOffSinceTheBeginningOfTheYear; // списана заборгованість з початку року

        public double AtTheBeginingOfTheYear
        {
            get { return atTheBeginingOfTheYear; }
            set
            {
                atTheBeginingOfTheYear = value;
                OnPropertyChanged("AtTheBeginingOfTheYear");
                if (Changed != null)
                    Changed();
            }
        }
        public double AtTheEndOfTheReportingPeriod
        {
            get { return atTheEndOfTheReportingPeriod; }
            set
            {
                atTheEndOfTheReportingPeriod = value;
                OnPropertyChanged("AtTheEndOfTheReportingPeriod");
                    if(Changed9 != null)
                        Changed9();
            }
        }
        public double OverdueAtTheEndOfTheReportingPeriod { get; set; }
        public double WrittenOffSinceTheBeginningOfTheYear { get; set; }
    }
}
