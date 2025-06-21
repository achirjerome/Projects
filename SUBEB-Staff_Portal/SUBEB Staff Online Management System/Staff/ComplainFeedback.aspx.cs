using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SUBEB_Staff_Online_Management_System.Staff
{
    public partial class ComplainFeedback : System.Web.UI.Page
    {
        DataSet dsComplainFeedback = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            string staffNo = HttpContext.Current.User.Identity.Name; // string.Empty;
            publicClass.connectToDB();
            publicClass.daStaff = new SqlDataAdapter("SELECT Workstation FROM tblPosting WHERE staffno='" + staffNo + "'", publicClass.conn);
            publicClass.daStaff.Fill(dsComplainFeedback, "complain");
            lblAddressee.Text = dsComplainFeedback.Tables["complain"].Rows[0]["workstation"].ToString();
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            string tygg = HttpUtility.UrlEncode(txtBody.Text);
            Response.Redirect("ComplainPreview.aspx?addressTo=" + ddlAddressTo.Text + "&addressee=" + lblAddressee.Text + "&body=" + txtBody.Text + "&Title=" + txtTitle.Text, true);

        }
    }
}