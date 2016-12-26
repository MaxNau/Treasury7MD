using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Treasury7MD.Commands
{
    public class MyCommand : ICommand
    {
        private Action execute;
        private Predicate<object> canExecute;

        public MyCommand(Action execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            bool isExecute = canExecute == null ? true : canExecute(parameter);
            return isExecute;
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}
