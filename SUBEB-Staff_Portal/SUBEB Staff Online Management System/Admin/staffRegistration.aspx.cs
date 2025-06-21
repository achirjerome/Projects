using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;


namespace SUBEB_Staff_Online_Management_System.Admin
{
    public partial class staffRegistration : System.Web.UI.Page
    {
        public DataSet dsStaff = new DataSet();

        public void selectWorkLGEA()
        {
            //try
            //{
                if (rbtLGEA.Checked == true)
                {
                    //MessageBox.Show(publicClass.conn.State.ToString());
                    if (dsStaff.Tables.Contains("lgea"))
                    {
                        dsStaff.Tables.Remove("lgea");
                    }

                    publicClass.daStaff = new SqlDataAdapter("SELECT DISTINCT LGEA FROM tblWorkStations ORDER BY LGEA", publicClass.conn);
                    publicClass.daStaff.Fill(dsStaff, "lgea");

                    ddlWorkLGEA.DataTextField = "LGEA";
                    ddlWorkLGEA.DataValueField = "LGEA";
                    ddlWorkLGEA.DataSource = dsStaff.Tables["lgea"];
                    ddlWorkLGEA.DataBind();
                    //publicClass.conn.Close();
                }
                else
                {
                    //Select Makurdi LGEA
                }
            //}
            //catch(Exception ex)
            //{

            //}
}

        public void selectWorkStation()
        {
            //try
            //{
                if (rbtLGEA.Checked == true)
                {
                    //MessageBox.Show(publicClass.conn.State.ToString());
                    if (dsStaff.Tables.Contains("schools"))
                    {
                        dsStaff.Tables.Remove("schools");
                    }

                    publicClass.daStaff = new SqlDataAdapter("SELECT School FROM tblWorkStations WHERE LGEA='" + ddlWorkLGEA.Text + "' ORDER BY School", publicClass.conn);
                    publicClass.daStaff.Fill(dsStaff, "schools");

                    ddlWorkStation.DataTextField = "school";
                    //cboWorkLGEA.ValueMember = "LGEA";
                    ddlWorkStation.DataSource = dsStaff.Tables["schools"];
                    ddlWorkStation.DataBind();
                    //publicClass.conn.Close();
                }
            //}
            //catch(Exception ex)
            //{

            //}

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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


                    selectWorkLGEA();
                    if (!string.IsNullOrEmpty(ddlWorkLGEA.Text))
                    {
                        selectWorkStation();
                    }

                    //publicClass.daStaff = new SqlDataAdapter("SELECT * FROM tblSuspendEmp", publicClass.conn);
                    //publicClass.daStaff.Fill(dsOrigin, "suspend");

                    //if(dsOrigin.Tables["suspend"].Rows[0]["suspendEmployment"].ToString() =="1")
                    //{
                    //    btnContinue.Enabled = false;
                    //}
                    //else
                    //{
                    //    btnContinue.Enabled = true;
                    //}
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
        }

