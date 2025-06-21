using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SUBEB_Staff_Online_Management_System.Chairman
{
    public partial class RegApprovalHqtrs : System.Web.UI.Page
    {

        SqlConnection connHtqrs;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;

        SqlDataAdapter daApproval;
        DataSet dsApproval = new DataSet();
        SqlCommand cmdDaApproval = new SqlCommand();

        public void selectHqtrsData()
        {           
                GridView1.Controls.Clear();
                if (dsApproval.Tables.Contains("hqtrs"))
                {
                    dsApproval.Tables.Remove("hqtrs");
                }
                connHtqrs = new SqlConnection(conStrHqtrs);
                connHtqrs.Open();
                daApproval = new SqlDataAdapter("SELECT StaffNo, Surname + ' ' + FirstName AS Name, DateofBirth, DateofAppointment FROM TempTblStaffRegistration", connHtqrs);
                daApproval.Fill(dsApproval, "hqtrs");
                connHtqrs.Close();

                if (!(dsApproval.Tables["hqtrs"].Columns.Contains("Approve")))
                {
                    dsApproval.Tables["hqtrs"].Columns.Add("Approve");
                }

                if (!(dsApproval.Tables["hqtrs"].Columns.Contains("Delete")))
                {
                    dsApproval.Tables["hqtrs"].Columns.Add("Delete");
                }

                GridView1.DataSource = dsApproval.Tables["hqtrs"];
                GridView1.DataBind();

            

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            selectHqtrsData();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var firstCell = e.Row.Cells[0];
                firstCell.Controls.Clear();
                HyperLink hl = new HyperLink();
                hl.Text = firstCell.Text;
               
                hl.NavigateUrl = "http://localhost:1647/Chairman/viewReg.aspx?id=" + dsApproval.Tables["hqtrs"].Rows[e.Row.RowIndex]["staffNo"].ToString() + "&DB=0";
               
                
                firstCell.Controls.Add(hl);
            }

           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var secondCell = e.Row.Cells[4];
                secondCell.Controls.Clear();
                ImageButton btnApprove = new ImageButton();
               
                btnApprove.ID = "btn" + e.Row.RowIndex;
              
                btnApprove.ImageUrl = "~/buttons/Checkmark.png";
               

                btnApprove.Click += new ImageClickEventHandler(btnApprove_Click);
                //btnApproveHqtrs.Click += new ImageClickEventHandler(btnApproveHqtrs_Click);
                //hl.NavigateUrl = "~/Chairman/ScrutinyLetters.aspx?id=" + dsScrutiny.Tables["query"].Rows[e.Row.RowIndex]["staffNo"].ToString();
                secondCell.Controls.Add(btnApprove);

                var cancelcell = e.Row.Cells[5];
                //cancelcell.Controls.Clear();
                ImageButton btncancel = new ImageButton();
                btncancel.ID = "btncancel" + e.Row.RowIndex;
                btncancel.ImageUrl = "~/buttons/Not.png";

                btncancel.Click += new ImageClickEventHandler(btncancel_Click);
                //hl.NavigateUrl = "~/Chairman/ScrutinyLetters.aspx?id=" + dsScrutiny.Tables["query"].Rows[e.Row.RowIndex]["staffNo"].ToString();
                cancelcell.Controls.Add(btncancel);
            }

        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            lblMsg.Text = string.Empty;
            SqlTransaction transApproved;
            ImageButton btn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            btn.ID = "btn" + row.RowIndex;
            string staffNo = row.Cells[0].Text; // here you will get Name 
            //string
            //btn.ImageUrl = "~/Buttons/checkmark.png";
            
                connHtqrs = new SqlConnection(conStrHqtrs);
                cmdDaApproval.Connection = connHtqrs;
            
            
            if(dsApproval.Tables.Contains("exist"))
            {
                dsApproval.Tables.Remove("exist");
            }

            connHtqrs.Open();
            daApproval = new SqlDataAdapter("SELECT StaffNo FROM tblStaffRegistration WHERE StaffNo='" + staffNo + "'", connHtqrs);
            daApproval.Fill(dsApproval, "exist");
            connHtqrs.Close();

            if (dsApproval.Tables["exist"].Rows.Count == 0)
            {
                connHtqrs.Open();
                transApproved = connHtqrs.BeginTransaction();
                try
                {
                    cmdDaApproval.Transaction = transApproved;
                    cmdDaApproval.CommandText = "INSERT INTO tblStaffRegistration SELECT * FROM TemptblSTaffRegistration WHERE StaffNo='" + staffNo + "'";
                    //cmdDaApproval.Parameters.AddWithValue("@staffno", staffNo);

                    cmdDaApproval.ExecuteNonQuery();

                    cmdDaApproval.CommandText = "DELETE FROM TemptblStaffRegistration WHERE StaffNo=@staffno";
                    cmdDaApproval.Parameters.AddWithValue("@staffno", staffNo);
                    cmdDaApproval.ExecuteNonQuery();

                    cmdDaApproval.CommandText = "INSERT INTO tblRegApproved Values('" + staffNo + "')";
                    cmdDaApproval.ExecuteNonQuery();

                    transApproved.Commit();
                                       
                    selectHqtrsData();
                    cmdDaApproval.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    lblMsg.Text = ex.Message;
                    try
                    {
                        transApproved.Rollback();
                    }
                    catch (SqlException ex2)
                    {
                        lblMsg.Text = ex2.Message;
                    }
                }
                connHtqrs.Close();
            }   
            else
            {
                lblMsg.Text = "Staff Number already exists";
            }
        }


        protected void btncancel_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "OpenInputDialog();", true);
            ImageButton btn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            btn.ID = "btn" + row.RowIndex;
            string staffNo = row.Cells[0].Text; // here you will get Name 
            //string
            //btn.ImageUrl = "~/Buttons/checkmark.png";
            
            connHtqrs = new SqlConnection(conStrHqtrs);
            cmdDaApproval.Connection = connHtqrs;
            cmdDaApproval.CommandText = "DELETE FROM TemptblStaffRegistration WHERE StaffNo=@staffno";
            cmdDaApproval.Parameters.AddWithValue("@staffno", staffNo);
            connHtqrs.Open();
            cmdDaApproval.ExecuteNonQuery();
            connHtqrs.Close();

            cmdDaApproval.Parameters.Clear();
            //GridView1.DeleteRow(row.RowIndex);
            //dsApproval.Tables["lga"].Rows.RemoveAt(row.RowIndex);
            selectHqtrsData();
            

        }

    }
}