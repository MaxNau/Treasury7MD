using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Treasury7MD.Model.Helpers
{
    [AttributeUsage(AttributeTargets.Field)]
    public class KEKVDescriptionAttribute : DescriptionAttribute
    {
        public string Indicator { get; set; }
        public string RowCode { get; set; }
    }
}
