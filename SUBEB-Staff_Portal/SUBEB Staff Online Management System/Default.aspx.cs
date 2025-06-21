using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Configuration;


namespace SUBEB_Staff_Online_Management_System
{
    public partial class Default : System.Web.UI.Page
    {
        
        public static string retirementRemider(DataTable dtStaff, DateTime nextReminder)
        {
            SqlConnection conn;
            SqlConnection connHtqrs;
            string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            
            string staffNo = string.Empty;
            string phoneNo = string.Empty;
            int noofMonths = 0;
            DataSet dsRetirementReminder = new DataSet();
            SqlDataAdapter daRetirementReminder;
            int remaininMonths = 0;
            SqlTransaction saveTransact;
            //saveTransact = publicClass.conn.BeginTransaction("save");
            //publicClass.cmdStaff.Transaction = saveTransact;
            //try
            //{


                for (int i = 0; i < dtStaff.Rows.Count; i++)
                {
                    staffNo = dtStaff.Rows[i]["staffNo"].ToString();
                    phoneNo = dtStaff.Rows[i]["PhoneNo"].ToString();
                    noofMonths = int.Parse(dtStaff.Rows[i]["NoofMonths"].ToString());
                    if (!(string.IsNullOrEmpty(phoneNo))) 
                    {
                        string APIurl = "https://netbulksms.com/index.php?option=com_spc&comm=spc_api&username=achirjerome&password=Achir.Gbenyi1$&sender=SUBEB&recipient=" + phoneNo + "&message=Your reitrement date is " + dtStaff.Rows[i]["RetirementDate"].ToString() + ", You have " + noofMonths + " months left. SUBEB";
                        // Create a request object  
                        WebRequest request = HttpWebRequest.Create(APIurl);
                        // Get the response back  
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        Stream s = (Stream)response.GetResponseStream();
                        StreamReader readStream = new StreamReader(s);
                        string dataString = readStream.ReadToEnd();
                        string reply = response.StatusCode.ToString();
                        response.Close();
                        s.Close();
                        readStream.Close();
                    }

                        remaininMonths = noofMonths - 1;
                        
                            int LGEAToUse = int.Parse(dtStaff.Rows[i]["LGEADB"].ToString());
                            if (LGEAToUse == 1)
                            {
                                conn = new SqlConnection(conStr);
                               
                                if (remaininMonths > 0)
                                {
                                    conn.Open();
                                    publicClass.cmdStaff.Connection = conn;
                                    publicClass.cmdStaff.CommandText = "UPDATE tblExpectedRetirees SET NoofMonths=@remainingmonths WHERE StaffNo=@staffnum";
                                    publicClass.cmdStaff.Parameters.AddWithValue("@staffnum", staffNo);
                                    publicClass.cmdStaff.Parameters.AddWithValue("@remainingmonths", remaininMonths);
                                    publicClass.cmdStaff.ExecuteNonQuery();
                                    conn.Close();
                                    publicClass.cmdStaff.Parameters.Clear();
                                }
                                else
                                {
                                    conn.Open();
                                    publicClass.daStaff = new SqlDataAdapter("SELECT tblStaffRegistration.*, tblRetirementDate.RetirementDate, tblRetirementDate.RetirementReason FROM tblStaffRegistration INNER JOIN tblREtirementDate ON tblStaffRegistration.StaffNo=tblRetirementDate.StaffNo WHERE tblStaffRegistration.StaffNo='" + staffNo + "'", conn);
                                    publicClass.daStaff.Fill(dsRetirementReminder, "retire");

                                    //INSERT INTO retirees table
                                    if (dsRetirementReminder.Tables["retire"].Rows.Count == 1)
                                    {
                                        publicClass.cmdStaff.Connection = conn;
                                        publicClass.cmdStaff.CommandText = "DELETE FROM tblExpectedRetirees WHERE StaffNo=@staffnum";
                                        publicClass.cmdStaff.Parameters.AddWithValue("@staffnum", staffNo);

                                        publicClass.cmdStaff.ExecuteNonQuery();
                                        publicClass.cmdStaff.Parameters.Clear();

                                        publicClass.cmdStaff.CommandText = "INSERT INTO tblRetirees VALUES(@staffno, @fn, @mn, @ln, @sex, @mstatus, @noofchild, @dob, @ht, @nationality, @soo, @lga, @religion, @caddress, @paddress, @phone, @email, @qua, @specialty, @doa, @rank, @grade, @blood, @pix, @Rdate, @Rreason)";
                                        publicClass.cmdStaff.Parameters.AddWithValue("@staffno", dsRetirementReminder.Tables["retire"].Rows[0]["StaffNo"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@fn", dsRetirementReminder.Tables["retire"].Rows[0]["FirstName"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@mn", dsRetirementReminder.Tables["retire"].Rows[0]["Middlename"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@ln", dsRetirementReminder.Tables["retire"].Rows[0]["Surname"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@sex", dsRetirementReminder.Tables["retire"].Rows[0]["sex"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@mstatus", dsRetirementReminder.Tables["retire"].Rows[0]["MarritalStatus"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@noofchild", dsRetirementReminder.Tables["retire"].Rows[0]["NoofChildren"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@dob", dsRetirementReminder.Tables["retire"].Rows[0]["DateofBirth"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@ht", dsRetirementReminder.Tables["retire"].Rows[0]["HomeTown"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@nationality", dsRetirementReminder.Tables["retire"].Rows[0]["Nationality"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@soo", dsRetirementReminder.Tables["retire"].Rows[0]["StateofOrigin"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@lga", dsRetirementReminder.Tables["retire"].Rows[0]["LGA"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@religion", dsRetirementReminder.Tables["retire"].Rows[0]["Religion"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@caddress", dsRetirementReminder.Tables["retire"].Rows[0]["ContactAddress"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@paddress", dsRetirementReminder.Tables["retire"].Rows[0]["PermanentAddress"].ToString());

                                        publicClass.cmdStaff.Parameters.AddWithValue("@phone", dsRetirementReminder.Tables["retire"].Rows[0]["PhoneNo"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@email", dsRetirementReminder.Tables["retire"].Rows[0]["Email"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@qua", dsRetirementReminder.Tables["retire"].Rows[0]["Qualification"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@specialty", dsRetirementReminder.Tables["retire"].Rows[0]["Speciaty"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@doa", dsRetirementReminder.Tables["retire"].Rows[0]["DateofAppointment"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@rank", dsRetirementReminder.Tables["retire"].Rows[0]["JobTitle"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@grade", dsRetirementReminder.Tables["retire"].Rows[0]["GradelevelSteps"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@blood", dsRetirementReminder.Tables["retire"].Rows[0]["BloodGroup"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@pix", dsRetirementReminder.Tables["retire"].Rows[0]["pix"]);
                                        publicClass.cmdStaff.Parameters.AddWithValue("@Rdate", dsRetirementReminder.Tables["retire"].Rows[0]["RetirementDate"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@Rreason", dsRetirementReminder.Tables["retire"].Rows[0]["RetirementReason"].ToString());
                                 
                                        publicClass.cmdStaff.ExecuteNonQuery();
                                        publicClass.cmdStaff.Parameters.Clear();
                                    }
                                    conn.Close();
                                }
                            }
                            else//Hqtrs
                            {
                                connHtqrs = new SqlConnection(conStrHqtrs);
                                if (remaininMonths > 0)
                                {                                    
                                    publicClass.cmdStaff.Connection = connHtqrs;
                                    connHtqrs.Open();
                                    publicClass.cmdStaff.CommandText = "UPDATE tblExpectedRetirees SET NoofMonths=@remainingmonths WHERE StaffNo=@staffnum";
                                    publicClass.cmdStaff.Parameters.AddWithValue("@staffnum", staffNo);
                                    publicClass.cmdStaff.Parameters.AddWithValue("@remainingmonths", remaininMonths);
                                    publicClass.cmdStaff.ExecuteNonQuery();
                                    connHtqrs.Close();
                                    publicClass.cmdStaff.Parameters.Clear();
                                }
                                else
                                {
                                    connHtqrs.Open();
                                    publicClass.daStaff = new SqlDataAdapter("SELECT tblStaffRegistration.*, tblRetirementDate.RetirementDate, tblRetirementDate.RetirementReason FROM tblStaffRegistration INNER JOIN tblREtirementDate ON tblStaffRegistration.StaffNo=tblRetirementDate.StaffNo WHERE tblStaffRegistration.StaffNo='" + staffNo + "'", connHtqrs);
                                    publicClass.daStaff.Fill(dsRetirementReminder, "retire");

                                    //INSERT INTO retirees table
                                    if (dsRetirementReminder.Tables["retire"].Rows.Count == 1)
                                    {
                                        publicClass.cmdStaff.Connection = connHtqrs;
                                        publicClass.cmdStaff.CommandText = "DELETE FROM tblExpectedRetirees WHERE StaffNo=@staffnum";
                                        publicClass.cmdStaff.Parameters.AddWithValue("@staffnum", staffNo);

                                        publicClass.cmdStaff.ExecuteNonQuery();
                                        publicClass.cmdStaff.Parameters.Clear();

                                        publicClass.cmdStaff.CommandText = "INSERT INTO tblRetirees VALUES(@staffno, @fn, @mn, @ln, @sex, @mstatus, @noofchild, @dob, @ht, @nationality, @soo, @lga, @religion, @caddress, @paddress, @phone, @email, @qua, @specialty, @doa, @rank, @grade, @blood, @pix, @Rdate, @Rreason)";
                                        publicClass.cmdStaff.Parameters.AddWithValue("@staffno", dsRetirementReminder.Tables["retire"].Rows[0]["StaffNo"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@fn", dsRetirementReminder.Tables["retire"].Rows[0]["FirstName"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@mn", dsRetirementReminder.Tables["retire"].Rows[0]["Middlename"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@ln", dsRetirementReminder.Tables["retire"].Rows[0]["Surname"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@sex", dsRetirementReminder.Tables["retire"].Rows[0]["sex"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@mstatus", dsRetirementReminder.Tables["retire"].Rows[0]["MarritalStatus"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@noofchild", dsRetirementReminder.Tables["retire"].Rows[0]["NoofChildren"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@dob", dsRetirementReminder.Tables["retire"].Rows[0]["DateofBirth"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@ht", dsRetirementReminder.Tables["retire"].Rows[0]["HomeTown"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@nationality", dsRetirementReminder.Tables["retire"].Rows[0]["Nationality"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@soo", dsRetirementReminder.Tables["retire"].Rows[0]["StateofOrigin"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@lga", dsRetirementReminder.Tables["retire"].Rows[0]["LGA"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@religion", dsRetirementReminder.Tables["retire"].Rows[0]["Religion"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@caddress", dsRetirementReminder.Tables["retire"].Rows[0]["ContactAddress"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@paddress", dsRetirementReminder.Tables["retire"].Rows[0]["PermanentAddress"].ToString());

                                        publicClass.cmdStaff.Parameters.AddWithValue("@phone", dsRetirementReminder.Tables["retire"].Rows[0]["PhoneNo"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@email", dsRetirementReminder.Tables["retire"].Rows[0]["Email"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@qua", dsRetirementReminder.Tables["retire"].Rows[0]["Qualification"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@specialty", dsRetirementReminder.Tables["retire"].Rows[0]["Speciaty"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@doa", dsRetirementReminder.Tables["retire"].Rows[0]["DateofAppointment"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@rank", dsRetirementReminder.Tables["retire"].Rows[0]["JobTitle"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@grade", dsRetirementReminder.Tables["retire"].Rows[0]["GradelevelSteps"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@blood", dsRetirementReminder.Tables["retire"].Rows[0]["BloodGroup"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@pix", dsRetirementReminder.Tables["retire"].Rows[0]["pix"]);
                                        publicClass.cmdStaff.Parameters.AddWithValue("@Rdate", dsRetirementReminder.Tables["retire"].Rows[0]["RetirementDate"].ToString());
                                        publicClass.cmdStaff.Parameters.AddWithValue("@Rreason", dsRetirementReminder.Tables["retire"].Rows[0]["RetirementReason"].ToString());

                                        publicClass.cmdStaff.ExecuteNonQuery();
                                        publicClass.cmdStaff.Parameters.Clear();
                                    }
                                    connHtqrs.Close();
                                }
                        }
                        
                        
                    
                }//nforext
                conn = new SqlConnection(conStr);
                publicClass.cmdStaff.Connection = conn;
                publicClass.cmdStaff.CommandText = "UPDATE tblReminder SET ReminderDate=@reminderdate";
                publicClass.cmdStaff.Parameters.AddWithValue("@reminderdate", nextReminder);
                conn.Open();
                publicClass.cmdStaff.ExecuteNonQuery();
                conn.Close();
                publicClass.cmdStaff.Parameters.Clear();
                //saveTransact.Commit();
            //}
            //catch(Exception ex)
            //{
            //    try
            //    {
            //        saveTransact.Rollback();
            //    }
            //    catch(Exception ex2)
            //    {

            //    }
            //}
            return "1";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (HttpContext.Current.User.Identity.Name == "achirjerome")
            //{
            //    Button1.Visible = true;
            //}
            //else
            //{
            //    Button1.Visible = false;
            //}
            DateTime date = DateTime.Now.Date;

            DataSet dsReminder = new DataSet();
            DateTime nextSixMonths = date.AddMonths(6);
            int dayofTheMonth = date.Day;
            int month = nextSixMonths.Month;
            int sYear = nextSixMonths.Year;
            int lastDayOfMonth = DateTime.DaysInMonth(sYear, month);
            DateTime retireDate = DateTime.Parse(sYear + "-" + month + "-" + lastDayOfMonth);

            //Check if a check has been ran this month and updated
            //publicClass.connectToDB();
            //publicClass.daStaff = new SqlDataAdapter("SELECT * FROM tblReminder", publicClass.conn);
            //publicClass.daStaff.Fill(dsReminder, "remind");

            //DateTime reminderDate = DateTime.Parse(dsReminder.Tables["remind"].Rows[0]["ReminderDate"].ToString());

            //if (dsReminder.Tables["remind"].Rows[0]["Reminded"].ToString() == "1")// 1 means reminder has not occured
            //{

            //    if (reminderDate < date)
            //    {
            //        //Select those that are due for retirement in six months in th LGEA Database
            //        publicClass.connectToDB();
            //        publicClass.daStaff = new SqlDataAdapter("SELECT tblRetirementDate.staffNo, tblRetirementDate.RetirementDate, tblStaffRegistration.PhoneNo FROM tblRetirementDate INNER JOIN tblstaffRegistration ON tblRetirementDate.StaffNo=tblStaffRegistration.StaffNo WHERE tblRetirementDate.RetirementDate='" + retireDate + "'", publicClass.conn);
            //        publicClass.daStaff.Fill(dsReminder, "moreretirees");

            //        if (dsReminder.Tables["moreretirees"].Rows.Count > 0)
            //        {
            //            for (int noToRetire = 0; noToRetire < dsReminder.Tables["moreretirees"].Rows.Count; noToRetire++)
            //            {
            //                string StaffNum = dsReminder.Tables["moreretirees"].Rows[noToRetire]["staffNo"].ToString();
            //                if (dsReminder.Tables.Contains("stff"))
            //                {
            //                    dsReminder.Tables.Remove("stff");
            //                }
            //                publicClass.connectToDB();
            //                publicClass.daStaff = new SqlDataAdapter("SELECT staffNo FROM tblExpectedRetirees WHERE staffNo='" + StaffNum + "'", publicClass.conn);
            //                publicClass.daStaff.Fill(dsReminder, "stff");

            //                if (dsReminder.Tables["stff"].Rows.Count == 0)
            //                {
            //                    publicClass.cmdStaff.Connection = publicClass.conn;
            //                    publicClass.cmdStaff.CommandText = "INSERT INTO tblExpectedRetirees VALUES(@staffnumber, @phoneno, @monthsleft, @retiredate, @lgeadb)";
            //                    publicClass.cmdStaff.Parameters.AddWithValue("@staffnumber", StaffNum);
            //                    publicClass.cmdStaff.Parameters.AddWithValue("@phoneno", dsReminder.Tables["moreretirees"].Rows[noToRetire]["phoneno"].ToString());
            //                    publicClass.cmdStaff.Parameters.AddWithValue("@monthsleft", 6);
            //                    publicClass.cmdStaff.Parameters.AddWithValue("@retiredate", dsReminder.Tables["moreretirees"].Rows[noToRetire]["retirementDate"].ToString());
            //                    publicClass.cmdStaff.Parameters.AddWithValue("@lgeadb", "1");
            //                    publicClass.cmdStaff.ExecuteNonQuery();
            //                    publicClass.cmdStaff.Parameters.Clear();
            //                }
            //            }
            //        }



            //        //Select those that are due for retirement in six months in th HQTrs Database
            //        publicClass.connectToDB();
            //        publicClass.daStaff = new SqlDataAdapter("SELECT tblRetirementDate.staffNo, tblRetirementDate.RetirementDate, tblStaffRegistration.PhoneNo FROM tblRetirementDate INNER JOIN tblstaffRegistration ON tblRetirementDate.StaffNo=tblStaffRegistration.StaffNo WHERE tblRetirementDate.RetirementDate='" + retireDate + "'", publicClass.conn);
            //        publicClass.daStaff.Fill(dsReminder, "moreretirees");

            //        if (dsReminder.Tables["moreretirees"].Rows.Count > 0)
            //        {
            //            for (int noToRetire = 0; noToRetire < dsReminder.Tables["moreretirees"].Rows.Count; noToRetire++)
            //            {
            //                string StaffNum = dsReminder.Tables["moreretirees"].Rows[noToRetire]["staffNo"].ToString();
            //                if (dsReminder.Tables.Contains("stff"))
            //                {
            //                    dsReminder.Tables.Remove("stff");
            //                }
            //                publicClass.daStaff = new SqlDataAdapter("SELECT staffNo FROM tblExpectedRetirees WHERE staffNo='" + StaffNum + "'", publicClass.conn);
            //                publicClass.daStaff.Fill(dsReminder, "stff");

            //                //Check to see if staffNo is in tblExpectedRetirees b4 inserting

            //                if (dsReminder.Tables["stff"].Rows.Count == 0)
            //                {
            //                    publicClass.cmdStaff.Connection = publicClass.conn;
            //                    publicClass.cmdStaff.CommandText = "INSERT INTO tblExpectedRetirees VALUES(@staffnum, @phoneno, @monthsleft, @retiredate, @lgeadb)";
            //                    publicClass.cmdStaff.Parameters.AddWithValue("@staffnum", StaffNum);
            //                    publicClass.cmdStaff.Parameters.AddWithValue("@phoneno", dsReminder.Tables["moreretirees"].Rows[noToRetire]["phoneno"].ToString());
            //                    publicClass.cmdStaff.Parameters.AddWithValue("@monthsleft", 6);
            //                    publicClass.cmdStaff.Parameters.AddWithValue("@retiredate", dsReminder.Tables["moreretirees"].Rows[noToRetire]["retirementDate"].ToString());
            //                    publicClass.cmdStaff.Parameters.AddWithValue("@lgeadb", "1");
            //                    publicClass.cmdStaff.ExecuteNonQuery();
            //                    publicClass.cmdStaff.Parameters.Clear();
            //                }
            //            }
            //        }

            //        DateTime nextReminder = date.AddMonths(1);
            //        int Rmonth = nextReminder.Month;
            //        int Rday = DateTime.DaysInMonth(nextReminder.Year, Rmonth);

            //        nextReminder = DateTime.Parse(nextReminder.Year + "-" + Rmonth + "-" + Rday);
            //        publicClass.daStaff = new SqlDataAdapter("SELECT * FROM tblExpectedRetirees", publicClass.conn);
            //        publicClass.daStaff.Fill(dsReminder, "retirees");
            //        if (dsReminder.Tables["retirees"].Rows.Count > 0)
            //        {
            //            string dff = retirementRemider(dsReminder.Tables["retirees"], nextReminder);
            //        }


            //    }


            //}



            //publicClass.connectToDB();
            //publicClass.daStaff = new SqlDataAdapter("SELECT * FROM tblReminder", publicClass.conn);
            //publicClass.daStaff.Fill(dsReminder, "remind");




        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //UpdatePanel1.Update();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //publicClass.cmdStaff.Connection = publicClass.conn;
            //publicClass.cmdStaff.CommandType = CommandType.Text;
            //publicClass.cmdStaff.CommandText = "INSERT INTO tblTimer VALUES(@TimerValue)";
            //publicClass.cmdStaff.Parameters.AddWithValue("@TimerValue", "1");
            //publicClass.cmdStaff.ExecuteNonQuery();
            //Timer2.Enabled = true;

        }

        protected void Timer2_Tick(object sender, EventArgs e)
        {
            this.Visible = false;
        }

       
    }
}