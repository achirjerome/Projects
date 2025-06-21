using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SUBEB_Staff_Online_Management_System.Admin
{
    public partial class SummaryStaffList : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;

        public DataSet SelectWorkPlace(string LGEA)
        {
            conn = new SqlConnection(conStr);
            conn.Open();
           
            DataSet dsWork = new DataSet();
            if (publicClass.dbLGEA == true)
            {                
                publicClass.daStaff = new SqlDataAdapter("SELECT School FROM tblWorkstations WHERE LGEA='" + LGEA + "' ORDER BY School", conn);
                publicClass.daStaff.Fill(dsWork, "workplace");                
            }
            conn.Close();
            return dsWork;
        }       
        DataSet dstaffRecord = new DataSet();
        DataSet dsSchools = new DataSet();
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                DataSet dsStaffList = new DataSet();
                if (rbtLGEA.Checked == true)
                {
                    rbtAllStaff.Enabled = false;
                }


                if (publicClass.dbLGEA == true)//LGEA DB
                {
                    conn = new SqlConnection(conStr);
                    conn.Open();
                    publicClass.daStaff = new SqlDataAdapter("SELECT DISTINCT LGEA FROM tblWorkStations ORDER BY LGEA", conn);
                    publicClass.daStaff.Fill(dsStaffList, "lgea");
                    conn.Close();

                    ddlLGEA.DataTextField = "LGEA";
                    ddlLGEA.DataSource = dsStaffList.Tables["lgea"];
                    ddlLGEA.DataBind();

                    if (dsStaffList.Tables["lgea"].Rows.Count > 0)
                    {
                        DataSet dtWork = SelectWorkPlace(ddlLGEA.Text);
                        ddlSchools.DataTextField = "School";
                        ddlSchools.DataSource = dtWork.Tables[0];
                        ddlSchools.DataBind();
                    }
                }
            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            

            //if (rbtAllStaff.Checked==true)
            //{

            //}
            //else
            //{
            //    if(rbtStaffByWorkStation.Checked==true)
            //    {

            //    }
            //}
            //string PSN = HttpContext.Current.User.Identity.Name;
            //publicClass.connectToDB();
            //publicClass.daStaff = new SqlDataAdapter("SELECT tblStaffRegistration.PSN, tblStaffRegistration.SurName + ' ' + tblStaffRegistration.MiddleName + ' ' + tblStaffRegistration.FirstName AS Name, tblStaffRegistration.Sex, tblStaffRegistration.PhoneNo, tblStaffRegistration.HighestQualification, tblStaffRegistration.Speciality AS [Field of Study], tblStaffRegistration.DateofAppointment AS [Date of First Appointment], tblStaffRegistration.JobTitle AS [Job Type], tblPosting.PPA AS WorkStation, tblCurrentLevel.[GradeLevel/Step] AS [Grade Level], tblCurrentLevel.DateofPromotion AS Date of Last Promotion, tblCurrentLevel.Rank, tblNextOfKin.FirstName AS KinFirstName,  tblNextOfKin.MiddleName AS KinMiddleName,  tblNextOfKin.SurName AS KinSurName,  tblNextOfKin.Relationship,  tblNextOfKin.ContactAddress AS [KinContact Address],  tblNextOfKin.PhoneNo AS KinPhoneNo FROM tblStaffRegistration INNER JOIN tblNextOfKin ON tblStaffRegistration.PSN = tblNextOfKin.AdminNo INNER JOIN tblPosting ON tblStaffRegistration.PSN = tblPosting.PSN INNER JOIN tblCurrentLevel ON tblStaffRegistration.PSN = tblCurrentLevel.PSN", publicClass.conn);
            //publicClass.daStaff.Fill(dstaffRecord, "record");

            //if (dstaffRecord.Tables["record"].Rows.Count > 0)
            //{
            //    GridView1.DataSource = dstaffRecord.Tables["record"];
            //    GridView1.DataBind();
            //}
        }

        protected void ddlSchools_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            //try
            //{
           
           
               
                
            if (rbtStaffByWorkStation.Checked == true)
            {
                publicClass.dbLGEA = true;
                if(dstaffRecord.Tables.Contains("list"))
                {
                    dstaffRecord.Tables.Remove("list");
                }

                conn = new SqlConnection(conStr);
                conn.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT tblPosting.staffNo, tblStaffRegistration.SurName, tblStaffRegistration.FirstName, tblStaffRegistration.Sex, tblStaffRegistration.JobTitle AS [Job Type] FROM tblPosting INNER JOIN tblStaffRegistration ON tblPosting.staffno= tblSTaffRegistration.Staffno WHERE tblPosting.Workstation='" + ddlSchools.Text + "' AND tblPosting.workLGEA='" + ddlLGEA.Text + "'", conn);
                publicClass.daStaff.Fill(dstaffRecord, "list");
                conn.Close();

                int dfgg = dstaffRecord.Tables["list"].Rows.Count;                  
                    

            }
                
            if(rbtLGEANames.Checked==true)
            {
                publicClass.dbLGEA = true;
                if (dstaffRecord.Tables.Contains("list"))
                {
                    dstaffRecord.Tables.Remove("list");
                }
                conn = new SqlConnection(conStr);
                if (dstaffRecord.Tables.Contains("list"))
                {
                    dstaffRecord.Tables.Remove("list");
                }
                conn.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT tblPosting.staffNo, tblStaffRegistration.Surname, tblStaffRegistration.Firstname, tblStaffRegistration.Sex, tblStaffRegistration.JobTitle AS [Job Type] FROM tblPosting INNER JOIN tblStaffRegistration ON tblPosting.StaffNo=tblStaffRegistration.staffNo WHERE tblPosting.workLGEA='" + ddlLGEA.Text + "'", conn);
                publicClass.daStaff.Fill(dstaffRecord, "list");
                conn.Close();

                       
            }
                         

           
            if (rbtAllStaff.Checked == true)
            {
                publicClass.dbLGEA = false;
                if (dstaffRecord.Tables.Contains("list"))
                {
                    dstaffRecord.Tables.Remove("list");
                }
                connHtqrs = new SqlConnection(conStrHqtrs);

                connHtqrs.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT tblPosting.staffNo, tblStaffRegistration.SurName, tblStaffRegistration.FirstName, tblStaffRegistration.Sex, tblStaffRegistration.JobTitle AS [Job Type] FROM tblPosting INNER JOIN tblStaffRegistration ON tblPosting.staffno= tblSTaffRegistration.Staffno ORDER BY tblStaffRegistration.Surname", connHtqrs);
                publicClass.daStaff.Fill(dstaffRecord, "list");

                connHtqrs.Close();

            }
            
            DataTable dtIncremented = new DataTable(dstaffRecord.Tables["list"].ToString());
            DataColumn dc = new DataColumn("S/No");
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 1;
            dc.AutoIncrementStep = 1;
            dc.DataType = typeof(Int32);
            dtIncremented.Columns.Add(dc);

            dtIncremented.BeginLoadData();

            DataTableReader dtReader = new DataTableReader(dstaffRecord.Tables["list"]);
            dtIncremented.Load(dtReader);

            dtIncremented.EndLoadData();

            GridView1.DataSource = dtIncremented;
            GridView1.DataBind();
            
        }

        protected void rbtLGEA_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtLGEA.Checked == true)
            {
                rbtAllStaff.Checked = false;
                rbtAllStaff.Enabled = false;               
                rbtStaffByWorkStation.Enabled = true;
                rbtLGEANames.Enabled = true;
            }
           
        }

        protected void rbtHqtrs_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtHqtrs.Checked == true)
            {
                rbtAllStaff.Enabled = true;
                rbtAllStaff.Checked = true;
                rbtStaffByWorkStation.Enabled = false;
                rbtLGEANames.Enabled = false;
            }
            
        }

        protected void ddlLGEA_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dtWork = SelectWorkPlace(ddlLGEA.Text);
            ddlSchools.DataTextField = "School";
            ddlSchools.DataSource = dtWork.Tables[0];
            ddlSchools.DataBind();
        }

        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var firstCell = e.Row.Cells[1];
                firstCell.Controls.Clear();
                HyperLink hl = new HyperLink();
                hl.Text = firstCell.Text;
                if (rbtLGEA.Checked == true)
                {
                    hl.NavigateUrl = "~/Admin/staffBioAdmin.aspx?id=" + dstaffRecord.Tables["list"].Rows[e.Row.RowIndex]["staffNo"].ToString() + "&DB=1";
                    hl.Target = "_blank";
                }
                else
                {
                    hl.NavigateUrl = "~/Admin/staffBioAdmin.aspx?id=" + dstaffRecord.Tables["list"].Rows[e.Row.RowIndex]["staffNo"].ToString() + "&DB=0";
                    hl.Target = "_blank";
                }
                firstCell.Controls.Add(hl);
            }
        }
    }
}