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
    public partial class AddSliderCategory : ControlPage
    {
        DbJobs jobs = new DbJobs();
        public List<Slidercategories> slidercategoriess = new List<Slidercategories>();
        Slidercategories slidercategories = new Slidercategories();
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
            slidercategoriess = jobs.Slidercategories();
            languagess = jobs.Languages();

            if (Request.QueryString["Process"] != null)
            {

                string Processs = Request.QueryString["Process"];

                if (Processs == "EditCategoryName")
                {
                    Prcs = AddSliderCategory.Process.EditCategoryName;
                    id = Request.QueryString["id"].Clean();
                    Dictionary<string, string> condition = new Dictionary<string, string>();
                    condition.Add("id", id);
                    slidercategoriess = jobs.Slidercategories(condition);
                    btnUpdate.Value = Resources.Index.Update;
                    if (slidercategoriess.Count > 0)
                    {
                        PageTitle = Resources.Index.EditGalleryCategory;
                        {
                            if (!Page.IsPostBack)
                            {
                                txtCategoryNameTR.Value = slidercategoriess[0].SliderCategoryNameTR.ToString().Clean();
                                txtCategoryNameEN.Value = slidercategoriess[0].SliderCategoryNameEN.ToString().Clean();
                            }

                        }
                    }
                    else
                    {
                        PageTitle = Resources.Index.DataNotFound;
                        Prcs = AddSliderCategory.Process.DataNotFound;

                    }

                }
                else if (Processs == "DeleteCategoryName")
                {
                    PageTitle = Resources.Index.DeleteSliderCategory;
                    Prcs = AddSliderCategory.Process.DeleteCategoryName;
                    id = Request.QueryString["id"].Clean();
                    int result = jobs.query("Delete slidercategories where id='" + id + "'");
                    if (result > 0)
                    {
                        Response.Redirect("/AddSliderCategory.aspx");
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
                PageTitle = Resources.Index.AddGalleryCategory;
                Prcs = Process.AddCategoryName;
            }


        }

        protected void BtnUpdate_ServerClick(object sender, EventArgs e)
        {
            string CategoryNameEN = txtCategoryNameEN.Value.ToString().Clean();
            string CategoryNameTR = txtCategoryNameTR.Value.ToString().Clean();

            if (Prcs == Process.EditCategoryName)
            {
                int result = jobs.query("Update slidercategories set SliderCategoryNameEN='" + CategoryNameEN + "',SliderCategoryNameTR='" + CategoryNameTR + "' where id='" + id + "'");

                if (result > 0)
                {
                    Response.Redirect("/AddSliderCategory.aspx");
                }
            }
            else if (Prcs == Process.AddCategoryName)
            {


                if (CategoryNameEN != "" && CategoryNameTR != "")
                {
                    int result = jobs.query("Insert Into slidercategories(SliderCategoryNameEN,SliderCategoryNameTR) values('" + CategoryNameEN + "','" + CategoryNameTR + "')");
                    if (result > 0)
                    {
                        Response.Redirect("/AddSliderCategory.aspx");
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
            txtCategoryNameTR.Value = "";
            txtCategoryNameEN.Value = "";
        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {

        }
    }
}