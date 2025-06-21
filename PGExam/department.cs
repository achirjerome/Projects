using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DesignTemplate1
{
    public class department
    {
        public string departmentName { get; set; }
        public string collegeName { get; set; }

        public static string register(department newDept)
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
                daReg = new SqlDataAdapter("SELECT department FROM tblDepartment WHERE department LIKE '%" + newDept.departmentName + "%'", conn);
                daReg.Fill(dsReg, "reg");
                conn.Close();

                if (dsReg.Tables["reg"].Rows.Count == 0)
                {
                    cmdSave.CommandType = CommandType.Text;
                    //cmdStudent.Transaction = register_transaction;
                    cmdSave.Connection = conn;
                    cmdSave.CommandType = CommandType.Text;
                    cmdSave.CommandText = "INSERT INTO tblDepartment VALUES(@dept, @college)";
                    cmdSave.Parameters.AddWithValue("@dept", newDept.departmentName);
                    cmdSave.Parameters.AddWithValue("@college", newDept.collegeName);


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

        public static DataTable select_departments(string college)
        {
            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection conn;
            SqlDataAdapter daReg;
            DataSet dsStates = new DataSet();
            DataSet dsReg = new DataSet();
            SqlCommand cmdSave = new SqlCommand();

            DataTable depts;
            if (dsReg.Tables.Contains("dept"))
            {
                dsReg.Tables.Remove("dept");
            }

            conn = new SqlConnection(conStr);
            conn.Open();
            daReg = new SqlDataAdapter("SELECT department FROM tblDepartment WHERE College ='" + college + "'", conn);
            daReg.Fill(dsReg, "dept");
            conn.Close();
            depts = dsReg.Tables["depts"].Copy();
            return depts;
        }
    }
}