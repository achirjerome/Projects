using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SUBEB_Staff_Online_Management_System.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SUBEB_Staff_Online_Management_System.Admin
{
    public partial class RegisterEs : System.Web.UI.Page
    {
        DataSet dsEs = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_Init(object sender, EventArgs e)
        {
            publicClass.connectToDB();
            publicClass.daStaff = new SqlDataAdapter("SELECT LGEA FROM tblLGAs", publicClass.conn);
            publicClass.daStaff.Fill(dsEs, "lga");

            ddlLGEA.DataTextField = "LGEA";
            ddlLGEA.DataSource = dsEs.Tables["lga"];
            ddlLGEA.DataBind();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            publicClass.connectToDB();
            publicClass.daStaff = new SqlDataAdapter("SELECT Username FROM ASPNetUsers WHERE Username='" + txtUserName.Text + "'", publicClass.conn);
            publicClass.daStaff.Fill(dsEs, "exist");

            if(dsEs.Tables["exist"].Rows.Count>0)
            {
                lblMsg.Text = "Username must be different from staffNo";
            }
            else
            {
                publicClass.connectToDB();
                publicClass.daStaff = new SqlDataAdapter("SELECT tblStaffRegistration.PhoneNo, tblStaffRegistration.Email, tblPosting.WorkLGEA FROM tblStaffRegistration INNER JOIN tblPosting ON tblStaffRegistration.StaffNo=tblPosting.StaffNo WHERE tblStaffRegistration.StaffNo='" + txtStaffNo.Text + "'", publicClass.conn);
                publicClass.daStaff.Fill(dsEs, "phone");

                if (dsEs.Tables["phone"].Rows.Count == 1)
                {
                    string LGEA = dsEs.Tables["phone"].Rows[0]["WorkLGEA"].ToString();
                    string phoneNo = dsEs.Tables["phone"].Rows[0]["PhoneNo"].ToString();
                    string eMail= dsEs.Tables["phone"].Rows[0]["Email"].ToString();

                    if (LGEA == ddlLGEA.Text)//Staff belongs to that LGEA
                    {
                        var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
                        var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                        var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                        var user = new ApplicationUser() { UserName = txtUserName.Text, Email=eMail };
                        IdentityResult result = manager.Create(user, "Subeb.12345");

                        if (result.Succeeded)
                        {
                            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                            //string code = manager.GenerateEmailConfirmationToken(user.Id);
                            //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                            //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                            //signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                            var bnm = um.FindByName(txtUserName.Text);
                            if (!um.IsInRole(bnm.Id, "ES"))
                            {
                                var userResult = um.AddToRole(bnm.Id, "ES");
                            }

                            IdentityHelper.RedirectToReturnUrl("~/Account/Login.aspx", Response);
                        }
                        else
                        {
                            lblMsg.Text = result.Errors.FirstOrDefault();
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Staff does not work in the selected LGEA";
                    }
                }

            }
        }
    }
}