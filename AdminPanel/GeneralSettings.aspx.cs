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
    public partial class GeneralSettings : ControlPage
    {
        DbJobs jobs = new DbJobs();
        public List<Generalsetting> generalsettings = new List<Generalsetting>();
        Generalsetting generalsetting = new Generalsetting();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();

        public string PageTitle = Resources.Index.GeneralSettings;
        public string Error1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            btnUpdate.ServerClick += BtnUpdate_ServerClick;
            btnClear.ServerClick += BtnClear_ServerClick;
            btnClear.Value = Resources.Index.Clean;

            generalsettings = jobs.Generalsetting();

            if (!Page.IsPostBack)
            {

                lblid.Text = generalsettings[0].id.ToString().Clean();
                txtCompanyName.Value = generalsettings[0].CompanyName.ToString().Clean();
                txtKeywords.Value = generalsettings[0].Keywords.ToString().Clean();
                txtSiteURL.Value = generalsettings[0].SiteUrl.ToString().Clean();
                txtCompanyEmail.Value = generalsettings[0].CompanyEmail.ToString().Clean();
                txtCompanyPhone.Value = generalsettings[0].CompanyPhone.ToString().Clean();
                txtCompanyAddress.Value = generalsettings[0].CompanyAddress.ToString().Clean();
                txtWeekdaysWorkingHours.Value = generalsettings[0].WeekdaysWorkingHours.ToString().Clean();
                txtWeekendWorkingHours.Value = generalsettings[0].WeekendWorkingHours.ToString().Clean();
                txtCopyright.Value = generalsettings[0].Copyright.ToString().Clean();
                txtCompanyFacebook.Value = generalsettings[0].CompanyFacebook.ToString().Clean();
                txtCompanyTwitter.Value = generalsettings[0].CompanyTwitter.ToString().Clean();
                txtCompanyLinkedin.Value = generalsettings[0].CompanyLinkedin.ToString().Clean();
                txtCompanySkype.Value = generalsettings[0].CompanySkype.ToString().Clean();
                if (generalsettings[0].SiteStution == Resources.Index.Open)
                {
                    chkopen.Checked = true;
                }
                if (generalsettings[0].SiteStution == Resources.Index.Close)
                {
                    chkclose.Checked = true;
                }
                if (generalsettings[0].SiteLogo == "")
                {
                    image1.ImageUrl = "Content\\img\\logo.png";
                }
                else
                {
                    image1.ImageUrl = generalsettings[0].SiteLogo.ToString().Clean();

                }

            }

        }

        private void SettingsUpdate(int id)
        {

            string Companyname = txtCompanyName.Value.ToString().Clean();
            string keywords = txtKeywords.Value.ToString().Clean();
            string Siteurl = txtSiteURL.Value.ToString().Clean();
            string CompanyEmail = txtCompanyEmail.Value.ToString().Clean();
            string CompanyPhone = txtCompanyPhone.Value.ToString().Clean();
            string CompanyAddress = txtCompanyAddress.Value.ToString().Clean();
            string WeekdaysWorkingHours = txtWeekdaysWorkingHours.Value.ToString().Clean();
            string WeekendWorkingHours = txtWeekendWorkingHours.Value.ToString().Clean();
            string Copyright = txtCopyright.Value.ToString().Clean();
            string CompanyFacebook = txtCompanyFacebook.Value.ToString().Clean();
            string CompanyTwitter = txtCompanyTwitter.Value.ToString().Clean();
            string CompanyLinkedin = txtCompanyLinkedin.Value.ToString().Clean();
            string CompanySkype = txtCompanySkype.Value.ToString().Clean();
            string SiteStation = "";
            if (chkopen.Checked)
            {
                SiteStation = chkopen.Value.ToString().Clean();
            }
            if (chkclose.Checked)
            {
                SiteStation = chkclose.Value.ToString().Clean();
            }
            if (FileUpload1.HasFile)
            {
                if (Path.GetExtension(FileUpload1.PostedFile.FileName) == ".jpg" || Path.GetExtension(FileUpload1.PostedFile.FileName) == ".png")
                {
                    Random rndm = new Random();
                    string PhotoExtensions = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    string PhotoName = FileUpload1.PostedFile.FileName + rndm.Next(99999999, 999999999) + PhotoExtensions;
                    //Firstly we will save chosen images to \\images\\ folder as temporary
                    FileUpload1.SaveAs(Server.MapPath("~\\Content\\img\\uploads\\temp\\") + PhotoName);
                    //After we are converting as bitmap
                    Bitmap Photo = new Bitmap(Server.MapPath("~\\Content\\img\\uploads\\temp\\") + PhotoName);
                    int Width = 215;
                    int Height = 215;
                    //Resizing the photo
                    Size Size = new Size(Width, Height);
                    //Resmi boyutlandırıyoruz.
                    Bitmap ResizedPhoto = new Bitmap(Photo, Size);
                    string Resizedandsavedphoto = "~\\Content\\img\\uploads\\" + PhotoName;
                    //We are saving resized photo to \\images\\userphotos\\ folder
                    ResizedPhoto.Save(Server.MapPath(Resizedandsavedphoto), ImageFormat.Jpeg);
                    Photo.Dispose();
                    ResizedPhoto.Dispose();
                    //we delete the photo we saved as temporary
                    FileInfo Firstuploadedphoto = new FileInfo(Server.MapPath("~\\Content\\img\\uploads\\temp\\") + PhotoName);
                    Firstuploadedphoto.Delete();
                    image1.ImageUrl = Resizedandsavedphoto.Clean();
                }
            }
            var img1 = image1.ImageUrl.ToString().Clean();

            int result = jobs.query("Update generalsettings set CompanyName='" + Companyname + "',Keywords='" + keywords + "',SiteUrl='" + Siteurl + "',CompanyEmail='" + CompanyEmail + "',CompanyPhone='" + CompanyPhone + "',CompanyAddress='" + CompanyAddress + "',WeekdaysWorkingHours='" + WeekdaysWorkingHours + "',WeekendWorkingHours='" + WeekendWorkingHours + "',Copyright='" + Copyright + "' ,CompanyFacebook='" + CompanyFacebook + "',CompanyTwitter='" + CompanyTwitter + "',CompanyLinkedin='" + CompanyLinkedin + "',CompanySkype='" + CompanySkype + "',SiteStution='" + SiteStation + "',SiteLogo='" + img1 + "' where id='" + id + "'"); ;

            if (result > 0)
            {
                Response.Redirect("/index.aspx");
            }
            else
            {
                Error1 = Resources.Index.Pleasefillallrequiredfields;
            }


        }
        protected void BtnUpdate_ServerClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(generalsettings[0].id.ToString().Clean());
            SettingsUpdate(id);
        }
        protected void BtnClear_ServerClick(object sender, EventArgs e)
        {

            txtCompanyName.Value = "";
            txtKeywords.Value = "";
            txtSiteURL.Value = "";
            txtCompanyEmail.Value = "";
            txtCompanyPhone.Value = "";
            txtCompanyAddress.Value = "";
            txtWeekdaysWorkingHours.Value = "";
            txtWeekendWorkingHours.Value = "";
            txtCopyright.Value = "";
            txtCompanyFacebook.Value = "";
            txtCompanyTwitter.Value = "";
            txtCompanyLinkedin.Value = "";
            txtCompanySkype.Value = "";
            image1.ImageUrl = "Content\\img\\logo.png";

        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {
           
        }

    }
}
