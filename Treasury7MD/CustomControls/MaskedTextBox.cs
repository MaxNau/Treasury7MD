using System.Text;
using System.Windows.Controls;

namespace Treasury7MD.CustomControls
{
    public class MaskedTextBox : TextBox
    {
        public TextBoxMask Mask { get; set; }

        public MaskedTextBox()
        {
            this.TextChanged += new TextChangedEventHandler(MaskedTextBox_TextChanged);
        }

        void MaskedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tbEntry = sender as MaskedTextBox;

            if (tbEntry != null && tbEntry.Text.Length > 0)
            {
                tbEntry.Text = Format(tbEntry.Text, tbEntry.Mask);
            }
        }

        public static string Format(string mask, TextBoxMask dateFormat)
        {
            int x;
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            if (mask != null)
            {
                for (int i = 0; i < mask.Length; i++)
                {
                    if (int.TryParse(mask.Substring(i, 1), out x))
                    {
                        sb.Append(x.ToString());
                    }
                }
                switch (dateFormat)
                {
                    case TextBoxMask.Date:
                        return DateFormat(sb.ToString()).ToString();
                    default:
                        break;
                }

            }
            return sb.ToString();
        }

        public static StringBuilder DateFormat(string sb)
        {
            StringBuilder sb2 = new StringBuilder();

            if (sb.Length > 0) sb2.Append(sb.Substring(0, 1));
            if (sb.Length > 1) sb2.Append(sb.Substring(1, 1));
 
            if (sb.Length > 1) sb2.Append("/");

            if (sb.Length > 2) sb2.Append(sb.Substring(2, 1));
            if (sb.Length > 3) sb2.Append(sb.Substring(3, 1));

            if (sb.Length > 3) sb2.Append("/");

            if (sb.Length > 4) sb2.Append(sb.Substring(4, 1));
            if (sb.Length > 5) sb2.Append(sb.Substring(5, 1));
            if (sb.Length > 6) sb2.Append(sb.Substring(6, 1));
            if (sb.Length > 7) sb2.Append(sb.Substring(7, 1));

            return sb2;
        }

        public enum TextBoxMask
        {
            Date
        }
    }
}
