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
    public partial class index : ControlPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbluyari.Text = " DİKKAT !!!DEMO AMAÇLI GÖSTERİM OLDUĞU İÇİN GÜVENLİK AÇISINDAN TÜM BUTONLARIN ( SİLME LİNKLERİ DAHİL ) TIKLANMA OLAYINI DEVRE DIŞI BIRAKTIM.";

        }
    }
}