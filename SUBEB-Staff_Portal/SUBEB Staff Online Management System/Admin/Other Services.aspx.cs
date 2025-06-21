using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace SUBEB_Staff_Online_Management_System.Admin
{
    public partial class Other_Services : System.Web.UI.Page
    {
        SqlDataAdapter daSelectStaff;
        DataSet dsSelectStaff = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGW_Click(object sender, EventArgs e)
        {
            string staffNumber;        
            publicClass.connectToDB();
            daSelectStaff = new SqlDataAdapter("SELECT * FROM tblStaffRegistration", publicClass.conn);
            daSelectStaff.Fill(dsSelectStaff, "staff");
            publicClass.conn.Close();
            for(int staffcount=0; staffcount < dsSelectStaff.Tables["staff"].Rows.Count; staffcount++)
            {
                staffNumber = dsSelectStaff.Tables["staff"].Rows[staffcount]["staffno"].ToString();

                publicClass.connectToSUBEBPV();
                daSelectStaff = new SqlDataAdapter("SELECT StaffNo FROM tblStaffRegistration WHERE StaffNo='" + staffNumber + "'", publicClass.conn);
            }
        }
    }
}