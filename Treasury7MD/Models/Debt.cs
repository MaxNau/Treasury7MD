
namespace Treasury7MD.Models
{
    public abstract class Debt : PropertyChangedObserver
    {
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
            }
        }
        public double AtTheEndOfTheReportingPeriod { get; set; }
        public double OverdueAtTheEndOfTheReportingPeriod { get; set; }
        public double WrittenOffSinceTheBeginningOfTheYear { get; set; }
    }
}
