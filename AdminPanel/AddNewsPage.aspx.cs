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
    public partial class AddNewsPage : ControlPage
    {
        DbJobs jobs = new DbJobs();
        public List<News> newss = new List<News>();
        News news = new News();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();
        public enum Process
        {
            AddNews,
            EditNews,
            DeleteNews,
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

                if (Processs == "EditNews")
                {
                    Prcs = AddNewsPage.Process.EditNews;
                    id = Request.QueryString["id"].Clean();
                    Dictionary<string, string> condition = new Dictionary<string, string>();
                    condition.Add("id", id);
                    newss = jobs.News(condition);
                    btnUpdate.Value = Resources.Index.Update;
                    if (newss.Count > 0)
                    {
                        PageTitle = Resources.Index.EditPage;
                        {
                            if (!Page.IsPostBack)
                            {
                                lblturkish.Text = Resources.Index.Turkish;
                                lblenglish.Text = Resources.Index.English;
                                txtTurkishTitle.Value = newss[0].NewsTitleTR.ToString().Clean();
                                txtEnglishTitle.Value = newss[0].NewsTitleEN.ToString().Clean();
                                txtturkish.Value = newss[0].NewsContentTR.ToString().Clean();
                                txtenglish.Value = newss[0].NewsContentEN.ToString().Clean();
                                txtNewsDate.Value = newss[0].NewsDate.ToString().Clean();
                                image1.ImageUrl = newss[0].NewsImage.ToString().Clean();
                                imageuploading.Visible = false;

                            }

                        }
                    }
                    else
                    {
                        PageTitle = Resources.Index.DataNotFound;
                        Prcs = AddNewsPage.Process.DataNotFound;

                    }

                }
                else if (Processs == "DeleteNews")
                {
                    PageTitle = Resources.Index.DeleteNews;
                    Prcs = AddNewsPage.Process.DeleteNews;
                    id = Request.QueryString["id"].Clean();
                    int result = jobs.query("Delete news where id='" + id + "'");
                    if (result > 0)
                    {
                        Response.Redirect("/NewsList.aspx");
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
                btnUpdate.Value = Resources.Index.AddNews;
                PageTitle = Resources.Index.AddNews;
                Prcs = Process.AddNews;
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
            
        }

        protected void BtnUpdate_ServerClick(object sender, EventArgs e)
        {
            string turkish = txtTurkishTitle.Value.ToString().Clean();
            string english = txtEnglishTitle.Value.ToString().Clean();
            string turkishdescription = txtturkish.Value.ToString().Clean();
            string englishdescription = txtenglish.Value.ToString().Clean();
            string NewsDate = txtNewsDate.Value.ToString().Clean();

            if (Prcs == Process.EditNews)
            {
                var img1 = image1.ImageUrl.ToString().Clean();

                int result = jobs.query("Update news set NewsTitleTR='" + turkish + "',NewsTitleEN='" + english + "',NewsContentTR='" + turkishdescription + "',NewsContentEN='" + englishdescription + "',NewsImage='" + img1 + "',NewsDate='" + NewsDate + "' where id = '" + id + "'");

                if (result > 0)
                {
                    Response.Redirect("/NewsList.aspx");
                }
            }
            else if (Prcs == Process.AddNews)
            {
                var img1 = this.Context.Request.Form["hid1"].ToString().Clean();

                if (turkish != "" && english != "" && turkishdescription != "" && englishdescription != "" && img1 != "" && NewsDate != "")
                {
                    int result = jobs.query("Insert Into news(NewsTitleTR,NewsTitleEN,NewsContentTR,NewsContentEN,NewsImage,NewsDate) values('" + turkish + "','" + english + "','" + turkishdescription + "','" + englishdescription + "','" + img1 + "','" + NewsDate + "')");
                    if (result > 0)
                    {
                        Response.Redirect("/NewsList.aspx");
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
            txtNewsDate.Value = "";
            image1.ImageUrl = "Content\\img\\resimyok.png";
        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {

        }
    }
}