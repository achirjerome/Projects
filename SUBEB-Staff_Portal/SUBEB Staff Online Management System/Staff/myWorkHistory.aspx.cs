using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace SUBEB_Staff_Online_Management_System.Staff
{
    public partial class myWorkHistory : System.Web.UI.Page
    {
        DataSet dsWorkHistory = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //GridView1.Width = Panel4.Width;
                if (dsWorkHistory.Tables.Contains("current"))
                {
                    dsWorkHistory.Tables["current"].Clear();
                }

                if (dsWorkHistory.Tables.Contains("history"))
                {
                    dsWorkHistory.Tables["history"].Clear();
                }

                if (dsWorkHistory.Tables.Contains("bio"))
                {
                    dsWorkHistory.Tables["bio"].Clear();
                }
                string StaffNo = HttpContext.Current.User.Identity.Name;
                publicClass.connectToDB();
                publicClass.daStaff = new SqlDataAdapter("Select tblStaffRegistration.staffno, tblStaffRegistration.Surname + ' ' + tblStaffRegistration.Firstname + ' ' + tblStaffRegistration.middlename AS Name, tblStaffRegistration.Pix, tblposting.Workstation, tblPosting.WorkLGEA from tblStaffRegistration INNER JOIN tblPosting ON tblStaffRegistration.staffno=tblPosting.StaffNo WHERE tblStaffRegistration.staffno='" + StaffNo + "'", publicClass.conn);
                publicClass.daStaff.Fill(dsWorkHistory, "bio");
                Label1.Text = dsWorkHistory.Tables["bio"].Rows[0]["Name"].ToString();
                lblWorkstation.Text = dsWorkHistory.Tables["bio"].Rows[0]["workstation"].ToString();
                lblWorkLGEA.Text= dsWorkHistory.Tables["bio"].Rows[0]["workLGEA"].ToString();


                publicClass.daStaff = new SqlDataAdapter("Select tblPostingHistory.Workstation, tblPostingHistory.WorkLGEA, tblPostingHistory.fromDate As [Start Date], tblPostingHistory.toDate AS [Transfer Date] From tblPostingHistory WHERE tblPostingHistory.staffno='" + StaffNo + "'", publicClass.conn);
                publicClass.daStaff.Fill(dsWorkHistory, "history");

                //    publicClass.daStaff = new SqlDataAdapter("Select tblPosting.staffno, tblWorkStation.schoolName, tblPosting.fromDate As [Start Date] From tblPosting INNER JOIN tblWorkStation ON tblPosting.WorkStation=tblWorkStation.SchoolCode WHERE tblPosting.staffno='" + txtStaffNo.Text + "'", publicClass.conn);
                //    publicClass.daStaff.Fill(dsWorkHistory, "current");

                //    dsWorkHistory.Tables["history"].Rows.Add(dsWorkHistory.Tables["current"].Rows[0]["staffno"].ToString(),
                //        dsWorkHistory.Tables["current"].Rows[0]["SchoolName"].ToString(),
                //        dsWorkHistory.Tables["current"].Rows[0]["Start Date"].ToString(), string.Empty);
                //dsWorkHistory.Tables["history"].Rows[0]["Start Date"]=DateTime.Parse(dsWorkHistory.Tables["history"].Rows[0]["Start Date"].ToString()).ToShortDateString();
                //GridView1.Width = Panel4.Width;
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