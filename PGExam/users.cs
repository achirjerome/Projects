using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DesignTemplate1
{
    public class users
    {
        public string staffNo { get; set; }
        public string Department { get; set; }

        public static string register(users new_user)
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
                daReg = new SqlDataAdapter("SELECT staffno FROM tblUsers WHERE staffno='" + new_user.staffNo + "'", conn);
                daReg.Fill(dsReg, "reg");
                conn.Close();

                if (dsReg.Tables["reg"].Rows.Count == 0)
                {
                    cmdSave.CommandType = CommandType.Text;
                    //cmdStudent.Transaction = register_transaction;
                    cmdSave.Connection = conn;
                    cmdSave.CommandType = CommandType.Text;
                    cmdSave.CommandText = "INSERT INTO tblUsers VALUES( @staffno, @dept)";
                    cmdSave.Parameters.AddWithValue("@staffno", new_user.staffNo);
                    cmdSave.Parameters.AddWithValue("@dept", new_user.Department);


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

    }
}