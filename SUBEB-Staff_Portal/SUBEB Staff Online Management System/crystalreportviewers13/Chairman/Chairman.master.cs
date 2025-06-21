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
    public partial class Chairman : System.Web.UI.MasterPage
    {
        SqlDataAdapter daNot;
        DataSet dsNot = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {          
            int LGAStff = 0;
            int HqtrsStaff = 0;
            int allStaff = 0;
            SqlConnection conn;
            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connHtqrs;
            string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
            //newReg.Font.Italic=

            if (dsNot.Tables.Contains("lga"))
            {
                dsNot.Tables.Remove("lga");
            }

            if (dsNot.Tables.Contains("hqtrs"))
            {
                dsNot.Tables.Remove("hqtrs");
            }

            conn = new SqlConnection(conStr);
            conn.Open();
            daNot = new SqlDataAdapter("SELECT staffNo FROM TemptblStaffRegistration", conn);
            daNot.Fill(dsNot, "lga");

            if (dsNot.Tables["lga"].Rows.Count > 0)
            {
                LGAStff = dsNot.Tables["lga"].Rows.Count;
            }

            connHtqrs = new SqlConnection(conStrHqtrs);
            connHtqrs.Open();


            daNot = new SqlDataAdapter("SELECT staffNo FROM TemptblStaffRegistration", connHtqrs);
            daNot.Fill(dsNot, "hqtrs");



            if (dsNot.Tables["hqtrs"].Rows.Count > 0)
            {
                HqtrsStaff = dsNot.Tables["hqtrs"].Rows.Count;
            }

            //Add both LGEA and Hqtrs new staff
            allStaff = LGAStff + HqtrsStaff;
            if (allStaff > 0)
            {
                lblReg.Text = "New " + allStaff;
                lblReg.Visible = true;
            }
            else
            {
                lblReg.Visible = false;
            }

        }
    }
}