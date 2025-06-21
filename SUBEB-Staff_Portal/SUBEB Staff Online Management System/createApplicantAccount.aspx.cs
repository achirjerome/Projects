using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SUBEB_Staff_Online_Management_System
{
    public partial class createApplicantAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/ApplicantsAccountCreated.aspx");
        }
    }
}