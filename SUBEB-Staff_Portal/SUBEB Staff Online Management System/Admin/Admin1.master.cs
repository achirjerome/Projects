using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SUBEB_Staff_Online_Management_System.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SUBEB_Staff_Online_Management_System.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
            //if (!(HttpContext.Current.User.IsInRole("Admin") && HttpContext.Current.User.Identity.IsAuthenticated))
            //{
            //    Response.Redirect("~/Account/Login.aspx");
            //}

        }
    }
}