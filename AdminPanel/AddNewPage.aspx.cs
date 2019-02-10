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
    public partial class AddNews : ControlPage
    {
        DbJobs jobs = new DbJobs();
        public List<Pages> pages = new List<Pages>();
        Pages page = new Pages();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();
        public enum Process
        {
            AddPage,
            EditPage,
            DeletePage,
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
            BtnUpload.Text = Resources.Index.Upload;
            btnClear.Value = Resources.Index.Clean;

            if (Request.QueryString["Process"] != null)
            {

                string Processs = Request.QueryString["Process"];

                if (Processs == "EditPage")
                {
                    Prcs = AddNews.Process.EditPage;
                    id = Request.QueryString["id"].Clean();
                    Dictionary<string, string> condition = new Dictionary<string, string>();
                    condition.Add("id", id);
                    pages = jobs.Pages(condition);
                    btnUpdate.Value = Resources.Index.Update;
                    if (pages.Count > 0)
                    {
                        PageTitle = Resources.Index.EditPage;
                        {
                            if (!Page.IsPostBack)
                            {
                                lblturkish.Text = Resources.Index.Turkish;
                                lblenglish.Text = Resources.Index.English;
                                txtTurkishTitle.Value = pages[0].PageTitleTR.ToString().Clean();
                                txtEnglishTitle.Value = pages[0].PageTitleEN.ToString().Clean();
                                txtturkish.Value = pages[0].PageContentTR.ToString().Clean();
                                txtenglish.Value = pages[0].PageContentEN.ToString().Clean();
                                txtPageUrl.Value = pages[0].PageUrl.ToString().Clean();
                                image1.ImageUrl = pages[0].SmallPicture.ToString().Clean();
                                image2.ImageUrl = pages[0].ContentPicture.ToString().Clean();
                                imageuploading.Visible = false;

                            }

                        }
                    }
                    else
                    {
                        PageTitle = Resources.Index.DataNotFound;
                        Prcs = AddNews.Process.DataNotFound;

                    }

                }
                else if (Processs == "DeletePage")
                {
                    PageTitle = Resources.Index.DeletePage;
                    Prcs = AddNews.Process.DeletePage;
                    id = Request.QueryString["id"].Clean();
                    int result = jobs.query("Delete pages where id='" + id + "'");
                    if (result > 0)
                    {
                        Response.Redirect("/PagesList.aspx");
                    }
                    else
                    {
                        Response.Write("Error1");
                    }
                }
                else
                {
                    Title = Resources.Index.WrongParameter;
                }
            }
            else
            {
                btnUpdate.Value = Resources.Index.AddPage;
                PageTitle = Resources.Index.AddPage;
                Prcs = Process.AddPage;
                Viewingimages.Visible = false;
                uploadbuttondiv.Visible = false;
            }
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
            if (FileUpload2.HasFile)
            {
                if (Path.GetExtension(FileUpload2.PostedFile.FileName) == ".jpg" || Path.GetExtension(FileUpload2.PostedFile.FileName) == ".png")
                {
                    Random rndm = new Random();
                    string PhotoExtensions = Path.GetExtension(FileUpload2.PostedFile.FileName);
                    string PhotoName = FileUpload1.PostedFile.FileName /*+ rndm.Next(99999999, 999999999) + PhotoExtensions*/;
                    //Firstly we will save chosen images to \\images\\ folder as temporary
                    FileUpload2.SaveAs(Server.MapPath("~\\Content\\img\\uploads\\temp\\") + PhotoName);
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
                    image2.ImageUrl = Resizedandsavedphoto.Clean();
                }
            }
        }

        protected void BtnUpdate_ServerClick(object sender, EventArgs e)
        {
            string turkish = txtTurkishTitle.Value.ToString().Clean();
            string english = txtEnglishTitle.Value.ToString().Clean();
            string turkishdescription = txtturkish.Value.ToString().Clean();
            string englishdescription = txtenglish.Value.ToString().Clean();
            string PageURL = txtPageUrl.Value.ToString().Clean();

            if (Prcs == Process.EditPage)
            {
                var img1 = image1.ImageUrl.ToString().Clean();
                var img2 = image2.ImageUrl.ToString().Clean();

                int result = jobs.query("Update pages set PageTitleTR='" + turkish + "',PageTitleEN='" + english + "',PageContentTR='" + turkishdescription + "',PageContentEN='" + englishdescription + "',SmallPicture='" + img1 + "',ContentPicture='" + img2 + "',PageUrl='" + PageURL + "' where id='" + id + "'");

                if (result > 0)
                {
                    Response.Redirect("/PagesList.aspx");
                }
            }
            else if (Prcs == Process.AddPage)
            {
                var img1 = this.Context.Request.Form["hid1"].ToString().Clean();
                var img2 = this.Context.Request.Form["hid2"].ToString().Clean();

                if (turkish != "" && english != "" && turkishdescription != "" && englishdescription != "" && img1 != "" && img2 != "" && PageURL != "")
                {
                    int result = jobs.query("Insert Into pages(PageTitleTR,PageTitleEN,PageContentTR,PageContentEN,SmallPicture,ContentPicture,PageUrl) values('" + turkish + "','" + english + "','" + turkishdescription + "','" + englishdescription + "','" + img1 + "','" + img2 + "','" + PageURL + "')");
                    if (result > 0)
                    {
                        Response.Redirect("/PagesList.aspx");
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

            txtTurkishTitle.Value = "";
            txtEnglishTitle.Value = "";
            txtturkish.Value = "";
            txtenglish.Value = "";
            txtPageUrl.Value = "";
            image1.ImageUrl = "Content\\img\\resimyok.png";
            image2.ImageUrl = "Content\\img\\resimyok.png";
        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {

        }
    }
}