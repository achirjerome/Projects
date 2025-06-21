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
    public partial class RegApproval : System.Web.UI.Page
    {
        SqlConnection conn;
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        //SqlConnection connHtqrs;
        //string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;

        SqlDataAdapter daApproval;
        DataSet dsApproval = new DataSet();
        SqlCommand cmdDaApproval=new SqlCommand();

        public bool DBLGA = true;

        public void selectLGAData()
        {
            
                if(dsApproval.Tables.Contains("lga"))
                {
                    dsApproval.Tables.Remove("lga");
                }
                conn = new SqlConnection(conStr);
                conn.Open();
                daApproval = new SqlDataAdapter("SELECT StaffNo, Surname + ' ' + FirstName AS Name, DateofBirth, DateofAppointment FROM TempTblStaffRegistration", conn);
                daApproval.Fill(dsApproval, "lga");
                conn.Close();

                if (!(dsApproval.Tables["lga"].Columns.Contains("Approve")))
                {
                    dsApproval.Tables["lga"].Columns.Add("Approve");
                }

                if (!(dsApproval.Tables["lga"].Columns.Contains("Delete")))
                {
                    dsApproval.Tables["lga"].Columns.Add("Delete");
                }
                GridView1.DataSource = dsApproval.Tables["lga"];
                GridView1.DataBind();
                
                   

        }

       


        protected void Page_Load(object sender, EventArgs e)
        {
            
                selectLGAData();
                DBLGA = true;//use LGA DB
           

        }

        protected void rbtLGEA_CheckedChanged(object sender, EventArgs e)
        {
            
                GridView1.DataSource = null;
                GridView1.DataBind();
                DBLGA = true;
                selectLGAData();
               
            
            
        }

       
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var firstCell = e.Row.Cells[0];
                firstCell.Controls.Clear();
                HyperLink hl = new HyperLink();
                hl.Text = firstCell.Text;
                if (DBLGA == true)
                {
                    hl.NavigateUrl = "http://localhost:1647/Chairman/viewReg.aspx?id=" + dsApproval.Tables["lga"].Rows[e.Row.RowIndex]["staffNo"].ToString() + "&DB=1";
                    
                }
                else
                {
                    hl.NavigateUrl = "http://localhost:1647/Chairman/viewReg.aspx?id=" + dsApproval.Tables["hqtrs"].Rows[e.Row.RowIndex]["staffNo"].ToString() + "&DB=0";
                    //if (!(dsApproval.Tables["hqtrs"].Columns.Contains("Action")))
                    //{
                    //    dsApproval.Tables["hqtrs"].Columns.Add("Action");
                    //}
                }
                firstCell.Controls.Add(hl);
            }
            
            //ImageButton approve = new ImageButton();
            //approve.ID = "btnApprove";
            //approve.ImageUrl = "~/Images/checkmark.png";

            //GridView1.Columns.Add(3);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var secondCell = e.Row.Cells[4];
                secondCell.Controls.Clear();
                ImageButton btn = new ImageButton();
                ImageButton btnApproveHqtrs = new ImageButton();

                btn.ID = "btn" + e.Row.RowIndex;
                btnApproveHqtrs.ID = "btn" + e.Row.RowIndex;

                btn.ImageUrl = "~/buttons/Checkmark.png";
                btnApproveHqtrs.ImageUrl = "~/buttons/Checkmark.png"; ;

                btn.Click += new ImageClickEventHandler(btn_Click);
                //btnApproveHqtrs.Click += new ImageClickEventHandler(btnApproveHqtrs_Click);
                //hl.NavigateUrl = "~/Chairman/ScrutinyLetters.aspx?id=" + dsScrutiny.Tables["query"].Rows[e.Row.RowIndex]["staffNo"].ToString();
                secondCell.Controls.Add(btn);

                var cancelcell = e.Row.Cells[5];
                cancelcell.Controls.Clear();
                ImageButton btncancel = new ImageButton();
                btncancel.ID = "btncancel" + e.Row.RowIndex;
                btncancel.ImageUrl = "~/buttons/Not.png";
               
                btncancel.Click += new ImageClickEventHandler(btncancel_Click);
                //hl.NavigateUrl = "~/Chairman/ScrutinyLetters.aspx?id=" + dsScrutiny.Tables["query"].Rows[e.Row.RowIndex]["staffNo"].ToString();
                cancelcell.Controls.Add(btncancel);
            }

        }

       
        protected void btn_Click(object sender, EventArgs e)
        {
            lblMsg.Text = string.Empty;
            SqlTransaction transApproved;
            ImageButton btn =(ImageButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            btn.ID = "btn" + row.RowIndex;
            string staffNo = row.Cells[0].Text; // here you will get Name 
            //string
            //btn.ImageUrl = "~/Buttons/checkmark.png";
                         
            conn = new SqlConnection(conStr);
            cmdDaApproval.Connection = conn;
            if(dsApproval.Tables.Contains("exist"))
            {
                dsApproval.Tables.Remove("exist");
            }

            daApproval = new SqlDataAdapter("SELECT staffNo FROM tblStaffRegistration WHERE staffNo='" + staffNo + "'", conn);
            daApproval.Fill(dsApproval, "exist");

            if (dsApproval.Tables["exist"].Rows.Count == 0)
            {
                conn.Open();
                transApproved = conn.BeginTransaction();
                try
                {
                    cmdDaApproval.Transaction=transApproved;
                    cmdDaApproval.CommandText = "INSERT INTO tblStaffRegistration SELECT * FROM TemptblSTaffRegistration WHERE StaffNo='" + staffNo + "'";
                    //cmdDaApproval.Parameters.AddWithValue("@staffno", staffNo);
                    
                    cmdDaApproval.ExecuteNonQuery();

                    cmdDaApproval.CommandText = "DELETE FROM TemptblStaffRegistration WHERE StaffNo=@staffno";
                    cmdDaApproval.Parameters.AddWithValue("@staffno", staffNo);
                    cmdDaApproval.ExecuteNonQuery();

                    cmdDaApproval.CommandText = "INSERT INTO tblRegApproved Values('" + staffNo + "')";
                    cmdDaApproval.ExecuteNonQuery();

                    transApproved.Commit();

                    selectLGAData();
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

                conn.Close();
            }
            else
            {
                lblMsg.Text = "Staff number already exists";
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
          
            conn = new SqlConnection(conStr);
            cmdDaApproval.Connection = conn;
            cmdDaApproval.CommandText = "DELETE FROM TemptblStaffRegistration WHERE StaffNo=@staffno";
            cmdDaApproval.Parameters.AddWithValue("@staffno", staffNo);
            conn.Open();
            cmdDaApproval.ExecuteNonQuery();                
            conn.Close();

            cmdDaApproval.Parameters.Clear();
            //GridView1.DeleteRow(row.RowIndex);
            //dsApproval.Tables["lga"].Rows.RemoveAt(row.RowIndex);
            selectLGAData();

        }
    }
}