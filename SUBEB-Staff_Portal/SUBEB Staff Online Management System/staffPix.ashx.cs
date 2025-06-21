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
    /// Summary description for staffPix
    /// </summary>
    public class staffPix : IHttpHandler
    {
        //SqlCommand cmdPix;
        DataSet dsPix = new DataSet();
        SqlConnection conn;
        SqlConnection connHqtrs;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;        
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        
        public void ProcessRequest(HttpContext context)
        {
            try
            {               
                string id = context.Request.QueryString["id"];

                if (publicClass.dbLGEA == true)
                {
                    conn = new SqlConnection(conStr);
                    
                    publicClass.cmdStaff.Connection = conn;
                    publicClass.cmdStaff.CommandType = CommandType.Text;
                    publicClass.cmdStaff = new SqlCommand("SELECT pix FROM tblStaffRegistration WHERE staffNo= @id", conn);
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
                else
                {
                    connHqtrs = new SqlConnection(conStrHqtrs);
                    
                    publicClass.cmdStaff.Connection = connHqtrs;
                    publicClass.cmdStaff.CommandType = CommandType.Text;
                    publicClass.cmdStaff = new SqlCommand("SELECT pix FROM tblStaffRegistration WHERE staffNo= @id", connHqtrs);
                    publicClass.cmdStaff.Parameters.AddWithValue("@id", id);
                    //publicClass.connectToDB();
                    connHqtrs.Open();
                    var pass = publicClass.cmdStaff.ExecuteScalar();

                    if (pass != DBNull.Value)
                    {
                        byte[] pict = (byte[])publicClass.cmdStaff.ExecuteScalar();
                        context.Response.ContentType = "image/bmp";
                        context.Response.OutputStream.Write(pict, 0, pict.Length);
                    }
                    connHqtrs.Close();
                }
            }
            catch(Exception ex)
            {

            }
            
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}