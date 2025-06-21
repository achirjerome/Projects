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
    public partial class Indictment : System.Web.UI.Page
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
            try
            {
                Label1.Text = string.Empty;
                if (dsIndictment.Tables.Contains("indict"))
                {
                    dsIndictment.Tables.Remove("indict");
                }
                if (rbtLGEA.Checked == true)
                {
                    publicClass.dbLGEA = true;
                    conn = new SqlConnection(conStr);
                    conn.Open();
                    publicClass.daStaff = new SqlDataAdapter("SELECT Surname + ' ' + Firstname + ' ' + Middlename AS Name FROM tblStaffRegistration WHERE staffNo='" + txtStaffNo.Text + "'", conn);
                    publicClass.daStaff.Fill(dsIndictment, "indict");
                    conn.Close();
                }
                else
                {
                    //Hqtrs
                    publicClass.dbLGEA = false;
                    connHtqrs = new SqlConnection(conStrHqtrs);
                    connHtqrs.Open();
                    publicClass.daStaff = new SqlDataAdapter("SELECT Surname + ' ' + Firstname + ' ' + Middlename AS Name FROM tblStaffRegistration WHERE staffNo='" + txtStaffNo.Text + "'", connHtqrs);
                    publicClass.daStaff.Fill(dsIndictment, "indict");
                    connHtqrs.Close();
                }

                if (dsIndictment.Tables["indict"].Rows.Count > 0)
                {
                    lblName.Text = dsIndictment.Tables["indict"].Rows[0]["Name"].ToString();
                    Image2.ImageUrl = "~/StaffPix.ashx?id=" + txtStaffNo.Text;
                }
                else
                {
                    Label1.Text = "No record foud";
                }
            }
            catch(Exception ex)
            {
                Label1.Text = ex.Message;
            }

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                        
                if(!(txtStaffNo.Text ==string.Empty && lblName.Text ==string.Empty))
                {
                    string queryDate = txtDate.Text;

                    if(!fuLetter.HasFile)
                    {
                        Label1.Text = "Add letter please";
                        return;
                    }
                
                    if (rbtLGEA.Checked == true)
                    {
                        var Letter = fuLetter.FileBytes;
                        conn = new SqlConnection(conStr);
                        conn.Open();
                        publicClass.daStaff = new SqlDataAdapter("SELECT staffNo FROM tblScrutiny WHERE queryDate='" + txtDate.Text + "'", conn);
                        publicClass.daStaff.Fill(dsIndictment, "date");
                        conn.Close();

                        if (dsIndictment.Tables["date"].Rows.Count == 0)
                        {
                            publicClass.cmdStaff.Connection = conn;
                            publicClass.cmdStaff.CommandText = "INSERT INTO tblScrutiny VALUES(@staffNo, @qryreason, @qrydate, @letter)";
                            publicClass.cmdStaff.Parameters.AddWithValue("@staffno", txtStaffNo.Text);
                            publicClass.cmdStaff.Parameters.AddWithValue("@qryreason", txtqueryTitle.Text);
                            publicClass.cmdStaff.Parameters.AddWithValue("@qrydate", txtDate.Text);
                            publicClass.cmdStaff.Parameters.AddWithValue("@letter", Letter);

                            conn.Open();

                            publicClass.cmdStaff.ExecuteNonQuery();
                            conn.Close();

                            publicClass.cmdStaff.Parameters.Clear();

                            Label1.Text = "Saved successfully";
                        }
                        else
                        {
                            Label1.Text = "Already uploaded";
                        }
                    }
                    else //Hqtrs
                    {
                        var Letter = fuLetter.FileBytes;
                        connHtqrs = new SqlConnection(conStrHqtrs);

                        connHtqrs.Open();
                        publicClass.daStaff = new SqlDataAdapter("SELECT staffNo FROM tblScrutiny WHERE queryDate='" + txtDate.Text + "'", connHtqrs);
                        publicClass.daStaff.Fill(dsIndictment, "date");
                        connHtqrs.Close();

                        if (dsIndictment.Tables["date"].Rows.Count == 0)
                        {
                            publicClass.cmdStaff.Connection = connHtqrs;
                            publicClass.cmdStaff.CommandText = "INSERT INTO tblScrutiny VALUES(@staffNo, @qryreason, @qrydate, @letter)";
                            publicClass.cmdStaff.Parameters.AddWithValue("@staffno", txtStaffNo.Text);
                            publicClass.cmdStaff.Parameters.AddWithValue("@qryreason", txtqueryTitle.Text);
                            publicClass.cmdStaff.Parameters.AddWithValue("@qrydate", txtDate.Text);
                            publicClass.cmdStaff.Parameters.AddWithValue("@letter", Letter);

                            connHtqrs.Open();
                            publicClass.cmdStaff.ExecuteNonQuery();
                            connHtqrs.Close();

                            publicClass.cmdStaff.Parameters.Clear();

                            Label1.Text = "Saved successfully";
                        }
                        else
                        {
                            Label1.Text = "Already uploaded";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
            Label1.Text = string.Empty;
        }
    }
}