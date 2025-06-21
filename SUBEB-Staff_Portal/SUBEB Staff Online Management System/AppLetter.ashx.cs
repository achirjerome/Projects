using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SUBEB_Staff_Online_Management_System
{
    /// <summary>
    /// Summary description for AppLetter
    /// </summary>
    public class AppLetter : IHttpHandler
    {
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;
        public void ProcessRequest(HttpContext context)
        {
            DataSet dsdsLetter = new DataSet();
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string ID = context.Request.QueryString["id"];
            string AppDate = context.Request.QueryString["appdate"];

            if (publicClass.dbLGEA == true)
            {
                conn = new SqlConnection(conStr);

                publicClass.cmdStaff.Connection = conn;
                publicClass.cmdStaff.CommandType = CommandType.Text;
                publicClass.cmdStaff = new SqlCommand("SELECT AppLetter FROM tblApplicationLetters WHERE StaffNo=@id AND AppDate=@appdate", conn);
                publicClass.cmdStaff.Parameters.AddWithValue("@id", ID);
                publicClass.cmdStaff.Parameters.AddWithValue("@appdate", AppDate);
                conn.Open();
                var pass = publicClass.cmdStaff.ExecuteScalar();

                if (pass != DBNull.Value)
                {
                    byte[] pict = (byte[])publicClass.cmdStaff.ExecuteScalar();
                    context.Response.ContentType = "image/bmp";
                    context.Response.OutputStream.Write(pict, 0, pict.Length);
                }
                conn.Close();
            }
            else
            {
                //Hqtrs
                connHtqrs = new SqlConnection(conStrHqtrs);

                publicClass.cmdStaff.Connection = connHtqrs;
                publicClass.cmdStaff.CommandType = CommandType.Text;
                publicClass.cmdStaff = new SqlCommand("SELECT AppLetter FROM tblApplicationLetters WHERE StaffNo= @id AND AppDate=@appdate", connHtqrs);
                publicClass.cmdStaff.Parameters.AddWithValue("@id", ID);
                publicClass.cmdStaff.Parameters.AddWithValue("@appdate", AppDate);
                connHtqrs.Open();
                var pass = publicClass.cmdStaff.ExecuteScalar();

                if (pass != DBNull.Value)
                {
                    byte[] pict = (byte[])publicClass.cmdStaff.ExecuteScalar();
                    context.Response.ContentType = "image/bmp";
                    context.Response.OutputStream.Write(pict, 0, pict.Length);
                }
                connHtqrs.Close();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}