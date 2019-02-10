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
    public partial class NewsList : ControlPage
    {
        DbJobs jobs = new DbJobs();
        public List<News> newss = new List<News>();
        News news = new News();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();
        public string ErrorMessage = "";
        public string PageTitle;
        protected void Page_Load(object sender, EventArgs e)
        {
            newss = jobs.News();
            languagess = jobs.Languages();
            BtnAddNew.Text = Resources.Index.AddNews;
        }
        protected void BtnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewsPage.aspx");

        }
    }
}

