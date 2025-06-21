using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DesignTemplate1
{
    public class student
    {
        public string matric_no { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string surname { get; set; }
        public string program { get; set; }
        public string course_of_study { get; set; }
        public string Department { get; set; }

        public static string register(student newstudent)
        {
            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection conn;
            SqlDataAdapter daReg;
            DataSet dsStates = new DataSet();
            DataSet dsReg = new DataSet();
            SqlCommand cmdSave = new SqlCommand();

            string responsecode = "1"; //1 is error and anything else is success
            try
            {
                if (dsReg.Tables.Contains("reg"))
                {
                    dsReg.Tables.Remove("reg");
                }

                conn = new SqlConnection(conStr);
                conn.Open();
                daReg = new SqlDataAdapter("SELECT matric_no FROM tblStudents WHERE matric_no='" + newstudent.matric_no + "'", conn);
                daReg.Fill(dsReg, "reg");
                conn.Close();

                if (dsReg.Tables["reg"].Rows.Count == 0)
                {
                    cmdSave.CommandType = CommandType.Text;
                    //cmdStudent.Transaction = register_transaction;
                    cmdSave.Connection = conn;
                    cmdSave.CommandType = CommandType.Text;
                    cmdSave.CommandText = "INSERT INTO tblStudents VALUES(@matric_no, @fn, @mn, @sn, @prog, @course, @dept)";
                    cmdSave.Parameters.AddWithValue("@matric_no", newstudent.matric_no);
                    cmdSave.Parameters.AddWithValue("@fn", newstudent.firstname);
                    cmdSave.Parameters.AddWithValue("@mn", newstudent.middlename);
                    cmdSave.Parameters.AddWithValue("@sn", newstudent.surname);
                    cmdSave.Parameters.AddWithValue("@prog", newstudent.program);
                    cmdSave.Parameters.AddWithValue("@course", newstudent.course_of_study);
                    cmdSave.Parameters.AddWithValue("@dept", newstudent.Department);


                    conn.Open();
                    cmdSave.ExecuteNonQuery();
                    conn.Close();
                    responsecode = "0";

                    cmdSave.Parameters.Clear();
                }
                else
                {
                    responsecode = "Record already exists";
                }
                //register_transaction.Commit();
                //connectionClass.conn.Close();
            }
            catch (Exception ex)
            {
                responsecode = ex.Message;

            }
            return responsecode;
        }

        public static int reg_sem_courses(student newstudent)
        {
            int reg_courses = 0;

            return reg_courses;
        }
    }
}