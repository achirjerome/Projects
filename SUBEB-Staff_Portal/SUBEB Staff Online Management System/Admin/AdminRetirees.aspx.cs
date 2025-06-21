using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace SUBEB_Staff_Online_Management_System.Admin
{
    public partial class AdminRetirees : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;
        DataSet dsRet = new DataSet();
        SqlDataAdapter daRet;
        public DataTable returnRetirees()
        {
            DataTable dtRet = new DataTable();

            if (dsRet.Tables.Contains("ret"))
            {
                dsRet.Tables.Remove("ret");
            }

            if(rbtLGEA.Checked==true)
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                daRet = new SqlDataAdapter("SELECT tblRetirees.StaffNo, tblRetirees.Surname, tblRetirees.Firstname, tblRetirees.Sex, tblRetirees.DateofBirth, tblRetirees.DateofAppointment, tblRetirees.RetirementDate, tblRetirees.RetirementReason FROM tblRetirees ORDER BY RetirementDate", conn);
                daRet.Fill(dsRet, "ret");
                conn.Close();
                dtRet = dsRet.Tables["ret"].Copy();
                lblDB.Text = "LGEA";
            }
            else
            {
                connHtqrs = new SqlConnection(conStrHqtrs);
                connHtqrs.Open();
                daRet = new SqlDataAdapter("SELECT tblRetirees.StaffNo, tblRetirees.Surname, tblRetirees.Firstname, tblRetirees.Sex, tblRetirees.DateofBirth, tblRetirees.DateofAppointment, tblRetirees.RetirementDate, tblRetirees.RetirementReason FROM tblRetirees ORDER BY RetirementDate", connHtqrs);
                daRet.Fill(dsRet, "ret");
                connHtqrs.Close();
                dtRet = dsRet.Tables["ret"].Copy();
                lblDB.Text = "Hqtrs";
            }            

            return dtRet;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (rbtLGEA.Checked == true)
            {
                DataTable dtRet = new DataTable();
                dtRet = returnRetirees();
                GridView1.DataSource = dtRet;
                GridView1.DataBind();
            }
        }

        protected void rbtLGEA_CheckedChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            if (rbtLGEA.Checked == true)
            {
                DataTable dtRet = new DataTable();
                dtRet = returnRetirees();
                GridView1.DataSource = dtRet;
                GridView1.DataBind();
            }

        }

        protected void rbtHqtrs_CheckedChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            if (rbtHqtrs.Checked == true)
            {
                DataTable dtRet = new DataTable();
                dtRet = returnRetirees();
                GridView1.DataSource = dtRet;
                GridView1.DataBind();
            }
        }
    }
}