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
    public partial class StaffsList : ControlPage
    {
        DbJobs jobs = new DbJobs();
        public List<StaffJobPosition> staffJobPositions = new List<StaffJobPosition>();
        StaffJobPosition staffJobPosition = new StaffJobPosition();
        public List<Staffs> allstaffs = new List<Staffs>();
        Staffs staffss = new Staffs();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();
        public string ErrorMessage = "";
        public string PageTitle;
        protected void Page_Load(object sender, EventArgs e)
        {          
            languagess = jobs.Languages();
            allstaffs = jobs.Staffs();
            BtnAddNew.Text = Resources.Index.AddNewStaff;
        }
        protected void BtnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewStaff.aspx");

        }
    }
}

