using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;

namespace DesignTemplate1.students
{
    public partial class semester_reg : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlDataAdapter daCourses;
        DataSet dsCourses = new DataSet();
        SqlCommand cmdSave = new SqlCommand();
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string Dept_ = string.Empty;
        int total_credit = 0;
        int CO_credit = 0;
        int New_credit = 0;
        DataTable dtRegister = new DataTable();
        int no_of_rows = 0;

        message new_message = new message();
        public DataTable select_cos(string matric_no, string semester, string acad_session)
        {
            DataTable dtCOs = new DataTable();
            if (dsCourses.Tables.Contains("co"))
            {
                dsCourses.Tables.Remove("co");
            }
            conn = new SqlConnection(conStr);
            conn.Open();
            daCourses = new SqlDataAdapter("SELECT tblCOs.course_code, tblCourses.course_title, tblCourses.credit_units, tblCourses.status AS display FROM tblCOs INNER JOIN tblCourses ON tblCOs.course_code=tblCourses.course_code WHERE tblCOs.matric_no='" + matric_no + "' AND tblCOs.semester='" + semester + "'AND tblCOs.academic_session='" + acad_session + "' ORDER BY tblCOs.course_code", conn);
            daCourses.Fill(dsCourses, "co");
            conn.Close();

            dtCOs = RemoveDuplicateRows(dsCourses.Tables["co"], "course_code");
            return dtCOs;
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }


        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            //Datatable which contains unique records will be return as output.
            return dTable;
        }

        private void bind_data()
        {
            Dept_ = Session["department"].ToString();
            if (dsCourses.Tables.Contains("courses"))
            {
                dsCourses.Tables.Remove("courses");
            }

            conn = new SqlConnection(conStr);
            conn.Open();
            daCourses = new SqlDataAdapter("SELECT course_code, course_code + ' ' + course_title AS display FROM tblCourses WHERE Dept='" + Dept_ + "' ORDER BY course_code", conn);
            daCourses.Fill(dsCourses, "courses");
            conn.Close();
            DataTable dtCourses = dsCourses.Tables["courses"].Copy();

            ddlCourses.DataTextField = "display";
            ddlCourses.DataSource = dtCourses;
            ddlCourses.DataBind();
            //    GridView1.DataSource = dsCourses.Tables["courses"];
            //    GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),"movePanel();", true);
            //ClientScript.RegisterStartupScript(this.GetType(), "key", "movePanel();", true);
            Session["sem"] = ddlSemester.Text;
            Session["prog"] = ddlProgram.Text;
            Session["dept"] = Session["department"];
            string acad_session = string.Empty;

            if (!IsPostBack)
            {
                Label2.Text = string.Empty;


                for (int i = 2010; i <= DateTime.Now.Year; i++)
                {
                    int y = i + 1;
                    ddlLsession.Items.Add(i.ToString());
                    ddlUsession.Items.Add(y.ToString());
                }
                dtRegister.Columns.Add("S/No");
                dtRegister.Columns.Add("course_code");
                dtRegister.Columns.Add("course_title");
                dtRegister.Columns.Add("credit_units");


                programme new_prog = new programme();
                DataTable dtoptions = new_prog.select_course_options(Session["department"].ToString());

                bind_data();
                ddlCourse_option.DataTextField = "program";
                ddlCourse_option.DataSource = dtoptions;
                ddlCourse_option.DataBind();


                Session["acad"] = ddlLsession.Text + "/" + ddlUsession.Text;
                Session["option"] = ddlCourse_option.Text;
                acad_session = ddlLsession.Text + "/" + ddlUsession.Text;
                //COs
                string logOnUser = Session["user"].ToString();//HttpContext.Current.User.Identity.Name
                DataTable dtCOs = select_cos(logOnUser, ddlSemester.Text, acad_session);
                //ViewState["COs"] = dtCOs;
                gvCOs.DataSource = dtCOs;
                gvCOs.DataBind();
                gvCOs.Caption = "Courses to be registered first";
                CO_credit = int.Parse(dtCOs.Compute("Sum(credit_units)", "").ToString());
                Label1.Text = CO_credit.ToString();
                ViewState["co_credit"] = CO_credit;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Dept_ = Session["department"].ToString();
            string code = string.Empty;
            string title = string.Empty;
            int credit = 0;
            string semester = ddlSemester.Text;
            string academic_session = ddlLsession.Text + "/" + ddlUsession.Text;
            int no_of_courses = GridView1.Rows.Count;
            string sem_code = string.Empty;
            string status = string.Empty;
            string program = ddlProgram.Text;
            string course_option = ddlCourse_option.Text;
            string mat_no = Session["user"].ToString();

            int no_added = 0;

            int co_courses = gvCOs.Rows.Count;
            conn = new SqlConnection(conStr);
            //if there is one or more carry overs
            if (co_courses > 0)
            {
                for (int i = 0; i < co_courses; i++)
                {
                    code = gvCOs.Rows[i].Cells[0].Text;
                    title = gvCOs.Rows[i].Cells[1].Text;
                    credit = int.Parse(gvCOs.Rows[i].Cells[2].Text);
                    status = gvCOs.Rows[i].Cells[3].Text;
                    sem_code = academic_session + "_" + semester + "_" + code + mat_no;

                    if (dsCourses.Tables.Contains("exist"))
                    {
                        dsCourses.Tables.Remove("exist");
                    }
                    
                    conn.Open();
                    daCourses = new SqlDataAdapter("SELECT sem_reg_code FROM tblstudents_semester_Courses WHERE sem_reg_code='" + sem_code + "'", conn);
                    daCourses.Fill(dsCourses, "exist");
                    conn.Close();

                    if (dsCourses.Tables["exist"].Rows.Count == 0)
                    {
                        conn = new SqlConnection(conStr);
                        cmdSave.CommandType = CommandType.Text;
                        cmdSave.Connection = conn;
                        cmdSave.CommandText = "INSERT INTO tblstudents_semester_Courses VALUES( @sem_code, @mat, @code, @title, @units, @sem, @sess, @prog, @option, @dept, @status)";
                        cmdSave.Parameters.AddWithValue("@sem_code", sem_code);
                        cmdSave.Parameters.AddWithValue("@mat", mat_no);
                        cmdSave.Parameters.AddWithValue("@code", code);
                        cmdSave.Parameters.AddWithValue("@title", title);
                        cmdSave.Parameters.AddWithValue("@units", credit);
                        cmdSave.Parameters.AddWithValue("@sem", semester);
                        cmdSave.Parameters.AddWithValue("@sess", academic_session);
                        cmdSave.Parameters.AddWithValue("@prog", program);
                        cmdSave.Parameters.AddWithValue("@option", course_option);
                        cmdSave.Parameters.AddWithValue("@dept", Dept_);
                        cmdSave.Parameters.AddWithValue("@status", status);

                        conn.Open();
                        no_added += cmdSave.ExecuteNonQuery();
                        cmdSave.Parameters.Clear();
                        conn.Close();
                    }//end if
                }//end for
            }

            //if there is no new course to register
            if (no_of_courses == 0)
            {
                //lbl_msg.Visible = true;
                Label2.Text = no_added + " course(s) registered";
                //btnAdd.Text = "Nothing";
            }
            else //if there is one or more new courses to register
            {
                for (int i = 0; i < no_of_courses; i++)
                {
                    code = GridView1.Rows[i].Cells[0].Text;
                    title = GridView1.Rows[i].Cells[1].Text;
                    credit = int.Parse(GridView1.Rows[i].Cells[2].Text);
                    status = GridView1.Rows[i].Cells[3].Text;
                    sem_code = academic_session + semester + code + mat_no;

                    if (dsCourses.Tables.Contains("exist"))
                    {
                        dsCourses.Tables.Remove("exist");
                    }
                    conn = new SqlConnection(conStr);
                    conn.Open();
                    daCourses = new SqlDataAdapter("SELECT sem_reg_code FROM tblstudents_semester_Courses WHERE sem_reg_code='" + sem_code + "'", conn);
                    daCourses.Fill(dsCourses, "exist");
                    conn.Close();

                    if (dsCourses.Tables["exist"].Rows.Count == 0)
                    {
                        conn = new SqlConnection(conStr);
                        cmdSave.CommandType = CommandType.Text;
                        cmdSave.Connection = conn;
                        cmdSave.CommandText = "INSERT INTO tblstudents_semester_Courses VALUES( @sem_code, @mat, @code, @title, @units, @sem, @sess, @prog, @option, @dept, @status)";
                        cmdSave.Parameters.AddWithValue("@sem_code", sem_code);
                        cmdSave.Parameters.AddWithValue("@mat", mat_no);
                        cmdSave.Parameters.AddWithValue("@code", code);
                        cmdSave.Parameters.AddWithValue("@title", title);
                        cmdSave.Parameters.AddWithValue("@units", credit);
                        cmdSave.Parameters.AddWithValue("@sem", semester);
                        cmdSave.Parameters.AddWithValue("@sess", academic_session);
                        cmdSave.Parameters.AddWithValue("@prog", program);
                        cmdSave.Parameters.AddWithValue("@option", course_option);
                        cmdSave.Parameters.AddWithValue("@dept", Dept_);
                        cmdSave.Parameters.AddWithValue("@status", status);

                        conn.Open();
                        no_added += cmdSave.ExecuteNonQuery();
                        cmdSave.Parameters.Clear();
                        conn.Close();
                    }//end if
                }//end for

                Label2.Text = no_added + " courses added successfully";
            }//end if
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string course_code = ddlCourses.SelectedValue.ToString().Substring(0, 7);
            if (dsCourses.Tables.Contains("list"))
            {
                dsCourses.Tables.Remove("list");
            }

            conn = new SqlConnection(conStr);
            conn.Open();
            daCourses = new SqlDataAdapter("SELECT course_code, course_title, credit_units, status FROM tblCourses WHERE course_code='" + course_code + "'", conn);
            daCourses.Fill(dsCourses, "list");
            conn.Close();
            dtRegister = dsCourses.Tables["list"].Copy();


            //ViewState["courses"] = dsCourses.Tables["list"];

            if (ViewState["courses"] != null)
            {
                dtRegister = (DataTable)ViewState["courses"];
                dtRegister.Merge(dsCourses.Tables["list"]);
                
                dtRegister = RemoveDuplicateRows(dtRegister, "course_code");
                     
                GridView1.DataSource = dtRegister;
                GridView1.DataBind();
            }
            else
            {
                dtRegister = RemoveDuplicateRows(dsCourses.Tables["list"], "course_code");
               
                ViewState["courses"] = dtRegister;
                GridView1.DataSource = dtRegister;
                GridView1.DataBind();
                //Decimal TotalPrice = Convert.ToDecimal(dtRegister.Compute("SUM(Price)", string.Empty));               

            }
            int TotalPrice = int.Parse(dtRegister.Compute("SUM(credit_units)", string.Empty).ToString());
            New_credit = TotalPrice;

            //Display total credit. COs + added credits
            int co = 0;
            if (ViewState["co_credit"] != null)//co credits is not empty
            {
               co =(int)ViewState["co_credit"];
            }
            Label1.Text = ( co + New_credit).ToString();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            int Total_credit_units = 0;
            string to_remove_code = ddlCourses.SelectedValue.ToString().Substring(0, 7);
            dtRegister = (DataTable)ViewState["courses"];

            for (int i = dtRegister.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtRegister.Rows[i];
                if (dr["course_code"].ToString() == to_remove_code)
                    dr.Delete();
            }
            dtRegister.AcceptChanges();
            GridView1.DataSource = dtRegister;
            GridView1.DataBind();
            if (dtRegister.Rows.Count > 0)
            {
                Total_credit_units = Convert.ToInt32(dtRegister.Compute("SUM(credit_units)", string.Empty));
            }
            else
            {
                Total_credit_units = 0;
                GridView1.DataSource = dtRegister;
                GridView1.DataBind();
            }
            int co = 0;
            if (ViewState["co_credit"] != null)//co credits is not empty
            {
                co = (int)ViewState["co_credit"];
            }
            Label1.Text = (co + Total_credit_units).ToString();
        }


        protected void btnView_courses_Click(object sender, EventArgs e)
        {
            Dept_ = Session["department"].ToString();
            string semester = HttpUtility.UrlEncode(ddlSemester.Text);
            string academic_session = HttpUtility.UrlEncode(ddlLsession.Text + "/" + ddlUsession.Text);
            string program = HttpUtility.UrlEncode(ddlProgram.Text);
            string course_option = ddlCourse_option.Text;

            string modified_dept = Dept_.Replace(" ", "_"); //Replace spaces with _ to avoid URL encoding errors
            string Dept = HttpUtility.UrlEncode(modified_dept);
            Session["sem"] = semester;
            Session["acad"] = academic_session;
            Session["prog"] = program;
            Session["option"] = course_option;
            Session["dept"] = Dept_;

        }

        protected void ddlUsession_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvCOs.DataSource = null;
            string acad_session = ddlLsession.Text + "/" + ddlUsession.Text;
            string logOnUser = Session["user"].ToString();
            DataTable dtCOs = select_cos(logOnUser, ddlSemester.Text, acad_session);
            //ViewState["COs"] = dtCOs;
            gvCOs.DataSource = dtCOs;
            gvCOs.DataBind();
            gvCOs.Caption = "Courses to be registered first";
        }

        protected void ddlLsession_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvCOs.DataSource = null;
            string acad_session = ddlLsession.Text + "/" + ddlUsession.Text;
            string logOnUser = Session["user"].ToString();
            DataTable dtCOs = select_cos(logOnUser, ddlSemester.Text, acad_session);
            //ViewState["COs"] = dtCOs;
            int gh= dtCOs.Rows.Count;
            gvCOs.DataSource = dtCOs;
            gvCOs.DataBind();
            gvCOs.Caption = "Courses to be registered first";
        }

        protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvCOs.DataSource = null;
            string acad_session = ddlLsession.Text + "/" + ddlUsession.Text;
            string logOnUser = Session["user"].ToString();
            DataTable dtCOs = select_cos(logOnUser, ddlSemester.Text, acad_session);
            //ViewState["COs"] = dtCOs;
            int gh = dtCOs.Rows.Count;
            gvCOs.DataSource = dtCOs;
            gvCOs.DataBind();
            gvCOs.Caption = "Courses to be registered first";
        }
    }
}