using System;
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
    public partial class Login : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(username.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        //SqlDataAdapter daPhone = new SqlDataAdapter("SELECT PhoneNo FROM tblStaffRegistration WHERE staffNo='" + StaffNo + "'", conn);
                        //daPhone.Fill(dsPhoneNo, "phone");

                        //if (dsPhoneNo.Tables["phone"].Rows.Count > 0)
                        //{
                        //    if (!(string.IsNullOrEmpty(dsPhoneNo.Tables["phone"].Rows[0]["Phoneno"].ToString())))
                        //    {
                        //        string PhoneNo = "07037839080";// dsPhoneNo.Tables["phone"].Rows[0]["Phoneno"].ToString();
                        //        sendText newSMS = new sendText();
                        //        newSMS.sendSMS(PhoneNo, "You changed your next of kin. If you were not the one please call " + publicClass.HelpNo + "'.");
                        //    }
                        //}
                        //conn.Close();
                        var userto = um.FindByName(username.Text);
                        if(um.IsInRole(userto.Id, "Staff"))
                        {
                            IdentityHelper.RedirectToReturnUrl("~/Staff/StaffPage.aspx", Response);
                        }
                        //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        if (um.IsInRole(userto.Id, "Chairman"))
                        {
                            IdentityHelper.RedirectToReturnUrl("~/Chairman/ChairmanMainPage.aspx", Response);
                            
                        }

                        if (um.IsInRole(userto.Id, "Admin"))
                        {
                            IdentityHelper.RedirectToReturnUrl("~/Admin/AdminPage.aspx", Response);
                        }
                       
                        if (um.IsInRole(userto.Id, "ES"))
                        {
                            IdentityHelper.RedirectToReturnUrl("~/ES/ESAdmin.aspx", Response);
                        }
                        break;

                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                        Request.QueryString["ReturnUrl"],
                                                        RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }
    }
}