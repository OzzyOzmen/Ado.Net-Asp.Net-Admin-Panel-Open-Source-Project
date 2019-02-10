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
    public partial class AddNewProduct : ControlPage
    {
        DbJobs jobs = new DbJobs();
        public List<Productcategory> productcategories = new List<Productcategory>();
        Productcategory productcategory = new Productcategory();
        public List<Products> products = new List<Products>();
        Products product = new Products();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();
        public enum Process
        {
            AddProduct,
            EditProduct,
            DeleteProduct,
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
                productcategories = jobs.Productcategory();

                foreach (var item in productcategories)
                {

                    ddlCategory.Items.Add(item.ProductCategoryNameEN.ToString());
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

                if (Processs == "EditProduct")
                {
                    Prcs = AddNewProduct.Process.EditProduct;
                    id = Request.QueryString["id"].Clean();
                    Dictionary<string, string> condition = new Dictionary<string, string>();
                    condition.Add("id", id);
                    products = jobs.Products(condition);
                    btnUpdate.Value = Resources.Index.Update;
                    if (products.Count > 0)
                    {
                        PageTitle = Resources.Index.EditProduct;
                        {
                            if (!Page.IsPostBack)
                            {
                                string CategoryName = products[0].id.ToString().Clean();
                                ddlCategory.SelectedValue = CategoryName;
                                lblturkish.Text = Resources.Index.Turkish;
                                lblenglish.Text = Resources.Index.English;
                                txtTurkishTitle.Value = products[0].ProductNameTR.ToString().Clean();
                                txtEnglishTitle.Value = products[0].ProductNameEN.ToString().Clean();
                                txtturkish.Value = products[0].ProductDescriptionTR.ToString().Clean();
                                txtenglish.Value = products[0].ProductDescriptionEN.ToString().Clean();
                                txtProductCode.Value = products[0].ProductCode.ToString().Clean();
                                txtProductUrl.Value = products[0].ProductURL.ToString().Clean();
                                image1.ImageUrl = products[0].ProductPhoto.ToString().Clean();
                                imageuploading.Visible = false;

                            }

                        }
                    }
                    else
                    {
                        PageTitle = Resources.Index.DataNotFound;
                        Prcs = AddNewProduct.Process.DataNotFound;

                    }

                }
                else if (Processs == "DeleteProduct")
                {
                    PageTitle = Resources.Index.DeleteProduct;
                    Prcs = AddNewProduct.Process.DeleteProduct;
                    id = Request.QueryString["id"].Clean();
                    int result = jobs.query("Delete products where id='" + id + "'");
                    if (result > 0)
                    {
                        Response.Redirect("/ProductList.aspx");
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
                btnUpdate.Value = Resources.Index.AddProduct;
                PageTitle = Resources.Index.AddProduct;
                Prcs = Process.AddProduct;
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
            string CategoryName = ddlCategory.SelectedIndex.ToString().Clean();
            string turkishdescription = txtturkish.Value.ToString().Clean();
            string englishdescription = txtenglish.Value.ToString().Clean();
            string ProductCode = txtProductCode.Value.ToString().Clean();
            string ProductURL = txtProductUrl.Value.ToString().Clean();


            if (Prcs == Process.EditProduct)
            {
                var img1 = image1.ImageUrl.ToString().Clean();

                int result = jobs.query("Update products set ProductNameTR='" + turkish + "',ProductNameEN='" + english + "',ProductCategoryName='" + CategoryName + "',ProductDescriptionTR='" + turkishdescription + "',ProductDescriptionEN='" + englishdescription + "',ProductCode='" + ProductCode + "',ProductURL='" + ProductURL + "',ProductPhoto='" + img1 + "' where id='" + id + "'");

                if (result > 0)
                {
                    Response.Redirect("/ProductList.aspx");
                }
            }
            else if (Prcs == Process.AddProduct)
            {
                var img1 = this.Context.Request.Form["hid1"].ToString().Clean();

                if (turkish != "" && english != "" && turkishdescription != "" && englishdescription != "" && CategoryName != "" && ProductCode != "" && ProductURL != "" && img1 != "")
                {
                    int result = jobs.query("Insert Into products(ProductNameTR,ProductNameEN,ProductCategoryName,ProductDescriptionTR,ProductDescriptionEN,ProductCode,ProductURL,ProductPhoto) values('" + turkish + "','" + english + "','" + CategoryName + "','" + turkishdescription + "','" + englishdescription + "','" + ProductCode + "','" + ProductURL + "','" + img1 + "')");
                    if (result > 0)
                    {
                        Response.Redirect("/ProductList.aspx");
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
            txtturkish.Value = ""; ;
            txtenglish.Value = "";
            txtProductCode.Value = "";
            txtProductUrl.Value = "";
            image1.ImageUrl = "Content\\img\\resimyok.png";
        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {

        }
    }
}