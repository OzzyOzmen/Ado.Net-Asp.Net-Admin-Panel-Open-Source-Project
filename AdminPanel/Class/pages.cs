using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanel.Class
{
    public class Pages
    {
        public int id { get; set; }
        public string PageTitleTR { get; set; }
        public string PageTitleEN { get; set; }
        public string PageContentTR { get; set; }
        public string PageContentEN { get; set; }
        public string SmallPicture { get; set; }
        public string ContentPicture { get; set; }
        public string PageUrl { get; set; }
    }
}