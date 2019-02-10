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
    public partial class AddNewStaff : ControlPage
    {
        DbJobs jobs = new DbJobs();
        public List<StaffJobPosition> staffJobPositions = new List<StaffJobPosition>();
        StaffJobPosition staffJobPosition = new StaffJobPosition();
        public List<Staffs> allstaffs = new List<Staffs>();
        Staffs staffss = new Staffs();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();

        public enum Process
        {
            AddStaff,
            EditStaff,
            DeleteStaff,
            DataNotFound
        }
        public Process Prcs = new Process();
        string id;
        public string PageTitle;
        public string Error1;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (ddlStaffPosition.Items.Count != 0)
            {
                staffJobPositions = jobs.StaffJobPosition();

                foreach (var item in staffJobPositions)
                {

                    ddlStaffPosition.Items.Add(item.StaffJobPositionTR.ToString());
                    ddlStaffPosition.Items[ddlStaffPosition.Items.Count - 1].Value = item.id.ToString().Clean();

                }
            }



            btnUpdate.ServerClick += BtnUpdate_ServerClick;
            btnClear.ServerClick += BtnClear_ServerClick;
            BtnUpload.Text = Resources.Index.Upload;
            btnClear.Value = Resources.Index.Clean;

            if (Request.QueryString["Process"] != null)
            {

                string Processs = Request.QueryString["Process"];

                if (Processs == "EditStaff")
                {
                    Prcs = AddNewStaff.Process.EditStaff;
                    id = Request.QueryString["id"].Clean();
                    Dictionary<string, string> condition = new Dictionary<string, string>();
                    condition.Add("id", id);
                    allstaffs = jobs.Staffs(condition);
                    btnUpdate.Value = Resources.Index.Update;
                    if (allstaffs.Count > 0)
                    {
                        PageTitle = Resources.Index.EditReference;
                        {
                            if (!Page.IsPostBack)
                            {
                                string CategoryName = allstaffs[0].id.ToString().Clean();
                                ddlStaffPosition.SelectedValue = CategoryName;
                                txtStaffName.Value = allstaffs[0].StaffName.ToString().Clean();
                                txtStaffNumber.Value = allstaffs[0].StaffPhone.ToString().Clean();
                                txtStaffEmail.Value = allstaffs[0].StaffEmail.ToString().Clean(); 
                                image1.ImageUrl = allstaffs[0].StaffProfilePhoto.ToString().Clean();
                                imageuploading.Visible = false;

                            }

                        }
                    }
                    else
                    {
                        PageTitle = Resources.Index.DataNotFound;
                        Prcs = AddNewStaff.Process.DataNotFound;

                    }

                }
                else if (Processs == "DeleteStaff")
                {
                    PageTitle = Resources.Index.DeleteStaff;
                    Prcs = AddNewStaff.Process.DeleteStaff;
                    id = Request.QueryString["id"].Clean();
                    int result = jobs.query("Delete staffs where id='" + id + "'");
                    if (result > 0)
                    {
                        Response.Redirect("/StaffsList.aspx");
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
                btnUpdate.Value = Resources.Index.AddStaff;
                PageTitle = Resources.Index.AddStaff;
                Prcs = Process.AddStaff;
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
            string StaffName = txtStaffName.Value.ToString().Clean();
            string StaffNumber = txtStaffNumber.Value.ToString().Clean();
            string StaffEmail = txtStaffEmail.Value.ToString().Clean();
            string CategoryName = ddlStaffPosition.SelectedIndex.ToString().Clean();


            if (Prcs == Process.EditStaff)
            {
                var img1 = image1.ImageUrl.ToString().Clean();

                int result = jobs.query("Update staffs set StaffName='" + StaffName + "',StaffPhone='" + StaffNumber + "',StaffJobPosition='" + CategoryName + "',StaffProfilePhoto='" + img1 + "',StaffEmail='" + StaffEmail + "'  where id='" + id + "'");

                if (result > 0)
                {
                    Response.Redirect("/StaffsList.aspx");
                }
            }
            else if (Prcs == Process.AddStaff)
            {
                var img1 = this.Context.Request.Form["hid1"].ToString().Clean();

                if (StaffName != "" && StaffNumber != "" && StaffEmail != ""  && CategoryName != "" && img1 != "")
                {
                    int result = jobs.query("Insert Into staffs(StaffName,StaffPhone,StaffJobPosition,StaffProfilePhoto,StaffEmail) values ('" + StaffName + "','" + StaffNumber + "','" + CategoryName + "','" + img1 + "','" + StaffEmail + "')");

                    if (result > 0)
                    {
                        Response.Redirect("/StaffsList.aspx");
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
            ddlStaffPosition.SelectedValue = "Listeden Seçiniz";
            txtStaffName.Value = "";
            txtStaffNumber.Value = "";
            txtStaffEmail.Value = "";
            image1.ImageUrl = "Content\\img\\resimyok.png";
        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {

        }
    }
}