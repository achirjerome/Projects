using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;    

namespace DesignTemplate1.Lecturer
{
    public partial class exam_upload : System.Web.UI.Page
    {
        examination new_exam = new examination();
        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }        
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
                public_objects.Dept_ = Session["department"].ToString();
                programme new_prog = new programme();
                dtcourse_option = new_prog.select_course_options(public_objects.Dept_);

                ddlCourse_Option.DataTextField = "Program";
                ddlCourse_Option.DataSource = dtcourse_option;
                ddlCourse_Option.DataBind();

                DataTable dtcourse;
                dtcourse = course.select_course(ddlCourse_Option.Text, ddlProgram.Text);
                ddlCourseCode.DataTextField = "course_code";
                ddlCourseCode.DataSource = dtcourse;
                ddlCourseCode.DataBind();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string success = string.Empty;
            SqlConnection conn;
            SqlDataAdapter daReg;
            DataSet dsStates = new DataSet();
            DataSet dsReg = new DataSet();

            DataTable dtcourse_option;

            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            conn = new SqlConnection(conStr);
                                 
            try
            {
                //===========================================
                //Check to make sure the lower part of session is 1 less than the upper part
                int YrDiff = int.Parse(ddlUsession.Text) - int.Parse(ddlLsession.Text);


                //==============Upload the entire encel book to server=================
                string strFileName = string.Empty;
                string strFilePath = string.Empty;
                string strFolder = string.Empty;
                strFolder = Server.MapPath("/ExcelFiles/");
                // Retrieve the name of the file that is posted.
                strFileName = fulExam.PostedFile.FileName;
                strFileName = Path.GetFileName(strFileName);
                string staff_id = Session["user"].ToString();

                if (fulExam.FileName != "")
                {
                    // Create the folder if it does not exist.
                    if (!Directory.Exists(strFolder))
                    {
                        Directory.CreateDirectory(strFolder);
                    }
                    // Save the uploaded file to the server.
                    strFilePath = strFolder + strFileName;
                    if (File.Exists(strFilePath))
                    {
                        MsgBox(" Already exists on the server!", this.Page, Page);
                        return;
                    }
                    else
                    {
                        //save the entire encel book to server
                        fulExam.PostedFile.SaveAs(strFilePath);

                        string[] not_uploaded = new string[] { };

                        string subject = string.Empty;
                        string course_title = string.Empty;
                        int no_uploaded = 0;
                        int rowCount = 0;
                        string admission_no = string.Empty;
                        string term = string.Empty;
                        double score = 0;
                        string exam_code = string.Empty;
                        DataSet dset = new DataSet();

                        string acadSession = ddlLsession.Text + "/" + ddlUsession.Text;

                        //After a succesful upload, read the excel file content
                        OleDbConnection connection = null;
                        string read = Path.GetFullPath(Server.MapPath("/ExcelFiles/" + fulExam.FileName));

                        if (Path.GetExtension(read) == ".xls")
                        {
                            connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + read + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"");
                        }
                        else if (Path.GetExtension(read) == ".xlsx")
                        {
                            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" + read + ";Extended Properties='Excel 16.0;HDR=YES;IMEX=1;';");
                        }
                        connection.Open();
                        if (dset.Tables.Contains("excel"))
                        {
                            dset.Tables.Remove("excel");
                        }

                        OleDbDataAdapter daRead = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connection);

                        daRead.Fill(dset, "excel");
                        //GridView1.DataSource = dset.Tables["excel"].DefaultView;
                        //GridView1.DataBind();

                        success = new_exam.upload(acadSession, ddlSemester.Text, ddlCourseCode.Text, dset.Tables["excel"], staff_id);
                        
                        if(int.TryParse(success, out int value))
                        {
                            MsgBox(success + " successfully uploaded.", this.Page, Page);
                        }
                        else
                        {
                            MsgBox(success, this.Page, Page);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MsgBox(ex.Message, this.Page, Page);
            }
        }       
                

        protected void ddlCourse_Option_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtcourse;
            dtcourse = course.select_course(ddlCourse_Option.Text, ddlProgram.Text);
            ddlCourseCode.DataTextField = "course_code";
            ddlCourseCode.DataSource = dtcourse;
            ddlCourseCode.DataBind();
        }
    }
}