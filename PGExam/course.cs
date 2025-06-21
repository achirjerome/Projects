using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DesignTemplate1
{
    public class course
    {
        public string course_code { get; set; }
        public string course_title { get; set; }
        public string program { get; set; }
        public string course_option { get; set; }
        public string department { get; set; }

        public static string register(course newcourse)
        {
            string responsecode = "1";
            return responsecode;
        }
        public static DataTable select_course(string course_option, string program)
        {
            DataTable dtcourse = null;
            SqlConnection conn;
            SqlDataAdapter dacourse;
            DataSet dscourse = new DataSet();

            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
          
            if (dscourse.Tables.Contains("course"))
            {
                dscourse.Tables.Remove("course");
            }

            conn = new SqlConnection(conStr);
            conn.Open();
            dacourse = new SqlDataAdapter("SELECT course_code FROM tblCourses WHERE program ='" + program + "' AND course_option='" + course_option + "' ORDER By Course_code", conn);
            dacourse.Fill(dscourse, "course");
            conn.Close();

            dtcourse = dscourse.Tables["course"].Copy();
            return dtcourse;
        }
    }
}