using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Configuration;
using System.Threading;
using System.Globalization;
using AdminPanel.Class;

namespace AdminPanel
{
    public class Global : HttpApplication
    {

        DbJobs jobs = new DbJobs();
        public List<Languages> languagess = new List<Languages>();
        Languages languages = new Languages();

        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            // This will work with every request..

            HttpCookie cookie = Request.Cookies["locale"];

            if (cookie != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(cookie.Value);

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(cookie.Value);
            }
            else
            {
                //Querying the languages

                string language = Request.UserLanguages[0].ToLowerInvariant().Trim();

                CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture(language);

                Languages lang = jobs.Languages().Where(x => x.DisplayName == cultureInfo.DisplayName).SingleOrDefault();
                // The languages will chosing on browser will compare with the languages which are comes from dbase
                // otherwise default lang will be set as current language
                if (lang != null)
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(lang.DisplayName);

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang.DisplayName);

                    HttpCookie newCookie = new HttpCookie("locale");

                    newCookie.Value = lang.DisplayName;

                    newCookie.Expires = DateTime.UtcNow.AddDays(7);

                    Response.Cookies.Add(newCookie);
                }
                else
                {
                    // Chosing the default language

                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                    HttpCookie newCookie = new HttpCookie("locale");

                    newCookie.Value = "en-US";

                    newCookie.Expires = DateTime.UtcNow.AddDays(7);

                    Response.Cookies.Add(newCookie);
                }
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            CultureInfo newCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            newCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            newCulture.DateTimeFormat.DateSeparator = "/";
            Thread.CurrentThread.CurrentCulture = newCulture;
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}