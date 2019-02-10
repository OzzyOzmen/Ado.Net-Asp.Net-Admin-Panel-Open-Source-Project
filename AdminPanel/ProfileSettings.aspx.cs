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
    public partial class ProfileSettings : ControlPage
    {
        DbJobs jobs = new DbJobs();
        public List<Users> users = new List<Users>();
        Users user = new Users();
        public List<Role> roless = new List<Role>();
        Role roles = new Role();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();

        public string PageTitle = Resources.Index.ProfileSettings;
        public string Error1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (ddlYetki.Items.Count >= 0)
            {
                roless = jobs.Role();
                foreach (var item in roless)
                {
                    ddlYetki.Items.Add(item.PkID.ToString());
                    ddlYetki.Items[ddlYetki.Items.Count - 1].Value = item.PkID.ToString();
                }
            }
            btnUpdate.ServerClick += BtnUpdate_ServerClick;
            btnClear.ServerClick += BtnClear_ServerClick;          
            btnClear.Value = Resources.Index.Clean;
            btnUpdate.Value = Resources.Index.Save;
            users = jobs.User();

            if (!Page.IsPostBack)
            {

                lblid.Text = users[0].id.ToString().Clean();
                txtUserName.Value = users[0].UserName.ToString().Clean();
                txtPassword.Value = users[0].Password.ToString().Clean();
                txtConfirmPassword.Value = users[0].ConfirmPassword.ToString().Clean();
                txtNameSurname.Value = users[0].UserName.ToString().Clean();
                txtEmail.Value = users[0].Email.ToString().Clean();
                string UserRole = users[0].RoleID.ToString().Clean();
                ddlYetki.SelectedValue = UserRole;
                if (users[0].ProfilePhoto == "")
                {
                    image1.ImageUrl = "Content\\img\\user2-160x160.jpg";
                }
                else
                {
                    image1.ImageUrl = users[0].ProfilePhoto.ToString().Clean();

                }

            }

        }
        private void SettingsUpdate(int id)
        {
            string UserName = txtUserName.Value.ToString().Clean();
            string Password = txtPassword.Value.ToString().Clean();
            string ConfirmPassword = txtConfirmPassword.Value.ToString().Clean();
            string NameSurname = txtNameSurname.Value.ToString().Clean();
            string Email= txtEmail.Value.ToString().Clean();
            string UserRole = ddlYetki.SelectedValue.Clean();
            if (FileUpload1.HasFile)
            {
                if (Path.GetExtension(FileUpload1.PostedFile.FileName) == ".jpg" || Path.GetExtension(FileUpload1.PostedFile.FileName) == ".png")
                {
                    Random rndm = new Random();
                    string PhotoExtensions = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    string PhotoName = FileUpload1.PostedFile.FileName /*+ rndm.Next(99999999, 999999999) + PhotoExtensions*/;
                    //Firstly we will save chosen images to \\images\\ folder as temporary
                    FileUpload1.SaveAs(Server.MapPath("~\\Content\\img\\uploads\\temp\\") + PhotoName);
                    //After we are converting as bitmap
                    Bitmap Photo = new Bitmap(Server.MapPath("~\\Content\\img\\uploads\\temp\\") + PhotoName);
                    int Width = 160;
                    int Height = 160;
                    //Resizing the photo
                    Size Size = new Size(Width, Height);
                    //Resizing Proho.
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

            int result = jobs.query("Update users set UserName='" + UserName + "',Password='" + Password + "',ConfirmPassword='" + ConfirmPassword + "',NameSurname='" + NameSurname + "',Email='" + Email + "',RoleID='" + UserRole + "',ProfilePhoto='" + img1 + "' where id='" + id + "'");

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
            int id = Convert.ToInt32(users[0].id.ToString().Clean());
            SettingsUpdate(id);

        }
        protected void BtnClear_ServerClick(object sender, EventArgs e)
        {
            txtUserName.Value = "";
            txtPassword.Value ="";
            txtConfirmPassword.Value = "";
            txtNameSurname.Value = "";
            txtEmail.Value = "";
            ddlYetki.SelectedValue = "Listeden Seçiniz";
            image1.ImageUrl = "Content\\img\\user2-160x160.jpg";

          
       

    }
}
}
