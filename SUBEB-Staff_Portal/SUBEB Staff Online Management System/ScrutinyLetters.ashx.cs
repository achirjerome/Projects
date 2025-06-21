using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace SUBEB_Staff_Online_Management_System.Chairman
{
    /// <summary>
    /// Summary description for ScrutinyLetters
    /// </summary>
    ///     
    public class ScrutinyLetters : IHttpHandler
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
            string ID= context.Request.QueryString["id"];
            string queryDate = context.Request.QueryString["queryDate"];

            if (publicClass.dbLGEA == true)
            {
                conn = new SqlConnection(conStr);
                               
                publicClass.cmdStaff.Connection = conn;
                publicClass.cmdStaff.CommandType = CommandType.Text;
                publicClass.cmdStaff = new SqlCommand("SELECT Letter FROM tblScrutiny WHERE staffNo= @id AND queryDate=@date", conn);
                publicClass.cmdStaff.Parameters.AddWithValue("@id", ID);
                publicClass.cmdStaff.Parameters.AddWithValue("@id", queryDate);
                conn.Open();
                var pass = publicClass.cmdStaff.ExecuteScalar();
                              
                if (pass != DBNull.Value)
                {
                    byte[] pict = (byte[])publicClass.cmdStaff.ExecuteScalar();
                    context.Response.ContentType = "image/bmp";
                    context.Response.OutputStream.Write(pict, 0, pict.Length);
                }
                conn.Close();
                publicClass.cmdStaff.Parameters.Clear();
            }
            else
            {
                //Hqtrs
                connHtqrs = new SqlConnection(conStrHqtrs);
                
                publicClass.cmdStaff.Connection = connHtqrs;
                publicClass.cmdStaff.CommandType = CommandType.Text;
                publicClass.cmdStaff = new SqlCommand("SELECT Letter FROM tblScrutiny WHERE staffNo= @id AND queryDate=@date", connHtqrs);
                publicClass.cmdStaff.Parameters.AddWithValue("@id", ID);
                publicClass.cmdStaff.Parameters.AddWithValue("@date", queryDate);
                connHtqrs.Open();
                var pass = publicClass.cmdStaff.ExecuteScalar();
                
                if (pass != DBNull.Value)
                {
                    byte[] pict = (byte[])publicClass.cmdStaff.ExecuteScalar();
                    context.Response.ContentType = "image/bmp";
                    context.Response.OutputStream.Write(pict, 0, pict.Length);
                }
                connHtqrs.Close();
                publicClass.cmdStaff.Parameters.Clear();
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