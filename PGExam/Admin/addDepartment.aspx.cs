using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DesignTemplate1.Admin
{
    public partial class addDepartment : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn;
        SqlDataAdapter daReg;
        DataSet dsStates = new DataSet();
        DataSet dsReg = new DataSet();
        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string successCode = "0";
            department new_dept = new department();
            new_dept.departmentName = ("Department of " + txtDeptName.Text).ToUpper();
            new_dept.collegeName = (ddlCollege.Text).ToUpper();

            successCode = department.register(new_dept);

            if (successCode == "0")
            {
                txtDeptName.Text = string.Empty;
            }
            else
            {
                MsgBox(successCode, this.Page, this);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable select_colleges = college.select_colleges();
            //MsgBox(select_colleges.Rows[0]["college"].ToString(), this.Page, this);            
            ddlCollege.DataSource = select_colleges;
            ddlCollege.DataTextField = "college";
            ddlCollege.DataBind();
                        
        }
    }
}