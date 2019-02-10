using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using AdminPanel.Class;

namespace AdminPanel
{
    public partial class Login : System.Web.UI.Page
    {
        DbJobs jobs = new DbJobs();
        Users user = new Users();
        public string ErrorMessage = "";
        public string ErrorMessage2 = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            lblkadi.Text = "Admin";
            lblksifre.Text = "12345";

            BtnLogin.Value = Resources.Index.Login;
            txtUserName.Attributes.Add("placeholder", Resources.Index.UserName);
            txtPassword.Attributes.Add("placeholder", Resources.Index.Password);
        }

        protected void BtnLogin_ServerClick(object sender, EventArgs e)
        {
            Dictionary<string, string> condition = new Dictionary<string, string>();
            condition.Add("UserName", txtUserName.Value.Clean());
            condition.Add("Password", txtPassword.Value.Clean());
            user = jobs.User(condition).FirstOrDefault();


            if (user != null)
            {
                Session["USER"] = user;
                Response.Redirect("~/index.aspx");
            }
            else
            {
                Session["USER"] = null;
                //ErrorMessage = Resources.Index.signingerror;
            }
        }
    }
}