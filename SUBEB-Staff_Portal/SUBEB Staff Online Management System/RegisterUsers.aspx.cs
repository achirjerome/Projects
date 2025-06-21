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


namespace SUBEB_Staff_Online_Management_System
{
    public partial class RegisterUsers : System.Web.UI.Page
    {
        DataSet dsReg = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //publicClass.connectToHqtrsDB();
            //publicClass.daStaff = new SqlDataAdapter("SELECT staffno, email FROM tblstaffRegistration", publicClass.connHqtrs);
            //publicClass.daStaff.Fill(dsReg, "reg");
            //publicClass.connHqtrs.Close();
            //if(dsReg.Tables["reg"].Rows.Count>0)
            //{
                string staffnum = string.Empty;
                string staffEmail = string.Empty;
                string password = string.Empty;
                publicClass.connectToDB();
            //for (int i=0; i<dsReg.Tables["reg"].Rows.Count; i++)
            //{
            staffnum = "702";// dsReg.Tables["reg"].Rows[i]["StaffNo"].ToString();
                    staffEmail = staffnum + "@subeb.be.gov.ng";//dsReg.Tables["reg"].Rows[i]["email"].ToString();
                    password = "Subeb.12345";
                    //if(string.IsNullOrEmpty(staffEmail))
                    //{
                    //    staffEmail = "staff." + staffnum + "@benuesubeb.gov.ng";
                    //}
                    //if (staffnum != "702")
                    //{
                        var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
                        var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                        //var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                        var user = new ApplicationUser() { UserName = staffnum, Email = staffEmail };
                        IdentityResult result = manager.Create(user, password);
                        var staffid = um.FindByName(staffnum);
                        if (!um.IsInRole(staffid.Id, "Chairman"))
                        {
                            var userResult = um.AddToRole(staffid.Id, "Chairman");
                        }
                    //}
                //}
                //publicClass.conn.Close();
                Label1.Text = "Done";
            //}
        }

        protected void sendSMS_Click(object sender, EventArgs e)
        {
            Label1.Text = string.Empty;
            publicClass.connectToDB();
            publicClass.daStaff = new SqlDataAdapter("select StaffNo, PhoneNo from tblStaffRegistration where PhoneNo is not null AND Staffno IN (SELECT staffNo FROM tblPVPermanentIncomes WHERE LGEA Like '%Katsina%')", publicClass.conn);
            publicClass.daStaff.Fill(dsReg, "ph");
            publicClass.conn.Close();
            if (dsReg.Tables["ph"].Rows.Count > 0)
            {
                for (int i = 0; i < dsReg.Tables["ph"].Rows.Count; i++)
                {
                    string phone_number = dsReg.Tables["ph"].Rows[i]["phoneNo"].ToString();
                    string staffno = dsReg.Tables["ph"].Rows[i]["staffNo"].ToString();
                    string msg = "Welcome to SUBEB Online;subeb.be.gov.ng. Username:'" + staffno + "' password:Subeb.12345. Galaxy Analytica Ltd.";
                    sendText msgHqtrs = new sendText();
                    msgHqtrs.sendSMS(phone_number, msg);

                }
                Label1.Text = "Done";
            }


            //Label1.Text = string.Empty;
            //publicClass.connectToDB();
            //publicClass.daStaff = new SqlDataAdapter("SELECT StaffNo, PhoneNo, SurName FROM tblStaffRegistration WHERE DateofBirth LIKE '%08-21'", publicClass.conn);
            //publicClass.daStaff.Fill(dsReg, "ph");
            //publicClass.conn.Close();
            //if (dsReg.Tables["ph"].Rows.Count > 0)
            //{
            //for (int i = 80; i < dsReg.Tables["ph"].Rows.Count; i++)
            //{
            //string phone_number = dsReg.Tables["ph"].Rows[i]["phoneNo"].ToString();
            //string staffno = dsReg.Tables["ph"].Rows[i]["staffNo"].ToString();
            //string surname = dsReg.Tables["ph"].Rows[i]["surname"].ToString();
            //string msg = "Happy birthday'" + surname + "'. Enjoy ur day. From all of us @ SUBEB. Powered by: Galaxy Analytica Ltd.";
            //sendText msgHqtrs = new sendText();
            //msgHqtrs.sendSMS(phone_number, msg);

            //}
            //Label1.Text = "Done";
            //}
        }
    }
}