using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Transactions;

namespace DesignTemplate1
{
    public class examination
    {
        //SqlTransaction exam_transact;
        public DataTable core_courses(string sem, string a_session, string option, string program)
        {
            DataTable dtcore;
            SqlConnection conn;
            SqlDataAdapter dacore;
            DataSet dscore = new DataSet();
            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            conn = new SqlConnection(conStr);
            conn.Open();
            dacore = new SqlDataAdapter("SELECT course_code FROM tblsemester_courses WHERE semester='" + sem + "'AND academic_session='" + a_session + "'AND program='" + program + "'AND course_option='" + option + "' AND status='core' ORDER BY course_code", conn);
            dacore.Fill(dscore, "exam");
            conn.Close();

            dtcore = dscore.Tables["exam"].Copy();
            return dtcore;
        }
        public string upload(string a_session, string sem, string course, DataTable dtExam, string id)
        {
            SqlConnection conn;
            SqlDataAdapter daScore;
            DataSet dsScore = new DataSet();
            SqlCommand cmdSave = new SqlCommand();
            //=======================================
            //string responsecode = "success";
            string academic_session = a_session;
            string semester = sem;
            string matric_no = string.Empty;
            string exam_code = string.Empty; //session + semester + course code. Same for all students that took a course
            string exam_id = string.Empty; //session + semester + course code + matric no. unique for every student for every course
            int score = 0;
            string return_msg = string.Empty;
            //========================================
            double marks = 0.0;
            int no_uploaded = 0;

            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                conn = new SqlConnection(conStr);
                for (int no_of_students = 0; no_of_students < dtExam.Rows.Count; no_of_students++)
                {                   

                    //if matric number is not empty but marks is null, assign 0 to marks
                    if (dtExam.Rows[no_of_students]["matric"].ToString() != string.Empty)
                    {
                        matric_no = dtExam.Rows[no_of_students]["matric"].ToString();
                        string sem_code = academic_session + "_" + semester + "_" + course + matric_no;
                        //Check if the student registered for the course
                        if (dsScore.Tables.Contains("reg"))
                        {
                            dsScore.Tables.Remove("reg");
                        }

                        conn.Open();
                        daScore = new SqlDataAdapter("SELECT sem_reg_code FROM tblstudents_semester_Courses WHERE sem_reg_code='" + sem_code + "'", conn);
                        daScore.Fill(dsScore, "reg");
                        conn.Close();

                         //Check if the student registered for the course
                        //if (dsScore.Tables["reg"].Rows.Count == 1) 
                        //{ ENABLE 
                            if (dtExam.Rows[no_of_students]["score"].ToString() != string.Empty)
                            {
                                marks = Math.Round(double.Parse(dtExam.Rows[no_of_students]["score"].ToString()));
                            }
                            else
                            {
                                marks = 0;
                            }

                            score = int.Parse(marks.ToString());
                            exam_code = academic_session + "_" + semester + "_" + course;
                            exam_id = exam_code + matric_no;

                            if (dsScore.Tables.Contains("exam"))
                            {
                                dsScore.Tables.Remove("exam");
                            }
                            //Select from tblExamScores by current exam_id
                            conn = new SqlConnection(conStr);
                            conn.Open();
                            daScore = new SqlDataAdapter("SELECT exam_id FROM tblExamScores WHERE exam_id ='" + exam_id + "'", conn);
                            daScore.Fill(dsScore, "exam");
                            conn.Close();

                            //Make sure the exam_id does not exists
                            if (dsScore.Tables["exam"].Rows.Count == 0)
                            {
                                cmdSave.CommandType = CommandType.Text;
                                //cmdStudent.Transaction = register_transaction;
                                cmdSave.Connection = conn;
                                cmdSave.CommandType = CommandType.Text;
                                cmdSave.CommandText = "INSERT INTO tblExamScores VALUES(@id, @exam_code, @matric, @course_code, @sem, @sess, @score, @cc, @grade, @gradecode, @ce, @pe, @remark, @flag, @staffid, @stamp)";
                                cmdSave.Parameters.AddWithValue("@id", exam_id);
                                cmdSave.Parameters.AddWithValue("@exam_code", exam_code);
                                cmdSave.Parameters.AddWithValue("@matric", matric_no);
                                cmdSave.Parameters.AddWithValue("@course_code", course);
                                cmdSave.Parameters.AddWithValue("@sem", semester);
                                cmdSave.Parameters.AddWithValue("@sess", academic_session);
                                cmdSave.Parameters.AddWithValue("@score", score);
                                cmdSave.Parameters.AddWithValue("@cc", 0);
                                cmdSave.Parameters.AddWithValue("@grade", string.Empty);
                                cmdSave.Parameters.AddWithValue("@gradecode", string.Empty);
                                cmdSave.Parameters.AddWithValue("@ce", 0);
                                cmdSave.Parameters.AddWithValue("@pe", 0);
                                cmdSave.Parameters.AddWithValue("@remark", string.Empty);
                                cmdSave.Parameters.AddWithValue("@flag", "0");
                                cmdSave.Parameters.AddWithValue("@staffid", id);
                                cmdSave.Parameters.AddWithValue("@stamp", DateTime.Now.ToString("yyyy-mm-dd HH:mm:s"));

                                conn.Open();
                                no_uploaded += cmdSave.ExecuteNonQuery();
                                conn.Close();
                                cmdSave.Parameters.Clear();
                            }
                        //}ENABLE

                        //register_transaction.Commit();
                        //connectionClass.conn.Close();
                    }

                }
                return_msg = no_uploaded.ToString();
            }
            catch (Exception ex)
            {
                 return_msg = ex.Message.ToString();
            }
            return return_msg;

        }
        public string compute(string acad_session, string semester, string course_option, string program)
        {
            string response_code = string.Empty;
            string exam_id = string.Empty;
            int score = 0;
            string graded = string.Empty;
            string grade_code = string.Empty;
            int cc = 0;
            string course_code = string.Empty;
            string remark = string.Empty;
            double points_earned = 0.0;
            int credit_earned = 0;

            SqlConnection conn;
            SqlDataAdapter dagrade;
            DataSet dsgrade = new DataSet();
            SqlCommand cmdSave = new SqlCommand();

            examination new_exam = new examination();
            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            conn = new SqlConnection(conStr);



            //========
            double previous_CCC = 0.0;
            double previous_CCE = 0.0;
            double previous_CPE = 0.0;
            double previous_CGPA = 0.0;
            DataSet dsExamSheet = new DataSet();
            //========
            cmdSave.Connection = conn;
            conn.Open();
            
            using (TransactionScope exam_transact = new TransactionScope())
            {
                try
                {
               


                    DataTable dtExamSheet = new DataTable();
                    dtExamSheet.Columns.Add("matric_no");
                    dtExamSheet.Columns.Add("academic_session");
                    dtExamSheet.Columns.Add("semester");
                    dtExamSheet.Columns.Add("course1");
                    dtExamSheet.Columns.Add("score1");
                    dtExamSheet.Columns.Add("credit_carried1");
                    dtExamSheet.Columns.Add("grade1");
                    dtExamSheet.Columns.Add("course2");
                    dtExamSheet.Columns.Add("score2");
                    dtExamSheet.Columns.Add("credit_carried2");
                    dtExamSheet.Columns.Add("grade2");
                    dtExamSheet.Columns.Add("course3");
                    dtExamSheet.Columns.Add("score3");
                    dtExamSheet.Columns.Add("credit_carried3");
                    dtExamSheet.Columns.Add("grade3");
                    dtExamSheet.Columns.Add("course4");
                    dtExamSheet.Columns.Add("score4");
                    dtExamSheet.Columns.Add("credit_carried4");
                    dtExamSheet.Columns.Add("grade4");
                    dtExamSheet.Columns.Add("course5");
                    dtExamSheet.Columns.Add("score5");
                    dtExamSheet.Columns.Add("credit_carried5");
                    dtExamSheet.Columns.Add("grade5");
                    dtExamSheet.Columns.Add("course6");
                    dtExamSheet.Columns.Add("score6");
                    dtExamSheet.Columns.Add("credit_carried6");
                    dtExamSheet.Columns.Add("grade6");
                    dtExamSheet.Columns.Add("course7");
                    dtExamSheet.Columns.Add("score7");
                    dtExamSheet.Columns.Add("credit_carried7");
                    dtExamSheet.Columns.Add("grade7");
                    dtExamSheet.Columns.Add("course8");
                    dtExamSheet.Columns.Add("score8");
                    dtExamSheet.Columns.Add("credit_carried8");
                    dtExamSheet.Columns.Add("grade8");
                    dtExamSheet.Columns.Add("course9");
                    dtExamSheet.Columns.Add("score9");
                    dtExamSheet.Columns.Add("credit_carried9");
                    dtExamSheet.Columns.Add("grade9");
                    dtExamSheet.Columns.Add("course10");
                    dtExamSheet.Columns.Add("score10");
                    dtExamSheet.Columns.Add("credit_carried10");
                    dtExamSheet.Columns.Add("grade10");

                    dtExamSheet.Columns.Add("carry_overs_others");

                    dtExamSheet.Columns.Add("TCC");
                    dtExamSheet.Columns.Add("TCE");
                    dtExamSheet.Columns.Add("TPE");
                    dtExamSheet.Columns.Add("GPA");

                    dtExamSheet.Columns.Add("PCCC");
                    dtExamSheet.Columns.Add("PCCE");
                    dtExamSheet.Columns.Add("PCPE");
                    dtExamSheet.Columns.Add("PCGPA");

                    dtExamSheet.Columns.Add("CCC");
                    dtExamSheet.Columns.Add("CCE");
                    dtExamSheet.Columns.Add("CPE");
                    dtExamSheet.Columns.Add("CGPA");
                    dtExamSheet.Columns.Add("CO");
                    dtExamSheet.Columns.Add("remarks");
                    //=========

                    //Select the core courses for the semester, session, program and course option
                    DataTable dtStructures = new_exam.core_courses(semester, acad_session, course_option, program);

                    if (dtStructures.Rows.Count == 0)
                    {

                        response_code = "Semester courses may not have been added by the Exam Officer";
                        return response_code;
                    }

                    if (dsgrade.Tables.Contains("exam"))
                    {
                        dsgrade.Tables.Remove("exam");
                    }
                    //Select courses for grading                
                    //conn.Open();
                    dagrade = new SqlDataAdapter("SELECT tblstudents.matric_no, tblExamScores.exam_id, tblExamScores.course_code, tblExamScores.score FROM tblstudents INNER JOIN tblExamScores ON tblStudents.matric_no=tblExamScores.matricno WHERE tblstudents.program='" + program + "'AND tblstudents.course_option='" + course_option + "'AND tblExamScores.sheet_flag='0' AND tblExamScores.semester='" + semester + "'AND tblExamScores.academic_session='" + acad_session + "'", conn);
                    dagrade.Fill(dsgrade, "exam");
                    //conn.Close();
                    //Grade all selected courses
                    for (int no_of_courses = 0; no_of_courses < dsgrade.Tables["exam"].Rows.Count; no_of_courses++)
                    {
                        exam_id = dsgrade.Tables["exam"].Rows[no_of_courses]["exam_id"].ToString();
                        score = int.Parse(dsgrade.Tables["exam"].Rows[no_of_courses]["score"].ToString());
                        graded = grade(score);
                        course_code = dsgrade.Tables["exam"].Rows[no_of_courses]["course_code"].ToString();

                        cc = credit_carried(course_code);
                        credit_earned = cc; //credits earned equals credit carried 
                                            //unless course is failed then credit_earned becomes zero

                        switch (graded)
                        {
                            case "A":
                                remark = "PASS";
                                points_earned = 5;
                                break;
                            case "B":
                                remark = "PASS";
                                points_earned = 4;
                                break;
                            case "C":
                                remark = "PASS";
                                points_earned = 3;
                                break;
                            case "D":
                                remark = "PASS";
                                points_earned = 2;
                                break;
                            case "E":
                                remark = "PASS";
                                points_earned = 1;
                                break;
                            case "F":
                                remark = "FAIL";
                                points_earned = 0;
                                credit_earned = 0;
                                break;

                        }
                        grade_code = cc.ToString() + graded + score.ToString();

                        //cmdSave.Connection = conn;

                        cmdSave.CommandText = "UPDATE tblExamScores SET credit_carried=@cc, Grade=@grade, GradeCode=@gcode, credits_earned=@ce, points_earned=@pe, remark=@remark WHERE exam_id=@id";
                        cmdSave.Parameters.AddWithValue("@cc", cc);
                        cmdSave.Parameters.AddWithValue("@grade", graded);
                        cmdSave.Parameters.AddWithValue("@gcode", grade_code);
                        cmdSave.Parameters.AddWithValue("@ce", credit_earned);
                        cmdSave.Parameters.AddWithValue("@pe", points_earned);
                        cmdSave.Parameters.AddWithValue("@remark", remark);
                        cmdSave.Parameters.AddWithValue("@id", exam_id);

                        //conn.Open();
                        cmdSave.ExecuteNonQuery();
                        cmdSave.Parameters.Clear();
                        //conn.Close();                    
                    }


                    if (dsgrade.Tables.Contains("distinct"))
                    {
                        dsgrade.Tables.Remove("distinct");
                    }
                    //Select students to computer their results
                    //conn.Open();
                    dagrade = new SqlDataAdapter("SELECT DISTINCT tblstudents.matric_no, tblExamScores.MatricNo FROM tblExamScores INNER JOIN tblstudents ON tblExamScores.MatricNo = tblStudents.matric_no WHERE tblstudents.program='" + program + "'AND tblstudents.course_option='" + course_option + "'AND tblExamScores.sheet_flag='0' AND tblExamScores.semester='" + semester + "'AND tblExamScores.academic_session='" + acad_session + "' ORDER BY tblstudents.matric_no", conn);
                    dagrade.Fill(dsgrade, "distinct");
                    //conn.Close();
                    //Add all the students matric_no, semester, session, course info to dtExamSheet  
                    for (int no_of_students = 0; no_of_students < dsgrade.Tables["distinct"].Rows.Count; no_of_students++)
                    {
                        string matric_no = dsgrade.Tables["distinct"].Rows[no_of_students]["matric_no"].ToString();
                        dtExamSheet.Rows.Add(no_of_students);
                        dtExamSheet.Rows[no_of_students]["matric_no"] = matric_no;
                        dtExamSheet.Rows[no_of_students]["academic_session"] = acad_session;
                        dtExamSheet.Rows[no_of_students]["semester"] = semester;

                        //Assign all core courses as base for registered courses
                        for (int no_of_core_courses = 0; no_of_core_courses < dtStructures.Rows.Count; no_of_core_courses++)
                        {
                            dtExamSheet.Rows[no_of_students]["course" + (no_of_core_courses + 1)] = dtStructures.Rows[no_of_core_courses]["course_code"].ToString();
                            //Console.WriteLine(dtExamSheet.Rows[no_of_students]["course" + (no_of_core_courses + 1)]);
                        }
                    }
                    for (int no_of_students = 0; no_of_students < dtExamSheet.Rows.Count; no_of_students++)
                    {
                        double TCC = 0.0;
                        double TCE = 0.0;
                        double TPE = 0.0;
                        decimal GPA = 0;
                        double CCC = 0.0;
                        double CCE = 0.0;
                        double CPE = 0.0;
                        decimal CGPA = 0;

                        string COs = string.Empty;
                        string matric_no = dtExamSheet.Rows[no_of_students]["matric_no"].ToString();
                        if (dsgrade.Tables.Contains("result"))
                        {
                            dsgrade.Tables.Remove("result");
                        }
                        //retrieve all exam resources concerning a given student in a given semester and session where flag is still 0
                        dagrade = new SqlDataAdapter("SELECT * FROM tblExamScores WHERE semester='" + semester + "' AND academic_session ='" + acad_session + "' AND sheet_flag='0' AND MatricNo='" + matric_no + "' ORDER BY course_code", conn);
                        dagrade.Fill(dsgrade, "result");


                        for (int student_courses = 0; student_courses < dsgrade.Tables["result"].Rows.Count; student_courses++)
                        {
                            bool found = false;
                            string course_grade = dsgrade.Tables["result"].Rows[student_courses]["GradeCode"].ToString();
                            string c_code = dsgrade.Tables["result"].Rows[student_courses]["course_code"].ToString();
                            points_earned = double.Parse(dsgrade.Tables["result"].Rows[student_courses]["Points_earned"].ToString());

                            int i = 0;
                            while (found == false) //Course not a core fro the semester for the level
                            {
                                string cou = dtExamSheet.Rows[i]["course" + (i + 1)].ToString();
                                if (c_code == cou) //dtExamSheet.Rows[i]["course" + (student_courses + 1)].ToString())
                                {
                                    dtExamSheet.Rows[no_of_students]["score" + (i + 1)] = dsgrade.Tables["result"].Rows[student_courses]["score"].ToString(); //Assign course score
                                    dtExamSheet.Rows[no_of_students]["credit_carried" + (i + 1)] = dsgrade.Tables["result"].Rows[student_courses]["credit_carried"].ToString(); //Assign course credit units
                                    dtExamSheet.Rows[no_of_students]["grade" + (i + 1)] = dsgrade.Tables["result"].Rows[student_courses]["Grade"].ToString(); //Assign course Grade
                                    found = true;
                                }
                                i += 1;
                            }
                            if (found == false)//course not found then its either elective or it was previously dropped and registered now so it cant be in the semesters course courses
                            {
                                dtExamSheet.Rows[no_of_students]["score" + (i + 1)] = dsgrade.Tables["result"].Rows[student_courses]["score"].ToString();
                                dtExamSheet.Rows[no_of_students]["credit_carried" + (i + 1)] = dsgrade.Tables["result"].Rows[student_courses]["credit_carried"].ToString();
                                dtExamSheet.Rows[no_of_students]["carry_overs_others"] = course_grade;
                            }
                            if (points_earned == 0) //Use point earned instead of grade
                            {
                                COs += dsgrade.Tables["result"].Rows[student_courses]["course_code"].ToString();
                            }
                            //Check if the course was carried b4
                            string result = check_co(matric_no, semester, acad_session, course_code, points_earned);

                            double CC = double.Parse(dsgrade.Tables["result"].Rows[student_courses]["credit_carried"].ToString()); //Credits carried for each course
                            double PE = int.Parse(dsgrade.Tables["result"].Rows[student_courses]["points_earned"].ToString()); //Points earned per course (A=5, B=4 .. F=0)
                            double CE = int.Parse(dsgrade.Tables["result"].Rows[student_courses]["credits_earned"].ToString()); //Passed credits for each CC

                            double GPE = CC * PE;
                            TCC = TCC + CC;
                            TPE = TPE + GPE;
                            TCE = TCE + CE; // Total of passed credits out of TCC                    
                        }
                        dtExamSheet.Rows[no_of_students]["TCC"] = TCC;
                        dtExamSheet.Rows[no_of_students]["TCE"] = TCE;
                        dtExamSheet.Rows[no_of_students]["TPE"] = TPE;

                        //if there is no CO, then Passed should be assigned
                        if (COs == string.Empty)
                        {
                            COs = "PASSED";
                        }
                        GPA = Convert.ToDecimal(TPE / TCC);
                        dtExamSheet.Rows[no_of_students]["GPA"] = GPA;
                        dtExamSheet.Rows[no_of_students]["CO"] = COs;

                        //Select the students privious, TCC, TPE, TCE, CGPA
                        if (dsgrade.Tables.Contains("previous"))
                        {
                            dsgrade.Tables.Remove("previous");
                        }

                        dagrade = new SqlDataAdapter("SELECT * FROM tblResultSheet WHERE matric_no ='" + matric_no + "'", conn);
                        dagrade.Fill(dsgrade, "previous");
                        //connectionClass.conn.Close();

                        if (dsgrade.Tables["previous"].Rows.Count == 1) //Previous Results exists
                        {
                            //Assign the current cumulatives to become previous
                            previous_CCC = Double.Parse(dsgrade.Tables["previous"].Rows[0]["CCC"].ToString());
                            previous_CCE = Double.Parse(dsgrade.Tables["previous"].Rows[0]["CCE"].ToString()); ;
                            previous_CPE = Double.Parse(dsgrade.Tables["previous"].Rows[0]["CPE"].ToString()); ;
                            previous_CGPA = Double.Parse(dsgrade.Tables["previous"].Rows[0]["CGPA"].ToString()); ;

                            dtExamSheet.Rows[no_of_students]["PCCC"] = previous_CCC;
                            dtExamSheet.Rows[no_of_students]["PCCE"] = previous_CCE;
                            dtExamSheet.Rows[no_of_students]["PCPE"] = previous_CPE;
                            dtExamSheet.Rows[no_of_students]["PCGPA"] = previous_CGPA;

                            CCC = previous_CCC + TCC;
                            CCE = previous_CCE + TCE;
                            CPE = previous_CPE + TPE;
                            CGPA = Convert.ToDecimal(CPE / CCC);
                            //string adddecimal = CGPA.ToString("#.00");
                            //CGPA = Convert.ToDecimal(adddecimal);
                            dtExamSheet.Rows[no_of_students]["CCC"] = CCC;
                            dtExamSheet.Rows[no_of_students]["CCE"] = CCE;
                            dtExamSheet.Rows[no_of_students]["CPE"] = CPE;
                            dtExamSheet.Rows[no_of_students]["CGPA"] = CGPA;
                        }
                        else
                        {
                            dtExamSheet.Rows[no_of_students]["PCCC"] = previous_CCC;
                            dtExamSheet.Rows[no_of_students]["PCCE"] = previous_CCE;
                            dtExamSheet.Rows[no_of_students]["PCPE"] = previous_CPE;
                            dtExamSheet.Rows[no_of_students]["PCGPA"] = previous_CGPA;

                            CCC = TCC;
                            CCE = TCE;
                            CPE = TPE;
                            CGPA = Convert.ToDecimal(CPE / CCC);
                            //string adddecimal = CGPA.ToString("#.00");
                            //CGPA = Convert.ToDecimal(adddecimal);

                            dtExamSheet.Rows[no_of_students]["CCC"] = CCC;
                            dtExamSheet.Rows[no_of_students]["CCE"] = CCE;
                            dtExamSheet.Rows[no_of_students]["CPE"] = CPE;
                            dtExamSheet.Rows[no_of_students]["CGPA"] = CGPA;
                        }

                    }

                    //Save results
                    for (int noofStudents = 0; noofStudents < dtExamSheet.Rows.Count; noofStudents++)
                    {
                        string result_code = acad_session + semester + dtExamSheet.Rows[noofStudents]["matric_no"].ToString();
                        //cmdSave.Connection = conn;
                        cmdSave.CommandText = "INSERT INTO tblResultSheet (result_code, matric_no, academic_session, semester, course_code1, score1, credit_carried1, grade1, course_code2,score2, credit_carried2, grade2, course_code3, score3, credit_carried3, grade3, course_code4, score4, credit_carried4, grade4, course_code5, score5, credit_carried5, grade5, course_code6, score6, credit_carried6, grade6, course_code7, score7, credit_carried7, grade7, course_code8, score8, credit_carried8, grade8, course_code9, score9, credit_carried9, grade9, course_code10, score10, credit_carried10, grade10, carry_over_others, TCC, TCE, TPE, GPA, PCCC, PCCE, PCPE, PCGPA, CCC, CCE, CPE, CGPA, CO, remarks) VALUES (@result_code, @matric_no, @academic_session, @semester, @course1, @score1, @credit1, @grade1, @course2, @score2, @credit2, @grade2, @course3, @score3, @credit3, @grade3, @course4, @score4, @credit4, @grade4, @course5, @score5, @credit5, @grade5, @course6, @score6, @credit6, @grade6, @course7, @score7, @credit7, @grade7, @course8, @score8, @credit8, @grade8, @course9, @score9, @credit9, @grade9, @course10, @score10, @credit10, @grade10, @carry_over_others, @TCC, @TCE, @TPE, @GPA, @PCCC, @PCCE, @PCPE, @PCGPA, @CCC, @CCE, @CPE, @CGPA, @co, @remarks)";
                        cmdSave.Parameters.AddWithValue("@result_code", result_code);
                        cmdSave.Parameters.AddWithValue("@matric_no", dtExamSheet.Rows[noofStudents]["matric_no"]);
                        cmdSave.Parameters.AddWithValue("@academic_session", dtExamSheet.Rows[noofStudents]["academic_session"]);
                        cmdSave.Parameters.AddWithValue("@semester", dtExamSheet.Rows[noofStudents]["semester"]);
                        cmdSave.Parameters.AddWithValue("@course1", dtExamSheet.Rows[noofStudents]["course1"]);
                        cmdSave.Parameters.AddWithValue("@score1", dtExamSheet.Rows[noofStudents]["score1"]);
                        cmdSave.Parameters.AddWithValue("@credit1", dtExamSheet.Rows[noofStudents]["credit_carried1"]);
                        cmdSave.Parameters.AddWithValue("@grade1", dtExamSheet.Rows[noofStudents]["grade1"]);
                        cmdSave.Parameters.AddWithValue("@course2", dtExamSheet.Rows[noofStudents]["course2"]);
                        cmdSave.Parameters.AddWithValue("@score2", dtExamSheet.Rows[noofStudents]["score2"]);
                        cmdSave.Parameters.AddWithValue("@credit2", dtExamSheet.Rows[noofStudents]["credit_carried2"]);
                        cmdSave.Parameters.AddWithValue("@grade2", dtExamSheet.Rows[noofStudents]["grade2"]);
                        cmdSave.Parameters.AddWithValue("@course3", dtExamSheet.Rows[noofStudents]["course3"]);
                        cmdSave.Parameters.AddWithValue("@score3", dtExamSheet.Rows[noofStudents]["score3"]);
                        cmdSave.Parameters.AddWithValue("@credit3", dtExamSheet.Rows[noofStudents]["credit_carried3"]);
                        cmdSave.Parameters.AddWithValue("@grade3", dtExamSheet.Rows[noofStudents]["grade3"]);
                        cmdSave.Parameters.AddWithValue("@course4", dtExamSheet.Rows[noofStudents]["course4"]);
                        cmdSave.Parameters.AddWithValue("@score4", dtExamSheet.Rows[noofStudents]["score4"]);
                        cmdSave.Parameters.AddWithValue("@credit4", dtExamSheet.Rows[noofStudents]["credit_carried4"]);
                        cmdSave.Parameters.AddWithValue("@grade4", dtExamSheet.Rows[noofStudents]["grade4"]);
                        cmdSave.Parameters.AddWithValue("@course5", dtExamSheet.Rows[noofStudents]["course5"]);
                        cmdSave.Parameters.AddWithValue("@score5", dtExamSheet.Rows[noofStudents]["score5"]);
                        cmdSave.Parameters.AddWithValue("@credit5", dtExamSheet.Rows[noofStudents]["credit_carried5"]);
                        cmdSave.Parameters.AddWithValue("@grade5", dtExamSheet.Rows[noofStudents]["grade5"]);
                        cmdSave.Parameters.AddWithValue("@course6", dtExamSheet.Rows[noofStudents]["course6"]);
                        cmdSave.Parameters.AddWithValue("@score6", dtExamSheet.Rows[noofStudents]["score6"]);
                        cmdSave.Parameters.AddWithValue("@credit6", dtExamSheet.Rows[noofStudents]["credit_carried6"]);
                        cmdSave.Parameters.AddWithValue("@grade6", dtExamSheet.Rows[noofStudents]["grade6"]);
                        cmdSave.Parameters.AddWithValue("@course7", dtExamSheet.Rows[noofStudents]["course7"]);
                        cmdSave.Parameters.AddWithValue("@score7", dtExamSheet.Rows[noofStudents]["score7"]);
                        cmdSave.Parameters.AddWithValue("@credit7", dtExamSheet.Rows[noofStudents]["credit_carried7"]);
                        cmdSave.Parameters.AddWithValue("@grade7", dtExamSheet.Rows[noofStudents]["grade7"]);
                        cmdSave.Parameters.AddWithValue("@course8", dtExamSheet.Rows[noofStudents]["course8"]);
                        cmdSave.Parameters.AddWithValue("@score8", dtExamSheet.Rows[noofStudents]["score8"]);
                        cmdSave.Parameters.AddWithValue("@credit8", dtExamSheet.Rows[noofStudents]["credit_carried8"]);
                        cmdSave.Parameters.AddWithValue("@grade8", dtExamSheet.Rows[noofStudents]["grade8"]);
                        cmdSave.Parameters.AddWithValue("@course9", dtExamSheet.Rows[noofStudents]["course9"]);
                        cmdSave.Parameters.AddWithValue("@score9", dtExamSheet.Rows[noofStudents]["score9"]);
                        cmdSave.Parameters.AddWithValue("@credit9", dtExamSheet.Rows[noofStudents]["credit_carried9"]);
                        cmdSave.Parameters.AddWithValue("@grade9", dtExamSheet.Rows[noofStudents]["grade9"]);
                        cmdSave.Parameters.AddWithValue("@course10", dtExamSheet.Rows[noofStudents]["course10"]);
                        cmdSave.Parameters.AddWithValue("@score10", dtExamSheet.Rows[noofStudents]["score10"]);
                        cmdSave.Parameters.AddWithValue("@credit10", dtExamSheet.Rows[noofStudents]["credit_carried10"]);
                        cmdSave.Parameters.AddWithValue("@grade10", dtExamSheet.Rows[noofStudents]["grade10"]);
                        cmdSave.Parameters.AddWithValue("@carry_over_others", dtExamSheet.Rows[noofStudents]["carry_overs_others"]);
                        cmdSave.Parameters.AddWithValue("@TCC", dtExamSheet.Rows[noofStudents]["TCC"]);
                        cmdSave.Parameters.AddWithValue("@TCE", dtExamSheet.Rows[noofStudents]["TCE"]);
                        cmdSave.Parameters.AddWithValue("@TPE", dtExamSheet.Rows[noofStudents]["TPE"]);
                        cmdSave.Parameters.AddWithValue("@GPA", dtExamSheet.Rows[noofStudents]["GPA"]);
                        cmdSave.Parameters.AddWithValue("@PCCC", dtExamSheet.Rows[noofStudents]["PCCC"]);
                        cmdSave.Parameters.AddWithValue("@PCCE", dtExamSheet.Rows[noofStudents]["PCCE"]);
                        cmdSave.Parameters.AddWithValue("@PCPE", dtExamSheet.Rows[noofStudents]["PCPE"]);
                        cmdSave.Parameters.AddWithValue("@PCGPA", dtExamSheet.Rows[noofStudents]["PCGPA"]);
                        cmdSave.Parameters.AddWithValue("@CCC", dtExamSheet.Rows[noofStudents]["CCC"]);
                        cmdSave.Parameters.AddWithValue("@CCE", dtExamSheet.Rows[noofStudents]["CCE"]);
                        cmdSave.Parameters.AddWithValue("@CPE", dtExamSheet.Rows[noofStudents]["CPE"]);
                        cmdSave.Parameters.AddWithValue("@CGPA", dtExamSheet.Rows[noofStudents]["CGPA"]);
                        cmdSave.Parameters.AddWithValue("@CO", dtExamSheet.Rows[noofStudents]["CO"]);
                        cmdSave.Parameters.AddWithValue("@remarks", dtExamSheet.Rows[noofStudents]["remarks"]);

                        cmdSave.ExecuteNonQuery();
                        cmdSave.Parameters.Clear();
                    }
                    response_code = "SUCCESS";
                    exam_transact.Complete();
                    exam_transact.Dispose();

                    
                }
                catch (Exception ex)
                {
                    exam_transact.Dispose();
                    response_code = ex.Message;
                }
                
            }
            conn.Close();
            return response_code;
        }
        public static string grade(int score)
        {
            string grad = string.Empty;
            if(score >= 70)
            {
                grad="A";
            }
            else
            {
                if(score >=60)
                {
                    grad = "B";
                }
                else
                {
                    if(score>=50)
                    {
                        grad = "C";
                    }
                    else
                    {
                        if(score>=45)
                        {
                            grad = "D";
                        }
                        else
                        {
                            if(score >= 40)
                            {
                                grad = "E";
                            }
                            else
                            {
                                grad = "F";
                            }
                        }
                    }
                }
            }
            return grad;
        }

