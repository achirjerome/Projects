using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DesignTemplate1.students
{
    public partial class studentsMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["department"] = "DEPARTMENT OF COMPUTER SCIENCE";
            Session["user"] = "16/39629/UE";
        }
    }
}