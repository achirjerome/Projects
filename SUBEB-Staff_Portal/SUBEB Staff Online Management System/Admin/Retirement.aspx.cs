using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
//using CrystalDecisions.ReportSource;
//using System.IO;
using System.Configuration;
using System.Data;

namespace SUBEB_Staff_Online_Management_System.Admin
{
    public partial class Retirement : System.Web.UI.Page
    {
        DataTable dtRetirees = new DataTable();
        protected void setDbInfo(ReportDocument rpt, string ServerName, string DatabaseName, string UserName, string Password)
        {
            TableLogOnInfo logoninfo = new TableLogOnInfo();
            foreach (CrystalDecisions.CrystalReports.Engine.Table t in rpt.Database.Tables)
            {
                logoninfo = t.LogOnInfo;
                logoninfo.ReportName = rpt.Name;
                logoninfo.ConnectionInfo.ServerName = ServerName;
                logoninfo.ConnectionInfo.DatabaseName = DatabaseName;
                logoninfo.ConnectionInfo.UserID = UserName;
                logoninfo.ConnectionInfo.Password = Password;
                logoninfo.TableName = t.Name;
                t.ApplyLogOnInfo(logoninfo);
                t.Location = t.Name;
            }
        }

        protected void DisplayReport()
        {
            //try
            //{
                ReportDocument rpt = new ReportDocument();
                rpt.Load(Server.MapPath("~/Admin/crptRetirement.rpt"));
                string ServerName = ConfigurationManager.AppSettings["Server"].ToString();
                string DatabaseName = ConfigurationManager.AppSettings["DBName"].ToString();
                string UserName = ConfigurationManager.AppSettings["UserName"].ToString();
                string Password = ConfigurationManager.AppSettings["Password"].ToString();
                setDbInfo(rpt, ServerName, DatabaseName, UserName, Password);
                //CrystalReportViewer1.ReportSource = rpt;
                //CrystalReportViewer1.RefreshReport();
            //ConfigurationManager.AppSettings[""]
            //}
            //catch (Exception exc)
            //{
            //    //throw exc;
            //}
        }
        public DataTable selectRetirement(string eRetireDateString)
        {
            DataSet dsRetire = new DataSet();
            string selectCriteria = eRetireDateString;
            
            if(dsRetire.Tables.Contains("retire"))
            {
                dsRetire.Tables.Remove("retire");
            }
            
            publicClass.connectToDB();
            publicClass.daStaff = new SqlDataAdapter("SELECT tblStaffRegistration.StaffNo, tblStaffRegistration.Surname, tblStaffRegistration.FirstName, tblPosting.Workstation, tblPosting.WorkLGEA, tblRetirementDate.RetirementDate, tblRetirementDate.RetirementReason FROM tblStaffRegistration INNER JOIN tblPosting ON tblStaffRegistration.StaffNo=tblPosting.StaffNo INNER JOIN tblRetirementDate ON tblSTaffRegistration.StaffNo=tblRetirementDate.StaffNo WHERE tblRetirementDate.RetirementDate ='" + selectCriteria + "' ORDER BY tblRetirementDate.REtirementDate", publicClass.conn);
            publicClass.daStaff.Fill(dsRetire, "retire");
            return dsRetire.Tables["retire"];
        }

