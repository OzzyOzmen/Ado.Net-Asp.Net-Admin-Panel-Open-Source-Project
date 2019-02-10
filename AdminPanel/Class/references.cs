using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanel.Class
{
    public class References
    {
        public int id { get; set; }
        public string TurkishReferenceName { get; set; }
        public string EnglishReferenceName { get; set; }
        public string ReferenceCategory { get; set; }
        public string ReferenceDescriptionTR { get; set; }
        public string ReferenceDescriptionEN { get; set; }
        public string RefereneLogo { get; set; }
    }
}