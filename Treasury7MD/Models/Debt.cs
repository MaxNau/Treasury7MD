
namespace Treasury7MD.Models
{
    public abstract class Debt : PropertyChangedObserver
    {
        public delegate void KEKVStateHandler(int name, double value);
        public static event KEKVStateHandler Changed;

        private double atTheBeginingOfTheYear;
        private double atTheEndOfTheReportingPeriod;
        private double overdueAtTheEndOfTheReportingPeriod;
        private double writtenOffSinceTheBeginningOfTheYear;

        public double AtTheBeginingOfTheYear
        {
            get { return atTheBeginingOfTheYear; }
            set
            {
                atTheBeginingOfTheYear = value;
                OnPropertyChanged("AtTheBeginingOfTheYear");
                if (Changed != null)
                    Changed(1, atTheBeginingOfTheYear);
            }
        }
        public double AtTheEndOfTheReportingPeriod { get; set; }
        public double OverdueAtTheEndOfTheReportingPeriod { get; set; }
        public double WrittenOffSinceTheBeginningOfTheYear { get; set; }
    }
}
