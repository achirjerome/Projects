using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace DesignTemplate1.Admin
{
    public partial class addCollege : System.Web.UI.Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (dsReg.Tables.Contains("institute"))
            {
                dsReg.Tables.Remove("institute");
            }

            conn = new SqlConnection(conStr);
            conn.Open();
            daReg = new SqlDataAdapter("SELECT institution FROM tblinstitution", conn);
            daReg.Fill(dsReg, "institute");
            conn.Close();

            if(dsReg.Tables["institute"].Rows.Count>0)
            {
                lblUni.Text = dsReg.Tables["institute"].Rows[0]["institution"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string successCode = "0";
            college new_college = new college();
            new_college.collegeName = ("College of " + txtCollegeName.Text).ToUpper();
            new_college.uni = lblUni.Text.ToUpper();

            successCode = college.register(new_college);

            if (successCode == "0")
            {
                txtCollegeName.Text = string.Empty;
            }
            else
            {
                MsgBox(successCode, this.Page, this);
            }
        }
    }
}