using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Treasury7MD.Models
{
    public abstract class ADepartmentalClassification : PropertyChangedObserver
    {
        private int code;
        private string name;

        public int Code
        {
            get { return code; }
            set
            {
                code = value;
                OnPropertyChanged("Code");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
    }
}
