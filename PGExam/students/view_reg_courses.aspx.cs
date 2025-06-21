using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DesignTemplate1.students
{
    public partial class view_reg_courses : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlDataAdapter daCourses;
        DataSet dsCourses = new DataSet();
        SqlCommand cmdSave = new SqlCommand();
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string Dept = Session["dept"].ToString();
            string semester = Session["sem"].ToString();
            string academic_session = Session["acad"].ToString();
            string program = Session["prog"].ToString();
            string course_option = Session["option"].ToString();

            if (dsCourses.Tables.Contains("view"))
            {
                dsCourses.Tables.Remove("view");
            }
            conn = new SqlConnection(conStr);
            conn.Open();
            daCourses = new SqlDataAdapter("SELECT course_code, course_title, credit_units, Status FROM tblStudents_semester_courses WHERE semester='" + semester + "' AND + academic_session='" + academic_session + "'AND program='" + program + "'AND course_option='" + course_option + "' AND Dept='" + Dept + "'", conn);
            daCourses.Fill(dsCourses, "view");
            conn.Close();
            GridView1.DataSource = dsCourses.Tables["view"];
            GridView1.DataBind();
        }
    }
}