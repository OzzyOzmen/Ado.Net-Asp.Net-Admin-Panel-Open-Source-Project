using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanel.Class
{
    public class Products
    {
        public int id { get; set; }
        public string ProductCategory { get; set; }
        public string ProductNameTR { get; set; }
        public string ProductNameEN { get; set; }
        public string ProductDescriptionTR { get; set; }
        public string ProductDescriptionEN { get; set; }
        public string ProductCode { get; set; }
        public string ProductPhoto { get; set; }
        public string ProductURL { get; set; }
    }
}