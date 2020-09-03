using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmaticAccountingSystem
{
    public static class extensionMethods
    {
        public static string ToNonTurkishString(this object value)
        {
            if (value == null)
                return null;
            else
                return value.ToString().Replace("Ğ", "G").Replace("ğ", "g").Replace("Ü", "U").Replace("ü", "u").Replace("Ş", "S").Replace("ş", "s").Replace("ı", "i").Replace("İ", "I").Replace("Ö", "O").Replace("ö", "o").Replace("Ç", "C").Replace("ç", "c");
        }
    }
}