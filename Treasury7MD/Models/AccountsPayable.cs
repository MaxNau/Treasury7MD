using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Treasury7MD.Models
{
    public class AccountsPayable : Debt
    {
        public int AccountsPayableId { get; set; }
        public double DebtNotDue { get; set; }
    }
}
