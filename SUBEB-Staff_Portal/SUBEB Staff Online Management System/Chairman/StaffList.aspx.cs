using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;

namespace SUBEB_Staff_Online_Management_System.Chairman
{
    public partial class StaffList : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;

        public DataSet SelectWorkPlace(string LGEA)
        {
            DataSet dsWork = new DataSet();
            if (publicClass.dbLGEA == true)
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT School FROM tblWorkstations WHERE LGEA='" + LGEA + "' ORDER BY School", conn);
                publicClass.daStaff.Fill(dsWork, "workplace");
                conn.Close();
            }
            return dsWork;
        }
        DataSet dstaffRecord = new DataSet();
        DataSet dsSchools = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
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

        
        protected void ddlLGEA_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dtWork = SelectWorkPlace(ddlLGEA.Text);
            ddlSchools.DataTextField = "School";
            ddlSchools.DataSource = dtWork.Tables[0];
            ddlSchools.DataBind();
        }

        protected void ddlLGEA_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (rbtLGEA.Checked == true)
            {
                rbtAllStaff.Enabled = false;
                rbtStaffByWorkStation.Enabled = true;
                rbtLGEANames.Enabled = true;
            }
        }

        protected void rbtLGEA_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtLGEA.Checked == true)
            {
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

        protected void ddlSchools_SelectedIndexChanged(object sender, EventArgs e)
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
                    hl.NavigateUrl = "~/staffBio.aspx?id=" + dstaffRecord.Tables["list"].Rows[e.Row.RowIndex]["staffNo"].ToString();
                    hl.Target = "_blank";
                }
                else
                {
                    hl.NavigateUrl = "~/STaffBio.aspx?id=" + dstaffRecord.Tables["list"].Rows[e.Row.RowIndex]["staffNo"].ToString();
                    hl.Target = "_blank";
                    //if (!(dsApproval.Tables["hqtrs"].Columns.Contains("Action")))
                    //{
                    //    dsApproval.Tables["hqtrs"].Columns.Add("Action");
                    //}
                }
                firstCell.Controls.Add(hl);
            }
        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            //try
            //{

            if (rbtLGEA.Checked == true)
            {
                publicClass.dbLGEA = true;
                if (rbtStaffByWorkStation.Checked == true)
                {
                    if (dstaffRecord.Tables.Contains("list"))
                    {
                        dstaffRecord.Tables.Remove("list");
                    }

                    conn = new SqlConnection(conStr);
                    conn.Open();
                    publicClass.daStaff = new SqlDataAdapter("SELECT tblPosting.staffNo, tblStaffRegistration.SurName, tblStaffRegistration.FirstName, tblStaffRegistration.Sex, tblStaffRegistration.JobTitle FROM tblPosting INNER JOIN tblStaffRegistration ON tblPosting.staffno= tblSTaffRegistration.Staffno WHERE tblPosting.Workstation='" + ddlSchools.Text + "' AND tblPosting.workLGEA='" + ddlLGEA.Text + "'", conn);
                    publicClass.daStaff.Fill(dstaffRecord, "list");
                    conn.Close();
                    int dfgg = dstaffRecord.Tables["list"].Rows.Count;

                    ReportDocument ListDoc = new ReportDocument();
                    crptStaffList stafflist = new crptStaffList();
                    stafflist.SetDataSource(dstaffRecord.Tables["list"]);
                    CrystalDecisions.CrystalReports.Engine.TextObject tb = (CrystalDecisions.CrystalReports.Engine.TextObject)stafflist.ReportDefinition.Sections["Section1"].ReportObjects["Text8"];

                    if (ddlSchools.Text == "PV NO 001 - ADMIN STAFF")
                    {
                        tb.Text = ddlSchools.Text + " at " + ddlLGEA.Text;
                    }
                    else
                    {
                        tb.Text = "Staff List at " + ddlSchools.Text + ", " + ddlLGEA.Text;
                    }
                    //stafflist.DataSourceConnections[0].SetConnection("JeromePC", "SUBEBStaffMgtDB", "sa", "Admin1$");
                    ListDoc.Load(Server.MapPath("~/crptStaffList.rpt"));

                    ////crptCertificate report = new crptCertificate();
                    //ListDoc.SetDataSource(dstaffRecord.Tables["list"]);
                    //CrystalReportViewer2.ReportSource = ListDoc;
                    //CrystalReportViewer2.DataBind();
                    //CrystalReportViewer2.SeparatePages = false;



                    ////report.DataSourceConnections[0].SetConnection("JeromePC", "SUBEBStaffMgtDB", "sa", "Admin1$");


                }
                else
                {
                    if (rbtLGEANames.Checked == true)
                    {
                        if (dstaffRecord.Tables.Contains("list"))
                        {
                            dstaffRecord.Tables.Remove("list");
                        }
                        conn = new SqlConnection(conStr);
                        conn.Open();
                        publicClass.daStaff = new SqlDataAdapter("SELECT tblPosting.staffNo, tblStaffRegistration.SurName, tblStaffRegistration.FirstName, tblStaffRegistration.Sex, tblStaffRegistration.JobTitle FROM tblPosting INNER JOIN tblStaffRegistration ON tblPosting.staffno= tblSTaffRegistration.Staffno WHERE tblPosting.workLGEA='" + ddlLGEA.Text + "' ORDER BY tblStaffRegistration.JobTitle", conn);
                        publicClass.daStaff.Fill(dstaffRecord, "list");
                        conn.Close();
                        int dfgg = dstaffRecord.Tables["list"].Rows.Count;
                        crptStaffList stafflist = new crptStaffList();
                        stafflist.SetDataSource(dstaffRecord.Tables["list"]);
                        CrystalDecisions.CrystalReports.Engine.TextObject tb = (CrystalDecisions.CrystalReports.Engine.TextObject)stafflist.ReportDefinition.Sections["Section1"].ReportObjects["Text8"];
                        tb.Text = " Staff List at " + ddlLGEA.Text;
                        //stafflist.DataSourceConnections[0].SetConnection("JeromePC", "SUBEBStaffMgtDB", "sa", "Admin1$");
                        //CrystalReportViewer2.ReportSource = stafflist;
                        //CrystalReportViewer2.DataBind();
                        //CrystalReportViewer2.SeparatePages = false;
                    }
                }



            }
            else//Hqtrs
            {
                publicClass.dbLGEA = false;
                if (dstaffRecord.Tables.Contains("list"))
                {
                    dstaffRecord.Tables.Remove("list");
                }
                connHtqrs = new SqlConnection(conStrHqtrs);
                connHtqrs.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT tblStaffRegistration.staffNo, tblStaffRegistration.SurName, tblStaffRegistration.FirstName, tblStaffRegistration.Sex, tblStaffRegistration.JobTitle AS [Job Type] FROM tblStaffRegistration ORDER BY tblSTaffRegistration.Surname", connHtqrs);
                publicClass.daStaff.Fill(dstaffRecord, "list");
                connHtqrs.Close();
                //string vgfd = dstaffRecord.Tables["list"].Columns[2].ColumnName;
                //int dfgg = dstaffRecord.Tables["list"].Rows.Count;
                //crptStaffList stafflist = new crptStaffList();
                //stafflist.SetDataSource(dstaffRecord.Tables["list"]);
                ////Reference text8 in section 1 in code
                //CrystalDecisions.CrystalReports.Engine.TextObject tb = (CrystalDecisions.CrystalReports.Engine.TextObject)stafflist.ReportDefinition.Sections["Section1"].ReportObjects["Text8"];
                //tb.Text = " Staff List SUBEB Hqtrs";

                //CrystalReportViewer2.ReportSource = stafflist;
                //CrystalReportViewer2.DataBind();
                //CrystalReportViewer2.SeparatePages = false;
            }

            DataTable dtIncremented = new DataTable(dstaffRecord.Tables["list"].ToString());
            if (dstaffRecord.Tables["list"].Rows.Count > 0)
            {

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
            }

            GridView1.DataSource = dtIncremented;
            GridView1.DataBind();
        }
    }
}