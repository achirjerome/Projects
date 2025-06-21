using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DesignTemplate1
{
    public class college
    {
        public string collegeName { get; set; }
        public string uni { get; set; }

        public static string register(college new_college)
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
                daReg = new SqlDataAdapter("SELECT college FROM tblCollege WHERE college LIKE '%" + new_college.collegeName + "%'", conn);
                daReg.Fill(dsReg, "reg");
                conn.Close();

                if (dsReg.Tables["reg"].Rows.Count == 0)
                {
                    cmdSave.CommandType = CommandType.Text;
                    //cmdStudent.Transaction = register_transaction;
                    cmdSave.Connection = conn;
                    cmdSave.CommandType = CommandType.Text;
                    cmdSave.CommandText = "INSERT INTO tblCollege VALUES( @college, @uni)";
                    cmdSave.Parameters.AddWithValue("@college", new_college.collegeName);
                    cmdSave.Parameters.AddWithValue("@uni", new_college.uni);


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

        public static DataTable select_colleges()
        {
            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection conn;
            SqlDataAdapter daReg;
            DataSet dsStates = new DataSet();
            DataSet dsReg = new DataSet();
            SqlCommand cmdSave = new SqlCommand();

            DataTable colleges;
            if (dsReg.Tables.Contains("coll"))
            {
                dsReg.Tables.Remove("coll");
            }

            conn = new SqlConnection(conStr);
            conn.Open();
            daReg = new SqlDataAdapter("SELECT college FROM tblcollege", conn);
            daReg.Fill(dsReg, "coll");
            conn.Close();
            colleges = dsReg.Tables["coll"].Copy();
            return colleges;
        }
    }
}