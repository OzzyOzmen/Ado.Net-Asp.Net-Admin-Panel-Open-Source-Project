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
    public partial class AddNewPartner : ControlPage
    {
        DbJobs jobs = new DbJobs();
        public List<Partners> partnerss = new List<Partners>();
        Partners partners = new Partners();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();
        public enum Process
        {
            AddPartner,
            EditPartner,
            DeletePartner,
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

                if (Processs == "EditPartner")
                {
                    Prcs = AddNewPartner.Process.EditPartner;
                    id = Request.QueryString["id"].Clean();
                    Dictionary<string, string> condition = new Dictionary<string, string>();
                    condition.Add("id", id);
                    partnerss = jobs.Partners(condition);
                    btnUpdate.Value = Resources.Index.Update;
                    if (partnerss.Count > 0)
                    {
                        PageTitle = Resources.Index.EditServices;
                        {
                            if (!Page.IsPostBack)
                            {
                                txtPartnerName.Value = partnerss[0].PartnerName.ToString().Clean();
                                image1.ImageUrl = partnerss[0].PartnerLogo.ToString().Clean();
                                imageuploading.Visible = false;

                            }

                        }
                    }
                    else
                    {
                        PageTitle = Resources.Index.DataNotFound;
                        Prcs = AddNewPartner.Process.DataNotFound;

                    }

                }
                else if (Processs == "DeletePartner")
                {
                    PageTitle = Resources.Index.DeletePartner;
                    Prcs = AddNewPartner.Process.DeletePartner;
                    id = Request.QueryString["id"].Clean();
                    int result = jobs.query("Delete partners where id='" + id + "'");
                    if (result > 0)
                    {
                        Response.Redirect("/PartnerList.aspx");
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
                btnUpdate.Value = Resources.Index.AddNewPartner;
                PageTitle = Resources.Index.AddNewPartner;
                Prcs = Process.AddPartner;
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
            string PartnerName = txtPartnerName.Value.ToString().Clean();

            if (Prcs == Process.EditPartner)
            {
                var img1 = image1.ImageUrl.ToString().Clean();

                int result = jobs.query("Update partners set PartnerName='" + PartnerName + "',PartnerLogo='" + img1 + "' where id='" + id + "'");

                if (result > 0)
                {
                    Response.Redirect("/PartnerList.aspx");
                }
            }
            else if (Prcs == Process.AddPartner)
            {
                var img1 = this.Context.Request.Form["hid1"].ToString().Clean();

                if (PartnerName != "" && img1 != "" )
                {
                    int result = jobs.query("Insert Into partners(PartnerName,PartnerLogo) values('" + PartnerName + "','" + img1 + "')");
                    if (result > 0)
                    {
                        Response.Redirect("/PartnerList.aspx");
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
            txtPartnerName.Value = "";
            image1.ImageUrl = "Content\\img\\logoyok.png";
        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {

        }
    }
}