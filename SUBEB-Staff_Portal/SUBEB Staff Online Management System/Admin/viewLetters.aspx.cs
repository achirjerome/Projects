using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SUBEB_Staff_Online_Management_System.Admin
{
    public partial class viewLetters : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            Image1.ImageUrl = "~/ScrutinyLetters.ashx?id=" + id;
        }
    }
}