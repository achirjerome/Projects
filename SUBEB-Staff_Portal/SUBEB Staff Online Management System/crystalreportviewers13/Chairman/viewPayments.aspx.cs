using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SUBEB_Staff_Online_Management_System.Chairman
{
    public partial class viewPayments : System.Web.UI.Page
    {
        DataSet dsPaySummary = new DataSet();
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
            string payMonth = ddlMonth.Text + "-" + ddlYear.Text;       
            if(dsPaySummary.Tables.Contains("pay"))
            {
                dsPaySummary.Tables.Remove("pay");
            }

            if (rbtLGEA.Checked == true)
            {

                publicClass.connectToDB();
                publicClass.daStaff = new SqlDataAdapter("SELECT Paymonth, LGEA, SUM(Grosspay) AS GrosspayAmount, SUM(TotalDeduction) AS TotalDeductionAmount, SUM(Net) AS NetPay FROM tblSalaryPV WHERE payMonth='" + payMonth + "' GROUP BY LGEA, PayMonth ORDER BY LGEA", publicClass.conn);
                publicClass.daStaff.Fill(dsPaySummary, "pay");
            }
            else//Hqtrs
            {

                publicClass.connectToHqtrsDB();
                publicClass.daStaff = new SqlDataAdapter("SELECT Paymonth, Bank, SUM(Grosspay) AS GrosspayAmount, SUM(TotalDeduction) AS TotalDeductionAmount, SUM(Net) AS NetPay FROM tblPayRol WHERE payMonth='" + payMonth + "' GROUP BY Bank, PayMonth ORDER BY Bank", publicClass.connHqtrs);
                publicClass.daStaff.Fill(dsPaySummary, "pay");

                crptViewPayments viewPayment = new crptViewPayments();
                CrystalDecisions.CrystalReports.Engine.TextObject tb = (CrystalDecisions.CrystalReports.Engine.TextObject)viewPayment.ReportDefinition.Sections["Section2"].ReportObjects["Text2"];
                tb.Text = " SUBEB Headquarters";
            }
            crptViewPayments viewPay = new crptViewPayments();
            viewPay.SetDataSource(dsPaySummary.Tables["pay"]);
            
            CrystalReportViewer1.ReportSource = viewPay;
            CrystalReportViewer1.DataBind();
            CrystalReportViewer1.SeparatePages = false;
        }


        protected void CrystalReportViewer1_ReportRefresh(object source, CrystalDecisions.Web.ViewerEventArgs e)
        {
            crptViewPayments viewPay = new crptViewPayments();
            viewPay.DataSourceConnections[0].SetConnection("JeromePC", "SUBEBStaffMgtDB", "sa", "Admin1$");
        }
    }
}