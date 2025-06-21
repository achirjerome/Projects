using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SUBEB_Staff_Online_Management_System.Staff
{
    public partial class StaffNextofKin : System.Web.UI.Page
    {
        DataSet dsOrigin = new DataSet();
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {        
            if (!(IsPostBack))
            {
                txtKStaffNo.Text = HttpContext.Current.User.Identity.Name;
                conn = new SqlConnection(conStr);

                if (ddlNationality.Text == "Nigeria")
                {
                    conn.Open();
                    publicClass.daStaff = new SqlDataAdapter("Select * From tblStates ORDER BY StateName", conn);
                    publicClass.daStaff.Fill(dsOrigin, "states");
                    conn.Close();

                    ddlSOO.DataTextField = "StateName";
                    ddlSOO.DataValueField = "StateCode";
                    ddlSOO.DataSource = dsOrigin.Tables["states"];
                    ddlSOO.DataBind();

                    conn.Open();
                    publicClass.daStaff = new SqlDataAdapter("Select * From tblLGA Where StateCode='" + ddlSOO.Text + "' ORDER BY LGAName", conn);
                    publicClass.daStaff.Fill(dsOrigin, "lga");
                    conn.Close();
                    //string df = dsOrigin.Tables["lga"].Rows[0][0].ToString();
                    ddlLGA.DataTextField = "LGAName";
                    ddlLGA.DataValueField = "LGAName";
                    ddlLGA.DataSource = dsOrigin.Tables["lga"];
                    ddlLGA.DataBind();
                    dsOrigin.Clear();
                }
                conn.Open();
                publicClass.daStaff = new SqlDataAdapter("Select * From tblNextofKin WHERE STaffNo='" + txtKStaffNo.Text + "'", conn);
                publicClass.daStaff.Fill(dsOrigin, "next");
                conn.Close();

                if(dsOrigin.Tables["next"].Rows.Count ==1)
                {
                    txtKFirstName.Text = dsOrigin.Tables["next"].Rows[0]["Firstname"].ToString();
                    txtMiddleName.Text= dsOrigin.Tables["next"].Rows[0]["middlename"].ToString();
                    txtKLastName.Text = dsOrigin.Tables["next"].Rows[0]["Surname"].ToString();
                    txtHomeTown.Text = dsOrigin.Tables["next"].Rows[0]["Hometown"].ToString();
                    ddlNationality.Text = dsOrigin.Tables["next"].Rows[0]["Nationality"].ToString();
                    ddlSOO.Text = dsOrigin.Tables["next"].Rows[0]["StateofOrigin"].ToString();                  
                    ddlLGA.Text = dsOrigin.Tables["next"].Rows[0]["LGA"].ToString();



                    ddlRelationShip.Text = dsOrigin.Tables["next"].Rows[0]["Relationship"].ToString();
                    txtKContactAddress.Text = dsOrigin.Tables["next"].Rows[0]["ContactAddress"].ToString();
                    txtKPhoneNo.Text = dsOrigin.Tables["next"].Rows[0]["PhoneNo"].ToString();

                    publicClass.dbLGEA = true;
                }
                else
                {
                    connHtqrs = new SqlConnection(conStrHqtrs);
                    connHtqrs.Open();
                    publicClass.daStaff = new SqlDataAdapter("Select * From tblNextofKin WHERE STaffNo='" + txtKStaffNo.Text + "'", connHtqrs);
                    publicClass.daStaff.Fill(dsOrigin, "next");
                    connHtqrs.Close();

                    if (dsOrigin.Tables["next"].Rows.Count == 1)
                    {
                        txtKFirstName.Text = dsOrigin.Tables["next"].Rows[0]["Firstname"].ToString();
                        txtMiddleName.Text = dsOrigin.Tables["next"].Rows[0]["middlename"].ToString();
                        txtKLastName.Text = dsOrigin.Tables["next"].Rows[0]["Surname"].ToString();
                        txtHomeTown.Text = dsOrigin.Tables["next"].Rows[0]["Hometown"].ToString();
                        ddlNationality.Text = dsOrigin.Tables["next"].Rows[0]["Nationality"].ToString();
                        ddlSOO.Text = dsOrigin.Tables["next"].Rows[0]["StateofOrigin"].ToString();
                        ddlLGA.Text = dsOrigin.Tables["next"].Rows[0]["LGA"].ToString();



                        ddlRelationShip.Text = dsOrigin.Tables["next"].Rows[0]["Relationship"].ToString();
                        txtKContactAddress.Text = dsOrigin.Tables["next"].Rows[0]["ContactAddress"].ToString();
                        txtKPhoneNo.Text = dsOrigin.Tables["next"].Rows[0]["PhoneNo"].ToString();

                        publicClass.dbLGEA = false;
                    }
                    else
                    {
                        
                    }
                }


               


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string sex = "M";
            string kCode;
            Boolean fileOK = false;

            try
            {
                nextofKin newKin = new nextofKin();
                newKin.StaffNo = txtKStaffNo.Text;
                newKin.KinCode = "kc" + txtKStaffNo.Text;
                newKin.firstName = txtKFirstName.Text;
                newKin.middleName = txtMiddleName.Text;
                newKin.Surname = txtKLastName.Text;
                newKin.HomeTown = txtHomeTown.Text;
                newKin.LGA = ddlLGA.Text;
                newKin.StateofOrigin = ddlSOO.Text;
                newKin.Nationality = ddlNationality.Text;
                newKin.Relationship = ddlRelationShip.Text;
                newKin.ContactAddress = txtKContactAddress.Text;
                newKin.PhoneNo = txtKPhoneNo.Text;
                
                newKin.updateNextofKin(newKin);

                txtHomeTown.Text = string.Empty;
                txtKContactAddress.Text = string.Empty;
                txtKFirstName.Text = string.Empty;
                txtKLastName.Text = string.Empty;
                txtKPhoneNo.Text = string.Empty;
                txtKStaffNo.Text = string.Empty;
                txtMiddleName.Text = string.Empty;
             
            }
            catch (Exception ex)
            {
                publicClass.conn.Close();
                Label1.Text = ex.Message;
            }

        }

        protected void ddlNationality_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSOO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                DataSet dsLGA = new DataSet();
                conn = new SqlConnection(conStr);
                conn.Open();
                publicClass.daStaff = new SqlDataAdapter("Select * From tblLGA Where StateCode='" + ddlSOO.Text + "'", conn);
                publicClass.daStaff.Fill(dsLGA, "lga");
                conn.Close();

                ddlLGA.DataTextField = "LGAName";
                ddlLGA.DataValueField = "LGAName";
                ddlLGA.DataSource = dsLGA.Tables["lga"];
                ddlLGA.DataBind();
                dsLGA.Clear();
            }
        }
    }
}