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
    public partial class Scrutiny : System.Web.UI.Page
    {
        DataSet dsScrutiny = new DataSet();
        SqlConnection conn;
        SqlConnection connHtqrs;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblName.Text = string.Empty;
            Image2.ImageUrl = null;
            if (rbtLGEA.Checked == true)
            {
                publicClass.dbLGEA = true;
                conn = new SqlConnection(conStr);
                conn.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT Surname + ' ' + FirstName + ' ' + Middlename AS Name FROM tblStaffRegistration WHERE StaffNo='" + txtSTaffNo.Text + "'", conn);
                publicClass.daStaff.Fill(dsScrutiny, "staff");
                conn.Close();

                if (dsScrutiny.Tables["staff"].Rows.Count > 0)
                {
                    lblName.Text = dsScrutiny.Tables["staff"].Rows[0]["Name"].ToString();
                    Image2.ImageUrl = "~/staffPix.ashx?id=" + txtSTaffNo.Text;

                    conn.Open();
                    publicClass.daStaff = new SqlDataAdapter("SELECT StaffNo, QueryReason, QueryDate FROM tblScrutiny WHERE StaffNo='" + txtSTaffNo.Text + "'", conn);
                    publicClass.daStaff.Fill(dsScrutiny, "query");
                    conn.Close();

                    if (dsScrutiny.Tables["query"].Rows.Count > 0)
                    {
                        GridView1.DataSource = dsScrutiny.Tables["query"];
                        GridView1.DataBind();
                    }
                }
            }
            else
            {
                publicClass.dbLGEA = false;
                connHtqrs = new SqlConnection(conStrHqtrs);
                connHtqrs.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT Surname + ' ' + FirstName + ' ' + Middlename AS Name FROM tblStaffRegistration WHERE StaffNo='" + txtSTaffNo.Text + "'", connHtqrs);
                publicClass.daStaff.Fill(dsScrutiny, "staff");
                connHtqrs.Close();

                if (dsScrutiny.Tables["staff"].Rows.Count > 0)
                {
                    lblName.Text = dsScrutiny.Tables["staff"].Rows[0]["Name"].ToString();
                    Image2.ImageUrl = "~/staffPix.ashx?id=" + txtSTaffNo.Text;

                    connHtqrs.Open();
                    publicClass.daStaff = new SqlDataAdapter("SELECT StaffNo, QueryReason, QueryDate FROM tblScrutiny WHERE StaffNo='" + txtSTaffNo.Text + "'", connHtqrs);
                    publicClass.daStaff.Fill(dsScrutiny, "query");
                    connHtqrs.Close();

                    if (dsScrutiny.Tables["query"].Rows.Count > 0)
                    {
                        GridView1.DataSource = dsScrutiny.Tables["query"];
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.DataRow)
            {
                var secondCell = e.Row.Cells[1];
                secondCell.Controls.Clear();
                HyperLink hl = new HyperLink();
                hl.Text = secondCell.Text;
                hl.NavigateUrl = "~/Chairman/ScrutinyLetters.aspx?id=" + dsScrutiny.Tables["query"].Rows[e.Row.RowIndex]["staffNo"].ToString();
                secondCell.Controls.Add(hl);
            }
        }
    }
}