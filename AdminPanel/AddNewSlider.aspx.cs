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
    public partial class AddNewSlider : ControlPage
    {
        DbJobs jobs = new DbJobs();
        public List<Slidercategories> slidercategoriess = new List<Slidercategories>();
        Slidercategories slidercategories = new Slidercategories();
        public List<Sliders> sliderss = new List<Sliders>();
        Sliders sliders = new Sliders();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();

        public enum Process
        {
            AddSlider,
            EditSlider,
            DeleteSlider,
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
                slidercategoriess = jobs.Slidercategories();

                foreach (var item in slidercategoriess)
                {

                    ddlCategory.Items.Add(item.SliderCategoryNameEN.ToString());
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

                if (Processs == "EditSlider")
                {
                    Prcs = AddNewSlider.Process.EditSlider;
                    id = Request.QueryString["id"].Clean();
                    Dictionary<string, string> condition = new Dictionary<string, string>();
                    condition.Add("id", id);
                    sliderss = jobs.Sliders(condition);
                    btnUpdate.Value = Resources.Index.Update;
                    if (sliderss.Count > 0)
                    {
                        PageTitle = Resources.Index.EditSlider;
                        {
                            if (!Page.IsPostBack)
                            {
                                string CategoryName = sliderss[0].id.ToString().Clean();
                                ddlCategory.SelectedValue = CategoryName;
                                lblturkish.Text = Resources.Index.Turkish;
                                lblenglish.Text = Resources.Index.English;
                                txtTurkishTitle.Value = sliderss[0].SliderNameTR.ToString().Clean();
                                txtEnglishTitle.Value = sliderss[0].SliderNameEN.ToString().Clean();
                                image1.ImageUrl = sliderss[0].SliderPhoto1.ToString().Clean();
                                image2.ImageUrl = sliderss[0].SliderPhoto2.ToString().Clean();
                                image3.ImageUrl = sliderss[0].SliderPhoto3.ToString().Clean();
                                image4.ImageUrl = sliderss[0].SliderPhoto4.ToString().Clean();
                                imageuploading.Visible = false;

                            }

                        }
                    }
                    else
                    {
                        PageTitle = Resources.Index.DataNotFound;
                        Prcs = AddNewSlider.Process.DataNotFound;

                    }

                }
                else if (Processs == "DeleteSlider")
                {
                    PageTitle = Resources.Index.DeleteSlider;
                    Prcs = AddNewSlider.Process.DeleteSlider;
                    id = Request.QueryString["id"].Clean();
                    int result = jobs.query("Delete sliders where id='" + id + "'");
                    if (result > 0)
                    {
                        Response.Redirect("/SliderList.aspx");
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
                btnUpdate.Value = Resources.Index.AddSlider;
                PageTitle = Resources.Index.AddSlider;
                Prcs = Process.AddSlider;
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

            if (Prcs == Process.EditSlider)
            {
                var img1 = image1.ImageUrl.ToString().Clean();
                var img2 = image2.ImageUrl.ToString().Clean();
                var img3 = image3.ImageUrl.ToString().Clean();
                var img4 = image4.ImageUrl.ToString().Clean();

                int result = jobs.query("Update sliders set SliderNameTR='" + turkish + "',SliderNameEN='" + english + "',SliderCategory='" + CategoryName + "',SliderPhoto1='" + img1 + "',SliderPhoto2='" + img2 + "',SliderPhoto3='" + img3 + "',SliderPhoto4='" + img4 + "' where id='" + id + "'");

                if (result > 0)
                {
                    Response.Redirect("/SliderList.aspx");
                }
            }
            else if (Prcs == Process.AddSlider)
            {
                var img1 = this.Context.Request.Form["hid1"].ToString().Clean();
                var img2 = this.Context.Request.Form["hid2"].ToString().Clean();
                var img3 = this.Context.Request.Form["hid3"].ToString().Clean();
                var img4 = this.Context.Request.Form["hid4"].ToString().Clean();

                if (turkish != "" && english != "" && CategoryName != "" && img1 != "" && img2 != "" && img3 != "" && img4 != "")
                {
                    int result = jobs.query("Insert Into sliders(SliderNameTR,SliderNameEN,SliderCategory,SliderPhoto1,SliderPhoto2,SliderPhoto3,SliderPhoto4) values('" + turkish + "','" + english + "','" + CategoryName + "','" + img1 + "','" + img2 + "','" + img3 + "','" + img4 + "')");
                    if (result > 0)
                    {
                        Response.Redirect("/SliderList.aspx");
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