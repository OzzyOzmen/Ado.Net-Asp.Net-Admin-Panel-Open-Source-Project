using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Globalization;
using System.Threading;
using System.Web.Security;
using AdminPanel.Class;

namespace AdminPanel
{
    public partial class SiteMaster : MasterPage
    {
        DbJobs jobs = new DbJobs();
        List<Role> roless = new List<Role>();
        Role roles = new Role();
        List<Users> users = new List<Users>();
        Users user = new Users();
        List<Generalsetting> generalsettings = new List<Generalsetting>();
        Generalsetting generalsetting = new Generalsetting();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();
        public List<Contacts> contacts = new List<Contacts>();
        Contacts contact = new Contacts();
        public List<Notification> notifications = new List<Notification>();
        Notification notification = new Notification();
        public List<Galleries> galleriess = new List<Galleries>();
        Galleries galleries = new Galleries();
        public List<Gallerycategories> gallericategoriess = new List<Gallerycategories>();
        Gallerycategories gallericategories = new Gallerycategories();
        public List<Partners> partnerss = new List<Partners>();
        Partners partners = new Partners();
        public List<Referencecategories> referencecategoriess = new List<Referencecategories>();
        Referencecategories referencecategories = new Referencecategories();
        public List<References> referencess = new List<References>();
        References references = new References();
        public List<Services> servicess = new List<Services>();
        Services services = new Services();
        public List<Slidercategories> slidercategoriess = new List<Slidercategories>();
        Slidercategories slidercategories = new Slidercategories();
        public List<Sliders> sliderss = new List<Sliders>();
        Sliders sliders = new Sliders();
        public List<StaffJobPosition> staffJobPositions = new List<StaffJobPosition>();
        StaffJobPosition staffJobPosition = new StaffJobPosition();
        public List<Staffs> allstaffs = new List<Staffs>();
        Staffs staffss = new Staffs();
        public List<Pages> pages = new List<Pages>();
        Pages page = new Pages();
        public List<News> newss = new List<News>();
        News news = new News();
        public List<Productcategory> productcategories = new List<Productcategory>();
        Productcategory productcategory = new Productcategory();
        public List<Products> products = new List<Products>();
        Products product = new Products();


        protected void Page_Load(object sender, EventArgs e)
        {
            user = (Users)Session["USER"];

            lblUserName.Text = user.UserName.ToString().Clean();
            lblNameSurname.Text = user.NameSurname.ToString().Clean();
            lblNameSurname2.Text = user.NameSurname.ToString().Clean();
            lblNameSurname3.Text = user.NameSurname.ToString().Clean();
            lblemail.Text = user.Email.ToString().Clean();
            ImgContact.ImageUrl = "Content\\img\\ImgContact.jpg";
            ImgProfilePhoto1.ImageUrl = user.ProfilePhoto.Clean();
            ImgProfilePhoto2.ImageUrl = user.ProfilePhoto.Clean();
            ImgProfilePhoto3.ImageUrl = user.ProfilePhoto.Clean();
            if (ImgProfilePhoto1.ImageUrl == "" )
            {
                ImgProfilePhoto1.ImageUrl = "Content\\img\\user2-160x160.jpg";
            }
            if (ImgProfilePhoto2.ImageUrl == "" )
            {
                ImgProfilePhoto2.ImageUrl = "Content\\img\\user2-160x160.jpg";
            }
            if (ImgProfilePhoto3.ImageUrl == "")
            {
                ImgProfilePhoto3.ImageUrl = "Content\\img\\user2-160x160.jpg";
            }
           
            languagess = jobs.Languages();
            contacts = jobs.Contact();
            pages = jobs.Pages();
            productcategories = jobs.Productcategory();
            products = jobs.Products();
            notifications = jobs.NotificationTop5(); // Top 5
            
        }

        private void ChangeLanguage(string displayName)
        {
     
            Thread.CurrentThread.CurrentCulture = new CultureInfo(displayName);//lang.DisplayName);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(displayName);//lang.DisplayName);
            HttpCookie newCookie = new HttpCookie("locale");
            newCookie.Value = displayName; //lang.DisplayName;
            newCookie.Expires = DateTime.UtcNow.AddDays(365);
            Response.Cookies.Add(newCookie);
          
        }

        protected void enUS_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en-US"); // chosing language
                                     //redirect to index page
            Response.Redirect(Request.RawUrl);

        }

        protected void trTR_Click(object sender, EventArgs e)
        {
            ChangeLanguage("tr-TR"); // chosing language

            Response.Redirect(Request.RawUrl);  //redirect to index page
        }
    }
}
