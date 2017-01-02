
namespace Treasury7MD.Model
{
    public class AccountsPayable : Debt
    {
        public int AccountsPayableId { get; set; }
        public double DebtNotDue { get; set; }
    }
}