        public static int credit_carried(string course_code)
        {
            SqlConnection conn;
            SqlDataAdapter daCC;
            DataSet dsCC = new DataSet();

            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            
            int cc = 0;

            if (dsCC.Tables.Contains("cc"))
            {
                dsCC.Tables.Remove("cc");
            }

            conn = new SqlConnection(conStr);
            conn.Open();
            daCC = new SqlDataAdapter("SELECT credit_units FROM tblCourses WHERE course_code='" + course_code + "'", conn);
            daCC.Fill(dsCC, "cc");
            conn.Close();
            cc =int.Parse(dsCC.Tables["cc"].Rows[0]["credit_units"].ToString());
            return cc;
        }

        public static string check_co(string matric, string semester, string academic_session, string course_code, double point_earned)
        {
            //This function resturns 'none', 'co' and 'pass' to indicate the the course wass
            // never carried by this student, was carried and still not pass and carried but
            //passed now respectively

            string success = string.Empty;
            SqlConnection conn;
            SqlDataAdapter daCOs;
            DataSet dsCOs = new DataSet();
            SqlCommand cmdSave = new SqlCommand();
            string co_status = string.Empty; //CO cleared (1) or pending (0)
            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    
            if (dsCOs.Tables.Contains("co"))
            {
                dsCOs.Tables.Remove("co");
            }

            conn = new SqlConnection(conStr);
            conn.Open();
            daCOs = new SqlDataAdapter("SELECT course_code FROM tblCOs WHERE matric_no='" + matric + "'AND course_code='" + course_code + "' AND status ='0'", conn);
            daCOs.Fill(dsCOs, "co");
            conn.Close();
            if(dsCOs.Tables["co"].Rows.Count > 0) //CO exists for this course
            {
                if(point_earned ==0) //still carried over the course
                {
                    co_status = "0";
                    cmdSave.Connection = conn;
                    cmdSave.CommandText = "INSERT INTO tblCOs VALUES (@matric, @semester, @academic_session, @course, @status, @remark)";
                    cmdSave.Parameters.AddWithValue("@matric", matric);
                    cmdSave.Parameters.AddWithValue("@semester", semester);
                    cmdSave.Parameters.AddWithValue("@academic_session", academic_session);
                    cmdSave.Parameters.AddWithValue("@course", course_code);
                    cmdSave.Parameters.AddWithValue("@status", co_status);
                    cmdSave.Parameters.AddWithValue("@remark", "FAIL");

                    conn.Open();
                    cmdSave.ExecuteNonQuery();
                    cmdSave.Parameters.Clear();
                    conn.Close();
                    success = "co";
                }
                else //course passed 
                {
                    co_status = "1";
                    cmdSave.Connection = conn;
                    cmdSave.CommandText = "INSERT INTO tblCOs VALUES (@matric, @semester, @academic_session, @course, @status, @remark)";
                    cmdSave.Parameters.AddWithValue("@matric", matric);
                    cmdSave.Parameters.AddWithValue("@semester", semester);
                    cmdSave.Parameters.AddWithValue("@academic_session", academic_session);
                    cmdSave.Parameters.AddWithValue("@course", course_code);
                    cmdSave.Parameters.AddWithValue("@status", co_status);
                    cmdSave.Parameters.AddWithValue("@remark", "FAIL");
                    conn.Open();
                    cmdSave.ExecuteNonQuery();
                    cmdSave.Parameters.Clear();
                    conn.Close();

                    //Update the status of all occurances of this course to 1 to show it has been passed
                    cmdSave.Connection = conn;
                    cmdSave.CommandText = "UPDATE tblCOs SET status='1', Remark='PASS' WHERE matric_no=@matric AND course_code=@course, Semester=@sem, academic_session=@aca";
                    cmdSave.Parameters.AddWithValue("@matric", matric);
                    cmdSave.Parameters.AddWithValue("@course", course_code);
                    cmdSave.Parameters.AddWithValue("@sem", semester);
                    cmdSave.Parameters.AddWithValue("@aca", academic_session);
                    conn.Open();
                    cmdSave.ExecuteNonQuery();
                    cmdSave.Parameters.Clear();
                    conn.Close();
                    success = "passed";
                }
            }
            else
            {
                if (point_earned == 0) //New CO
                {
                    co_status = "0";
                    cmdSave.Connection = conn;
                    cmdSave.CommandText = "INSERT INTO tblCOs VALUES (@matric, @semester, @academic_session, @course, @status, @remark)";
                    cmdSave.Parameters.AddWithValue("@matric", matric);
                    cmdSave.Parameters.AddWithValue("@semester", semester);
                    cmdSave.Parameters.AddWithValue("@academic_session", academic_session);
                    cmdSave.Parameters.AddWithValue("@course", course_code);
                    cmdSave.Parameters.AddWithValue("@status", co_status);
                    cmdSave.Parameters.AddWithValue("@remark", "FAIL");

                    conn.Open();
                    cmdSave.ExecuteNonQuery();
                    cmdSave.Parameters.Clear();
                    conn.Close();
                    success = "co"; // carried
                }
                else
                {
                    success = "none"; //no CO
                }
            }
            return success;
        }
    }
} 