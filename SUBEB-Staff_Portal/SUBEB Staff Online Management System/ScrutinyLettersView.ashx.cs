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
    /// Summary description for ScrutinyLettersView
    /// </summary>
    public class ScrutinyLettersView : IHttpHandler
    {
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;
        public void ProcessRequest(HttpContext context)
        {
            DataSet dsPix = new DataSet();
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string staffNo = context.Request.QueryString["id"];

            if (publicClass.dbLGEA == true)
            {
                conn = new SqlConnection(conStr);

                publicClass.cmdStaff.Connection = conn;
                publicClass.cmdStaff.CommandType = CommandType.Text;
                publicClass.cmdStaff = new SqlCommand("SELECT Letter FROM tblScrutiny WHERE staffNo= @id", conn);
                publicClass.cmdStaff.Parameters.AddWithValue("@id", staffNo);
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
                publicClass.cmdStaff = new SqlCommand("SELECT Letter FROM tblScrutiny WHERE staffNo= @id", connHtqrs);
                publicClass.cmdStaff.Parameters.AddWithValue("@id", staffNo);
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