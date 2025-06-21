using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DesignTemplate1.Admin
{
    public partial class StudentReg : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn;
        SqlDataAdapter daReg;
        DataSet dsStates = new DataSet();
        DataSet dsReg = new DataSet();
        SqlCommand cmdSave = new SqlCommand();

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (dsReg.Tables.Contains("prog"))
            {
                dsReg.Tables.Remove("prog");
            }

            conn = new SqlConnection(conStr);
            conn.Open();
            daReg = new SqlDataAdapter("SELECT program FROM tblProgram ORDER By program", conn);
            daReg.Fill(dsReg, "prog");
            conn.Close();
            ddlCourseofStudy.DataTextField = "program";
            ddlCourseofStudy.DataSource = dsReg.Tables["prog"];
            ddlCourseofStudy.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string success;
            student new_student = new student();
            new_student.matric_no = txtMatric_No.Text;
            new_student.firstname = txtFirstname.Text;
            new_student.middlename = txtFirstname.Text;
            new_student.surname = txtSurname.Text;
            new_student.program = ddlProgram.Text;
            new_student.course_of_study = ddlCourseofStudy.Text;
            new_student.Department = Session["dept"].ToString();

            success = student.register(new_student);
            if(success=="0")
            {
                MsgBox("Registered successfully", this.Page, this);
            }
        }
    }
}