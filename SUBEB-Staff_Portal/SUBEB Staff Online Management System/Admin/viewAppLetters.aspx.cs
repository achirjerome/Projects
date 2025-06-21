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
    public partial class viewAppLetters : System.Web.UI.Page
    {
        DataSet dsApp = new DataSet();
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;
        SqlCommand cmdTreated = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string AppDate = Request.QueryString["appdate"];
            Image1.ImageUrl = "~/AppLetter.ashx?id=" + id + "&appdate=" + AppDate;
        }

        protected void btnTreated_Click(object sender, EventArgs e)
        {
            if(publicClass.dbLGEA==true)
            {
                conn = new SqlConnection(conStr);
                cmdTreated.Connection = conn;
                cmdTreated.CommandText = "UPDATE tblApplicationLetters SET status=1";
                conn.Open();
                cmdTreated.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                connHtqrs = new SqlConnection(conStrHqtrs);
                cmdTreated.Connection = connHtqrs;
                cmdTreated.CommandText = "UPDATE tblApplicationLetters SET status=1";
                connHtqrs.Open();
                cmdTreated.ExecuteNonQuery();
                connHtqrs.Close();
            }
        }
    }
}