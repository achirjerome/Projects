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
    /// Summary description for RetireePix
    /// </summary>
    public class RetireePix : IHttpHandler
    {
        DataSet dsPix = new DataSet();
        SqlConnection conn;
        SqlConnection connHqtrs;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string id = context.Request.QueryString["id"];

            conn = new SqlConnection(conStr);

            publicClass.cmdStaff.Connection = conn;
            publicClass.cmdStaff.CommandType = CommandType.Text;
            publicClass.cmdStaff = new SqlCommand("SELECT pix FROM tblRetirees WHERE staffNo= @id", conn);
            publicClass.cmdStaff.Parameters.AddWithValue("@id", id);
            //publicClass.connectToDB();
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}