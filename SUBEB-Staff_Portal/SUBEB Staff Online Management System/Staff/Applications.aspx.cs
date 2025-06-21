using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SUBEB_Staff_Online_Management_System.Staff
{
    public partial class Applications : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;
        SqlDataAdapter daApplications;
        DataSet dsApplications = new DataSet();
        SqlCommand cmdApp = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            lblMsg.Text = string.Empty;
            conn = new SqlConnection(conStr);
            string staffNo = HttpContext.Current.User.Identity.Name;
            if (fuAppLetterUpload.HasFile)
            {
                string Appcode = staffNo + DateTime.Now.Date.ToString("yyyy-MM-dd"); 
                var letter = fuAppLetterUpload.FileBytes;
                string AppDate = DateTime.Now.Date.ToString("yyyy-MM-dd");

                conn = new SqlConnection(conStr);
                conn.Open();
                daApplications = new SqlDataAdapter("SELECT StaffNo FROM tblStaffRegistration WHERE StaffNo='" + staffNo + "'", conn);
                daApplications.Fill(dsApplications, "app");
                conn.Close();

                if(dsApplications.Tables["app"].Rows.Count==1)
                {                    
                    cmdApp.Connection = conn;
                    cmdApp.CommandText = "INSERT INTO tblApplicationLetters VALUES(@appcode,@appDate, @staffno, @apptitle, @letter, @status)";
                    cmdApp.Parameters.AddWithValue("@appcode", Appcode);
                    cmdApp.Parameters.AddWithValue("@appDate", AppDate);
                    cmdApp.Parameters.AddWithValue("@staffno", staffNo);
                    cmdApp.Parameters.AddWithValue("@apptitle", ddlTitle.Text);                    
                    cmdApp.Parameters.AddWithValue("@letter", letter);
                    cmdApp.Parameters.AddWithValue("@status", "0");

                    conn.Open();
                    cmdApp.ExecuteNonQuery();
                    conn.Close();
                    cmdApp.Parameters.Clear();
                    lblMsg.Text = "Successfully uploaded";
                    
                }
                else
                {
                    connHtqrs = new SqlConnection(conStrHqtrs);
                    cmdApp.Connection = connHtqrs;
                    cmdApp.CommandText = "INSERT INTO tblApplicationLetters VALUES(@appcode,@appDate, @staffno, @apptitle, @letter, @status)";
                    cmdApp.Parameters.AddWithValue("@appcode", Appcode);
                    cmdApp.Parameters.AddWithValue("@appDate", AppDate);
                    cmdApp.Parameters.AddWithValue("@staffno", staffNo);
                    cmdApp.Parameters.AddWithValue("@apptitle", ddlTitle.Text);
                    cmdApp.Parameters.AddWithValue("@letter", letter);
                    cmdApp.Parameters.AddWithValue("@status", "0");

                    connHtqrs.Open();
                    cmdApp.ExecuteNonQuery();
                    connHtqrs.Close();
                    cmdApp.Parameters.Clear();
                    lblMsg.Text = "Successfully uploaded";

                }
            }
            else
            {
                lblMsg.Text = "Select file to upload";
                
            }
           
            
        }
    }
}