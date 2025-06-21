using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNet.Identity;

namespace SUBEB_Staff_Online_Management_System.Account
{
    public partial class passwordReset : System.Web.UI.Page
    {
        DataSet dsUser = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            publicClass.connectToDB();
            //publicClass.daStaff = new SqlDataAdapter("SELECT userName FROM ASPNETUsers", publicClass.conn);
            //publicClass.daStaff.Fill(dsUser, "user");
            //int dfdghvhg = dsUser.Tables["user"].Rows.Count;
            //string pass =  "Faith.12345";
            
            var pass = Encoding.ASCII.GetBytes("Faith.12345");
           
            var sha1 = new SHA1CryptoServiceProvider();
            var sha1data = sha1.ComputeHash(pass);
            publicClass.cmdStaff.Connection = publicClass.conn;
            publicClass.cmdStaff.CommandText = "UPDATE ASPNetUsers SET passwordHash=@pass WHERE Username=@user";
            publicClass.cmdStaff.Parameters.AddWithValue("@pass", pass);
            publicClass.cmdStaff.Parameters.AddWithValue("@user", "23304");
            publicClass.cmdStaff.ExecuteNonQuery();
            publicClass.cmdStaff.Parameters.Clear();
        }
    }
}