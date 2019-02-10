using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanel.Class
{
    public class Notification
    {
        public int id { get; set; }
        public string NotificationDescription { get; set; }
        public string SentDate { get; set; }
        public bool IsRead { get; set; }
    }
}