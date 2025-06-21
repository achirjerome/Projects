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
    public partial class staffPromotionHistory : System.Web.UI.Page
    {
        DataSet dsPromotionHistory = new DataSet();
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPSHN_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void btnViewCert_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (rbtLGEA.Checked == true)
            {
                conn = new SqlConnection(conStr);
                if(dsPromotionHistory.Tables.Contains("history"))
                {
                    dsPromotionHistory.Tables.Remove("history");
                }

                conn.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT StaffNo, FirstName, MiddleName, SurName FROM tblStaffRegistration WHERE StaffNo='" + txtStaffNo.Text + "'", conn);
                publicClass.daStaff.Fill(dsPromotionHistory, "history");
                

                lblName.Text = dsPromotionHistory.Tables["history"].Rows[0]["Surname"].ToString() + " " +
                    dsPromotionHistory.Tables["history"].Rows[0]["FirstName"].ToString() + " " +
                    dsPromotionHistory.Tables["history"].Rows[0]["MiddleName"].ToString();
                
                publicClass.daStaff = new SqlDataAdapter("SELECT Gradelevelstep FROM tblCurrentLevel WHERE StaffNo='" + txtStaffNo.Text + "'", conn);
                publicClass.daStaff.Fill(dsPromotionHistory, "grade");

                lblLevel.Text = dsPromotionHistory.Tables["grade"].Rows[0]["Gradelevelstep"].ToString();

                publicClass.daStaff = new SqlDataAdapter("SELECT PromotionDate AS [Date of Promotion], GradeLevel, Rank FROM tblPromotionHistory Where StaffNo='" + txtStaffNo.Text + "'", conn);
                publicClass.daStaff.Fill(dsPromotionHistory, "promotionhistory");

                conn.Close();
                GridView1.DataSource = dsPromotionHistory.Tables["promotionhistory"];
                GridView1.DataBind();

                

            }
            //}
            //catch (Exception ex)
            //{
            //    Label2.Text = ex.Message;
            //}
        }
    }
}