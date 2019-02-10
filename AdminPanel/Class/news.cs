using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanel.Class
{
    public class News
    {
        public int id { get; set; }
        public string NewsTitleTR { get; set; }
        public string NewsTitleEN { get; set; }
        public string NewsContentTR { get; set; }
        public string NewsContentEN { get; set; }
        public string NewsDate { get; set; }
        public string NewsImage { get; set; }


    }
}