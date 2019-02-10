using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace AdminPanel.Class
{
    public class DbJobs
    {
        // db connection

        public static string SqlCommand = "Server=localhost\\SQLEXPRESS;Database=AdminPanel;Integrated Security=true";        

        // Datetable
        public DataTable QuerySelect(string query)
        {
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();
            return dt;
        }
		
        // query
        public int query(string query)
        {
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            return result;
        }

        //Users
        public List<Users> User(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }

            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from users" + condition.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<Users> users = new List<Users>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Users user = new Users();
                user.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                user.RoleID = int.Parse(dt.Rows[i]["RoleID"].ToString().Clean());
                user.UserName = dt.Rows[i]["UserName"].ToString().Clean();
                user.Password = dt.Rows[i]["Password"].ToString().Clean();
                user.ConfirmPassword = dt.Rows[i]["ConfirmPassword"].ToString().Clean();
                user.Email = dt.Rows[i]["Email"].ToString().Clean();
                user.NameSurname = dt.Rows[i]["NameSurname"].ToString().Clean();
                user.ProfilePhoto = dt.Rows[i]["ProfilePhoto"].ToString().Clean();
                users.Add(user);
            }

            connection.Close();
            return users;
        }

       

        // Roles
        public List<Role> Role(string id = "")
        {
            if (id != "")
            {
                id = " where id='" + id + "'";
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from roles" + id, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Role> roless = new List<Role>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Role roles = new Role();
                roles.PkID = int.Parse(dt.Rows[i]["PkID"].ToString().Clean());
                roles.UserGroupTR = dt.Rows[i]["UserGroupTR"].ToString().Clean();
                roles.UserGroupEN = dt.Rows[i]["UserGroupEN"].ToString().Clean();
                roless.Add(roles);
            }

            connection.Close();
            return roless;
        }

        // language Settings
        public List<Languages> Languages(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from languages" + condition.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Languages> languagess = new List<Languages>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Languages languages = new Languages();
                languages.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                languages.DisplayName = dt.Rows[i]["DisplayName"].ToString().Clean();


                languagess.Add(languages);
            }
            connection.Close();
            return languagess;
        }

        // Generalsettings
        public List<Generalsetting> Generalsetting(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from generalsettings" + condition.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Generalsetting> generalsettings = new List<Generalsetting>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Generalsetting generalsetting = new Generalsetting();
                generalsetting.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                generalsetting.CompanyName = dt.Rows[i]["CompanyName"].ToString().Clean();
                generalsetting.Keywords = dt.Rows[i]["Keywords"].ToString().Clean();
                generalsetting.SiteUrl = dt.Rows[i]["SiteUrl"].ToString().Clean();
                generalsetting.CompanyEmail = dt.Rows[i]["CompanyEmail"].ToString().Clean();
                generalsetting.CompanyPhone = dt.Rows[i]["CompanyPhone"].ToString().Clean();
                generalsetting.CompanyAddress = dt.Rows[i]["CompanyAddress"].ToString().Clean();
                generalsetting.WeekdaysWorkingHours = dt.Rows[i]["WeekdaysWorkingHours"].ToString().Clean();
                generalsetting.WeekendWorkingHours = dt.Rows[i]["WeekendWorkingHours"].ToString().Clean();
                generalsetting.Copyright = dt.Rows[i]["Copyright"].ToString().Clean();
                generalsetting.CompanyFacebook = dt.Rows[i]["CompanyFacebook"].ToString().Clean();
                generalsetting.CompanyTwitter = dt.Rows[i]["CompanyTwitter"].ToString().Clean();
                generalsetting.CompanyLinkedin = dt.Rows[i]["CompanyLinkedin"].ToString().Clean();
                generalsetting.CompanySkype = dt.Rows[i]["CompanySkype"].ToString().Clean();
                generalsetting.SiteStution = dt.Rows[i]["SiteStution"].ToString().Clean();
                generalsetting.SiteLogo = dt.Rows[i]["SiteLogo"].ToString().Clean();

                generalsettings.Add(generalsetting);
            }
            connection.Close();
            return generalsettings;
        }

        //Contact
        public List<Contacts> Contact(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from contact" + condition.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Contacts> contacts = new List<Contacts>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Contacts contact = new Contacts();
                contact.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                contact.SenderName = dt.Rows[i]["SenderName"].ToString().Clean();
                contact.ContactMessage = dt.Rows[i]["ContactMessage"].ToString().Clean();
                contact.SentDate = dt.Rows[i]["SentDate"].ToString().Clean();
                contact.IsRead = Convert.ToBoolean(dt.Rows[i]["IsRead"]);
                contacts.Add(contact);
            }

            connection.Close();
            return contacts;
        }

        // Gallery Categories
        public List<Gallerycategories> Gallerycategories(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from gallericategories" + condition.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Gallerycategories> gallerycategoriess = new List<Gallerycategories>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Gallerycategories gallerycategories = new Gallerycategories();
                gallerycategories.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                gallerycategories.GaleryCategoryNameTR = dt.Rows[i]["GaleryCategoryNameTR"].ToString().Clean();
                gallerycategories.GaleryCategoryNameEN = dt.Rows[i]["GaleryCategoryNameEN"].ToString().Clean();
                gallerycategoriess.Add(gallerycategories);
            }

            connection.Close();
            return gallerycategoriess;
        }

        // Gallery
        public List<Galleries> Galleries(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from galleries" + condition.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Galleries> galleriess = new List<Galleries>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Galleries galleries = new Galleries();
                galleries.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                galleries.GaleryNameTR = dt.Rows[i]["GaleryNameTR"].ToString().Clean();
                galleries.GaleryNameEN = dt.Rows[i]["GaleryNameEN"].ToString().Clean();
                galleries.GaleryCategory = dt.Rows[i]["GaleryCategory"].ToString().Clean();
                galleries.GaleryPhoto1 = dt.Rows[i]["GaleryPhoto1"].ToString().Clean();
                galleries.GaleryPhoto2 = dt.Rows[i]["GaleryPhoto2"].ToString().Clean();
                galleries.GaleryPhoto3 = dt.Rows[i]["GaleryPhoto3"].ToString().Clean();
                galleries.GaleryPhoto4 = dt.Rows[i]["GaleryPhoto4"].ToString().Clean();
                galleriess.Add(galleries);
            }

            connection.Close();
            return galleriess;
        }

        // Partners
        public List<Partners> Partners(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from partners" + condition.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Partners> partnerss = new List<Partners>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Partners partners = new Partners();
                partners.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                partners.PartnerName = dt.Rows[i]["PartnerName"].ToString().Clean();
                partners.PartnerLogo = dt.Rows[i]["PartnerLogo"].ToString().Clean();
                partnerss.Add(partners);
            }

            connection.Close();
            return partnerss;
        }

        // Referencecategories
        public List<Referencecategories> Referencecategories(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from referencecategories" + condition.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Referencecategories> referencecategoriess = new List<Referencecategories>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Referencecategories referencecategories = new Referencecategories();
                referencecategories.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                referencecategories.ReferenceCategoryNameTR = dt.Rows[i]["ReferenceCategoryNameTR"].ToString().Clean();
                referencecategories.ReferenceCategoryNameEN = dt.Rows[i]["ReferenceCategoryNameEN"].ToString().Clean();
                referencecategoriess.Add(referencecategories);
            }

            connection.Close();
            return referencecategoriess;
        }

        // References
        public List<References> References(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();
            
            SqlDataAdapter da = new SqlDataAdapter("select * from reference" + condition.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<References> referencess = new List<References>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                References references = new References();
                references.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                references.TurkishReferenceName = dt.Rows[i]["ReferenceNameTR"].ToString().Clean();
                references.EnglishReferenceName = dt.Rows[i]["ReferenceNameEN"].ToString().Clean();
                references.ReferenceCategory = dt.Rows[i]["ReferenceCategory"].ToString().Clean();
                references.ReferenceDescriptionEN = dt.Rows[i]["ReferenceDescriptionEN"].ToString().Clean();
                references.ReferenceDescriptionTR = dt.Rows[i]["ReferenceDescriptionTR"].ToString().Clean();
                references.RefereneLogo = dt.Rows[i]["ReferenceLogo"].ToString().Clean();
                referencess.Add(references);
            }
            

            connection.Close();
            return referencess;
        }

        // Services
        public List<Services> Services(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from services" + condition.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Services> servicess = new List<Services>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Services services = new Services();
                services.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                services.ServiceTitleTR = dt.Rows[i]["ServiceTitleTR"].ToString().Clean();
                services.ServiceTitleEN = dt.Rows[i]["ServiceTitleEN"].ToString().Clean();
                services.ServiceDescriptionTR = dt.Rows[i]["ServiceDescriptionTR"].ToString().Clean();
                services.ServiceDescriptionEN = dt.Rows[i]["ServiceDescriptionEN"].ToString().Clean();
                services.ServicePhoto1 = dt.Rows[i]["ServicePhoto1"].ToString().Clean();
                services.ServicePhoto2 = dt.Rows[i]["ServicePhoto2"].ToString().Clean();
                services.ServicePhoto3 = dt.Rows[i]["ServicePhoto3"].ToString().Clean();
                services.ServicePhoto4 = dt.Rows[i]["ServicePhoto4"].ToString().Clean();
                servicess.Add(services);
            }

            connection.Close();
            return servicess;
        }

        // Slidercategories
        public List<Slidercategories> Slidercategories(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from slidercategories" + condition.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Slidercategories> slidercategoriess = new List<Slidercategories>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Slidercategories slidercategories = new Slidercategories();
                slidercategories.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                slidercategories.SliderCategoryNameTR = dt.Rows[i]["SliderCategoryNameTR"].ToString().Clean();
                slidercategories.SliderCategoryNameEN = dt.Rows[i]["SliderCategoryNameEN"].ToString().Clean();
                slidercategoriess.Add(slidercategories);
            }

            connection.Close();
            return slidercategoriess;
        }

        // Sliders
        public List<Sliders> Sliders(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from sliders" + condition.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Sliders> sliderss = new List<Sliders>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sliders sliders = new Sliders();
                sliders.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                sliders.SliderNameTR = dt.Rows[i]["SliderNameTR"].ToString().Clean();
                sliders.SliderNameEN = dt.Rows[i]["SliderNameEN"].ToString().Clean();
                sliders.SliderCategory = dt.Rows[i]["SliderCategory"].ToString().Clean();
                sliders.SliderPhoto1 = dt.Rows[i]["SliderPhoto1"].ToString().Clean();
                sliders.SliderPhoto2 = dt.Rows[i]["SliderPhoto2"].ToString().Clean();
                sliders.SliderPhoto3 = dt.Rows[i]["SliderPhoto3"].ToString().Clean();
                sliders.SliderPhoto4 = dt.Rows[i]["SliderPhoto4"].ToString().Clean();
                sliderss.Add(sliders);
            }

            connection.Close();
            return sliderss;
        }

        // StaffJobPosition
        public List<StaffJobPosition> StaffJobPosition(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from StaffJobPosition" + condition.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<StaffJobPosition> staffJobPositions = new List<StaffJobPosition>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StaffJobPosition staffJobPosition = new StaffJobPosition();
                staffJobPosition.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                staffJobPosition.StaffJobPositionTR = dt.Rows[i]["StaffJobPositionTR"].ToString().Clean();
                staffJobPosition.StaffJobPositionEN = dt.Rows[i]["StaffJobPositionEN"].ToString().Clean();
                staffJobPositions.Add(staffJobPosition);
            }

            connection.Close();
            return staffJobPositions;
        }

        // Staffs
        public List<Staffs> Staffs(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from staffs " + condition.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Staffs> allstaffs = new List<Staffs>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Staffs staffss = new Staffs();
                staffss.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                staffss.StaffName = dt.Rows[i]["StaffName"].ToString().Clean();
                staffss.StaffPhone = dt.Rows[i]["StaffPhone"].ToString().Clean();
                staffss.StaffEmail = dt.Rows[i]["StaffEmail"].ToString().Clean();
                staffss.StaffJobPosition = dt.Rows[i]["StaffJobPosition"].ToString().Clean();
                staffss.StaffProfilePhoto = dt.Rows[i]["StaffProfilePhoto"].ToString().Clean();
                allstaffs.Add(staffss);
            }

            connection.Close();
            return allstaffs;
        }

        // Pages
        public List<Pages> Pages(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from pages" + condition.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Pages> pages = new List<Pages>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Pages page = new Pages();
                page.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                page.PageTitleTR = dt.Rows[i]["PageTitleTR"].ToString().Clean();
                page.PageTitleEN = dt.Rows[i]["PageTitleEN"].ToString().Clean();
                page.PageContentTR = dt.Rows[i]["PageContentTR"].ToString().Clean();
                page.PageContentEN = dt.Rows[i]["PageContentEN"].ToString().Clean();
                page.SmallPicture = dt.Rows[i]["SmallPicture"].ToString().Clean();
                page.ContentPicture = dt.Rows[i]["ContentPicture"].ToString().Clean();
                page.PageUrl = dt.Rows[i]["PageUrl"].ToString().Clean();
                pages.Add(page);
            }

            connection.Close();
            return pages;
        }

        // News
        public List<News> News(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from News" + condition.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<News> newss = new List<News>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                News news = new News();
                news.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                news.NewsTitleTR = dt.Rows[i]["NewsTitleTR"].ToString().Clean();
                news.NewsTitleEN = dt.Rows[i]["NewsTitleEN"].ToString().Clean();
                news.NewsContentTR = dt.Rows[i]["NewsContentTR"].ToString().Clean();
                news.NewsContentEN = dt.Rows[i]["NewsContentEN"].ToString().Clean();
                news.NewsDate = dt.Rows[i]["NewsDate"].ToString().Clean();
                news.NewsImage = dt.Rows[i]["NewsImage"].ToString().Clean();
                newss.Add(news);
            }

            connection.Close();
            return newss;
        }



        // Notifications
        public List<Notification> Notification(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from notifications" + condition.ToString(), connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Notification> notifications = new List<Notification>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Notification notification = new Notification();
                notification.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                notification.NotificationDescription = dt.Rows[i]["NotificationDescription"].ToString().Clean();
                notification.SentDate = dt.Rows[i]["SentDate"].ToString().Clean();
                notification.IsRead = Convert.ToBoolean(dt.Rows[i]["IsRead"]);
                notifications.Add(notification);
            }
            connection.Close();
            return notifications;
        }

        // Top 5  Notification
        public List<Notification> NotificationTop5(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select Top(5) * from notifications " + condition.ToString() + " order by id Desc", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Notification> notifications = new List<Notification>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Notification notification = new Notification();
                notification.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                notification.NotificationDescription = dt.Rows[i]["NotificationDescription"].ToString().Clean();
                notification.SentDate = dt.Rows[i]["SentDate"].ToString().Clean();
                notification.IsRead = Convert.ToBoolean(dt.Rows[i]["IsRead"]);


                notifications.Add(notification);
            }
            connection.Close();
            return notifications;
        }
        // Product Category
        public List<Productcategory> Productcategory(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select Top(5) * from productcategory " + condition.ToString() + " order by id Desc", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Productcategory> productcategories = new List<Productcategory>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Productcategory productcategory = new Productcategory();
                productcategory.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                productcategory.ProductCategoryNameTR = dt.Rows[i]["ProductCategoryNameTR"].ToString().Clean();
                productcategory.ProductCategoryNameEN = dt.Rows[i]["ProductCategoryNameEN"].ToString().Clean();


                productcategories.Add(productcategory);
            }
            connection.Close();
            return productcategories;
        }

        // Products
        public List<Products> Products(Dictionary<string, string> parameters = null)
        {
            System.Text.StringBuilder condition = new System.Text.StringBuilder();
            if (parameters != null)
            {
                condition.Append(" where 1=1 ");
                foreach (var item in parameters)
                {
                    string ColumnName = item.Key;
                    string value = item.Value;
                    string query = string.Format(" and ({0}='{1}') ", ColumnName, value);
                    condition.Append(query);
                }
            }
            SqlConnection connection = new SqlConnection(SqlCommand);
            connection.Open();

            SqlDataAdapter da = new SqlDataAdapter("select Top(5) * from products " + condition.ToString() + " order by id Desc", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Products> products = new List<Products>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Products product = new Products();
                product.id = int.Parse(dt.Rows[i]["id"].ToString().Clean());
                product.ProductCategory = dt.Rows[i]["ProductCategoryName"].ToString().Clean();
                product.ProductNameTR = dt.Rows[i]["ProductNameTR"].ToString().Clean();
                product.ProductNameEN = dt.Rows[i]["ProductNameEN"].ToString().Clean();
                product.ProductDescriptionTR = dt.Rows[i]["ProductDescriptionTR"].ToString().Clean();
                product.ProductDescriptionEN = dt.Rows[i]["ProductDescriptionEN"].ToString().Clean();
                product.ProductCode = dt.Rows[i]["ProductCode"].ToString().Clean();
                product.ProductPhoto = dt.Rows[i]["ProductPhoto"].ToString().Clean();
                product.ProductURL = dt.Rows[i]["ProductURL"].ToString().Clean();


                products.Add(product);
            }
            connection.Close();
            return products;
        }
    }


}