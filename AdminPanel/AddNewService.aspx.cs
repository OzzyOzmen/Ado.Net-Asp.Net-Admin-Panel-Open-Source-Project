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
    public partial class AddNewService : ControlPage
    {
        DbJobs jobs = new DbJobs();
        public List<Services> servicess = new List<Services>();
        Services services = new Services();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();
        public enum Process
        {
            AddService,
            EditService,
            DeleteService,
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

                if (Processs == "EditService")
                {
                    Prcs = AddNewService.Process.EditService;
                    id = Request.QueryString["id"].Clean();
                    Dictionary<string, string> condition = new Dictionary<string, string>();
                    condition.Add("id", id);
                    servicess = jobs.Services(condition);
                    btnUpdate.Value = Resources.Index.Update;
                    if (servicess.Count > 0)
                    {
                        PageTitle = Resources.Index.EditServices;
                        {
                            if (!Page.IsPostBack)
                            {
                                lblturkish.Text = Resources.Index.Turkish;
                                lblenglish.Text = Resources.Index.English;                            
                                txtTurkishTitle.Value = servicess[0].ServiceTitleTR.ToString().Clean();
                                txtEnglishTitle.Value = servicess[0].ServiceTitleEN.ToString().Clean();
                                txtturkish.Value = servicess[0].ServiceDescriptionTR.ToString().Clean();
                                txtenglish.Value = servicess[0].ServiceDescriptionEN.ToString().Clean();
                                image1.ImageUrl= servicess[0].ServicePhoto1.ToString().Clean();
                                image2.ImageUrl = servicess[0].ServicePhoto2.ToString().Clean();
                                image3.ImageUrl = servicess[0].ServicePhoto3.ToString().Clean();
                                image4.ImageUrl = servicess[0].ServicePhoto4.ToString().Clean();
                                imageuploading.Visible = false;

                            }
                            
                        }
                    }
                    else
                    {
                        PageTitle = Resources.Index.DataNotFound;
                        Prcs = AddNewService.Process.DataNotFound;
                        
                    }

                }
                else if (Processs == "DeleteService")
                {
                    PageTitle = Resources.Index.DeleteServices;
                    Prcs = AddNewService.Process.DeleteService;
                    id = Request.QueryString["id"].Clean();
                    int result = jobs.query("Delete services where id='" + id + "'");
                    if (result > 0)
                    {
                        Response.Redirect("/ServicesList.aspx");
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
                btnUpdate.Value = Resources.Index.AddServices;
                PageTitle = Resources.Index.AddServices;
                Prcs = Process.AddService;
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
            if (FileUpload3.HasFile)
            {
                if (Path.GetExtension(FileUpload3.PostedFile.FileName) == ".jpg" || Path.GetExtension(FileUpload3.PostedFile.FileName) == ".png")
                {
                    Random rndm = new Random();
                    string PhotoExtensions = Path.GetExtension(FileUpload3.PostedFile.FileName);
                    string PhotoName = FileUpload1.PostedFile.FileName /*+ rndm.Next(99999999, 999999999) + PhotoExtensions*/;
                    //Firstly we will save chosen images to \\images\\ folder as temporary
                    FileUpload3.SaveAs(Server.MapPath("~\\Content\\img\\uploads\\temp\\") + PhotoName);
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
                    image3.ImageUrl = Resizedandsavedphoto.Clean();
                }
            }
            if (FileUpload4.HasFile)
            {
                if (Path.GetExtension(FileUpload4.PostedFile.FileName) == ".jpg" || Path.GetExtension(FileUpload4.PostedFile.FileName) == ".png")
                {
                    Random rndm = new Random();
                    string PhotoExtensions = Path.GetExtension(FileUpload4.PostedFile.FileName);
                    string PhotoName = FileUpload1.PostedFile.FileName /*+ rndm.Next(99999999, 999999999) + PhotoExtensions*/;
                    //Firstly we will save chosen images to \\images\\ folder as temporary
                    FileUpload4.SaveAs(Server.MapPath("~\\Content\\img\\uploads\\temp\\") + PhotoName);
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
                    image4.ImageUrl = Resizedandsavedphoto.Clean();
                }
            }
        }

        protected void BtnUpdate_ServerClick(object sender, EventArgs e)
        {
            string turkish = txtTurkishTitle.Value.ToString().Clean();
            string english = txtEnglishTitle.Value.ToString().Clean();
            string turkishdescription = txtturkish.Value.ToString().Clean();
            string englishdescription = txtenglish.Value.ToString().Clean();

            if (Prcs == Process.EditService)
            {
                var img1 = image1.ImageUrl.ToString().Clean();
                var img2 = image2.ImageUrl.ToString().Clean();
                var img3 = image3.ImageUrl.ToString().Clean();
                var img4 = image4.ImageUrl.ToString().Clean();

                int result = jobs.query("Update services set ServiceTitleTR='" + turkish + "',ServiceTitleEN='" + english + "',ServiceDescriptionTR='" + turkishdescription + "',ServiceDescriptionEN='" + englishdescription + "',ServicePhoto1='" + img1 + "',ServicePhoto2='" + img2 + "',ServicePhoto3='" + img3 + "',ServicePhoto4='" + img4 + "' where id='" + id + "'");

                if (result > 0)
                {
                    Response.Redirect("/ServicesList.aspx");
                }
            }
            else if (Prcs == Process.AddService)
            {
                var img1 = this.Context.Request.Form["hid1"].ToString().Clean();
                var img2 = this.Context.Request.Form["hid2"].ToString().Clean();
                var img3 = this.Context.Request.Form["hid3"].ToString().Clean();
                var img4 = this.Context.Request.Form["hid4"].ToString().Clean();

                if (turkish != "" && english != "" && turkishdescription != "" && englishdescription != "" && img1 != "" && img2 != "" && img3 != "" && img4 != "" )
                {
                    int result = jobs.query("Insert Into services(ServiceTitleTR,ServiceTitleEN,ServiceDescriptionTR,ServiceDescriptionEN,ServicePhoto1,ServicePhoto2,ServicePhoto3,ServicePhoto4) values('" + turkish + "','" + english + "','" + turkishdescription + "','" + englishdescription + "','" + img1 + "','" + img2 + "','" + img3 + "','" + img4 + "')");
                    if (result > 0)
                    {
                        Response.Redirect("/ServicesList.aspx");
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