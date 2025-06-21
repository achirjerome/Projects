using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DesignTemplate1.Admin
{
    public partial class addCourseofStudy : System.Web.UI.Page
    {
        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string successCode="0";
            programme new_program = new programme();
            new_program.programmeName = (txtCourseofStudy.Text).ToUpper();
            new_program.departmentName = (ddlDepartment.Text).ToUpper();
            new_program.collegeName = (ddlCollege.Text).ToUpper();

            successCode = programme.register(new_program);

            if(successCode=="0")
            {
                txtCourseofStudy.Text = string.Empty;
            }
            else
            {
                MsgBox(successCode, this.Page, this);
            }
        }
    }
}