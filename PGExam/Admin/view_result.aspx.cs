using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CrystalDecisions.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace DesignTemplate1.Admin
{
    public partial class view_result : System.Web.UI.Page
    {
        DataSet dsReg = new DataSet();
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn;
        SqlDataAdapter daReg;
        DataSet dsStates = new DataSet();
        public DataTable selectResult(string academic_session, string semester, string program, string option)
        {
            DataTable dtResult = new DataTable();
            string matric_no = string.Empty;

            if (dsReg.Tables.Contains("result"))
            {
                dsReg.Tables.Remove("result");
            }
            conn = new SqlConnection(conStr);
            conn.Open();
            daReg = new SqlDataAdapter("Select * FROM tblResultSheet  ORDER BY matric_no", conn);
            daReg.Fill(dsReg, "result");
            //daReg = new SqlDataAdapter("SELECT tblPersonalData.MatricNo, tblPersonalData.Surname + ' ' + tblPersonalData.Firstname AS Name, tblPersonalData.Programme, tblPersonalData.CourseofStudy, tblPersonalData.Department, tblResultSheet.*, tblRegisteredDepartment.* FROM tblPersonalData INNER JOIN tblResultSheet ON tblPersonalData.MatricNo=tblResultSheet.matric_no INNER JOIN tblRegisteredDepartment ON tblPersonalData.Department=tblRegisteredDepartment.DeptName WHERE tblResultSheet.academic_session='" + academic_session + "' AND tblResultSheet.semester='" + semester + "'AND tblPersonalData.Programme='" + program + "' AND tblPersonalData.CourseofStudy='" + option + "' ORDER BY tblResultSheet.matric_no", conn);
            //daReg.Fill(dsReg, "result");
            conn.Close();
            //int fgg=dsReg.Tables["result"].Rows.Count;
            ////{
            ////    MessageBox.Show(dsReg.Tables["result"].Rows[0]["Name"].ToString());
            ////}
            //dsReg.Tables["result"].Columns.Add("Score1");
            //dsReg.Tables["result"].Columns.Add("Score2");
            //dsReg.Tables["result"].Columns.Add("Score3");
            //dsReg.Tables["result"].Columns.Add("Score4");
            //dsReg.Tables["result"].Columns.Add("Score5");
            //dsReg.Tables["result"].Columns.Add("Score6");
            //dsReg.Tables["result"].Columns.Add("Score7");
            //dsReg.Tables["result"].Columns.Add("Score8");
            //dsReg.Tables["result"].Columns.Add("Score9");
            //dsReg.Tables["result"].Columns.Add("Score10");

            //dsReg.Tables["result"].Columns.Add("units1");
            //dsReg.Tables["result"].Columns.Add("units2");
            //dsReg.Tables["result"].Columns.Add("units3");
            //dsReg.Tables["result"].Columns.Add("units4");
            //dsReg.Tables["result"].Columns.Add("units5");
            //dsReg.Tables["result"].Columns.Add("units6");
            //dsReg.Tables["result"].Columns.Add("units7");
            //dsReg.Tables["result"].Columns.Add("units8");
            //dsReg.Tables["result"].Columns.Add("units9");
            //dsReg.Tables["result"].Columns.Add("units10");

            //dsReg.Tables["result"].Columns.Add("points1");
            //dsReg.Tables["result"].Columns.Add("points2");
            //dsReg.Tables["result"].Columns.Add("points3");
            //dsReg.Tables["result"].Columns.Add("points4");
            //dsReg.Tables["result"].Columns.Add("points5");
            //dsReg.Tables["result"].Columns.Add("points6");
            //dsReg.Tables["result"].Columns.Add("points7");
            //dsReg.Tables["result"].Columns.Add("points8");
            //dsReg.Tables["result"].Columns.Add("points9");
            //dsReg.Tables["result"].Columns.Add("points10");

            ////Select carryovers for all selected students result
            //if (dsReg.Tables["result"].Rows.Count > 0)
            //{
            //    string COs = string.Empty;
            //    string course_code = string.Empty;
            //    string units = string.Empty;

            //    for (int noofResult = 0; noofResult < dsReg.Tables["result"].Rows.Count; noofResult++)
            //    {
            //        //Check to make sure the remark is fail, meaning there is a carryover
            //        string remark = dsReg.Tables["result"].Rows[noofResult]["remarks"].ToString();
            //        string ID = dsReg.Tables["result"].Rows[noofResult]["matric_no"].ToString();
            //        if (remark == "FAIL")
            //        {
            //            if (dsReg.Tables.Contains("carry"))
            //            {
            //                dsReg.Tables.Remove("carry");
            //            }
            //            conn.Open();
            //            daReg = new SqlDataAdapter("SELECT course_code FROM tblCOs WHERE academic_session='" + academic_session + "' AND semester='" + semester + "' AND matric_no='" + ID + "'", conn);
            //            daReg.Fill(dsReg, "carry");
            //            conn.Close();
            //            //If there are more than one carry over, join them together as a single field
            //            for (int noofCOs = 0; noofCOs < dsReg.Tables["carry"].Rows.Count; noofCOs++)
            //            {
            //                COs += dsReg.Tables["carry"].Rows[noofCOs]["course_code"].ToString();
            //            }

            //            //Update remarks field of resultsheet
            //            dsReg.Tables["result"].Rows[noofResult]["remarks"] = "RPT: " + COs;
            //            COs = string.Empty;
            //        }

            //        for (int noofCourses = 1; noofCourses <= 10; noofCourses++)
            //        {
            //            course_code = dsReg.Tables["result"].Rows[noofResult]["course_code" + noofCourses].ToString();
            //            matric_no = dsReg.Tables["result"].Rows[noofResult]["matric_no"].ToString();

            //            if (!(string.IsNullOrEmpty(course_code)))
            //            {
            //                if (dsReg.Tables.Contains("score"))
            //                {
            //                    dsReg.Tables.Remove("score");
            //                }
            //                conn.Open();
            //                daReg = new SqlDataAdapter("SELECT score, points_earned, credit_carried, grade FROM tblExamScores WHERE course_code='" + course_code + "' AND semester='" + semester + "' AND academic_session='" + academic_session + "' AND matricNo='" + matric_no + "'", conn);
            //                daReg.Fill(dsReg, "score");
            //                conn.Close();

            //                if (dsReg.Tables["score"].Rows.Count != 0)
            //                {
            //                    //units = dsReg.Tables["score"].Rows[0]["credit_carried"].ToString();
            //                    ////credit units for each course and attach to course code and display in the table headers
            //                    //dsReg.Tables["result"].Rows[0]["course_code" + noofCourses] += " " + units;

            //                    dsReg.Tables["result"].Rows[noofResult]["Score" + noofCourses] = dsReg.Tables["score"].Rows[0]["score"];
            //                    dsReg.Tables["result"].Rows[noofResult]["points" + noofCourses] = dsReg.Tables["score"].Rows[0]["points_earned"];
            //                    dsReg.Tables["result"].Rows[noofResult]["units" + noofCourses] = dsReg.Tables["score"].Rows[0]["credit_carried"];
            //                    //dsReg.Tables["result"].Rows[noofResult]["grade" + noofCourses] = dsReg.Tables["score"].Rows[0]["grade"];
            //                }


            //            }
            //        }


            //    }


            //}

            dtResult = dsReg.Tables["result"].Copy();
            int ggh = dtResult.Rows.Count;

            return dtResult;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataTable dtcourse_option;
                for (int i = 2010; i <= DateTime.Now.Year; i++)
                {
                    int y = i + 1;
                    ddlLsession.Items.Add(i.ToString());
                    ddlUsession.Items.Add(y.ToString());
                }
                programme new_prog = new programme();
                dtcourse_option = new_prog.select_course_options(public_objects.Dept_);

                ddlCourse_Option.DataTextField = "Program";
                ddlCourse_Option.DataSource = dtcourse_option;
                ddlCourse_Option.DataBind();
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                CrystalReportViewer1.ReportSource = (CrystalReport1)Session["Report"];
            }
        }

            protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            string academic_session = ddlLsession.Text + "/" + ddlUsession.Text;

            DataTable dtResult = new DataTable();
            string matric_no = string.Empty;
            CrystalReport1 rpt = new CrystalReport1();

            if (dsReg.Tables.Contains("result"))
            {
                dsReg.Tables.Remove("result");
            }
            conn = new SqlConnection(conStr);
            conn.Open();
            daReg = new SqlDataAdapter("Select * FROM tblResultSheet  ORDER BY matric_no", conn);
            daReg.Fill(dsReg, "result");

            dtResult = dsReg.Tables["result"].Copy();
            rpt.SetDataSource(dtResult);
            CrystalReportViewer1.ReportSource = rpt;
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
            Session["Report"] = rpt;
            //rpt.Refresh();



        }

        
    }
}