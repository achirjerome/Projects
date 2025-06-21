using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SUBEB_Staff_Online_Management_System
{
    public class staff
    {
        public string staffNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public string Sex { get; set; }
        public string MarritalStatus { get; set; }
        public string DateofBirth { get; set; }
        public string HomeTown { get; set; }
        public string Nationality { get; set; }
        public string Stateoforigin { get; set; }
        public string LGA { get; set; }
        public string Religion { get; set; }
        public string ResidentialAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Qualification { get; set; }
        public string Speciaty { get; set; }
        public string DateofAppointment { get; set; }
        public string DateofLastPromotion { get; set; }
        public string GradeLevelSteps { get; set; }
        public string WorkType { get; set; }
        public string WorkStation { get; set; }
        public string WorkLGEA { get; set; }
        public string PostedDate { get; set; }
        public string Rank { get; set; }
        public byte[] Pix { get; set; }
        public string Bank { get; set; }
        public string AccNo { get; set; }
        public string kSurname { get; set; }
        public string KFirstName { get; set; }
        public string kContactAddress { get; set; }
        public string kPhoneNo { get; set; }
        public string RetirementDate { get; set; }
        public string RetirementReason { get; set; }
        public string status { get; set; }
        public string Approval { get; set; }
        public string Category { get; set; }

        //Salary section
        public float Basic { get; set; }
        public float Consolidated { get; set; }
        public float Hazard { get; set; }
        public float Exams { get; set; }
        public float Inducement { get; set; }
        public float LRNGSociety { get; set; }
        public float SUPAll { get; set; }
        public float Tax { get; set; }
        public float NUT { get; set; }
        public float NUTWelfare { get; set; }
        public float CSU { get; set; }
        public static int Count()
        {
            DataSet dsStaff = new DataSet();
            int noofStaff = 0;

            publicClass.daStaff = new SqlDataAdapter("SELECT StaffNo FROM tblStaffRegistration", publicClass.conn);
            publicClass.daStaff.Fill(dsStaff, "noofstaff");
            noofStaff = dsStaff.Tables["noofstaff"].Rows.Count;
            return noofStaff;
        }
        //method to register a new staff
        SqlTransaction registerTransanc = null;
        public string Register( staff newstaff)
        {
            try {

                string success = "0";
                publicClass.connectToDB();
                publicClass.cmdStaff.Connection = publicClass.conn;

                publicClass.cmdStaff.CommandText = @"INSERT INTO tblStaffRegistration(StaffNo, Firstname, Middlename, 
                Surname, Sex, MarritalStatus, DateofBirth, Hometown, LGA, StateofOrigin, Nationality, Religion, 
                ResidentialAddress, PermanentAddress, PhoneNo, Email, Qualification, Speciaty, DateofAppointment, 
                DateofLastPromotion, GradeLevelSteps, WorkType, WorkStation, WorkLGEA, PostedDate, Rank, Picture, Bank, AccountNo,
                kinFirstname, kinSurname, kinContactAddress, kinPhoneNo, RetirementDate, RetirementReason, Status, Approval, Category) 
                VALUES(@staffno,@fn, @mn, @ln, @sex, @mstatus, @dob, @ht, @lga, @soo, @nationality, @religion, @caddress, 
                @paddress, @phone, @email, @qua, @specialty, @doa, @dolp, @grade, @worktype, @workstation, @worklgea, @posteddate, 
                @rank, @pix, @bank, @account, @kfn, @kSur, @kcontact, @kphone, @retiredate, @retirereason, 
                @status, @approval, @category)";

                publicClass.cmdStaff.Parameters.AddWithValue("@staffno", newstaff.staffNo);
                publicClass.cmdStaff.Parameters.AddWithValue("@fn", newstaff.FirstName);
                publicClass.cmdStaff.Parameters.AddWithValue("@mn", newstaff.MiddleName);
                publicClass.cmdStaff.Parameters.AddWithValue("@ln", newstaff.SurName);
                publicClass.cmdStaff.Parameters.AddWithValue("@sex", newstaff.Sex);
                publicClass.cmdStaff.Parameters.AddWithValue("@mstatus", newstaff.MarritalStatus);
                publicClass.cmdStaff.Parameters.AddWithValue("@dob", newstaff.DateofBirth);
                publicClass.cmdStaff.Parameters.AddWithValue("@ht", newstaff.HomeTown);
                publicClass.cmdStaff.Parameters.AddWithValue("@lga", newstaff.LGA);
                publicClass.cmdStaff.Parameters.AddWithValue("@soo", newstaff.Stateoforigin);
                publicClass.cmdStaff.Parameters.AddWithValue("@nationality", newstaff.Nationality);
                publicClass.cmdStaff.Parameters.AddWithValue("@religion", newstaff.Religion);
                publicClass.cmdStaff.Parameters.AddWithValue("@caddress", newstaff.ResidentialAddress);
                publicClass.cmdStaff.Parameters.AddWithValue("@paddress", newstaff.PermanentAddress);
                publicClass.cmdStaff.Parameters.AddWithValue("@phone", newstaff.PhoneNo);
                publicClass.cmdStaff.Parameters.AddWithValue("@email", newstaff.Email);
                publicClass.cmdStaff.Parameters.AddWithValue("@qua", newstaff.Qualification);
                publicClass.cmdStaff.Parameters.AddWithValue("@specialty", newstaff.Speciaty);
                publicClass.cmdStaff.Parameters.AddWithValue("@doa", newstaff.DateofAppointment);
                publicClass.cmdStaff.Parameters.AddWithValue("@dolp", newstaff.DateofLastPromotion);
                publicClass.cmdStaff.Parameters.AddWithValue("@grade", newstaff.GradeLevelSteps);
                publicClass.cmdStaff.Parameters.AddWithValue("@worktype", newstaff.WorkType);
                publicClass.cmdStaff.Parameters.AddWithValue("@workstation", newstaff.WorkStation);
                publicClass.cmdStaff.Parameters.AddWithValue("@worklgea", newstaff.WorkLGEA);
                publicClass.cmdStaff.Parameters.AddWithValue("@posteddate", newstaff.PostedDate);
                publicClass.cmdStaff.Parameters.AddWithValue("@rank", newstaff.Rank);
                publicClass.cmdStaff.Parameters.AddWithValue("@pix", newstaff.Pix);
                publicClass.cmdStaff.Parameters.AddWithValue("@bank", newstaff.Bank);
                publicClass.cmdStaff.Parameters.AddWithValue("@account", newstaff.AccNo);
                publicClass.cmdStaff.Parameters.AddWithValue("@kfn", newstaff.KFirstName);
                publicClass.cmdStaff.Parameters.AddWithValue("@kSur", newstaff.kSurname);
                publicClass.cmdStaff.Parameters.AddWithValue("@kcontact", newstaff.kContactAddress);
                publicClass.cmdStaff.Parameters.AddWithValue("@kphone", newstaff.kPhoneNo);
                publicClass.cmdStaff.Parameters.AddWithValue("@retiredate", newstaff.RetirementDate);
                publicClass.cmdStaff.Parameters.AddWithValue("@retirereason", newstaff.RetirementReason);
                publicClass.cmdStaff.Parameters.AddWithValue("@status", newstaff.status);
                publicClass.cmdStaff.Parameters.AddWithValue("@approval", newstaff.Approval);
                publicClass.cmdStaff.Parameters.AddWithValue("@category", newstaff.Category);


                publicClass.cmdStaff.ExecuteNonQuery();
                promote(newstaff);
                success = "1";

                publicClass.conn.Close();
                return success;
            }
            catch(Exception ex)
            {
                return (ex.Message);
                
            }
            
        }

        //Method to promote a staff to currentlevel table
        public static string promote(staff newstaff)
        {
            DataSet dsPromote = new DataSet();
            SqlDataAdapter daPromote;
            string staffno = newstaff.staffNo;
            string paygroup = newstaff.GradeLevelSteps;
            string promotioncode = newstaff.DateofLastPromotion + staffno;
            string success = string.Empty;

            try
            {
                switch (newstaff.Category)
                {
                    case "Teaching":


                        if (dsPromote.Tables.Contains("exist"))
                        {
                            dsPromote.Tables.Remove("exist");
                        }
                        daPromote = new SqlDataAdapter("SELECT staffNo FROM tblPVPermanentIncomes WHERE staffNo='" + staffno + "'", publicClass.conn); //Check if staffno not in LGEAPV 
                        daPromote.Fill(dsPromote, "exist");
                        if (dsPromote.Tables["exist"].Rows.Count > 0) //Already exists then move current to promoted history
                        {
                            if (dsPromote.Tables.Contains("old"))
                            {
                                dsPromote.Tables.Remove("old");
                            }

                            //publicClass.connecttoLGEADB();
                            daPromote = new SqlDataAdapter("SELECT StaffNo, PayGroupWithStep, DateofLastPromotion FROM tblStaffRegistration WHERE staffno='" + staffno + "'", publicClass.conn);
                            daPromote.Fill(dsPromote, "old");

                            //copy and save to promotion history table
                            publicClass.cmdStaff.Connection = publicClass.conn;

                            publicClass.cmdStaff.CommandText = "INSERT INTO tblPromotionHistory(PromotionCode, staffNo, Paygroup, PromotionDate) VALUES(@code, @staffno, @paygroup, @date)";
                            publicClass.cmdStaff.Parameters.AddWithValue("@code", promotioncode);
                            publicClass.cmdStaff.Parameters.AddWithValue("@staffno", staffno);
                            publicClass.cmdStaff.Parameters.AddWithValue("@paygroup", dsPromote.Tables["old"].Rows[0]["PayGroupWithStep"]);
                            publicClass.cmdStaff.Parameters.AddWithValue("@date", dsPromote.Tables["old"].Rows[0]["DateofLastPromotion"]);
                            publicClass.cmdStaff.ExecuteNonQuery();

                            if (dsPromote.Tables.Contains("inc"))
                            {
                                dsPromote.Tables.Remove("inc");
                            }
                            //SELECT income and tax based on the staff paygroup
                            daPromote = new SqlDataAdapter("SELECT tblLGEAIncome.*, tblTax.Tax, tblTax.NUT, tblTax.NUTWelfare FROM tblLGEAIncome INNER JOIN tblTax ON tblLGEAIncome.PaygroupStep=tblTax.PaygroupStep WHERE tblLGEAIncome.PaygroupStep='" + paygroup + "'", publicClass.conn);
                            daPromote.Fill(dsPromote, "inc");

                            //UPDATE tblstaffRegistration with new paygroup
                            //UPDATE tblPVPermanentIncomes with new paygroup

                            publicClass.cmdStaff.CommandText = "UPDATE tblPVPermanentIncomes SET PaygroupWIthStep='" + newstaff.GradeLevelSteps + "', Basic='" + dsPromote.Tables["inc"].Rows[0]["Basic"] + "', Consolidated='" + dsPromote.Tables["inc"].Rows[0]["Consolidated"] + "', Hazard='" + dsPromote.Tables["inc"].Rows[0]["Hazard"] + "', Exams='" + dsPromote.Tables["inc"].Rows[0]["Exams"] + "', Inducement='" + dsPromote.Tables["inc"].Rows[0]["Inducement"] + "', LRNGSociety='" + dsPromote.Tables["inc"].Rows[0]["LRNGSociety"] + "', SUPAll='" + dsPromote.Tables["inc"].Rows[0]["SUPAll"] + "' WHERE StaffNo='" + newstaff.staffNo + "'";
                            publicClass.cmdStaff.ExecuteNonQuery();

                            publicClass.cmdStaff.CommandText = "UPDATE tblPVPermanentDeductions SET Tax=@tax, NUT=@nut, NUTWelfare=@welfare, CSU=@csu WHERE StaffNo='" + newstaff.staffNo + "'";
                            publicClass.cmdStaff.Parameters.AddWithValue("@tax", dsPromote.Tables["inc"].Rows[0]["tax"]);
                            publicClass.cmdStaff.Parameters.AddWithValue("@nut", dsPromote.Tables["inc"].Rows[0]["nut"]);
                            publicClass.cmdStaff.Parameters.AddWithValue("@welfare", dsPromote.Tables["inc"].Rows[0]["NUTWelfare"]);
                            publicClass.cmdStaff.Parameters.AddWithValue("@csu", 0.0);
                            publicClass.cmdStaff.ExecuteNonQuery();
                            publicClass.cmdStaff.Parameters.Clear();

                            publicClass.cmdStaff.CommandText = "UPDATE tblStaffRegistration SET PayGroupWithStep=@paygroup, DateofLastPromotion=@date WHERE StaffNo=@staffno";
                            publicClass.cmdStaff.Parameters.AddWithValue("@paygroup", newstaff.GradeLevelSteps);
                            publicClass.cmdStaff.Parameters.AddWithValue("@date", newstaff.DateofLastPromotion);
                            publicClass.cmdStaff.Parameters.AddWithValue("@staffno", newstaff.staffNo);
                            publicClass.cmdStaff.ExecuteNonQuery();
                            publicClass.cmdStaff.Parameters.Clear();
                            success = "1";
                        }

                        break;
                    case "Non-Teaching":
                        if (dsPromote.Tables.Contains("exist"))
                        {
                            dsPromote.Tables.Remove("exist");
                        }
                        daPromote = new SqlDataAdapter("SELECT staffNo FROM tblPVPermanentIncomes WHERE staffNo='" + staffno + "'", publicClass.conn); //Check if staffno not in LGEAPV 
                        daPromote.Fill(dsPromote, "exist");
                        if (dsPromote.Tables["exist"].Rows.Count > 0) //Already exists then move current to promoted history
                        {
                            if (dsPromote.Tables.Contains("old"))
                            {
                                dsPromote.Tables.Remove("old");
                            }

                            //publicClass.connecttoLGEADB();
                            daPromote = new SqlDataAdapter("SELECT StaffNo, PayGroupWithStep, DateofLastPromotion FROM tblStaffRegistration WHERE staffno='" + staffno + "'", publicClass.conn);
                            daPromote.Fill(dsPromote, "old");

                            //copy and save to promotion history table
                            publicClass.cmdStaff.Connection = publicClass.conn;

                            publicClass.cmdStaff.CommandText = "INSERT INTO tblPromotionHistory(PromotionCode, staffNo, Paygroup, PromotionDate) VALUES(@code, @staffno, @paygroup, @date)";
                            publicClass.cmdStaff.Parameters.AddWithValue("@code", promotioncode);
                            publicClass.cmdStaff.Parameters.AddWithValue("@staffno", staffno);
                            publicClass.cmdStaff.Parameters.AddWithValue("@paygroup", dsPromote.Tables["old"].Rows[0]["PayGroupWithStep"]);
                            publicClass.cmdStaff.Parameters.AddWithValue("@date", dsPromote.Tables["old"].Rows[0]["DateofLastPromotion"]);
                            publicClass.cmdStaff.ExecuteNonQuery();

                            if (dsPromote.Tables.Contains("inc"))
                            {
                                dsPromote.Tables.Remove("inc");
                            }
                            //SELECT income and tax based on the staff paygroup
                            daPromote = new SqlDataAdapter("SELECT tblAdminIncome.*, tblTax.Tax, tblTax.CSU FROM tblAdminIncome INNER JOIN tblTax ON tblAdminIncome.PaygroupStep=tblTax.PaygroupStep WHERE tblAdminIncome.PaygroupStep='" + paygroup + "'", publicClass.conn);
                            daPromote.Fill(dsPromote, "inc");

                            //UPDATE tblstaffRegistration with new paygroup
                            //UPDATE tblPVPermanentIncomes with new paygroup

                            publicClass.cmdStaff.CommandText = "UPDATE tblPVPermanentIncomes SET PaygroupWIthStep='" + newstaff.GradeLevelSteps + "', Basic='" + dsPromote.Tables["inc"].Rows[0]["Basic"] + "', Consolidated='" + dsPromote.Tables["inc"].Rows[0]["Consolidated"] + "', Hazard='" + dsPromote.Tables["inc"].Rows[0]["Hazard"] + "', Exams='" + dsPromote.Tables["inc"].Rows[0]["Exams"] + "', Inducement='" + dsPromote.Tables["inc"].Rows[0]["Inducement"] + "', LRNGSociety='" + dsPromote.Tables["inc"].Rows[0]["LRNGSociety"] + "', SUPAll='" + dsPromote.Tables["inc"].Rows[0]["SUPAll"] + "' WHERE StaffNo='" + newstaff.staffNo + "'";
                            publicClass.cmdStaff.ExecuteNonQuery();

                            publicClass.cmdStaff.CommandText = "UPDATE tblPVPermanentDeductions SET Tax=@tax, NUT=@nut, NUTWelfare=@welfare, CSU=@csu WHERE StaffNo='" + newstaff.staffNo + "'";
                            publicClass.cmdStaff.Parameters.AddWithValue("@tax", dsPromote.Tables["inc"].Rows[0]["tax"]);
                            publicClass.cmdStaff.Parameters.AddWithValue("@nut", 0.0);
                            publicClass.cmdStaff.Parameters.AddWithValue("@welfare", 0.0);
                            publicClass.cmdStaff.Parameters.AddWithValue("@csu", dsPromote.Tables["inc"].Rows[0]["CSU"]);
                            publicClass.cmdStaff.ExecuteNonQuery();
                            publicClass.cmdStaff.Parameters.Clear();

                            publicClass.cmdStaff.CommandText = "UPDATE tblStaffRegistration SET PayGroupWithStep=@paygroup, DateofLastPromotion=@date WHERE StaffNo=@staffno";
                            publicClass.cmdStaff.Parameters.AddWithValue("@paygroup", newstaff.GradeLevelSteps);
                            publicClass.cmdStaff.Parameters.AddWithValue("@date", newstaff.DateofLastPromotion);
                            publicClass.cmdStaff.Parameters.AddWithValue("@staffno", newstaff.staffNo);
                            publicClass.cmdStaff.ExecuteNonQuery();
                            publicClass.cmdStaff.Parameters.Clear();
                            success = "1";
                        }

                        break;
                        //case "Hqtrs":
                        //    daPromote = new SQLiteDataAdapter("SELECT * FROM tblHqtrsIncome WHERE PaygroupStep='" + paygroup + "'", publicClass.connLGEA);
                        //    daPromote.Fill(dsPromote, "hqtrs");
                        //    break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return success;
        }
        //Method to post a staff to new workstation in posting table
        public string post(string _staffNo, string _fromDate, string _workStation,  string _workLGEA )
        {
            SqlDataAdapter daPosting;
            DataSet dsPosting = new DataSet();
            //try
            //{
                publicClass.connectToDB();
                daPosting = new SqlDataAdapter("SELECT * FROM tblPosting WHERE staffNo='" + _staffNo + "'", publicClass.conn);
                daPosting.Fill(dsPosting, "post");
                string postCode = "PC" + _staffNo;
                if (dsPosting.Tables["post"].Rows.Count == 0)
                {
                    publicClass.cmdStaff.CommandText = "INSERT INTO tblPosting VALUES(@staffno, @fromDate, @workstation, @worklgea )";
                    publicClass.cmdStaff.Parameters.AddWithValue("@staffno", _staffNo);
                    publicClass.cmdStaff.Parameters.AddWithValue("@fromDate", _fromDate);
                    publicClass.cmdStaff.Parameters.AddWithValue("@workstation", _workStation);
                    publicClass.cmdStaff.Parameters.AddWithValue("@worklgea", _workLGEA);

                    publicClass.cmdStaff.ExecuteNonQuery();
                    publicClass.cmdStaff.Parameters.Clear();
                }
            else
            {

                //publicClass.cmdStaff.CommandText = "INSERT INTO tblPostingHistory VALUES(@postingcode, @staffno, @workstation, @fromdate, @todate)";
                //publicClass.cmdStaff.Parameters.AddWithValue("@postingcode", dsPosting.Tables["post"].Rows[0]["postCode"].ToString());
                //publicClass.cmdStaff.Parameters.AddWithValue("@staffno", dsPosting.Tables["post"].Rows[0]["staffNo"].ToString());
                //publicClass.cmdStaff.Parameters.AddWithValue("@workstation", dsPosting.Tables["post"].Rows[0]["Workstation"].ToString());
                //publicClass.cmdStaff.Parameters.AddWithValue("@fromDate", dsPosting.Tables["post"].Rows[0]["fromDate"].ToString());
                //publicClass.cmdStaff.Parameters.AddWithValue("@fromDate", _toDate);
                //publicClass.cmdStaff.ExecuteNonQuery();

                //publicClass.cmdStaff.CommandText = "UPDATE tblPosting SET workstation=@workstation, fromDate=@fromdate)";
                //publicClass.cmdStaff.Parameters.AddWithValue("@workstation", _workStation);
                //publicClass.cmdStaff.Parameters.AddWithValue("@fromDate", _fromDate);
                //publicClass.cmdStaff.ExecuteNonQuery();
                //publicClass.cmdStaff.Parameters.Clear();
            }

            //}
            //catch (Exception ex)
            //{
            //    return ex.Message;
            //}
            return "0";
        }

        //Method to update a staff record
        public string Update(staff newstaff)
        {
            publicClass.connectToDB();
            publicClass.cmdStaff.CommandType = CommandType.Text;
            publicClass.cmdStaff.Connection = publicClass.conn;

            publicClass.cmdStaff.CommandText = "UPDATE tblStaffRegistration SET FirstName=@firstname, MiddleName=@middlename, SurName=@surname, Sex=@sex, MaritalStatus=@maritalstatus, NoofChildren=@noofchildren, DateofBirth=@dateofbirth, HomeTown=@hometown, LGA=@lga, StateofOrigin=@soo, Nationality=@nationality, Religion=@religion, ContactAddress@conaddress, PermanentAddress=@peraddress, PhoneNo=@phoneno, Email=@email, Qualification=@qualification, FieldofStudy=@fieldofstudy, DateofAppointment=@dateofAppoint,JobTitle=@job, Rank@rank, GradeLevel=@grade, BloodGroup=@bloodgroup, Pix=@pix";
            
            //publicClass.cmdStaff.Parameters.AddWithValue("@firstname", newstaff.FirstName);
            //publicClass.cmdStaff.Parameters.AddWithValue("@middlename", middleName);
            //publicClass.cmdStaff.Parameters.AddWithValue("@surname", Surname);
            //publicClass.cmdStaff.Parameters.AddWithValue("@sex", Sex);
            //publicClass.cmdStaff.Parameters.AddWithValue("@maritalstatus", MaritalStatus);
            //publicClass.cmdStaff.Parameters.AddWithValue("@noofchildren", NoofChildren);
            //publicClass.cmdStaff.Parameters.AddWithValue("@dateofbirth", DateofBirth);
            //publicClass.cmdStaff.Parameters.AddWithValue("@hometown", HomeTown);
            //publicClass.cmdStaff.Parameters.AddWithValue("@lga", LGA);
            //publicClass.cmdStaff.Parameters.AddWithValue("@soo", StateofOrigin);
            //publicClass.cmdStaff.Parameters.AddWithValue("@nationality", Nationality);
            //publicClass.cmdStaff.Parameters.AddWithValue("@religion", Religion);
            //publicClass.cmdStaff.Parameters.AddWithValue("@conaddress", ContactAddress);
            //publicClass.cmdStaff.Parameters.AddWithValue("@peraddress", PermanentAddress);
            //publicClass.cmdStaff.Parameters.AddWithValue("@phoneno", PhoneNo);
            //publicClass.cmdStaff.Parameters.AddWithValue("@email", Email);
            //publicClass.cmdStaff.Parameters.AddWithValue("@qualification", Qualification);
            //publicClass.cmdStaff.Parameters.AddWithValue("@fieldofstudy", FieldOfStyudy);
            //publicClass.cmdStaff.Parameters.AddWithValue("@dateofappoint", DateofAppointment);
            //publicClass.cmdStaff.Parameters.AddWithValue("@job", JobTitle);
            //publicClass.cmdStaff.Parameters.AddWithValue("@rank", Rank);
            //publicClass.cmdStaff.Parameters.AddWithValue("@grade", GradeLevel);
            //publicClass.cmdStaff.Parameters.AddWithValue("@bloodgroup", BloodGroup);
            //publicClass.cmdStaff.Parameters.AddWithValue("@pix", Passport);

            publicClass.cmdStaff.ExecuteNonQuery();
            publicClass.conn.Close();
            return "Record updated successfully.";

        }
        
        //Method to find if staff exists
        //public bool Find(string _StaffNo)
        //{
        //    DataSet dsStaff = new DataSet();
        //    publicClass.connectToDB();
            
        //    publicClass.daStaff = new SqlDataAdapter("SELECT * FROM tblStaffRegistration WHERE StaffNo='" + _StaffNo + "'", publicClass.conn);
        //    publicClass.daStaff.Fill(dsStaff, "found");
        //    if (dsStaff.Tables["found"].Rows.Count==1)
        //    {
        //        Found = true;
        //    }
        //    else
        //    {
        //        Found = false;
        //    }
        //    return Found;

        //}
        //Method to select staff record from database
        //public staff SelectByStaffNo(string No)
        //{
        //    staff selectedStaff = new staff();
        //    DataSet dsStaff = new DataSet();
        //    publicClass.connectToDB();
        //    int selectedNo;
        //    publicClass.daStaff = new SqlDataAdapter("SELECT * FROM tblStaffRegistration WHERE StaffNo='" + No + "'", publicClass.conn);
        //    publicClass.daStaff.Fill(dsStaff, "byno");
        //    if (dsStaff.Tables["byno"].Rows.Count == 1)
        //    {
        //        selectedStaff.staffNo = dsStaff.Tables["byno"].Rows[0]["staffNo"].ToString();
        //        selectedStaff.firstName = dsStaff.Tables["byno"].Rows[0]["FirstName"].ToString();
        //        selectedStaff.middleName = dsStaff.Tables["byno"].Rows[0]["middleName"].ToString();
        //        selectedStaff.Surname = dsStaff.Tables["byno"].Rows[0]["SurName"].ToString();
        //        selectedStaff.Sex = dsStaff.Tables["byno"].Rows[0]["Sex"].ToString();
        //        selectedStaff.MaritalStatus = dsStaff.Tables["byno"].Rows[0]["maritalStatus"].ToString();
        //        selectedStaff.NoofChildren = dsStaff.Tables["byno"].Rows[0]["NoofChildren"].ToString();
        //        selectedStaff.DateofBirth = dsStaff.Tables["byno"].Rows[0]["DateofBirth"].ToString();
        //        selectedStaff.HomeTown = dsStaff.Tables["byno"].Rows[0]["HomeTown"].ToString();
        //        selectedStaff.LGA = dsStaff.Tables["byno"].Rows[0]["LGA"].ToString();
        //        selectedStaff.StateofOrigin = dsStaff.Tables["byno"].Rows[0]["StateofOrigin"].ToString();
        //        selectedStaff.Nationality = dsStaff.Tables["byno"].Rows[0]["Nationality"].ToString();
        //        selectedStaff.Religion = dsStaff.Tables["byno"].Rows[0]["Religion"].ToString();
        //        selectedStaff.ContactAddress = dsStaff.Tables["byno"].Rows[0]["ContactAddress"].ToString();
        //        selectedStaff.PermanentAddress = dsStaff.Tables["byno"].Rows[0]["permanentAddress"].ToString();
        //        selectedStaff.PhoneNo = dsStaff.Tables["byno"].Rows[0]["PhoneNo"].ToString();
        //        selectedStaff.Email = dsStaff.Tables["byno"].Rows[0]["DateofBirth"].ToString();
        //        selectedStaff.Qualification = dsStaff.Tables["byno"].Rows[0]["HomeTown"].ToString();
        //        selectedStaff.FieldOfStyudy = dsStaff.Tables["byno"].Rows[0]["LGA"].ToString();
        //        selectedStaff.DateofAppointment = dsStaff.Tables["byno"].Rows[0]["StateofOrigin"].ToString();
        //        selectedStaff.JobTitle = dsStaff.Tables["byno"].Rows[0]["Nationality"].ToString();
        //        selectedStaff.Rank = dsStaff.Tables["byno"].Rows[0]["Religion"].ToString();
        //        selectedStaff.ContactAddress = dsStaff.Tables["byno"].Rows[0]["ContactAddress"].ToString();
        //        selectedStaff.PermanentAddress = dsStaff.Tables["byno"].Rows[0]["permanentAddress"].ToString();
        //        selectedStaff.PhoneNo = dsStaff.Tables["byno"].Rows[0]["PhoneNo"].ToString();
        //        selectedStaff.Email = dsStaff.Tables["byno"].Rows[0]["email"].ToString();
        //        selectedStaff.Qualification = dsStaff.Tables["byno"].Rows[0]["qualification"].ToString();
        //        selectedStaff.FieldOfStyudy = dsStaff.Tables["byno"].Rows[0]["fieldofStudy"].ToString();
        //        selectedStaff.DateofAppointment = dsStaff.Tables["byno"].Rows[0]["DateofAppointment"].ToString();
        //        selectedStaff.JobTitle = dsStaff.Tables["byno"].Rows[0]["jobTitle"].ToString();
        //        selectedStaff.Rank = dsStaff.Tables["byno"].Rows[0]["rank"].ToString();
        //        selectedStaff.GradeLevel = dsStaff.Tables["byno"].Rows[0]["gradeLevel"].ToString();
        //        selectedStaff.BloodGroup = dsStaff.Tables["byno"].Rows[0]["bloodgroup"].ToString();
        //        selectedStaff.Passport = dsStaff.Tables["byno"].Rows[0]["pix"].ToString();
        //    }
           
        //    return selectedStaff;
        //}

        public void retireStaff(string staffno, DateTime DOB, DateTime DOA)
        {
            //DataSet dsRetire = new DataSet();
            DateTime DOBR, DOAR;
            DateTime retirementDate;
            string retirementReason;
            int dayToRetire;
            
            if (!(string.IsNullOrEmpty(DOB.ToString()) || string.IsNullOrEmpty(DOA.ToString())))

            {
                
                DOBR = DOB.AddYears(60);
                DOAR = DOA.AddYears(35);

                if (DOBR < DOAR)
                {
                    retirementDate = DOBR;
                    retirementReason = "60 years of age";
                }
                else
                {
                    retirementDate = DOAR;
                    retirementReason = "35 years of work";
                }

                dayToRetire = retirementDate.Day;

                //If day of the month to retire is less that 3rd day of that month, retirement should be the end of previous month
                if (dayToRetire < 3)
                {
                    retirementDate = retirementDate.AddMonths(-1); //Reduce retirement month to previous month
                }
                int monthToRetire = retirementDate.Month;
                int yearToRetire = retirementDate.Year;
                dayToRetire = DateTime.DaysInMonth(yearToRetire, monthToRetire);//Retrieve the number of days in the retirement month
                retirementDate = DateTime.Parse(yearToRetire + "-" + monthToRetire + "-" + dayToRetire); //Make the retirement date to be the last day of the month

                publicClass.cmdStaff.Connection = publicClass.conn;
                publicClass.cmdStaff.CommandType = CommandType.Text;
                publicClass.cmdStaff.CommandText = "INSERT INTO tblRetirementDate VALUES(@staffNo, @dob, @doa, @retiredate, @reason)";
                publicClass.cmdStaff.Parameters.AddWithValue("@staffNo", staffno);
                publicClass.cmdStaff.Parameters.AddWithValue("@dob", DOB);
                publicClass.cmdStaff.Parameters.AddWithValue("@doa", DOA);
                publicClass.cmdStaff.Parameters.AddWithValue("@retiredate", retirementDate);
                publicClass.cmdStaff.Parameters.AddWithValue("@reason", retirementReason);
                publicClass.cmdStaff.ExecuteNonQuery();
                publicClass.cmdStaff.Parameters.Clear();
            }
           
        }
    }
}