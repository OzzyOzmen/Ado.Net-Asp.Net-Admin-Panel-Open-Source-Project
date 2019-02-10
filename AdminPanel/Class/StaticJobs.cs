using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanel.Class
{
    public static class StaticJobs
    {
        public static string Clean(this string value)
        {
            string text = value;
            text = text.Replace("'", "").Trim();
            return text;
        }
    }
}
