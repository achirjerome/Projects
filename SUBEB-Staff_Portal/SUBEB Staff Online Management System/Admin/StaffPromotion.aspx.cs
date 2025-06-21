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
    public partial class StaffPromotion : System.Web.UI.Page
    {
        public static string G = string.Empty;
        public static string S = string.Empty;
        DataSet dsStaffPromotion = new DataSet();
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;

        public void SelectData()
        {
            if (rbtLGEA.Checked == true)
            {
                conn = new SqlConnection(conStr);
                

                if (dsStaffPromotion.Tables.Contains("data"))
                {
                    dsStaffPromotion.Tables["data"].Clear();
                }
                conn.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT tblStaffRegistration.StaffNo, tblStaffRegistration.FirstName, tblStaffRegistration.MiddleName, tblStaffRegistration.SurName, tblCurrentLevel.DateofPromotion, tblCurrentLevel.GradeLevelStep, tblCurrentLevel.Rank FROM tblStaffRegistration INNER JOIN tblCurrentLevel ON tblStaffRegistration.StaffNo= tblcurrentLevel.StaffNo WHERE tblStaffRegistration.StaffNo='" + txtStaffNo.Text + "'", conn);
                publicClass.daStaff.Fill(dsStaffPromotion, "data");
                conn.Close();
                GridView1.DataSource = dsStaffPromotion.Tables["data"];
                GridView1.DataBind();
            }
            else
            {
                connHtqrs = new SqlConnection(conStrHqtrs);
                
                if (dsStaffPromotion.Tables.Contains("data"))
                {
                    dsStaffPromotion.Tables["data"].Clear();
                }
                connHtqrs = new SqlConnection(conStrHqtrs);
                connHtqrs.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT tblStaffRegistration.StaffNo, tblStaffRegistration.FirstName, tblStaffRegistration.MiddleName, tblStaffRegistration.SurName, tblCurrentLevel.DateofPromotion, tblCurrentLevel.GradeLevelStep, tblCurrentLevel.Rank FROM tblStaffRegistration INNER JOIN tblCurrentLevel ON tblStaffRegistration.StaffNo= tblcurrentLevel.StaffNo WHERE tblStaffRegistration.StaffNo='" + txtStaffNo.Text + "'", connHtqrs);
                publicClass.daStaff.Fill(dsStaffPromotion, "data");
                connHtqrs.Close();
                GridView1.DataSource = dsStaffPromotion.Tables["data"];
                GridView1.DataBind();
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            

            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
                
            
        }

        protected void ddlPSHN_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GridView1.DataSource = null;
            //if (rbtLGEA.Checked == true)
            //{
            //    conn = new SqlConnection(conStr);
            //    if (dsStaffPromotion.Tables.Contains("reselect"))
            //    {
            //        dsStaffPromotion.Tables["reselect"].Clear();
            //    }
            //    conn.Open();
            //    publicClass.daStaff = new SqlDataAdapter("SELECT tblStaffRegistration.StaffNo, tblStaffRegistration.FirstName, tblStaffRegistration.MiddleName, tblStaffRegistration.SurName, tblCurrentLevel.DateofPromotion, tblCurrentLevel.GradeLevelStep, tblCurrentLevel.Rank FROM tblStaffRegistration INNER JOIN tblCurrentLevel ON tblStaffRegistration.StaffNo= tblcurrentLevel.StaffNo WHERE tblStaffRegistration.StaffNo='" + ddlPSHN.Text + "'", conn);
            //    publicClass.daStaff.Fill(dsStaffPromotion, "reselect");
            //    conn.Close();
            //    GridView1.DataSource = dsStaffPromotion.Tables["reselect"];
            //    GridView1.DataBind();
            //}
            //else
            //{
            //    connHtqrs = new SqlConnection(conStrHqtrs);
            //    if (dsStaffPromotion.Tables.Contains("reselect"))
            //    {
            //        dsStaffPromotion.Tables["reselect"].Clear();
            //    }
            //    connHtqrs.Open();
            //    publicClass.daStaff = new SqlDataAdapter("SELECT tblStaffRegistration.StaffNo, tblStaffRegistration.FirstName, tblStaffRegistration.MiddleName, tblStaffRegistration.SurName, tblCurrentLevel.DateofPromotion, tblCurrentLevel.GradeLevelStep, tblCurrentLevel.Rank FROM tblStaffRegistration INNER JOIN tblCurrentLevel ON tblStaffRegistration.StaffNo= tblcurrentLevel.StaffNo WHERE tblStaffRegistration.StaffNo='" + ddlPSHN.Text + "'", connHtqrs);
            //    publicClass.daStaff.Fill(dsStaffPromotion, "reselect");
            //    connHtqrs.Close();
            //    GridView1.DataSource = dsStaffPromotion.Tables["reselect"];
            //    GridView1.DataBind();
            //}
            ////SelectData();
                      
        }

        protected void btnPromote_Click(object sender, EventArgs e)
        {
            SqlTransaction TransPromo;
            Label4.Text = string.Empty;
            try
            {
                if (GridView1.Rows.Count > 0)
                {
                    string dateOfLastPromotion = GridView1.Rows[0].Cells[4].Text;
                    //string dateOfPromotion = ddlYear.Text + "-" + ddlMonth.Text + "-" + ddlDay.Text;
                    string LastGrade = GridView1.Rows[0].Cells[5].Text;
                    string LastRank = GridView1.Rows[0].Cells[6].Text;
                    String GradeLevel = string.Empty;
                    string newStep = string.Empty;

                    if (dsStaffPromotion.Tables.Contains("check"))
                    {
                        dsStaffPromotion.Tables["check"].Clear();
                    }
                    DateTime lastPromo = Convert.ToDateTime(dateOfLastPromotion).Date;
                    DateTime datePromo = Convert.ToDateTime(txtDate.Text);
                    //int previousGrade = int.Parse(LastGrade.Substring(0, 1));//retrieve the Gradelevel part of gradelevel
                    //int previousStep = int.Parse(LastGrade.Substring(2, 1));   //retrieve the step part of gradelevel
                    //int newGrade = int.Parse(ddlGradeLevel.Text);
                    //int step = int.Parse(ddlSteps.Text);

                    if (lastPromo <= datePromo)
                    {
                        if (rbtLGEA.Checked == true)
                        {
                            conn = new SqlConnection(conStr);
                            conn.Open();

                            publicClass.daStaff = new SqlDataAdapter("SELECT * FROM tblCurrentLevel WHERE StaffNo='" + txtStaffNo.Text + "' AND DateofPromotion='" + dateOfLastPromotion + "'", conn);
                            publicClass.daStaff.Fill(dsStaffPromotion, "check");
                            conn.Close();

                            int foundStaff = dsStaffPromotion.Tables["check"].Rows.Count;


                            GradeLevel = "CONPSS " + ddlGradeLevel.Text + "/" + ddlSteps.Text;
                            if (foundStaff == 1)
                            {
                                publicClass.cmdStudents.Connection = conn;
                                conn.Open();
                                //TransPromo = conn.BeginTransaction();
                                //try
                                //{

                                //}
                                //catch(Exception ex)
                                //{

                                //}
                                publicClass.cmdStudents.CommandType = CommandType.Text;

                                string StaffNo = dsStaffPromotion.Tables["check"].Rows[0]["StaffNo"].ToString();

                                publicClass.cmdStudents.CommandText = "Insert Into tblPromotionHistory Values('" + StaffNo + "','"
                                    + dateOfLastPromotion + "','" + LastGrade + "','" + LastRank + "')";

                                publicClass.cmdStudents.ExecuteNonQuery();

                                string promotionCode = "PC" + txtStaffNo.Text;
                                //publicClass.cmdStudents.Connection = conn;
                                publicClass.cmdStudents.CommandType = CommandType.Text;
                                publicClass.cmdStudents.CommandText = "UPDATE tblCurrentLevel SET promotionCode='" + promotionCode + "', StaffNo='" + txtStaffNo.Text + "',dateofPromotion='" + txtDate.Text + "', GradeLevelStep='" + GradeLevel + "', Rank='" + txtRank.Text + "' WHERE StaffNo='" + txtStaffNo.Text + "'";
                                publicClass.cmdStudents.ExecuteNonQuery();

                                publicClass.cmdStudents.CommandText = "INSERT INTO tblTempPromotion VALUES(@staffno, @grade)";
                                publicClass.cmdStudents.Parameters.AddWithValue("@staffno", StaffNo);
                                publicClass.cmdStudents.Parameters.AddWithValue("@grade", GradeLevel);
                                publicClass.cmdStudents.ExecuteNonQuery();
                                conn.Close();
                                Label4.Text = txtStaffNo.Text + " promoted successfully.";

                            }
                        }
                        else
                        {
                            connHtqrs = new SqlConnection(conStrHqtrs);
                            connHtqrs.Open();

                            publicClass.daStaff = new SqlDataAdapter("SELECT * FROM tblCurrentLevel WHERE StaffNo='" + txtStaffNo.Text + "' AND DateofPromotion='" + dateOfLastPromotion + "'", connHtqrs);
                            publicClass.daStaff.Fill(dsStaffPromotion, "check");
                            connHtqrs.Close();

                            int foundStaff = dsStaffPromotion.Tables["check"].Rows.Count;


                            GradeLevel = "CONPSS " + ddlGradeLevel.Text + "/" + ddlSteps.Text;
                            if (foundStaff == 1)
                            {
                                connHtqrs.Open();
                                publicClass.cmdStudents.Connection = connHtqrs;
                                publicClass.cmdStudents.CommandType = CommandType.Text;

                                string StaffNo = dsStaffPromotion.Tables["check"].Rows[0]["StaffNo"].ToString();

                                publicClass.cmdStudents.CommandText = "Insert Into tblPromotionHistory Values('" + StaffNo + "','"
                                    + dateOfLastPromotion + "','" + LastGrade + "','" + LastRank + "')";
                                publicClass.cmdStudents.ExecuteNonQuery();

                                string promotionCode = "PC" + txtStaffNo.Text;
                                //publicClass.cmdStudents.Connection = publicClass.conn;
                                //publicClass.cmdStudents.CommandType = CommandType.Text;
                                publicClass.cmdStudents.CommandText = "UPDATE tblCurrentLevel SET promotionCode='" + promotionCode + "', StaffNo='" + txtStaffNo.Text + "',dateofPromotion='" + txtDate.Text + "', GradeLevelStep='" + GradeLevel + "', Rank='" + txtRank.Text + "' WHERE StaffNo='" + txtStaffNo.Text + "'";
                                publicClass.cmdStudents.ExecuteNonQuery();

                                publicClass.cmdStudents.CommandText = "INSERT INTO tblTempPromotion VALUES(@staffno, @grade)";
                                publicClass.cmdStudents.Parameters.AddWithValue("@staffno", StaffNo);
                                publicClass.cmdStudents.Parameters.AddWithValue("@grade", GradeLevel);
                                publicClass.cmdStudents.ExecuteNonQuery();

                                connHtqrs.Close();
                                Label4.Text = txtStaffNo.Text + " promoted successfully.";

                            }
                        }


                    }
                    else
                    {
                        Label4.Text = "Please the promotion date cannot be less or equal to the previous promotion date.";
                    }

                }
            }
            catch(Exception ex)
            {
                Label4.Text = ex.Message;
            }
 
        }      


        protected void rbtHqtrs_CheckedChanged(object sender, EventArgs e)
        {
            SelectData();
        }

        protected void rbtLGEA_CheckedChanged(object sender, EventArgs e)
        {
            SelectData();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            SelectData();
        }
    }
}