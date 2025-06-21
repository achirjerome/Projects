using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace DesignTemplate1.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(HttpContext.Current.User.Identity.IsAuthenticated)
            {
                user_image.Src = "/Pictures/padlock.jpg";
                label_name.Text = HttpContext.Current.User.Identity.Name;
            }
            Session["department"] = "DEPARTMENT OF COMPUTER SCIENCE";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //FormsAuthentication.SignOut();
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //Session.Clear();            
            Response.Redirect("/");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/");
        }
    }
}