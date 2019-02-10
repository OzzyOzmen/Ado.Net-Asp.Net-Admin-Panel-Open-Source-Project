using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanel.Class
{
    public class Contacts
    {
        public int id { get; set; }
        public string SenderName { get; set; }
        public string ContactMessage { get; set; }
        public string SentDate { get; set; }
        public bool IsRead { get; set; }
    }
}