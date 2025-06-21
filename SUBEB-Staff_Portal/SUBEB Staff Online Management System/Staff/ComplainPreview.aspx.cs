using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SUBEB_Staff_Online_Management_System.Staff
{
    public partial class ComplainPreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Addressee = Request.QueryString["addressee"];
            string AddressTo= Request.QueryString["AddressTo"];
            string body= Request.QueryString["body"];
            string title= Request.QueryString["Title"];
            
            //lblAddressee.Text = Addressee;
            //lblAddressTo.Text = "The " + AddressTo + ", <br/>" + "SUBEB Makurdi";
            //lblTitle.Text = title;
            //Label1.Text = body;
        }
    }
}