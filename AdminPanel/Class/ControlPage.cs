using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace AdminPanel.Class
{
    public class ControlPage : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["USER"] == null)
            {
                Response.Redirect("/Login.aspx");
                
            }
            base.OnLoad(e);
        }
    }
}