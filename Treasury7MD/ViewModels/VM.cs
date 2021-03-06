﻿using System;
using Treasury7MD.Model;

namespace Treasury7MD.ViewModels
{
    public class VM : PropertyChangedObserver
    {
        private string indicator;
        private string rowCode;

        public string Indicator
        {
            get { return indicator; }
            set
            {
                indicator = value;
                OnPropertyChanged("Indicator");
            }
        }

        public string RowCode { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<double> RegisteredBudgetaryAccountsPayableAtTheEndOfTheReportingPeriod { get; set; }
        public int FormId { get; set; }

        public virtual AccountsReceivable AccountsReceivable { get; set; }
        public virtual Form7MD Form { get; set; }
        public virtual AccountsPayable AccountsPayable { get; set; }

        public VM()
        {
            AccountsPayable = new AccountsPayable();
            AccountsReceivable = new AccountsReceivable();
        }
    }
}
