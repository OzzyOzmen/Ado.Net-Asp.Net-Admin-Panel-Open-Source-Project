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
    public partial class AddReferenceCategory :ControlPage
    {
        DbJobs jobs = new DbJobs();
        public List<Referencecategories> referencecategoriess = new List<Referencecategories>();
        Referencecategories referencecategories = new Referencecategories();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();
        public enum Process
        {
            AddCategoryName,
            EditCategoryName,
            DeleteCategoryName,
            DataNotFound
        }
        public Process Prcs = new Process();
        string id;
        public string PageTitle;
        public string Error1;
        protected void Page_Load(object sender, EventArgs e)
        {
           

            btnUpdate.ServerClick += BtnUpdate_ServerClick;
            btnClear.ServerClick += BtnClear_ServerClick;
            btnClear.Value = Resources.Index.Clean;
            btnUpdate.Value = Resources.Index.Add;
            referencecategoriess = jobs.Referencecategories();
            languagess = jobs.Languages();

            if (Request.QueryString["Process"] != null)
            {

                string Processs = Request.QueryString["Process"];

                if (Processs == "EditCategoryName")
                {
                    Prcs = AddReferenceCategory.Process.EditCategoryName;
                    id = Request.QueryString["id"].Clean();
                    Dictionary<string, string> condition = new Dictionary<string, string>();
                    condition.Add("id", id);
                    referencecategoriess = jobs.Referencecategories(condition);
                    btnUpdate.Value = Resources.Index.Update;
                    if (referencecategoriess.Count > 0)
                    {
                        PageTitle = Resources.Index.EditReferenceCategory;
                        {
                            if (!Page.IsPostBack)
                            {
                                txtCategoryNameTR.Value = referencecategoriess[0].ReferenceCategoryNameTR.ToString().Clean();
                                txtCategoryNameEN.Value = referencecategoriess[0].ReferenceCategoryNameEN.ToString().Clean();
                            }

                        }
                    }
                    else
                    {
                        PageTitle = Resources.Index.DataNotFound;
                        Prcs = AddReferenceCategory.Process.DataNotFound;

                    }

                }
                else if (Processs == "DeleteCategoryName")
                {
                    PageTitle = Resources.Index.DeleteReferenceCategory;
                    Prcs = AddReferenceCategory.Process.DeleteCategoryName;
                    id = Request.QueryString["id"].Clean();
                    int result = jobs.query("Delete referencecategories where id='" + id + "'");
                    if (result > 0)
                    {
                        Response.Redirect("/AddReferenceCategory.aspx");
                    }
                    else
                    {
                        Response.Write("Error");
                    }
                }
                else
                {
                    PageTitle = Resources.Index.WrongParameter;
                }
            }
            else
            {
                btnUpdate.Value = Resources.Index.Add;
                PageTitle = Resources.Index.AddReferenceCategory;
                Prcs = Process.AddCategoryName;
            }
          

        }

        protected void BtnUpdate_ServerClick(object sender, EventArgs e)
        {
            string CategoryNameEN = txtCategoryNameEN.Value.ToString().Clean();
            string CategoryNameTR = txtCategoryNameTR.Value.ToString().Clean();

            if (Prcs == Process.EditCategoryName)
            {              
                int result = jobs.query("Update referencecategories set ReferenceCategoryNameEN='" + CategoryNameEN + "',ReferenceCategoryNameTR='" + CategoryNameTR + "' where id='" + id + "'");

                if (result > 0)
                {
                    Response.Redirect("/AddReferenceCategory.aspx");
                }
            }
            else if (Prcs == Process.AddCategoryName)
            {
              

                if (CategoryNameEN != "" && CategoryNameTR != "")
                {
                    int result = jobs.query("Insert Into referencecategories(ReferenceCategoryNameEN,ReferenceCategoryNameTR) values('" + CategoryNameEN + "','" + CategoryNameTR + "')");
                    if (result > 0)
                    {
                        Response.Redirect("/AddReferenceCategory.aspx");
                    }
                }
                else
                {
                    Error1 = "Please fill all required fields.";
                }
            }
        }

        protected void BtnClear_ServerClick(object sender, EventArgs e)
        {
            txtCategoryNameTR.Value = "" ;
            txtCategoryNameEN.Value = "";
        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {

        }
    }
}