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
    public partial class ViewAppilcations : System.Web.UI.Page
    {
        DataSet dsApp = new DataSet();
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnViewPnding_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            if(rbtLGEA.Checked==true)
            {
                publicClass.dbLGEA = true;
                conn = new SqlConnection(conStr);
                conn.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT StaffNo, AppTitle AS Title, AppDate AS Date, Appletter FROM tblApplicationLetters WHERE Status=0", conn);
                publicClass.daStaff.Fill(dsApp, "letter");
                conn.Close();

                GridView1.DataSource = dsApp.Tables["letter"];
                GridView1.DataBind();
            }
            else
            {
                publicClass.dbLGEA = false;
                connHtqrs = new SqlConnection(conStrHqtrs);
                connHtqrs.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT StaffNo, AppTitle AS Title, AppDate AS Date, Appletter FROM tblApplicationLetters WHERE Status=0", connHtqrs);
                publicClass.daStaff.Fill(dsApp, "letter");
                connHtqrs.Close();

                GridView1.DataSource = dsApp.Tables["letter"];
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var secondCell = e.Row.Cells[2];
                secondCell.Controls.Clear();
                HyperLink hl = new HyperLink();
                hl.Text = secondCell.Text;
                hl.NavigateUrl = "~/Admin/viewAppLetters.aspx?id=" + dsApp.Tables["letter"].Rows[e.Row.RowIndex]["StaffNo"].ToString() + "&appdate=" + dsApp.Tables["letter"].Rows[e.Row.RowIndex]["Date"].ToString();
                secondCell.Controls.Add(hl);
            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            if (rbtLGEA.Checked == true)
            {
                publicClass.dbLGEA = true;
                conn = new SqlConnection(conStr);
                conn.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT StaffNo, AppTitle AS Title, AppDate AS Date, Appletter FROM tblApplicationLetters", conn);
                publicClass.daStaff.Fill(dsApp, "letter");
                conn.Close();

                GridView1.DataSource = dsApp.Tables["letter"];
                GridView1.DataBind();
            }
            else
            {
                publicClass.dbLGEA = false;
                connHtqrs = new SqlConnection(conStrHqtrs);
                connHtqrs.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT StaffNo, AppTitle AS Title, AppDate AS Date, Appletter FROM tblApplicationLetters", connHtqrs);
                publicClass.daStaff.Fill(dsApp, "letter");
                connHtqrs.Close();

                GridView1.DataSource = dsApp.Tables["letter"];
                GridView1.DataBind();
            }
        }
    }
}