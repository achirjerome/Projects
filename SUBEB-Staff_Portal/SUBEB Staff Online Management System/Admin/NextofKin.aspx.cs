using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace SUBEB_Staff_Online_Management_System.Admin
{
    public partial class NextofKin : System.Web.UI.Page
    {
        DataSet dsOrigin = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sNo = Request.QueryString["uri"];
            if(!(string.IsNullOrEmpty(sNo)))
            {
                txtKStaffNo.Text = sNo;
            }
            else
            {
                txtKStaffNo.Text = HttpContext.Current.User.Identity.Name;
            }
            
            if (!(IsPostBack))
            {

                DataSet dsOrigin = new DataSet();
                publicClass.connectToDB();
                if (ddlNationality.Text == "Nigeria")
                {
                    publicClass.daStaff = new SqlDataAdapter("Select * From tblStates ORDER BY StateName", publicClass.conn);
                    publicClass.daStaff.Fill(dsOrigin, "states");

                    ddlSOO.DataTextField = "StateName";
                    ddlSOO.DataValueField = "StateCode";
                    ddlSOO.DataSource = dsOrigin.Tables["states"];
                    ddlSOO.DataBind();

                    publicClass.daStaff = new SqlDataAdapter("Select * From tblLGA Where StateCode='" + ddlSOO.Text + "' ORDER BY LGAName", publicClass.conn);
                    publicClass.daStaff.Fill(dsOrigin, "lga");
                    //string df = dsOrigin.Tables["lga"].Rows[0][0].ToString();
                    ddlLGA.DataTextField = "LGAName";
                    ddlLGA.DataValueField = "LGAName";
                    ddlLGA.DataSource = dsOrigin.Tables["lga"];
                    ddlLGA.DataBind();
                    dsOrigin.Clear();
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

                newKin.Register(newKin);
                txtHomeTown.Text = string.Empty;
                txtKContactAddress.Text = string.Empty;
                txtKFirstName.Text = string.Empty;
                txtKLastName.Text = string.Empty;
                txtKPhoneNo.Text = string.Empty;
                txtKStaffNo.Text = string.Empty;
                txtMiddleName.Text = string.Empty;
                //string AdminNo = (string)(Session["AdminNo"]);
                //kCode = "kc" + AdminNo;

                ////string df = ddlKSOO.Text + ddlKSOO.SelectedItem;
                //publicClass.cmdStudents.Connection = publicClass.conn;
                //publicClass.cmdStudents.CommandType = CommandType.Text;
                //publicClass.cmdStudents.CommandText = "INSERT INTO tblNextOfKin VALUES('" + kCode + "','" + txtKFirstName.Text +
                //    "','" + txtMiddleName.Text + "','" + txtKLastName.Text + "','"
                //    + ddlRelationShip.Text + "','" + txtKContactAddress.Text + "','" + txtKPhoneNo.Text + "','"
                //    + AdminNo + "')";
                //publicClass.cmdStudents.ExecuteNonQuery();

                //txtKContactAddress.Text = string.Empty;
                //txtMiddleName.Text = string.Empty;
                //txtKeMail.Text = string.Empty;
                //txtKFirstName.Text = string.Empty;
                //txtKLastName.Text = string.Empty;
                //txtKContactAddress.Text = string.Empty;
                //txtKPhoneNo.Text = string.Empty;
                //Response.Redirect("upLoadDocuments.aspx", true);



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
            DataSet dsLGA = new DataSet();
            publicClass.daStaff = new SqlDataAdapter("Select * From tblLGA Where StateCode='" + ddlSOO.Text + "'", publicClass.conn);
            publicClass.daStaff.Fill(dsLGA, "lga");
            string df = dsLGA.Tables["lga"].Rows[0][0].ToString();
            ddlLGA.DataTextField = "LGAName";
            ddlLGA.DataValueField = "LGAName";
            ddlLGA.DataSource = dsLGA.Tables["lga"];
            ddlLGA.DataBind();
            dsLGA.Clear();
        }
    }
}