using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SUBEB_Staff_Online_Management_System.Staff
{
    public partial class Staff : System.Web.UI.MasterPage
    {
        DataSet dsRetireLetter = new DataSet();
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string staffNo = HttpContext.Current.User.Identity.Name;
            //if (!(HttpContext.Current.User.IsInRole("Staff") && HttpContext.Current.User.Identity.IsAuthenticated))
            //{
            //    Response.Redirect("~/Account/Login.aspx");
            //}
            conn = new SqlConnection(conStr);
            conn.Open();
            publicClass.daStaff = new SqlDataAdapter("SELECT StaffNo FROM tblRetirees WHERE StaffNo='" + staffNo + "'", conn);
            publicClass.daStaff.Fill(dsRetireLetter, "let");

            if(dsRetireLetter.Tables["let"].Rows.Count ==1)
            {
                Panel1.Visible = false;
                lnkRetirementLetter.Visible = true;
            }
            else
            {
                Panel1.Visible = true;
                lnkRetirementLetter.Visible = false;
            }
        }
    }
}