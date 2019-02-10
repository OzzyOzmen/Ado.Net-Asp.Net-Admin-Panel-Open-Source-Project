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
    public partial class ProductList : ControlPage
    {

        DbJobs jobs = new DbJobs();
        public List<Productcategory> productcategories = new List<Productcategory>();
        Productcategory productcategory = new Productcategory();
        public List<Products> products = new List<Products>();
        Products product = new Products();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();
        public string ErrorMessage = "";
        public string PageTitle;
        protected void Page_Load(object sender, EventArgs e)
        {
            products = jobs.Products();
            
            languagess = jobs.Languages();
            BtnAddNew.Text = Resources.Index.AddProduct;
        }
        protected void BtnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewProduct.aspx");

        }
    }
}