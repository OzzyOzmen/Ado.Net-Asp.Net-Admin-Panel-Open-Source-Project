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
    public partial class AddNewGallery : ControlPage
    {
        DbJobs jobs = new DbJobs();
        public List<Gallerycategories> gallerycategoriess = new List<Gallerycategories>();
        Gallerycategories gallerycategories = new Gallerycategories();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();
        public List<Galleries> galleriess = new List<Galleries>();
        Galleries galleries = new Galleries();
        public enum Process
        {
            AddGallery,
            EditGallery,
            DeleteGallery,
            DataNotFound
        }
        public Process Prcs = new Process();
        string id;
        public string PageTitle;
        public string Error1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddlCategory.Items.Count != 0)
            {
                gallerycategoriess = jobs.Gallerycategories();

                foreach (var item in gallerycategoriess)
                {

                    ddlCategory.Items.Add(item.GaleryCategoryNameEN.ToString());
                    ddlCategory.Items[ddlCategory.Items.Count - 1].Value = item.id.ToString().Clean();

                }
            }

            btnUpdate.ServerClick += BtnUpdate_ServerClick;
            btnClear.ServerClick += BtnClear_ServerClick;
            BtnUpload.Text = Resources.Index.Upload;
            btnClear.Value = Resources.Index.Clean;

            if (Request.QueryString["Process"] != null)
            {

                string Processs = Request.QueryString["Process"];

                if (Processs == "EditGallery")
                {
                    Prcs = AddNewGallery.Process.EditGallery;
                    id = Request.QueryString["id"].Clean();
                    Dictionary<string, string> condition = new Dictionary<string, string>();
                    condition.Add("id", id);
                    galleriess = jobs.Galleries(condition);
                    btnUpdate.Value = Resources.Index.Update;
                    if (galleriess.Count > 0)
                    {
                        PageTitle = Resources.Index.EditGallery;
                        {
                            if (!Page.IsPostBack)
                            {
                                string CategoryName = galleriess[0].id.ToString().Clean();
                                ddlCategory.SelectedValue = CategoryName;
                                lblturkish.Text = Resources.Index.Turkish;
                                lblenglish.Text = Resources.Index.English;
                                txtTurkishTitle.Value = galleriess[0].GaleryNameTR.ToString().Clean();
                                txtEnglishTitle.Value = galleriess[0].GaleryNameEN.ToString().Clean(); 
                                image1.ImageUrl = galleriess[0].GaleryPhoto1.ToString().Clean();
                                image2.ImageUrl = galleriess[0].GaleryPhoto2.ToString().Clean();
                                image3.ImageUrl = galleriess[0].GaleryPhoto3.ToString().Clean();
                                image4.ImageUrl = galleriess[0].GaleryPhoto4.ToString().Clean();
                                imageuploading.Visible = false;

                            }

                        }
                    }
                    else
                    {
                        PageTitle = Resources.Index.DataNotFound;
                        Prcs = AddNewGallery.Process.DataNotFound;

                    }

                }
                else if (Processs == "DeleteGallery")
                {
                    PageTitle = Resources.Index.DeleteServices;
                    Prcs = AddNewGallery.Process.DeleteGallery;
                    id = Request.QueryString["id"].Clean();
                    int result = jobs.query("Delete galleries where id='" + id + "'");
                    if (result > 0)
                    {
                        Response.Redirect("/GalleryList.aspx");
                    }
                    else
                    {
                        Response.Write("Error");
                    }
                }
                else
                {
                    Title = Resources.Index.WrongParameter;
                }
            }
            else
            {
                btnUpdate.Value = Resources.Index.AddGallery;
                PageTitle = Resources.Index.AddGallery;
                Prcs = Process.AddGallery;
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
                    int Width = 300;
                    int Height = 285;
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
                    string PhotoName = FileUpload2.PostedFile.FileName /*+ rndm.Next(99999999, 999999999) + PhotoExtensions*/;
                    //Firstly we will save chosen images to \\images\\ folder as temporary
                    FileUpload2.SaveAs(Server.MapPath("~\\Content\\img\\uploads\\temp\\") + PhotoName);
                    //After we are converting as bitmap
                    Bitmap Photo = new Bitmap(Server.MapPath("~\\Content\\img\\uploads\\temp\\") + PhotoName);
                    int Width = 300;
                    int Height = 285;
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
            if (FileUpload3.HasFile)
            {
                if (Path.GetExtension(FileUpload3.PostedFile.FileName) == ".jpg" || Path.GetExtension(FileUpload3.PostedFile.FileName) == ".png")
                {
                    Random rndm = new Random();
                    string PhotoExtensions = Path.GetExtension(FileUpload3.PostedFile.FileName);
                    string PhotoName = FileUpload3.PostedFile.FileName /*+ rndm.Next(99999999, 999999999) + PhotoExtensions*/;
                    //Firstly we will save chosen images to \\images\\ folder as temporary
                    FileUpload3.SaveAs(Server.MapPath("~\\Content\\img\\uploads\\temp\\") + PhotoName);
                    //After we are converting as bitmap
                    Bitmap Photo = new Bitmap(Server.MapPath("~\\Content\\img\\uploads\\temp\\") + PhotoName);
                    int Width = 300;
                    int Height = 285;
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
                    image3.ImageUrl = Resizedandsavedphoto.Clean();
                }
            }
            if (FileUpload4.HasFile)
            {
                if (Path.GetExtension(FileUpload4.PostedFile.FileName) == ".jpg" || Path.GetExtension(FileUpload4.PostedFile.FileName) == ".png")
                {
                    Random rndm = new Random();
                    string PhotoExtensions = Path.GetExtension(FileUpload4.PostedFile.FileName);
                    string PhotoName = FileUpload4.PostedFile.FileName /*+ rndm.Next(99999999, 999999999) + PhotoExtensions*/;
                    //Firstly we will save chosen images to \\images\\ folder as temporary
                    FileUpload4.SaveAs(Server.MapPath("~\\Content\\img\\uploads\\temp\\") + PhotoName);
                    //After we are converting as bitmap
                    Bitmap Photo = new Bitmap(Server.MapPath("~\\Content\\img\\uploads\\temp\\") + PhotoName);
                    int Width = 300;
                    int Height = 285;
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
                    image4.ImageUrl = Resizedandsavedphoto.Clean();
                }
            }
        }

        protected void BtnUpdate_ServerClick(object sender, EventArgs e)
        {
            string turkish = txtTurkishTitle.Value.ToString().Clean();
            string english = txtEnglishTitle.Value.ToString().Clean();
            string CategoryName = ddlCategory.SelectedIndex.ToString().Clean();

            if (Prcs == Process.EditGallery)
            {
                var img1 = image1.ImageUrl.ToString().Clean();
                var img2 = image2.ImageUrl.ToString().Clean();
                var img3 = image3.ImageUrl.ToString().Clean();
                var img4 = image4.ImageUrl.ToString().Clean();

                int result = jobs.query("Update galleries set GaleryNameTR='" + turkish + "',GaleryNameEN='" + english + "',GaleryCategory='" + CategoryName + "',GaleryPhoto1='" + img1 + "',GaleryPhoto2='" + img2 + "',GaleryPhoto3='" + img3 + "',GaleryPhoto4='" + img4 + "' where id='" + id + "'");

                if (result > 0)
                {
                    Response.Redirect("/GalleryList.aspx");
                }
            }
            else if (Prcs == Process.AddGallery)
            {
                var img1 = this.Context.Request.Form["hid1"].ToString().Clean();
                var img2 = this.Context.Request.Form["hid2"].ToString().Clean();
                var img3 = this.Context.Request.Form["hid3"].ToString().Clean();
                var img4 = this.Context.Request.Form["hid4"].ToString().Clean();

                if (turkish != "" && english != "" && CategoryName != ""  && img1 != "" && img2 != "" && img3 != "" && img4 != "")
                {
                    int result = jobs.query("Insert Into galleries(GaleryNameTR,GaleryNameEN,GaleryCategory,GaleryPhoto1,GaleryPhoto2,GaleryPhoto3,GaleryPhoto4) values('" + turkish + "','" + english + "','" + CategoryName + "','" + img1 + "','" + img2 + "','" + img3 + "','" + img4 + "')");
                    if (result > 0)
                    {
                        Response.Redirect("/GalleryList.aspx");
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
            image1.ImageUrl = "Content\\img\\resimyok.png";
            image2.ImageUrl = "Content\\img\\resimyok.png";
            image3.ImageUrl = "Content\\img\\resimyok.png";
            image4.ImageUrl = "Content\\img\\resimyok.png";
        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {

        }
    }
}