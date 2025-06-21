using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SUBEB_Staff_Online_Management_System.Admin
{
    public partial class viewIndictment : System.Web.UI.Page
    {
        DataSet dsIndictment = new DataSet();
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            lblName.Text = string.Empty;
            Image2.ImageUrl = null;
            lblMsg.Text = string.Empty;
            try
            {          
           
                if (rbtLGEA.Checked == true)
                {
                    publicClass.dbLGEA = true;
                    conn = new SqlConnection(conStr);
                    conn.Open();
                    publicClass.daStaff = new SqlDataAdapter("SELECT Surname + ' ' + FirstName + ' ' + Middlename AS Name FROM tblStaffRegistration WHERE StaffNo='" + txtSTaffNo.Text + "'", conn);
                    publicClass.daStaff.Fill(dsIndictment, "staff");
                    conn.Close();

                    if (dsIndictment.Tables["staff"].Rows.Count > 0)
                    {
                        conn.Open();
                        lblName.Text = dsIndictment.Tables["staff"].Rows[0]["Name"].ToString();
                        Image2.ImageUrl = "~/staffPix.ashx?id=" + txtSTaffNo.Text;
                                       
                        publicClass.daStaff = new SqlDataAdapter("SELECT StaffNo, QueryReason, QueryDate FROM tblScrutiny WHERE StaffNo='" + txtSTaffNo.Text + "'", conn);
                        publicClass.daStaff.Fill(dsIndictment, "query");
                        conn.Close();
                        if (dsIndictment.Tables["query"].Rows.Count > 0)
                        {
                            GridView1.DataSource = dsIndictment.Tables["query"];
                            GridView1.DataBind();
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Record not found";
                    }
                }
                else
                {
                    //Hqtrs
                    publicClass.dbLGEA = false;
                    connHtqrs = new SqlConnection(conStrHqtrs);
                    connHtqrs.Open();
                    publicClass.daStaff = new SqlDataAdapter("SELECT Surname + ' ' + FirstName + ' ' + Middlename AS Name FROM tblStaffRegistration WHERE StaffNo='" + txtSTaffNo.Text + "'", connHtqrs);
                    publicClass.daStaff.Fill(dsIndictment, "staff");
                    connHtqrs.Close();

                    if (dsIndictment.Tables["staff"].Rows.Count > 0)
                    {
                        connHtqrs.Open();
                        lblName.Text = dsIndictment.Tables["staff"].Rows[0]["Name"].ToString();
                        Image2.ImageUrl = "~/staffPix.ashx?id=" + txtSTaffNo.Text;

                        publicClass.daStaff = new SqlDataAdapter("SELECT StaffNo, QueryReason, QueryDate FROM tblScrutiny WHERE StaffNo='" + txtSTaffNo.Text + "'", connHtqrs);
                        publicClass.daStaff.Fill(dsIndictment, "query");
                        connHtqrs.Close();
                        if (dsIndictment.Tables["query"].Rows.Count > 0)
                        {
                            GridView1.DataSource = dsIndictment.Tables["query"];
                            GridView1.DataBind();
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Record not found";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
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
                hl.NavigateUrl = "~/Admin/viewLetters.aspx?id=" + dsIndictment.Tables["query"].Rows[e.Row.RowIndex]["QueryDate"].ToString();
                hl.Target = "_blank";
                secondCell.Controls.Add(hl);
            }
        }
    }
}