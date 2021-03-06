﻿
namespace Treasury7MD.Model
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
