using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SUBEB_Staff_Online_Management_System.Admin
{
    public partial class transfer : System.Web.UI.Page
    {
        DataSet dsPosting = new DataSet();
        public static string postedDate = string.Empty;
        DataTable dtWorkPlace = new DataTable();

        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHqtrs;
        SqlConnection conn;

        public void selectData()
        {
            if(dsPosting.Tables.Contains("posting"))
            {
                dsPosting.Tables.Remove("posting");
            }
            if (rbtLGEA.Checked == true)
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                publicClass.daStaff = new SqlDataAdapter("Select tblStaffRegistration.FirstName, tblStaffRegistration.MiddleName, tblStaffRegistration.SurName, tblPosting.* from tblPosting INNER JOIN tblStaffRegistration ON tblPosting.Staffno=tblStaffRegistration.Staffno WHERE tblPosting.Staffno='" + txtStaffNo.Text + "'", conn);

                //publicClass.daStaff = new SqlDataAdapter("Select * from tblPosting Where toDate='" + string.Empty + "' ORDER BY PSN", publicClass.conn);
                publicClass.daStaff.Fill(dsPosting, "posting");
                conn.Close();

                if (dsPosting.Tables["posting"].Rows.Count > 0)
                {                    
                    lblName.Text = dsPosting.Tables["posting"].Rows[0]["Surname"].ToString() + " " + dsPosting.Tables["posting"].Rows[0]["FirstName"].ToString() + " " + dsPosting.Tables["posting"].Rows[0]["MiddleName"].ToString();
                    DataTable dtWorkPlace = new DataTable();
                    dtWorkPlace = selectWorkPlace(txtStaffNo.Text);
                    lblPPA.Text = dtWorkPlace.Rows[0]["WorkStation"].ToString();
                    txtPreviousDate.Text = dtWorkPlace.Rows[0]["fromDate"].ToString();
                    Image2.ImageUrl = "~/staffPix.ashx?id=" + txtStaffNo.Text;

                    lblCurrentLGEA.Text = dtWorkPlace.Rows[0]["WorkLGEA"].ToString();
                }
            }
            else
            {
                connHqtrs = new SqlConnection(conStrHqtrs);
                connHqtrs.Open();
                publicClass.daStaff = new SqlDataAdapter("Select tblStaffRegistration.FirstName, tblStaffRegistration.MiddleName, tblStaffRegistration.SurName, tblPosting.* from tblPosting INNER JOIN tblStaffRegistration ON tblPosting.Staffno=tblStaffRegistration.Staffno WHERE tblPosting.STaffNo='" + txtStaffNo.Text +"'", connHqtrs);

                //publicClass.daStaff = new SqlDataAdapter("Select * from tblPosting Where toDate='" + string.Empty + "' ORDER BY PSN", publicClass.conn);
                publicClass.daStaff.Fill(dsPosting, "posting");
                connHqtrs.Close();

                if (dsPosting.Tables["posting"].Rows.Count > 0)
                {                    
                    lblName.Text = dsPosting.Tables["posting"].Rows[0]["Surname"].ToString() + " " + dsPosting.Tables["posting"].Rows[0]["FirstName"].ToString() + " " + dsPosting.Tables["posting"].Rows[0]["MiddleName"].ToString();
                    DataTable dtWorkPlace = new DataTable();
                    dtWorkPlace = selectWorkPlace(txtStaffNo.Text);
                    if (dtWorkPlace.Rows.Count > 0)
                    {
                        lblPPA.Text = dtWorkPlace.Rows[0]["WorkStation"].ToString();
                        txtPreviousDate.Text = dtWorkPlace.Rows[0]["fromDate"].ToString();
                        Image2.ImageUrl = "~/staffPix.ashx?id=" + txtStaffNo.Text;

                        lblCurrentLGEA.Text = dtWorkPlace.Rows[0]["WorkLGEA"].ToString();
                    }
                }
            }
        }
        public DataTable selectWorkPlace( string Staffno)
        {
            DataSet dsSD = new DataSet();
            if (rbtLGEA.Checked == true)
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                publicClass.daStaff = new SqlDataAdapter("Select * FROM tblPosting  WHERE staffNo='" + Staffno + "'", conn);
                publicClass.daStaff.Fill(dsSD, "posting");
                conn.Close();
            }
            else
            {
                connHqtrs = new SqlConnection(conStrHqtrs);
                connHqtrs.Open();
                publicClass.daStaff = new SqlDataAdapter("Select * FROM tblPosting  WHERE staffNo='" + Staffno + "'", connHqtrs);
                publicClass.daStaff.Fill(dsSD, "posting");
                connHqtrs.Close();
            }
        
           
            
            return dsSD.Tables["posting"];
           
        }

        public DataTable LoadWorkPlace(string LGEAName)
        {            
            DataSet dsSD = new DataSet();
            conn = new SqlConnection(conStr);
            conn.Open();

            publicClass.daStaff = new SqlDataAdapter("Select School FROM tblWorkstations WHERE LGEA='" + LGEAName + "' ORDER BY School", conn);
            publicClass.daStaff.Fill(dsSD, "postedlgea");
            //postedDate = dsSD.Tables["posting"].Rows[0]["fromDate"].ToString();
            return dsSD.Tables["postedlgea"];

        }

        public static DataTable selectWorkLGEA()
        {
            DataSet dsSD = new DataSet();
            publicClass.connectToDB();
            publicClass.daStaff = new SqlDataAdapter("Select DISTINCT LGEA FROM tblPVPermanentIncomes ORDER BY LGEA", publicClass.conn);
            publicClass.daStaff.Fill(dsSD, "lgea");
            //postedDate = dsSD.Tables["posting"].Rows[0]["fromDate"].ToString();
            return dsSD.Tables["lgea"];

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                DataTable dtWorkLGEA = new DataTable();
                dtWorkLGEA = selectWorkLGEA();
                ddlWorkLGEA.DataTextField = "LGEA";
                ddlWorkLGEA.DataSource = dtWorkLGEA;
                ddlWorkLGEA.DataBind();

                if (!(string.IsNullOrEmpty(ddlWorkLGEA.Text)))
                {
                    DataTable dtWorkStation = new DataTable();
                    dtWorkStation = LoadWorkPlace(ddlWorkLGEA.Text);
                    ddlPosting.DataTextField = "School";
                    ddlPosting.DataSource = dtWorkStation;
                    ddlPosting.DataBind();
                }

                //selectData();


                //publicClass.daStaff = new SqlDataAdapter("Select Schools from tblWorkStation ORDER BY SchoolName", publicClass.conn);
                //publicClass.daStaff.Fill(dsPosting, "schools");
                //if (dsPosting.Tables["schools"].Rows.Count > 0)
                //{
                //    ddlPosting.DataTextField = "SchoolName";
                //    ddlPosting.DataValueField = "SchoolCode";
                //    ddlPosting.DataSource = dsPosting.Tables["Schools"];
                //    ddlPosting.DataBind();
                //}
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ddlPSHN_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //{
            //    if (rbtLGEA.Checked == true)
            //    {
            //        dtWorkPlace = selectWorkPlace(ddlPSHN.Text);
            //        lblPPA.Text = dtWorkPlace.Rows[0]["WorkStation"].ToString();
            //        txtPreviousDate.Text = dtWorkPlace.Rows[0]["fromDate"].ToString();
            //        lblCurrentLGEA.Text = dtWorkPlace.Rows[0]["WorkLGEA"].ToString();
            //        conn = new SqlConnection(conStr);
            //        conn.Open();
            //        publicClass.daStaff = new SqlDataAdapter("Select FirstName, MiddleName, SurName FROM tblStaffRegistration WHERE staffNo='" + ddlPSHN.Text + "'", conn);

            //        publicClass.daStaff.Fill(dsPosting, "name");
            //        conn.Close();

            //        if (dsPosting.Tables["name"].Rows.Count > 0)
            //        {
            //            lblName.Text = dsPosting.Tables["name"].Rows[0]["Surname"].ToString() + " " + dsPosting.Tables["name"].Rows[0]["FirstName"].ToString() + " " + dsPosting.Tables["name"].Rows[0]["MiddleName"].ToString();
            //            Image2.ImageUrl = string.Empty;
            //            Image2.ImageUrl = "~/staffPix.ashx?id=" + ddlPSHN.Text;
            //        }
            //    }
            //    else
            //    {
            //        dtWorkPlace = selectWorkPlace(ddlPSHN.Text);
            //        lblPPA.Text = dtWorkPlace.Rows[0]["WorkStation"].ToString();
            //        txtPreviousDate.Text = dtWorkPlace.Rows[0]["fromDate"].ToString();
            //        lblCurrentLGEA.Text = dtWorkPlace.Rows[0]["WorkLGEA"].ToString();
            //        connHqtrs = new SqlConnection(conStrHqtrs);
            //        connHqtrs.Open();
            //        publicClass.daStaff = new SqlDataAdapter("Select FirstName, MiddleName, SurName FROM tblStaffRegistration WHERE staffNo='" + ddlPSHN.Text + "'", connHqtrs);

            //        publicClass.daStaff.Fill(dsPosting, "name");
            //        connHqtrs.Close();

            //        if (dsPosting.Tables["name"].Rows.Count > 0)
            //        {
            //            lblName.Text = dsPosting.Tables["name"].Rows[0]["Surname"].ToString() + " " + dsPosting.Tables["name"].Rows[0]["FirstName"].ToString() + " " + dsPosting.Tables["name"].Rows[0]["MiddleName"].ToString();
            //            Image2.ImageUrl = string.Empty;
            //            Image2.ImageUrl = "~/staffPix.ashx?id=" + ddlPSHN.Text;
            //        }
            //    }
            //}
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            Label1.Text = string.Empty;
            SqlTransaction transTransfer;
            
            Label1.Text = string.Empty;
            if (lblPPA.Text != string.Empty)
            {
                if (rbtLGEA.Checked == true)
                {
                    string toDate = txtNewDate.Text;
                    postedDate = txtPreviousDate.Text;
                    if (Convert.ToDateTime(toDate).Date > Convert.ToDateTime(postedDate).Date)
                    {
                        conn = new SqlConnection(conStr);
                        conn.Open();
                        transTransfer=conn.BeginTransaction();
                        try
                        {
                            publicClass.cmdStudents.Connection = conn;
                            publicClass.cmdStudents.CommandType = CommandType.Text;
                            publicClass.cmdStudents.Transaction = transTransfer;
                            //insert the selected record from tblPosting to tblPostingHistory and delete it from tblPosting table
                            publicClass.cmdStudents.CommandText = "Insert Into tblPostingHistory Values(@staffno, @fromDate, @toDate, @workstation, @worklgea)";
                            publicClass.cmdStudents.Parameters.AddWithValue("@staffno", txtStaffNo.Text);
                            publicClass.cmdStudents.Parameters.AddWithValue("@fromDate", DateTime.Parse(txtPreviousDate.Text));
                            publicClass.cmdStudents.Parameters.AddWithValue("@toDate", DateTime.Parse(txtNewDate.Text));
                            publicClass.cmdStudents.Parameters.AddWithValue("@workstation", lblPPA.Text);
                            publicClass.cmdStudents.Parameters.AddWithValue("@worklgea", lblCurrentLGEA.Text);

                            publicClass.cmdStudents.ExecuteNonQuery();
                          
                            publicClass.cmdStudents.Parameters.Clear();

                            
                            publicClass.cmdStudents.CommandText = "Update tblPosting SET fromDate =@fromdate, WorkStation=@workstation, WorkLGEA=@worklgea WHERE StaffNo=@staffno";
                            publicClass.cmdStudents.Parameters.AddWithValue("@fromDate", toDate);
                            publicClass.cmdStudents.Parameters.AddWithValue("@workstation", ddlPosting.Text);
                            publicClass.cmdStudents.Parameters.AddWithValue("@worklgea", ddlWorkLGEA.Text);
                            publicClass.cmdStudents.Parameters.AddWithValue("@staffno", txtStaffNo.Text);

                            publicClass.cmdStudents.ExecuteNonQuery();
                            
                            publicClass.cmdStudents.Parameters.Clear();

                            transTransfer.Commit();

                            lblPPA.Text = string.Empty;
                            lblCurrentLGEA.Text = string.Empty;
                            Label1.Text = "Transfer successfully";
                        }
                        catch(Exception ex)
                        {
                            Label1.Text = ex.Message;
                            try
                            {
                                transTransfer.Rollback();
                            }
                            catch(SqlException ex2)
                            {
                                Label1.Text = ex2.Message;
                            }
                        }
                        conn.Close();
                    }
                    else
                    {
                        Label1.Text = "Please check the Date of Transfer";
                    }
                }
            }
         
        }

        protected void ddlWorkLGEA_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtWorkPlace = LoadWorkPlace(ddlWorkLGEA.Text);
            ddlPosting.DataTextField = "School";
            ddlPosting.DataSource = dtWorkPlace;
            ddlPosting.DataBind();
            Image2.ImageUrl = "~/staffPix.ashx?id=" + txtStaffNo.Text;
        }

        protected void rbtHqtrs_CheckedChanged(object sender, EventArgs e)
        {
            publicClass.dbLGEA = false;
            txtPreviousDate.Text = string.Empty;
            lblCurrentLGEA.Text = string.Empty;
            lblName.Text = string.Empty;
            lblPPA.Text = string.Empty;
            selectData();
        }

        protected void rbtLGEA_CheckedChanged(object sender, EventArgs e)
        {
            publicClass.dbLGEA = true;
            txtPreviousDate.Text = string.Empty;
            lblCurrentLGEA.Text = string.Empty;
            lblName.Text = string.Empty;
            lblPPA.Text = string.Empty;
            selectData();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            selectData();
        }
    }
}