        protected void txtPSHN_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            try
            {
                //var pass = fuPassport.FileBytes;
                int noExist;
                string sex = "M";
                string DOB, DOA;
                Boolean fileOK = false;

                Label1.Text = string.Empty;
                //try
                //{
                int passportSize = int.Parse(fuPassport.PostedFile.ContentLength.ToString());

                //String path = Server.MapPath("~/UploadImages/");
                if (fuPassport.HasFile)
                {
                    fileOK = true;
                }

                if (fileOK)
                {
                    //fuPassport.PostedFile.SaveAs(path + txtStaffNo.Text + ".jpg");

                    publicClass.connectToDB();

                    publicClass.daStaff = new SqlDataAdapter("Select staffno FROM tblStaffRegistration WHERE StaffNo ='" + txtStaffNo.Text + "'", publicClass.conn);
                    publicClass.daStaff.Fill(dsStaff, "reg");

                    noExist = dsStaff.Tables["reg"].Rows.Count;

                    if (rbtMale.Checked == true)
                    {
                        sender = "M";
                    }
                    else { sex = "F"; }

                    //DOB = txtDateofBirth.Text;
                    //DOA = ddlYearAppointment.Text + "-" + ddlMonthAppointment.Text + "-" + ddlDayAppointment.Text;
                    string gradeLevelAndStep = "CONPSS " + ddlCurrentGradeLevel.Text + "/" + ddlCurrentStep.Text;

                    if (noExist == 0)
                    {
                        var pic = fuPassport.FileBytes; //File.ReadAllBytes(fuPassport.PostedFile.ToString());
                        //staff subebStaff = new staff();
                        //subebStaff.staffNo = txtStaffNo.Text;
                        //subebStaff.firstName = txtFirstName.Text;
                        //subebStaff.middleName = txtMiddleName.Text;
                        //subebStaff.Surname = txtLastName.Text;
                        //subebStaff.Sex = sex;
                        //subebStaff.MaritalStatus = ddlMaritalStatus.Text;
                        //subebStaff.NoofChildren = txtNoofChildren.Text;
                        //subebStaff.DateofBirth = txtDateofBirth.Text;
                        //subebStaff.HomeTown = txtHomeTown.Text;
                        //subebStaff.LGA = ddlLGA.Text;
                        //subebStaff.StateofOrigin = ddlSOO.Text;
                        //subebStaff.Nationality = ddlNationality.Text;
                        //subebStaff.Religion = ddlReligion.Text;
                        //subebStaff.ContactAddress = txtContactAddress.Text;
                        //subebStaff.PermanentAddress = txtPermanentAddress.Text;
                        //subebStaff.PhoneNo = txtPhoneNo.Text;
                        //subebStaff.Email = txtemail.Text;
                        //subebStaff.Qualification = ddlQualification.Text;
                        //subebStaff.FieldOfStyudy = txtSpeciaty.Text;
                        //subebStaff.DateofAppointment = txtDateofAppointment.Text;
                        //subebStaff.DateofLastPromotion = txtDateofLastPromotion.Text;
                        //subebStaff.JobTitle = ddlJobTitle.Text;
                        //subebStaff.Rank = txtRank.Text;
                        //subebStaff.GradeLevel = gradeLevelAndStep;
                        //subebStaff.BloodGroup = ddlBloodGroup.Text;
                        //subebStaff.Passport = pic;
                        ////subebStaff.certSerialNo = publicClass.GetSerialNumber(subebStaff.staffNo);
                        //string result = subebStaff.Register(subebStaff);

                        //if (result == "0")//registration successful
                        //{
                        //    subebStaff.post(subebStaff.staffNo, subebStaff.DateofAppointment, ddlWorkStation.Text, ddlWorkLGEA.Text); //save posting information of a staff
                        //    subebStaff.promote(subebStaff.staffNo, subebStaff.DateofLastPromotion, subebStaff.GradeLevel, subebStaff.Rank);//save promotion information of a staff
                        //    subebStaff.retireStaff(subebStaff.staffNo, DateTime.Parse(subebStaff.DateofBirth), DateTime.Parse(subebStaff.DateofAppointment)); //save retirement information of a staff
                        //    Response.Redirect("nextOfKin.aspx?uri=" + txtStaffNo.Text, true);
                        //}
                        //else
                        //{
                        //    Label1.Text = result;
                        //}


                    }
                    else
                    {
                        Label1.Text = "Record already exist";
                    }

                }
                else
                {
                    Label1.Text = "Cannot accept files of this type or size more than 50KB";
                }
                //}
                //catch (Exception ex)
                //{
                //    Label1.Text = ex.Message;
                //}
            }
            catch(Exception ex)
            {
                Label1.Text = ex.Message;
            }
            
        }

        protected void ddlNationality_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataSet dsOrigin = new DataSet();
            //publicClass.connectToDB();
            //if (ddlNationality.Text == "Nigeria")
            //{
            //    publicClass.daStaff = new SqlDataAdapter("Select * From tblStates", publicClass.conn);
            //    publicClass.daStaff.Fill(dsOrigin, "states");

            //    ddlSOO.DataTextField = "StateName";
            //    ddlSOO.DataValueField = "StateCode";
            //    ddlSOO.DataSource = dsOrigin.Tables["states"];
            //    ddlSOO.DataBind();

            //    publicClass.daStaff = new SqlDataAdapter("Select * From tblLGA Where StateCode='" + ddlSOO.Text + "'", publicClass.conn);
            //    publicClass.daStaff.Fill(dsOrigin, "lga");
            //    //string df = dsOrigin.Tables["lga"].Rows[0][0].ToString();
            //    ddlLGA.DataTextField = "LGAName";
            //    ddlLGA.DataValueField = "LGAName";
            //    ddlLGA.DataSource = dsOrigin.Tables["lga"];
            //    ddlLGA.DataBind();
            //    dsOrigin.Clear();
            //}
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

        protected void ddlWorkLGEA_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectWorkStation();
        }
    }
}