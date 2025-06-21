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
using System.Data;
using System.Data.SqlClient;

namespace SUBEB_Staff_Online_Management_System.Admin
{
    public partial class RegisterStaff : System.Web.UI.Page
    {
        DataSet dsReg = new DataSet();
        int noofusers = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            publicClass.connectToDB();
            publicClass.daStaff = new SqlDataAdapter("SELECT staffno, email FROM tblstaffRegistration", publicClass.conn);
            publicClass.daStaff.Fill(dsReg, "reg");
            if (dsReg.Tables["reg"].Rows.Count > 0)
            {
                string staffnum = string.Empty;
                string staffEmail = string.Empty;
                string password = "Subeb.12345";

                var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

                if (!roleManager.RoleExists("Staff"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Staff";
                    roleManager.Create(role);
                }


                for (int i = 0; i < dsReg.Tables["reg"].Rows.Count; i++)
                {
                    staffnum = dsReg.Tables["reg"].Rows[i]["StaffNo"].ToString();
                    staffEmail = "email" + dsReg.Tables["reg"].Rows[i]["staffNo"].ToString() + "@subeb.gov.ng";

                    var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
                    var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                    var user = new ApplicationUser() { UserName = staffnum, Email = staffEmail };
                    IdentityResult result = manager.Create(user, password);                   

                    
                    if (result.Succeeded)
                    {
                        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                        //string code = manager.GenerateEmailConfirmationToken(user.Id);
                        //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                        //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                        //signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                        var bnm = um.FindByName(staffnum);
                        if (!um.IsInRole(bnm.Id, "Staff"))
                        {
                            var userResult = um.AddToRole(bnm.Id, "Staff");
                        }
                        noofusers += 1;

                        //IdentityHelper.RedirectToReturnUrl("~/Account/AccoutSuccess.aspx", Response);
                    }
                    else
                    {
                        //ErrorMessage.Text = result.Errors.FirstOrDefault();
                    }

                }
                //Label1.Text = "Done";
            }
            Label1.Text = noofusers.ToString();
        }
    }
}