using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DesignTemplate1.Lecturer
{
    public partial class LecturerMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //the first 2 to be replaced with a staff the logs in and his department 
            Session["department"] = "DEPARTMENT OF COMPUTER SCIENCE";
            Session["user"] = "PF2739";
            Lecturer_image.Src = "lect_images/home.jpg";
        }
    }
}