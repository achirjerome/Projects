using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;

namespace SUBEB_Staff_Online_Management_System.Chairman
{
    public partial class StaffCount : System.Web.UI.Page
    {
        DataSet dsStaffCount = new DataSet();
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            if(dsStaffCount.Tables.Contains("count"))
            {
                dsStaffCount.Tables.Remove("count");
            }
            if (rbtLGEA.Checked == true)
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT tblPosting.WorkLGEA, COUNT(tblStaffRegistration.staffNo) AS StaffCount FROM tblPosting INNER JOIN tblStaffRegistration ON tblPosting.StaffNo=tblStaffRegistration.StaffNo GROUP BY WorkLGEA ORDER BY WorkLGEA", conn);
                publicClass.daStaff.Fill(dsStaffCount, "count");

                publicClass.daStaff = new SqlDataAdapter("SELECT COUNT(tblStaffRegistration.staffNo) AS StaffCount FROM tblStaffRegistration INNER JOIN tblPosting ON tblStaffRegistration.StaffNo=tblPosting.StaffNo", conn);
                publicClass.daStaff.Fill(dsStaffCount, "total");
                conn.Close();

                Panel2.Visible = true;
                lblHqtrsStaffCount.Visible = true;

                DataTable dtIncremented = new DataTable(dsStaffCount.Tables["count"].ToString());
                if (dsStaffCount.Tables["count"].Rows.Count > 0)
                {
                    
                    DataColumn dc = new DataColumn("S/No");
                    dc.AutoIncrement = true;
                    dc.AutoIncrementSeed = 1;
                    dc.AutoIncrementStep = 1;
                    dc.DataType = typeof(Int32);
                    dtIncremented.Columns.Add(dc);

                    dtIncremented.BeginLoadData();

                    DataTableReader dtReader = new DataTableReader(dsStaffCount.Tables["count"]);
                    dtIncremented.Load(dtReader);
                    dtIncremented.EndLoadData();
                }

                GridView1.DataSource = dtIncremented;
                GridView1.DataBind();
                lblHqtrsStaffCount.Text = "Total LGEA Staff Strength:" + dsStaffCount.Tables["total"].Rows[0]["staffcount"].ToString();



                //crptStaffCount staffCountReport = new crptStaffCount();
                //staffCountReport.SetDataSource(dsStaffCount.Tables["count"]);
                //staffCountReport.DataSourceConnections[0].SetConnection("JeromePC", "SUBEBStaffMgtDB", "sa", "Admin1$");
                //ReportDocument rdStaffCount = new ReportDocument();
                //rdStaffCount.Load(Server.MapPath("~/Chairman/crptStaffCount.rpt"));
                //rdStaffCount.SetDataSource(dsStaffCount.Tables["count"]);
                //CrystalReportViewer1.ReportSource = rdStaffCount; ;
                //CrystalReportViewer1.DataBind();
            }
            else//Hqtrs
            {
                connHtqrs = new SqlConnection(conStrHqtrs);
                connHtqrs.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT COUNT(staffNo) StaffCount FROM tblStaffRegistration", connHtqrs);
                publicClass.daStaff.Fill(dsStaffCount, "count");
                connHtqrs.Close();

                //crptStaffCount staffCountReport = new crptStaffCount();
                //staffCountReport.SetDataSource(dsStaffCount.Tables["count"]);
                //CrystalReportViewer1.ReportSource = staffCountReport;
                //CrystalReportViewer1.DataBind();
                Panel2.Visible = false;
                lblHqtrsStaffCount.Visible = true;
                lblHqtrsStaffCount.Text = "Headquaters Staff Strength: "  + dsStaffCount.Tables["count"].Rows[0]["staffcount"].ToString();
            }
        }
    }
}