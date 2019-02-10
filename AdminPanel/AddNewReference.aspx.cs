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
    public partial class AddNewReference : ControlPage
    {
        DbJobs jobs = new DbJobs();
        public List<Referencecategories> referencecategoriess = new List<Referencecategories>();
        Referencecategories referencecategories = new Referencecategories();
        public List<References> referencess = new List<References>();
        References references = new References();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();

        public enum Process
        {
            AddReference,
            EditReference,
            DeleteReference,
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
                referencecategoriess = jobs.Referencecategories();

                foreach (var item in referencecategoriess)
                {

                    ddlCategory.Items.Add(item.ReferenceCategoryNameTR.ToString());
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

                if (Processs == "EditReference")
                {
                    Prcs = AddNewReference.Process.EditReference;
                    id = Request.QueryString["id"].Clean();
                    Dictionary<string, string> condition = new Dictionary<string, string>();
                    condition.Add("id", id);
                    referencess = jobs.References(condition);
                    btnUpdate.Value = Resources.Index.Update;
                    if (referencess.Count > 0)
                    {
                        PageTitle = Resources.Index.EditReference;
                        {
                            if (!Page.IsPostBack)
                            {
                                string CategoryName = referencess[0].id.ToString().Clean();
                                ddlCategory.SelectedValue = CategoryName;
                                txtTurkishTitle.Value = referencess[0].TurkishReferenceName.ToString().Clean();
                                txtEnglishTitle.Value = referencess[0].EnglishReferenceName.ToString().Clean();
                                txtturkish.Value = referencess[0].ReferenceDescriptionTR.ToString().Clean();
                                txtenglish.Value = referencess[0].ReferenceDescriptionEN.ToString().Clean();
                                image1.ImageUrl = referencess[0].RefereneLogo.ToString().Clean();
                                imageuploading.Visible = false;

                            }

                        }
                    }
                    else
                    {
                        PageTitle = Resources.Index.DataNotFound;
                        Prcs = AddNewReference.Process.DataNotFound;

                    }

                }
                else if (Processs == "DeleteReference")
                {
                    PageTitle = Resources.Index.DeleteReference;
                    Prcs = AddNewReference.Process.DeleteReference;
                    id = Request.QueryString["id"].Clean();
                    int result = jobs.query("Delete reference where id='" + id + "'");
                    if (result > 0)
                    {
                        Response.Redirect("/ReferenceList.aspx");
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
                btnUpdate.Value = Resources.Index.AddReference;
                PageTitle = Resources.Index.AddNewReference;
                Prcs = Process.AddReference;
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
            string CategoryName = ddlCategory.SelectedIndex.ToString().Clean();

            if (Prcs == Process.EditReference)
            {
                var img1 = image1.ImageUrl.ToString().Clean();

                int result = jobs.query("Update reference set ReferenceNameTR='" + turkish + "',ReferenceNameEN='" + english + "',ReferenceCategory='" + CategoryName + "',ReferenceLogo='" + img1 + "',ReferenceDescriptionTR='" + turkishdescription + "' ,ReferenceDescriptionEN='" + englishdescription + "' where id='" + id + "'");

                if (result > 0)
                {
                    Response.Redirect("/ReferenceList.aspx");
                }
            }
            else if (Prcs == Process.AddReference)
            {
                var img1 = this.Context.Request.Form["hid1"].ToString().Clean();

                if (turkish != "" && english !="" && turkishdescription !="" && englishdescription !="" && CategoryName!="" && img1 != "")
                {
                    int result = jobs.query("Insert Into reference(ReferenceNameTR,ReferenceNameEN,ReferenceCategory,ReferenceLogo,ReferenceDescriptionTR,ReferenceDescriptionEN) values ('" + turkish + "','" + english + "','" + CategoryName + "','" + img1 + "','" + turkishdescription + "','" + englishdescription + "')");

                    if (result > 0)
                    {
                        Response.Redirect("/ReferenceList.aspx");
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
            ddlCategory.SelectedValue = "Listeden Seçiniz";
            txtTurkishTitle.Value = "";
            txtEnglishTitle.Value = "";
            txtturkish.Value = "";
            txtenglish.Value = "";
            image1.ImageUrl = "Content\\img\\resimyok.png";
        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {

        }
    }
}