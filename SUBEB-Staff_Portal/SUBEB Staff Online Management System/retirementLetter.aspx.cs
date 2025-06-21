using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;  

namespace SUBEB_Staff_Online_Management_System
{
    public partial class retirementLetter : System.Web.UI.Page
    {
        DataSet dsRetireLetter = new DataSet();
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string staffNo = HttpContext.Current.User.Identity.Name;
            conn = new SqlConnection(conStr);
            conn.Open();
            publicClass.daStaff = new SqlDataAdapter("SELECT * FROM tblRetirees  WHERE StaffNo='" + staffNo + "'", conn);
            publicClass.daStaff.Fill(dsRetireLetter, "letter");

            if(dsRetireLetter.Tables["letter"].Rows.Count ==1)
            {
                DateTime retireDate = DateTime.Parse(dsRetireLetter.Tables["letter"].Rows[0]["RetirementDate"].ToString());
                string staffReitreDate = retireDate.ToString("yyyy-MM-dd");
                lblName.Text= dsRetireLetter.Tables["letter"].Rows[0]["surname"].ToString() + ' ' + dsRetireLetter.Tables["letter"].Rows[0]["Firstname"].ToString();
                lblStaffNo.Text= dsRetireLetter.Tables["letter"].Rows[0]["staffNo"].ToString();
                lblRetirementDate.Text = staffReitreDate;
                lblRetirementDate0.Text = staffReitreDate;
                lblRetirementReason.Text= dsRetireLetter.Tables["letter"].Rows[0]["RetirementReason"].ToString();

                publicClass.dbLGEA = true;
                Image2.ImageUrl= "~/RetireePix.ashx?id=" + lblStaffNo.Text;
            }
            else
            {
                //Hqtrs
                connHtqrs = new SqlConnection(conStrHqtrs);
                connHtqrs.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT * FROM tblRetirees  WHERE StaffNo='" + staffNo + "'", connHtqrs);
                publicClass.daStaff.Fill(dsRetireLetter, "letter");

                if (dsRetireLetter.Tables["letter"].Rows.Count == 1)
                {
                    DateTime retireDate = DateTime.Parse(dsRetireLetter.Tables["letter"].Rows[0]["RetirementDate"].ToString());
                    string staffReitreDate = retireDate.ToString("yyyy-MM-dd");
                    lblName.Text = dsRetireLetter.Tables["letter"].Rows[0]["surname"].ToString() + ' ' + dsRetireLetter.Tables["letter"].Rows[0]["Firstname"].ToString();
                    lblStaffNo.Text = dsRetireLetter.Tables["letter"].Rows[0]["staffNo"].ToString();
                    lblRetirementDate.Text = staffReitreDate;
                    lblRetirementDate0.Text = staffReitreDate;
                    lblRetirementReason.Text = dsRetireLetter.Tables["letter"].Rows[0]["RetirementReason"].ToString();

                    publicClass.dbLGEA = true;
                    Image2.ImageUrl = "~/RetireePix.ashx?id=" + lblStaffNo.Text;
                }

            }
        }
    }
}