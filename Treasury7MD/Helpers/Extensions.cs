using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Treasury7MD.Helpers
{
    public static class Extensions
    {
        public static void GetDescription(Enum en, out string indicator, out string rowCode)
        {
            indicator = String.Empty;
            rowCode = String.Empty;
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());
            object[] attrs = memInfo[0].GetCustomAttributes(typeof(KEKVDescriptionAttribute), false);
            if (attrs.Length > 0)
            {
                indicator = ((KEKVDescriptionAttribute) attrs[0]).Indicator;
                rowCode = ((KEKVDescriptionAttribute) attrs[0]).RowCode;
            }
        }

    }
}
