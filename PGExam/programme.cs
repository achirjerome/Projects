using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DesignTemplate1
{
    public class programme
    {
        
        public string programmeName { get; set; }
        public string departmentName { get; set; }
        public string collegeName { get; set; }
        
        public static string register(programme newprogramme)
        {
            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection conn;
            SqlDataAdapter daStates;
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
                daReg = new SqlDataAdapter("SELECT program FROM tblProgram WHERE program LIKE '%" + newprogramme.programmeName + "%'", conn);
                daReg.Fill(dsReg, "reg");
                conn.Close();

                if (dsReg.Tables["reg"].Rows.Count == 0)
                {
                    cmdSave.CommandType = CommandType.Text;
                    //cmdStudent.Transaction = register_transaction;
                    cmdSave.Connection = conn;
                    cmdSave.CommandType = CommandType.Text;
                    cmdSave.CommandText = "INSERT INTO tblProgram VALUES(@program, @dept, @college)";
                    cmdSave.Parameters.AddWithValue("@program", newprogramme.programmeName);
                    cmdSave.Parameters.AddWithValue("@dept", newprogramme.departmentName);
                    cmdSave.Parameters.AddWithValue("@college", newprogramme.collegeName);


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
        public DataTable select_course_options(string dept)
        {
            SqlConnection conn;            
            SqlDataAdapter daReg;
            DataSet dsStates = new DataSet();
            DataSet dsReg = new DataSet();
            
            DataTable dtcourse_option;

            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
           

            if (dsReg.Tables.Contains("prog"))
            {
                dsReg.Tables.Remove("prog");
            }

            conn = new SqlConnection(conStr);
            conn.Open();
            daReg = new SqlDataAdapter("SELECT program FROM tblProgram ORDER By program", conn);
            daReg.Fill(dsReg, "prog");
            conn.Close();
            dtcourse_option = dsReg.Tables["prog"].Copy();
            return dtcourse_option;
        }
    }
}