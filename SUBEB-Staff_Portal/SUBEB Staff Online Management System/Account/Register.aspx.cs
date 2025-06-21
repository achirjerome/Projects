using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SUBEB_Staff_Online_Management_System.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data;
using System.Data.SqlClient;

namespace SUBEB_Staff_Online_Management_System.Account
{
    public partial class Register : Page
    {
        DataSet dsReg = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!(HttpContext.Current.User.Identity.IsAuthenticated && HttpContext.Current.User.IsInRole("Admin")))
            {
                Response.Redirect("~/Account/Login.aspx");
            }

        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Username.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                //signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                var bnm = um.FindByEmail(Email.Text);
                if (!um.IsInRole(bnm.Id, "Admin"))
                {
                    var userResult = um.AddToRole(bnm.Id, "Admin");
                }


                IdentityHelper.RedirectToReturnUrl("~/Account/AccoutSuccess.aspx", Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }

            //publicClass.connectToDB();
            //publicClass.daStaff = new SqlDataAdapter("SELECT staffno, email FROM tblstaffRegistration", publicClass.conn);
            //publicClass.daStaff.Fill(dsReg, "reg");
            //if (dsReg.Tables["reg"].Rows.Count > 0)
            //{
            //    string staffnum = string.Empty;
            //    string staffEmail = string.Empty;
            //    string password = string.Empty;

            //    //for (int i = 0; i < dsReg.Tables["reg"].Rows.Count; i++)
            //    //{
            //    //    staffnum = dsReg.Tables["reg"].Rows[i]["StaffNo"].ToString();
            //    //    staffEmail = dsReg.Tables["reg"].Rows[i]["email"].ToString();
            //    //    password = "SUBEB." + staffnum;
            //    //    if (string.IsNullOrEmpty(staffEmail))
            //    //    {
            //    //        staffEmail = "staff." + staffnum + "@benuesubeb.gov.ng";
            //    //    }

            //    //    var user = new ApplicationUser() { UserName = staffnum, Email = staffEmail };
            //    //    IdentityResult result = manager.Create(user, password);
            //    //    var staffid = um.FindByName(staffnum);
            //    //    if (result.Succeeded)
            //    //    {
            //    //        if (!um.IsInRole(staffid.Id, staffnum))
            //    //        {
            //    //            var userResult = um.AddToRole(staffid.Id, "Staff");
            //    //        }
            //    //    }

            //    //}
            //    ////Label1.Text = "Done";
            //}
        }
    }
}