using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SUBEB_Staff_Online_Management_System.Chairman
{
    public partial class scrutinyLetters : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string queryDate= Request.QueryString["queryDate"];
            Image1.ImageUrl = "~/ScrutinyLetters.ashx?id=" + id + "&queryDate=" + queryDate; 
            
        }
    }
}