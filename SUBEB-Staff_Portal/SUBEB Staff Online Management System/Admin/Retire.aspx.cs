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
    public partial class Retire : System.Web.UI.Page
    {
        DataSet dsRetire = new DataSet();
        SqlDataAdapter daRetire;
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHqtrs;
        SqlConnection conn;
        SqlTransaction transRetire;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            lblName.Text = string.Empty;
            Image2.ImageUrl = null;

            if(dsRetire.Tables.Contains("staff"))
            {
                dsRetire.Tables.Remove("staff");
            }
            if (rbtLGEA.Checked == true)
            {
                publicClass.dbLGEA = true;
                conn = new SqlConnection(conStr);
                conn.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT Surname + ' ' + FirstName + ' ' + Middlename AS Name FROM tblStaffRegistration WHERE StaffNo='" + txtSTaffNo.Text + "'", conn);
                publicClass.daStaff.Fill(dsRetire, "staff");
                conn.Close();
            }
            else
            {
                publicClass.dbLGEA = false;
                connHqtrs = new SqlConnection(conStrHqtrs);
                connHqtrs.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT Surname + ' ' + FirstName + ' ' + Middlename AS Name FROM tblStaffRegistration WHERE StaffNo='" + txtSTaffNo.Text + "'", connHqtrs);
                publicClass.daStaff.Fill(dsRetire, "staff");
                connHqtrs.Close();
            }
            if (dsRetire.Tables["staff"].Rows.Count > 0)
            {
                lblName.Text = dsRetire.Tables["staff"].Rows[0]["Name"].ToString();
                Image2.ImageUrl = "~/staffPix.ashx?id=" + txtSTaffNo.Text;
              
            }
        }

        protected void btnRetire_Click(object sender, EventArgs e)
        {
            lblMsg.Text = string.Empty;        
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('Message here');", true);
            if (!(txtSTaffNo.Text==string.Empty && lblName.Text==string.Empty))
            {
                if (rbtLGEA.Checked == true)//LGEA DB
                {
                    conn = new SqlConnection(conStr);
                    conn.Open();
                    daRetire = new SqlDataAdapter("SELECT * FROM tblStaffRegistration WHERE StaffNo='" + txtSTaffNo.Text + "'", conn);
                    daRetire.Fill(dsRetire, "bio");
                    conn.Close();

                    conn.Open();
                    transRetire = conn.BeginTransaction();
                    try
                    {
                        publicClass.cmdStaff.Connection = conn;
                        publicClass.cmdStaff.Transaction = transRetire;
                        publicClass.cmdStaff.CommandText = "INSERT INTO tblRetirees VALUES(@staffno, @fn, @mn, @ln, @sex, @mstatus, @noofchild, @dob, @ht, @nationality, @soo, @lga, @religion, @caddress, @paddress, @phone, @email, @qua, @specialty, @doa, @rank, @grade, @blood, @pix, @rd, @rr)";
                        publicClass.cmdStaff.Parameters.AddWithValue("@staffno", dsRetire.Tables["bio"].Rows[0]["staffNo"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@fn", dsRetire.Tables["bio"].Rows[0]["FirstName"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@mn", dsRetire.Tables["bio"].Rows[0]["Middlename"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@ln", dsRetire.Tables["bio"].Rows[0]["Surname"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@sex", dsRetire.Tables["bio"].Rows[0]["Sex"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@mstatus", dsRetire.Tables["bio"].Rows[0]["MarritalStatus"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@noofchild", dsRetire.Tables["bio"].Rows[0]["NoofChildren"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@dob", dsRetire.Tables["bio"].Rows[0]["DateofBirth"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@ht", dsRetire.Tables["bio"].Rows[0]["Hometown"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@nationality", dsRetire.Tables["bio"].Rows[0]["Nationality"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@soo", dsRetire.Tables["bio"].Rows[0]["StateofOrigin"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@lga", dsRetire.Tables["bio"].Rows[0]["LGA"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@religion", dsRetire.Tables["bio"].Rows[0]["Religion"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@caddress", dsRetire.Tables["bio"].Rows[0]["ContactAddress"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@paddress", dsRetire.Tables["bio"].Rows[0]["PermanentAddress"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@phone", dsRetire.Tables["bio"].Rows[0]["PhoneNo"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@email", dsRetire.Tables["bio"].Rows[0]["Email"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@qua", dsRetire.Tables["bio"].Rows[0]["Qualification"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@specialty", dsRetire.Tables["bio"].Rows[0]["Speciaty"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@doa", dsRetire.Tables["bio"].Rows[0]["DateofAppointment"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@rank", dsRetire.Tables["bio"].Rows[0]["JobTitle"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@grade", dsRetire.Tables["bio"].Rows[0]["GradelevelSteps"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@blood", dsRetire.Tables["bio"].Rows[0]["BloodGroup"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@pix", dsRetire.Tables["bio"].Rows[0]["Pix"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@rd", txtDate.Text);
                        publicClass.cmdStaff.Parameters.AddWithValue("@rr", txtReason.Text);


                        publicClass.cmdStaff.ExecuteNonQuery();
                        publicClass.cmdStaff.Parameters.Clear();

                        publicClass.cmdStaff.CommandText = "DELETE FROM tblStaffRegistration WHERE STaffNo=@staffno";
                        publicClass.cmdStaff.Parameters.AddWithValue("@staffno", txtSTaffNo.Text);

                        publicClass.cmdStaff.ExecuteNonQuery();
                        publicClass.cmdStaff.Parameters.Clear();

                        sendText newText = new sendText();
                        newText.sendSMS(dsRetire.Tables["bio"].Rows[0]["PhoneNo"].ToString(), "You have successfully retired from the services of Benue SUBEB. Thanks for your service");

                        transRetire.Commit();
                        txtReason.Text = string.Empty;
                        lblMsg.Text = "Successful";
                    }
                    catch(Exception ex)
                    {
                        lblMsg.Text = ex.Message;
                        try
                        {
                            transRetire.Rollback();
                        }
                        catch(SqlException ex2)
                        {
                            lblMsg.Text = ex2.Message;
                        }
                    }
                    conn.Close();
                }
                else
                {
                    //Hqtrs DB
                    connHqtrs = new SqlConnection(conStrHqtrs);
                    connHqtrs.Open();                   
                    daRetire = new SqlDataAdapter("SELECT * FROM tblStaffRegistration WHERE StaffNo='" + txtSTaffNo.Text + "'", connHqtrs);
                    daRetire.Fill(dsRetire, "bio");
                    connHqtrs.Close();

                    connHqtrs.Open();
                    
                    transRetire = connHqtrs.BeginTransaction();
                    try
                    {
                        publicClass.cmdStaff.Connection = connHqtrs;
                        publicClass.cmdStaff.Transaction = transRetire;
                        publicClass.cmdStaff.CommandText = "INSERT INTO tblRetirees VALUES(@staffno, @fn, @mn, @ln, @sex, @mstatus, @noofchild, @dob, @ht, @nationality, @soo, @lga, @religion, @caddress, @paddress, @phone, @email, @qua, @specialty, @doa, @rank, @grade, @blood, @pix, @rd, @rr)";
                        publicClass.cmdStaff.Parameters.AddWithValue("@staffno", dsRetire.Tables["bio"].Rows[0]["staffNo"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@fn", dsRetire.Tables["bio"].Rows[0]["FirstName"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@mn", dsRetire.Tables["bio"].Rows[0]["Middlename"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@ln", dsRetire.Tables["bio"].Rows[0]["Surname"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@sex", dsRetire.Tables["bio"].Rows[0]["Sex"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@mstatus", dsRetire.Tables["bio"].Rows[0]["MarritalStatus"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@noofchild", dsRetire.Tables["bio"].Rows[0]["NoofChildren"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@dob", dsRetire.Tables["bio"].Rows[0]["DateofBirth"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@ht", dsRetire.Tables["bio"].Rows[0]["Hometown"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@nationality", dsRetire.Tables["bio"].Rows[0]["Nationality"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@soo", dsRetire.Tables["bio"].Rows[0]["StateofOrigin"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@lga", dsRetire.Tables["bio"].Rows[0]["LGA"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@religion", dsRetire.Tables["bio"].Rows[0]["Religion"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@caddress", dsRetire.Tables["bio"].Rows[0]["ContactAddress"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@paddress", dsRetire.Tables["bio"].Rows[0]["PermanentAddress"]);

                        publicClass.cmdStaff.Parameters.AddWithValue("@phone", dsRetire.Tables["bio"].Rows[0]["PhoneNo"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@email", dsRetire.Tables["bio"].Rows[0]["Email"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@qua", dsRetire.Tables["bio"].Rows[0]["Qualification"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@specialty", dsRetire.Tables["bio"].Rows[0]["Speciaty"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@doa", dsRetire.Tables["bio"].Rows[0]["DateofAppointment"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@rank", dsRetire.Tables["bio"].Rows[0]["JobTitle"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@grade", dsRetire.Tables["bio"].Rows[0]["GradelevelSteps"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@blood", dsRetire.Tables["bio"].Rows[0]["BloodGroup"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@pix", dsRetire.Tables["bio"].Rows[0]["Pix"]);
                        publicClass.cmdStaff.Parameters.AddWithValue("@rd", txtDate.Text);
                        publicClass.cmdStaff.Parameters.AddWithValue("@rr", txtReason.Text);


                        publicClass.cmdStaff.ExecuteNonQuery();
                        publicClass.cmdStaff.Parameters.Clear();

                        publicClass.cmdStaff.CommandText = "DELETE FROM tblStaffRegistration WHERE STaffNo=@staffno";
                        publicClass.cmdStaff.Parameters.AddWithValue("@staffno", txtSTaffNo.Text);
                        publicClass.cmdStaff.ExecuteNonQuery();
                        publicClass.cmdStaff.Parameters.Clear();

                        sendText newText = new sendText();
                        newText.sendSMS(dsRetire.Tables["bio"].Rows[0]["PhoneNo"].ToString(), "You have successfully retired from the services of Benue SUBEB. Thanks for your service");


                        transRetire.Commit();
                        txtReason.Text = string.Empty;
                        lblMsg.Text = "Successful";

                    }
                    catch (Exception ex)
                    {
                        lblMsg.Text = ex.Message;
                        try
                        {
                            transRetire.Rollback();
                        }
                        catch (SqlException ex2)
                        {
                            lblMsg.Text = ex2.Message;
                        }
                    }
                    connHqtrs.Close();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Alert", "alert('No staff selected');", true);
            }
        }
    }
}