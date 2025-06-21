using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SUBEB_Staff_Online_Management_System.Chairman
{   
    public partial class viewPayments : System.Web.UI.Page
    {
        DataSet dsPaySummary = new DataSet();
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtMonth_CalendarExtender.Format = "MM/dddd/yyyy";
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            int sYear = DateTime.Now.Year;
            for (int i = 2019; i <= sYear; i++)
            {
                ddlYear.Items.Add(i.ToString());
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            lblTotalStaff.Text = string.Empty;
            string payMonth = ddlMonth.Text + "-" + ddlYear.Text;       
            if(dsPaySummary.Tables.Contains("pay"))
            {
                dsPaySummary.Tables.Remove("pay");
            }

            if (dsPaySummary.Tables.Contains("count"))
            {
                dsPaySummary.Tables.Remove("count");
            }

            if (rbtLGEA.Checked == true)
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT Paymonth, LGEA, StaffCount, Grosspay, TotalDeduction, Net FROM tblPaymentSummary WHERE Paymonth ='" + payMonth + "' ORDER BY LGEA", conn);
                publicClass.daStaff.Fill(dsPaySummary, "pay");

                publicClass.daStaff = new SqlDataAdapter("SELECT SUM(StaffCount) AS StaffStrength FROM tblPaymentSummary WHERE Paymonth ='" + payMonth + "'", conn);
                publicClass.daStaff.Fill(dsPaySummary, "count");
                conn.Close();
            }
            else//Hqtrs
            {

                connHtqrs = new SqlConnection(conStrHqtrs);
                connHtqrs.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT Paymonth, Bank, staffCount, Grosspay, TotalDeduction, Net FROM tblPaymentSummary WHERE payMonth='" + payMonth + "' ORDER BY Bank", connHtqrs);
                publicClass.daStaff.Fill(dsPaySummary, "pay");

                publicClass.daStaff = new SqlDataAdapter("SELECT SUM(staffCount) AS StaffStrength  FROM tblPaymentSummary WHERE payMonth='" + payMonth + "'", connHtqrs);
                publicClass.daStaff.Fill(dsPaySummary, "count");
                connHtqrs.Close();
                //crptViewPayments viewPayment = new crptViewPayments();
                //CrystalDecisions.CrystalReports.Engine.TextObject tb = (CrystalDecisions.CrystalReports.Engine.TextObject)viewPayment.ReportDefinition.Sections["Section2"].ReportObjects["Text2"];
                //tb.Text = " SUBEB Headquarters";
            }
            //crptViewPayments viewPay = new crptViewPayments();
            //viewPay.SetDataSource(dsPaySummary.Tables["pay"]);
            lblTotalStaff.Text ="Total Staff: " + dsPaySummary.Tables["count"].Rows[0]["StaffStrength"].ToString();
            int fgg = dsPaySummary.Tables["pay"].Rows.Count;
            GridView1.DataSource = dsPaySummary.Tables["pay"];
            GridView1.DataBind();

            //CrystalReportViewer1.ReportSource = viewPay;
            //CrystalReportViewer1.DataBind();
            //CrystalReportViewer1.SeparatePages = false;
        }


        protected void CrystalReportViewer1_ReportRefresh(object source, CrystalDecisions.Web.ViewerEventArgs e)
        {
            crptViewPayments viewPay = new crptViewPayments();
            viewPay.DataSourceConnections[0].SetConnection("JeromePC", "SUBEBStaffMgtDB", "sa", "Admin1$");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //decimal result;
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (decimal.TryParse(e.Row.Cells[4].Text, out result))
            //    {
            //        e.Row.Cells[3].Text = result.ToString("000,000,000.00");
            //        e.Row.Cells[4].Text = result.ToString("000,000,000.00");
            //        e.Row.Cells[5].Text = result.ToString("000,000,000.00");
                    
            //    }
            //}
        }
    }
}