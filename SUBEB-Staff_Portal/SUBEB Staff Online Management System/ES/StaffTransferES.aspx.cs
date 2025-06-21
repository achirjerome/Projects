using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace SUBEB_Staff_Online_Management_System.ES
{
    public partial class StaffTransferES : System.Web.UI.Page
    {
        DataSet dsPosting = new DataSet();
        public static string postedDate = string.Empty;
        DataTable dtWorkPlace = new DataTable();

        public static DataTable selectWorkPlace(string Staffno)
        {
            DataSet dsSD = new DataSet();
            publicClass.connectToDB();
            publicClass.daStaff = new SqlDataAdapter("Select * FROM tblPosting  WHERE staffNo='" + Staffno + "'", publicClass.conn);
            publicClass.daStaff.Fill(dsSD, "posting");
            //postedDate = dsSD.Tables["posting"].Rows[0]["fromDate"].ToString();
            return dsSD.Tables["posting"];

        }

        public static DataTable LoadWorkPlace(string LGEAName)
        {
            DataSet dsSD = new DataSet();
            publicClass.connectToDB();
            publicClass.daStaff = new SqlDataAdapter("Select DISTINCT Schools FROM tblPVPermanentIncomes WHERE LGEA='" + LGEAName + "' ORDER BY Schools", publicClass.conn);
            publicClass.daStaff.Fill(dsSD, "postedlgea");
            //postedDate = dsSD.Tables["posting"].Rows[0]["fromDate"].ToString();
            return dsSD.Tables["postedlgea"];

        }

        public static DataTable selectWorkLGEA()
        {
            DataSet dsSD = new DataSet();
            publicClass.connectToDB();
            publicClass.daStaff = new SqlDataAdapter("Select DISTINCT LGEA FROM tblPVPermanentIncomes ORDER BY LGEA", publicClass.conn);
            publicClass.daStaff.Fill(dsSD, "lgea");
            //postedDate = dsSD.Tables["posting"].Rows[0]["fromDate"].ToString();
            return dsSD.Tables["lgea"];

        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                DataTable dtWorkLGEA = new DataTable();
                dtWorkLGEA = selectWorkLGEA();
                ddlWorkLGEA.DataTextField = "LGEA";
                ddlWorkLGEA.DataSource = dtWorkLGEA;
                ddlWorkLGEA.DataBind();

                if (!(string.IsNullOrEmpty(ddlWorkLGEA.Text)))
                {
                    DataTable dtWorkStation = new DataTable();
                    dtWorkStation = LoadWorkPlace(ddlWorkLGEA.Text);
                    ddlPosting.DataTextField = "Schools";
                    ddlPosting.DataSource = dtWorkStation;
                    ddlPosting.DataBind();
                }
                publicClass.connectToDB();
                publicClass.daStaff = new SqlDataAdapter("Select tblStaffRegistration.FirstName, tblStaffRegistration.MiddleName, tblStaffRegistration.SurName, tblPosting.* from tblPosting INNER JOIN tblStaffRegistration ON tblPosting.Staffno=tblStaffRegistration.Staffno ORDER BY staffno", publicClass.conn);

                //publicClass.daStaff = new SqlDataAdapter("Select * from tblPosting Where toDate='" + string.Empty + "' ORDER BY PSN", publicClass.conn);
                publicClass.daStaff.Fill(dsPosting, "posting");
                if (dsPosting.Tables["posting"].Rows.Count > 0)
                {
                    ddlStaffNo.DataTextField = "staffNo";
                    ddlStaffNo.DataValueField = "staffNo";
                    ddlStaffNo.DataSource = dsPosting.Tables["posting"];
                    ddlStaffNo.DataBind();
                    lblName.Text = dsPosting.Tables["posting"].Rows[0]["Surname"].ToString() + " " + dsPosting.Tables["posting"].Rows[0]["FirstName"].ToString() + " " + dsPosting.Tables["posting"].Rows[0]["MiddleName"].ToString();
                    DataTable dtWorkPlace = new DataTable();
                    dtWorkPlace = selectWorkPlace(ddlStaffNo.Text);
                    lblPPA.Text = dtWorkPlace.Rows[0]["WorkStation"].ToString();
                    txtPreviousDate.Text = dtWorkPlace.Rows[0]["fromDate"].ToString();
                    Image2.ImageUrl = "~/staffPix.ashx?id=" + ddlStaffNo.Text;

                    lblCurrentLGEA.Text = dtWorkPlace.Rows[0]["WorkLGEA"].ToString();
                }


            }
        }

        protected void ddlStaffNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                dtWorkPlace = selectWorkPlace(ddlStaffNo.Text);
                lblPPA.Text = dtWorkPlace.Rows[0]["WorkStation"].ToString();
                txtPreviousDate.Text = dtWorkPlace.Rows[0]["fromDate"].ToString();
                lblCurrentLGEA.Text = dtWorkPlace.Rows[0]["WorkLGEA"].ToString();
                publicClass.connectToDB();
                publicClass.daStaff = new SqlDataAdapter("Select FirstName, MiddleName, SurName FROM tblStaffRegistration WHERE staffNo='" + ddlStaffNo.Text + "'", publicClass.conn);

                publicClass.daStaff.Fill(dsPosting, "name");
                if (dsPosting.Tables["name"].Rows.Count > 0)
                {
                    lblName.Text = dsPosting.Tables["name"].Rows[0]["Surname"].ToString() + " " + dsPosting.Tables["name"].Rows[0]["FirstName"].ToString() + " " + dsPosting.Tables["name"].Rows[0]["MiddleName"].ToString();
                    Image2.ImageUrl = string.Empty;
                    Image2.ImageUrl = "~/staffPix.ashx?id=" + ddlStaffNo.Text;
                }
            }
        }

        protected void ddlWorkLGEA_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtWorkPlace = LoadWorkPlace(ddlWorkLGEA.Text);
            ddlPosting.DataTextField = "Schools";
            ddlPosting.DataSource = dtWorkPlace;
            ddlPosting.DataBind();
            Image2.ImageUrl = "~/staffPix.ashx?id=" + ddlStaffNo.Text;
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {

        }
    }
}