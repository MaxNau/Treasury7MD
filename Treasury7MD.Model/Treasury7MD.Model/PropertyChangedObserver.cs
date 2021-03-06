﻿using System.ComponentModel;

namespace Treasury7MD.Model
{
    public abstract class PropertyChangedObserver : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
