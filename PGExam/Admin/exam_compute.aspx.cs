using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace DesignTemplate1.Admin
{
    public partial class exam_compute : System.Web.UI.Page
    {
        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        examination new_exam = new examination();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtcourse_option;
                for (int i = 2010; i <= DateTime.Now.Year; i++)
                {
                    int y = i + 1;
                    ddlLsession.Items.Add(i.ToString());
                    ddlUsession.Items.Add(y.ToString());
                }
                string Dept_ = Session["department"].ToString();
                programme new_prog = new programme();
                dtcourse_option = new_prog.select_course_options(Dept_);

                ddlCourse_Option.DataTextField = "Program";
                ddlCourse_Option.DataSource = dtcourse_option;
                ddlCourse_Option.DataBind();

            
            }
        }

        protected void btnCompute_Click(object sender, EventArgs e)
        {  
            
            try
            {
                //Check to make sure the lower part of session is 1 less than the upper part
                int YrDiff = int.Parse(ddlUsession.Text) - int.Parse(ddlLsession.Text);
                if (YrDiff != 1)
                {
                    MsgBox("Abnormal academic session", this.Page, Page);
                    return;
                }
                string academic_session = ddlLsession.Text + "/" + ddlUsession.Text;
                string semester = ddlSemester.Text;
                string course_option = ddlCourse_Option.Text;
                string program = ddlProgram.Text;

                string success = new_exam.compute(academic_session, semester, course_option, program);
                if (success == "SUCCESS")
                {
                    lblmsg.Text = success;
                }
                else
                {
                    throw new Exception(success);
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text=ex.Message;
            }
            
        }
    }
}