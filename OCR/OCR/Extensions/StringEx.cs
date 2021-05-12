using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCR.Extensions
{
    public static class StringEx
    {
        public static string Format(this string txt, object[] args = null)
        {
            return args != null ? String.Format(txt, args) : txt;
        }
    }
}