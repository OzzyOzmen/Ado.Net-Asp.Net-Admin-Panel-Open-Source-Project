using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanel.ajax
{
    /// <summary>
    /// Summary description for UploadService
    /// </summary>
    public class UploadService : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string resultPath = "";
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                HttpPostedFile file = files[0];
                string fileName = context.Server.MapPath("~/Content/img/uploads/" + file.FileName);
                int sayac = 1;
                string orjName = fileName;
                while (System.IO.File.Exists(fileName))
                {
                    fileName = orjName.Insert(orjName.Length - 4, "_" + sayac);
                    sayac++;
                }
                file.SaveAs(fileName);
                resultPath = System.IO.Path.GetFileName(fileName);
                resultPath = "/Content/img/uploads/" + resultPath;

            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(resultPath);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}