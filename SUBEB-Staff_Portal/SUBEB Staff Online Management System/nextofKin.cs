using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace SUBEB_Staff_Online_Management_System
{
    public class nextofKin
    {
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;

        public string KinCode { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string Surname { get; set; }
        public string HomeTown { get; set; }
        public string LGA { get; set; }
        public string StateofOrigin { get; set; }
        public string Nationality { get; set; }
        public string Relationship { get; set; }
        public string ContactAddress { get; set; }
        public string PhoneNo { get; set; }
        public string StaffNo { get; set; }

        public string Register(nextofKin kin)
        {
            try
            {
                if (publicClass.dbLGEA == true)
                {
                    conn = new SqlConnection(conStr);
                    publicClass.cmdStaff.CommandType = CommandType.Text;
                    publicClass.cmdStaff.Connection = conn;

                    publicClass.cmdStaff.CommandText = "INSERT INTO tblNextofKin VALUES(@kincode, @firstname, @middlename, @surname, @hometown, @lga, @soo, @nationality, @relationship, @conaddress, @phoneno, @staffno)";
                    publicClass.cmdStaff.Parameters.AddWithValue("@kincode", kin.KinCode);
                    publicClass.cmdStaff.Parameters.AddWithValue("@firstname", kin.firstName);
                    publicClass.cmdStaff.Parameters.AddWithValue("@middlename", kin.middleName);
                    publicClass.cmdStaff.Parameters.AddWithValue("@surname", kin.Surname);
                    publicClass.cmdStaff.Parameters.AddWithValue("@hometown", kin.HomeTown);
                    publicClass.cmdStaff.Parameters.AddWithValue("@lga", kin.LGA);
                    publicClass.cmdStaff.Parameters.AddWithValue("@soo", kin.StateofOrigin);
                    publicClass.cmdStaff.Parameters.AddWithValue("@nationality", kin.Nationality);
                    publicClass.cmdStaff.Parameters.AddWithValue("@relationship", kin.Relationship);
                    publicClass.cmdStaff.Parameters.AddWithValue("@conaddress", kin.ContactAddress);
                    publicClass.cmdStaff.Parameters.AddWithValue("@phoneno", kin.PhoneNo);
                    publicClass.cmdStaff.Parameters.AddWithValue("@staffno", kin.StaffNo);

                    conn.Open();
                    publicClass.cmdStaff.ExecuteNonQuery();
                    conn.Close();
                    publicClass.cmdStaff.Parameters.Clear();

                }
                else
                {
                    connHtqrs = new SqlConnection(conStrHqtrs);
                    publicClass.cmdStaff.CommandType = CommandType.Text;
                    publicClass.cmdStaff.Connection = connHtqrs;

                    publicClass.cmdStaff.CommandText = "INSERT INTO tblNextofKin VALUES(@kincode, @firstname, @middlename, @surname, @hometown, @lga, @soo, @nationality, @relationship, @conaddress, @phoneno, @staffno)";
                    publicClass.cmdStaff.Parameters.AddWithValue("@kincode", kin.KinCode);
                    publicClass.cmdStaff.Parameters.AddWithValue("@firstname", kin.firstName);
                    publicClass.cmdStaff.Parameters.AddWithValue("@middlename", kin.middleName);
                    publicClass.cmdStaff.Parameters.AddWithValue("@surname", kin.Surname);
                    publicClass.cmdStaff.Parameters.AddWithValue("@hometown", kin.HomeTown);
                    publicClass.cmdStaff.Parameters.AddWithValue("@lga", kin.LGA);
                    publicClass.cmdStaff.Parameters.AddWithValue("@soo", kin.StateofOrigin);
                    publicClass.cmdStaff.Parameters.AddWithValue("@nationality", kin.Nationality);
                    publicClass.cmdStaff.Parameters.AddWithValue("@relationship", kin.Relationship);
                    publicClass.cmdStaff.Parameters.AddWithValue("@conaddress", kin.ContactAddress);
                    publicClass.cmdStaff.Parameters.AddWithValue("@phoneno", kin.PhoneNo);
                    publicClass.cmdStaff.Parameters.AddWithValue("@staffno", kin.StaffNo);

                    connHtqrs.Open();
                    publicClass.cmdStaff.ExecuteNonQuery();
                    connHtqrs.Close();
                    publicClass.cmdStaff.Parameters.Clear();
                }
            }
            catch(Exception ex)
            { }
            return "Record registered successfully.";
        }

        public string updateNextofKin(nextofKin kin)
        {
            try {
                if (publicClass.dbLGEA == true)
                {
                    conn = new SqlConnection(conStr);
                    publicClass.cmdStaff.CommandType = CommandType.Text;
                    publicClass.cmdStaff.Connection = conn;

                    publicClass.cmdStaff.CommandText = "UPDATE tblNextofKin SET firstname=@firstname, middlename=@middlename, surname=@surname, homeTown=@hometown, LGA=@lga, StateofOrigin=@soo, Nationality=@nationality, Relationship=@relationship, ContactAddress=@conaddress, PhoneNo=@phoneno, StaffNo=@staffno WHERE StaffNo=@staffno";

                    publicClass.cmdStaff.Parameters.AddWithValue("@firstname", kin.firstName);
                    publicClass.cmdStaff.Parameters.AddWithValue("@middlename", kin.middleName);
                    publicClass.cmdStaff.Parameters.AddWithValue("@surname", kin.Surname);
                    publicClass.cmdStaff.Parameters.AddWithValue("@hometown", kin.HomeTown);
                    publicClass.cmdStaff.Parameters.AddWithValue("@lga", kin.LGA);
                    publicClass.cmdStaff.Parameters.AddWithValue("@soo", kin.StateofOrigin);
                    publicClass.cmdStaff.Parameters.AddWithValue("@nationality", kin.Nationality);
                    publicClass.cmdStaff.Parameters.AddWithValue("@relationship", kin.Relationship);
                    publicClass.cmdStaff.Parameters.AddWithValue("@conaddress", kin.ContactAddress);
                    publicClass.cmdStaff.Parameters.AddWithValue("@phoneno", kin.PhoneNo);
                    publicClass.cmdStaff.Parameters.AddWithValue("@staffno", kin.StaffNo);

                    conn.Open();
                    publicClass.cmdStaff.ExecuteNonQuery();
                    conn.Close();
                    publicClass.cmdStaff.Parameters.Clear();

                    DataSet dsPhoneNo = new DataSet();
                    conn.Open();
                    SqlDataAdapter daPhone = new SqlDataAdapter("SELECT PhoneNo FROM tblStaffRegistration WHERE staffNo='" + StaffNo + "'", conn);
                    daPhone.Fill(dsPhoneNo, "phone");

                    if (dsPhoneNo.Tables["phone"].Rows.Count > 0)
                    {
                        if (!(string.IsNullOrEmpty(dsPhoneNo.Tables["phone"].Rows[0]["Phoneno"].ToString())))
                        {
                            string PhoneNo = "08038447495";// dsPhoneNo.Tables["phone"].Rows[0]["Phoneno"].ToString();
                            sendText newSMS = new sendText();
                            newSMS.sendSMS(PhoneNo, "You changed your next of kin. If you were not the one please call " + publicClass.HelpNo + "'.");
                        }
                    }
                    conn.Close();

                }
                else
                {
                    connHtqrs = new SqlConnection(conStrHqtrs);
                    publicClass.cmdStaff.CommandType = CommandType.Text;
                    publicClass.cmdStaff.Connection = connHtqrs;

                    publicClass.cmdStaff.CommandText = "UPDATE tblNextofKin SET firstname=@firstname, middlename=@middlename, surname=@surname, homeTown=@hometown, LGA=@lga, StateofOrigin=@soo, Nationality=@nationality, Relationship=@relationship, ContactAddress=@conaddress, PhoneNo=@phoneno, StaffNo=@staffno WHERE StaffNo=@staffno";

                    publicClass.cmdStaff.Parameters.AddWithValue("@firstname", kin.firstName);
                    publicClass.cmdStaff.Parameters.AddWithValue("@middlename", kin.middleName);
                    publicClass.cmdStaff.Parameters.AddWithValue("@surname", kin.Surname);
                    publicClass.cmdStaff.Parameters.AddWithValue("@hometown", kin.HomeTown);
                    publicClass.cmdStaff.Parameters.AddWithValue("@lga", kin.LGA);
                    publicClass.cmdStaff.Parameters.AddWithValue("@soo", kin.StateofOrigin);
                    publicClass.cmdStaff.Parameters.AddWithValue("@nationality", kin.Nationality);
                    publicClass.cmdStaff.Parameters.AddWithValue("@relationship", kin.Relationship);
                    publicClass.cmdStaff.Parameters.AddWithValue("@conaddress", kin.ContactAddress);
                    publicClass.cmdStaff.Parameters.AddWithValue("@phoneno", kin.PhoneNo);
                    publicClass.cmdStaff.Parameters.AddWithValue("@staffno", kin.StaffNo);

                    connHtqrs.Open();
                    publicClass.cmdStaff.ExecuteNonQuery();
                    connHtqrs.Close();
                    publicClass.cmdStaff.Parameters.Clear();

                    DataSet dsPhoneNo = new DataSet();
                    conn.Open();
                    SqlDataAdapter daPhone = new SqlDataAdapter("SELECT PhoneNo FROM tblStaffRegistration WHERE staffNo='" + StaffNo + "'", conn);
                    daPhone.Fill(dsPhoneNo, "phone");

                    if (dsPhoneNo.Tables["phone"].Rows.Count > 0)
                    {
                        if (!(string.IsNullOrEmpty(dsPhoneNo.Tables["phone"].Rows[0]["Phoneno"].ToString())))
                        {
                            string PhoneNo = "07037839080";// dsPhoneNo.Tables["phone"].Rows[0]["Phoneno"].ToString();
                            sendText newSMS = new sendText();
                            newSMS.sendSMS(PhoneNo, "You changed your next of kin. If you were not the one please call " + publicClass.HelpNo + "'.");
                        }
                    }
                    conn.Close();
                }

            }
            catch(Exception ex)
            { }
            return "Record registered successfully.";
        }

    }

}