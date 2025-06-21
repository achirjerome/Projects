using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SUBEB_Staff_Online_Management_System
{
    public class publicClass
    {
        public static SqlConnection conn = new SqlConnection();
        public static SqlConnection connection = new SqlConnection();
        public static SqlCommand cmdStudents =new SqlCommand();
        public static SqlCommand cmdStaff = new SqlCommand();
        public static SqlDataAdapter daStaff;
        public static bool dbLGEA = true; //0 for LGEA DB and 1 for Hqtrs DB
        public static SqlConnection connHqtrs = new SqlConnection();
        public static string picID = string.Empty;
        public  string LogInuserRole = string.Empty;

        public static int radiButtonsValue=0;

        public static string HelpNo = "07037839080";

        public static string LGAID;

       
        public static void connectToDB()
        {
            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            conn = new SqlConnection(conStr);
            if (conn.State.ToString() == "Open")
            {
                conn.Close();
            }
            conn.Open();
        }

        public static void connectToHqtrsDB()
        {
            string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
            connHqtrs = new SqlConnection(conStrHqtrs);
            if (connHqtrs.State.ToString() == "Open")
            {
                connHqtrs.Close();
            }
            connHqtrs.Open();
        }

        public static void connectToSUBEBPV()
        {
            string conStr = ConfigurationManager.ConnectionStrings["GhostWorkers"].ConnectionString;
            connection = new SqlConnection(conStr);
            if (connection.State.ToString() == "Open")
            {
                connection.Close();
            }
            connection.Open();
        }
        public static DataTable selectWorkStation(string section)
        {
            string WorkSection = section;
            //initializeCtrls();
            DataSet dsWorkstation = new DataSet();
            publicClass.connectToDB();

            publicClass.daStaff = new SqlDataAdapter("Select SchoolCode, SchoolName From tblWorkstations WHERE WorkSection='" + WorkSection + "' ORDER BY SchoolName", publicClass.conn);
            publicClass.daStaff.Fill(dsWorkstation, "workstation");

            publicClass.conn.Close();
            return dsWorkstation.Tables["workstation"];
        }

        //Method to generate serial number for every staff
        public static string GetSerialNumber(string staffNo)
        {
            Guid SerialGuid = Guid.NewGuid();
            string uniqueSerial = SerialGuid.ToString("N");
            string uniqueSerialLength = uniqueSerial.Substring(0, 14).ToUpper();
            char[] SerialArray = uniqueSerialLength.ToCharArray();
            string midSerialNumber = string.Empty;
            string finalSerialNumber = string.Empty;
            char[] divideStaffNo = staffNo.ToCharArray();
            string mixSerial = string.Empty;
            int i = 0;
            while (finalSerialNumber.Length < 14)
            {
                //for (int i = 0; i < 14; i++)
                //{
                if (i < staffNo.Length)
                {
                    finalSerialNumber += SerialArray[i];
                    finalSerialNumber += divideStaffNo[i];
                }
                else
                {
                    finalSerialNumber += SerialArray[i];
                }
                i += 1;

                //if (p == 28)
                //{
                //    break;
                //}
                //else
                //{

                //    i = p - 1;
                //    finalSerialNumber += "-";
                //}
                //}
            }
            return finalSerialNumber;
        }

        public static void retireStaff()
        {
            DataSet dsRetire = new DataSet();
            DateTime DOB, DOA, DOBR, DOAR;
            DateTime retirementDate;
            string retirementReason;
            int dayToRetire;
            publicClass.connectToDB();
            publicClass.daStaff = new SqlDataAdapter("SELECT staffNo, DateofBirth,DateofAppointment FROM tblStaffRegistration", publicClass.conn);
            publicClass.daStaff.Fill(dsRetire, "retire");
            
            for (int i= 0; i < dsRetire.Tables["retire"].Rows.Count; i++)
            {
                if(!(string.IsNullOrEmpty(dsRetire.Tables["retire"].Rows[i]["DateofBirth"].ToString()) || string.IsNullOrEmpty(dsRetire.Tables["retire"].Rows[i]["DateofAppointment"].ToString())))

                {
                    DOB = DateTime.Parse(dsRetire.Tables["retire"].Rows[i]["DateofBirth"].ToString());
                    DOA = DateTime.Parse(dsRetire.Tables["retire"].Rows[i]["DateofAppointment"].ToString());

                    DOBR = DOB.AddYears(60);
                    DOBR = DOBR.AddDays(-1);
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
                        retirementDate= retirementDate.AddMonths(-1); //Reduce retirement month to previous month
                    }
                    int monthToRetire = retirementDate.Month;
                    int yearToRetire = retirementDate.Year;
                    dayToRetire = DateTime.DaysInMonth(yearToRetire, monthToRetire);//Retrieve the number of days in the retirement month
                    retirementDate = DateTime.Parse(yearToRetire + "-" + monthToRetire + "-" + dayToRetire); //Make the retirement date to be the last day of the month

                    publicClass.cmdStaff.Connection = publicClass.conn;
                    publicClass.cmdStaff.CommandType = CommandType.Text;
                    publicClass.cmdStaff.CommandText = "INSERT INTO tblRetirement VALUES(@staffNo, @retiredate, @reason)";
                    publicClass.cmdStaff.Parameters.AddWithValue("@staffNo", dsRetire.Tables["retire"].Rows[i]["staffno"].ToString());
                    publicClass.cmdStaff.Parameters.AddWithValue("@retiredate", retirementDate);
                    publicClass.cmdStaff.Parameters.AddWithValue("@reason", retirementReason);
                    publicClass.cmdStaff.ExecuteNonQuery();
                    publicClass.cmdStaff.Parameters.Clear();
                }
                else
                {
                    //open a textfile and write the staffno the has incomplete information
                    Console.WriteLine(dsRetire.Tables["retire"].Rows[i]["staffno"].ToString());
                }
               
            }

        }



        
    }
}