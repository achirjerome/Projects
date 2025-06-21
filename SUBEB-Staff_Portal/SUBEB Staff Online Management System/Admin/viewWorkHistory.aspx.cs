using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;
using System.Configuration;

namespace SUBEB_Staff_Online_Management_System.Admin
{
    public partial class viewWorkHistory : System.Web.UI.Page
    {
        DataSet dsWorkHistory = new DataSet();
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                if (!(IsPostBack))
                {
                    //if (dsWorkHistory.Tables.Contains("staffno"))
                    //{
                    //    dsWorkHistory.Tables["staffno"].Clear();
                    //}
                    //publicClass.connectToDB();
                    //publicClass.daStaff = new SqlDataAdapter("Select staffNo, FirstName, middlename, SurName, pix from tblStaffRegistration", publicClass.conn);
                    //publicClass.daStaff.Fill(dsWorkHistory, "staffno");

                    //if (dsWorkHistory.Tables["staffno"].Rows.Count > 0)
                    //{
                    //    ddlWorkHistory.DataTextField = "staffno";
                    //    ddlWorkHistory.DataValueField = "staffno";
                    //    ddlWorkHistory.DataSource = dsWorkHistory.Tables["staffno"];
                    //    ddlWorkHistory.DataBind();
                    //    Image2.ImageUrl = string.Empty;
                    //    Image2.ImageUrl = "~/staffPix.ashx?id=" + ddlWorkHistory.Text;
                    //    Label1.Text = dsWorkHistory.Tables["staffno"].Rows[0]["Surname"].ToString() + " " + dsWorkHistory.Tables["staffno"].Rows[0]["FirstName"].ToString() + " " + dsWorkHistory.Tables["staffno"].Rows[0]["MiddleName"].ToString();
                    //}
                }

            //}
            //catch (Exception ex)
            //{
            //    Label2.Text = ex.Message;
            //}
           
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Label2.Text = string.Empty;
            try
            {
                GridView1.Width = Panel4.Width;
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
                if (rbtLGEA.Checked == true)
                {
                    publicClass.dbLGEA = true;
                    conn = new SqlConnection(conStr);
                    conn.Open();
                    publicClass.daStaff = new SqlDataAdapter("Select tblStaffRegistration.staffno, tblStaffRegistration.Surname + ' ' + tblStaffRegistration.Firstname + ' ' + tblStaffRegistration.middlename AS Name, tblStaffRegistration.Pix, tblposting.Workstation from tblStaffRegistration INNER JOIN tblPosting ON tblStaffRegistration.staffno=tblPosting.StaffNo WHERE tblStaffRegistration.staffno='" + txtStaffNo.Text + "'", conn);
                    publicClass.daStaff.Fill(dsWorkHistory, "bio");
                    

                    Label1.Text = dsWorkHistory.Tables["bio"].Rows[0]["Name"].ToString();
                    lblWorkstation.Text = dsWorkHistory.Tables["bio"].Rows[0]["workstation"].ToString();


                    publicClass.daStaff = new SqlDataAdapter("Select tblPostingHistory.staffno, tblPostingHistory.fromDate As [Start Date], tblPostingHistory.toDate AS [Transfer Date] From tblPostingHistory WHERE tblPostingHistory.staffno='" + txtStaffNo.Text + "'", publicClass.conn);
                    publicClass.daStaff.Fill(dsWorkHistory, "history");
                    conn.Close();

                    //    publicClass.daStaff = new SqlDataAdapter("Select tblPosting.staffno, tblWorkStation.schoolName, tblPosting.fromDate As [Start Date] From tblPosting INNER JOIN tblWorkStation ON tblPosting.WorkStation=tblWorkStation.SchoolCode WHERE tblPosting.staffno='" + txtStaffNo.Text + "'", publicClass.conn);
                    //    publicClass.daStaff.Fill(dsWorkHistory, "current");

                    //    dsWorkHistory.Tables["history"].Rows.Add(dsWorkHistory.Tables["current"].Rows[0]["staffno"].ToString(),
                    //        dsWorkHistory.Tables["current"].Rows[0]["SchoolName"].ToString(),
                    //        dsWorkHistory.Tables["current"].Rows[0]["Start Date"].ToString(), string.Empty);
                    //dsWorkHistory.Tables["history"].Rows[0]["Start Date"]=DateTime.Parse(dsWorkHistory.Tables["history"].Rows[0]["Start Date"].ToString()).ToShortDateString();

                }
                else//Hqtrs
                {
                    publicClass.dbLGEA = false;
                    connHtqrs = new SqlConnection(conStrHqtrs);
                    connHtqrs.Open();
                    publicClass.daStaff = new SqlDataAdapter("Select tblStaffRegistration.staffno, tblStaffRegistration.Surname + ' ' + tblStaffRegistration.Firstname + ' ' + tblStaffRegistration.middlename AS Name, tblStaffRegistration.Pix, tblposting.Workstation from tblStaffRegistration INNER JOIN tblPosting ON tblStaffRegistration.staffno=tblPosting.StaffNo WHERE tblStaffRegistration.staffno='" + txtStaffNo.Text + "'", connHtqrs);
                    publicClass.daStaff.Fill(dsWorkHistory, "bio");
                   

                    Label1.Text = dsWorkHistory.Tables["bio"].Rows[0]["Name"].ToString();
                    lblWorkstation.Text = dsWorkHistory.Tables["bio"].Rows[0]["workstation"].ToString();


                    publicClass.daStaff = new SqlDataAdapter("Select tblPostingHistory.staffno, tblPostingHistory.fromDate As [Start Date], tblPostingHistory.toDate AS [Transfer Date] From tblPostingHistory WHERE tblPostingHistory.staffno='" + txtStaffNo.Text + "'", connHtqrs);
                    publicClass.daStaff.Fill(dsWorkHistory, "history");
                    connHtqrs.Close();
                }
                GridView1.Width = Panel4.Width;
                GridView1.DataSource = dsWorkHistory.Tables["history"];
                GridView1.DataBind();
                //Image2.ImageUrl = string.Empty;
                Image2.ImageUrl = "~/staffPix.ashx?id=" + txtStaffNo.Text;


            }
            catch (Exception ex)
            {
                Label2.Text = ex.Message;
            }
        }

        protected void ddlWorkHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dsWorkHistory.Tables.Contains("psn"))
            //    {
            //        dsWorkHistory.Tables["psn"].Clear();
            //    }
            //    publicClass.daStaff = new SqlDataAdapter("Select PSN, FirstName, middlename, SurName from tblStaffRegistration WHERE PSN='" + ddlWorkHistory.Text + "'", publicClass.conn);
            //    publicClass.daStaff.Fill(dsWorkHistory, "psn");
            //    Label1.Text = dsWorkHistory.Tables["psn"].Rows[0]["Surname"].ToString() + " " + dsWorkHistory.Tables["psn"].Rows[0]["FirstName"].ToString() + " " + dsWorkHistory.Tables["psn"].Rows[0]["MiddleName"].ToString();
            //}
            //catch (Exception ex)
            //{
            //    Label2.Text = ex.Message;
            //}
        }
    }
}