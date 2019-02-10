using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdminPanel.Class;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Globalization;
using System.Threading;
using System.Web.Security;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI.HtmlControls;

namespace AdminPanel
{
    public partial class ViewContactMessage : ControlPage
    {
        DbJobs jobs = new DbJobs();
        public List<Contacts> contacts = new List<Contacts>();
        Contacts contact = new Contacts();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();

        public enum Process
        {
            ViewContact,
            DataNotFound
        }
        public Process Prcs = new Process();
        string id;
        public string PageTitle;
        public string Error1;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["Process"] != null)
            {

                string Processs = Request.QueryString["Process"];

                if (Processs == "ViewContact")
                {
                    Prcs = ViewContactMessage.Process.ViewContact;
                    id = Request.QueryString["id"].Clean();
                    Dictionary<string, string> condition = new Dictionary<string, string>();
                    condition.Add("id", id);
                    contacts = jobs.Contact(condition);
                    if (contacts.Count > 0)
                    {
                        PageTitle = Resources.Index.ViewContact;

                        txtSenderName.Value = contacts[0].SenderName.ToString().Clean();
                        txtContactMessage.Value = contacts[0].ContactMessage.ToString().Clean();

                        int result = jobs.query("Update notifications set IsRead='" + true + "' where id='" + id + "'");
                        

                    }
                    else
                    {
                        PageTitle = Resources.Index.DataNotFound;
                        Prcs = ViewContactMessage.Process.DataNotFound;

                    }

                }


            }
        }
    }
}