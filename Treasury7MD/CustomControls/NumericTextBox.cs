using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace Treasury7MD.CustomControls
{
    public class NumericTextBox : TextBox
    {

        public NumericTextBox()
        {
            AddHandler(CommandManager.ExecutedEvent, new System.Windows.RoutedEventHandler(CommandExecuted), true);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key != Key.Decimal & e.Key < Key.D0 || e.Key > Key.D9)
            {
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
                    if (e.Key != Key.Back)
                    {
                        e.Handled = true;
                    }
                }
            }

            if (e.Key == Key.OemPeriod)
            {
                e.Handled = false;
                if (Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void CommandExecuted(object sender, System.Windows.RoutedEventArgs e)
        {
            if ((e as ExecutedRoutedEventArgs).Command == ApplicationCommands.Paste)
            {
                double result = 0;
                if (e.Handled)
                {
                    if (!double.TryParse(Text, out result))
                    {
                        Text = "0";
                    }
                }
            }
        }
    }
}