        //Select staff based on retirement year
        public DataTable selectRetireYr(int yrRetire)
        {
            DataSet dsRetire = new DataSet();
            //string selectCriteria = retireDateString;

            if (dsRetire.Tables.Contains("retire"))
            {
                dsRetire.Tables.Remove("retire");
            }

            publicClass.connectToDB();
            publicClass.daStaff = new SqlDataAdapter("SELECT tblStaffRegistration.StaffNo, tblStaffRegistration.Surname, tblStaffRegistration.FirstName, tblStaffRegistration.DateofBirth, tblStaffRegistration.DateofAppointment, tblPosting.workstation, tblRetirementDate.RetirementDate, tblRetirementDate.RetirementReason FROM tblStaffRegistration INNER JOIN tblPosting ON tblStaffRegistration.StaffNo=tblPosting.StaffNo INNER JOIN tblRetirementDate on tblStaffRegistration.StaffNo=tblRetirementDate.StaffNo WHERE YEAR(tblRetirementDate.RetirementDate)='" + yrRetire + "' ORDER BY tblRetirementDate.RetirementDate", publicClass.conn);
            publicClass.daStaff.Fill(dsRetire, "retire");
            return dsRetire.Tables["retire"];
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //{
            //    // DisplayReport();
            //    int fhfn = dtRetirees.Rows.Count;
            //    crptRetirement retireReport = new crptRetirement();
            //    retireReport.SetDataSource(dtRetirees);
            //    CrystalReportViewer1.ReportSource = retireReport;
            //}
            //Panel4.Visible = false;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                DateTime endDate;
                DateTime startDate;
                string endRetireDate = string.Empty;
                string DateToRetire = string.Empty;
                DateTime selectedDate;

                int monthToRetire;
                int yrToRetire;
                int noofDays;
                dtRetirees = null;
                if (rbtThisMonth.Checked == true)
                {
                    //Retrieve the no of days in this month
                    monthToRetire = currentDate.Month;
                    yrToRetire = currentDate.Year;
                    noofDays = DateTime.DaysInMonth(yrToRetire, monthToRetire);
                    //startDate= DateTime.Parse(yrToRetire + "-" + monthToRetire + "-" + "1");
                    endDate = DateTime.Parse(yrToRetire + "-" + monthToRetire + "-" + noofDays);
                    //startRetireDate=startDate.ToString("yyyy-MM-dd");
                    endRetireDate = endDate.ToString("yyyy-MM-dd");
                    dtRetirees = selectRetirement(endRetireDate);
                }
                else
                {
                    if (rbtThisYear.Checked == true)
                    {
                        yrToRetire = currentDate.Year;

                        dtRetirees = selectRetireYr(yrToRetire);
                    }
                    else
                    {
                        if (rbtSelectDate.Checked == true)
                        {
                            if (!(string.IsNullOrEmpty(txtSelectDate.Text)))
                            {
                                selectedDate = DateTime.Parse(txtSelectDate.Text);
                                DateToRetire = selectedDate.ToString("yyyy-MM-dd");
                                dtRetirees = selectRetirement(DateToRetire);
                            }
                        }
                    }
                }

                if (dtRetirees.Rows.Count > 0)
                {
                    DataTable dtIncremented = new DataTable(dtRetirees.TableName);
                    DataColumn dc = new DataColumn("Col1");
                    dc.AutoIncrement = true;
                    dc.AutoIncrementSeed = 1;
                    dc.AutoIncrementStep = 1;
                    dc.DataType = typeof(Int32);
                    dtIncremented.Columns.Add(dc);

                    dtIncremented.BeginLoadData();

                    DataTableReader dtReader = new DataTableReader(dtRetirees);
                    dtIncremented.Load(dtReader);

                    dtIncremented.EndLoadData();

                    GridView1.DataSource = dtIncremented;
                    GridView1.DataBind();
                    Panel4.Visible = true;
                }
                else { Panel4.Visible = false; }
            }
            catch(Exception ex)
            {

            }
        }

        protected void CrystalReportViewer1_ReportRefresh(object source, CrystalDecisions.Web.ViewerEventArgs e)
        {
            //DisplayReport();
            //crptRetirement retirees = new crptRetirement();
            //retirees.DataSourceConnections[0].SetConnection("JeromePC", "SUBEBStaffMgtDB", "sa", "Admin1$");
            ////crptRetirement retireReport = new crptRetirement();

            //retireReport.SetDataSource(dtRetirees);
            //CrystalReportViewer1.ReportSource = retireReport;
        }

        protected void txtSelectDate_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}