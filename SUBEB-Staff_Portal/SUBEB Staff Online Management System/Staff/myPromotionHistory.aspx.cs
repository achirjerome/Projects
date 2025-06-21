using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SUBEB_Staff_Online_Management_System.Staff
{
    public partial class myPromotionHistory : System.Web.UI.Page
    {
        DataSet dsWorkHistory = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (dsWorkHistory.Tables.Contains("history"))
                {
                    dsWorkHistory.Tables["history"].Clear();
                }

                if (dsWorkHistory.Tables.Contains("bio"))
                {
                    dsWorkHistory.Tables["bio"].Clear();
                }
                string StaffNo = HttpContext.Current.User.Identity.Name;
                publicClass.picID = StaffNo;
                publicClass.connectToDB();
                //publicClass.daStaff = new SqlDataAdapter("Select tblStaffRegistration.staffno, tblStaffRegistration.Surname + ' ' + tblStaffRegistration.Firstname + ' ' + tblStaffRegistration.middlename AS Name, tblStaffRegistration.Pix, tblposting.Workstation from tblStaffRegistration INNER JOIN tblPosting ON tblStaffRegistration.staffno=tblPosting.StaffNo WHERE tblStaffRegistration.staffno='" + txtStaffNo.Text + "'", publicClass.conn);
                //publicClass.daStaff.Fill(dsWorkHistory, "bio");
                //Label1.Text = dsWorkHistory.Tables["bio"].Rows[0]["Name"].ToString();
                //lblWorkstation.Text = dsWorkHistory.Tables["bio"].Rows[0]["workstation"].ToString();


                publicClass.daStaff = new SqlDataAdapter("Select tblPromotionHistory.PromotionDate, tblPromotionHistory.GradeLevel, tblPromotionHistory.Rank FROM tblPromotionHistory WHERE tblPromotionHistory.staffno='" + StaffNo + "'", publicClass.conn);
                publicClass.daStaff.Fill(dsWorkHistory, "history");

                GridView1.DataSource = dsWorkHistory.Tables["history"];
                GridView1.DataBind();
                Image3.ImageUrl = string.Empty;
                Image3.ImageUrl = "~/staffPix.ashx?id=" + StaffNo;


            }
            catch (Exception ex)
            {
                //Label2.Text = ex.Message;
            }
        }
    }
}