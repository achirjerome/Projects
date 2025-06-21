using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace SUBEB_Staff_Online_Management_System.Admin
{
    public partial class StaffReg : System.Web.UI.Page
    {
        protected void Wizard1_PreRender(object sender, EventArgs e)
        {
            Repeater SideBarList = Wizard1.FindControl("HeaderContainer").FindControl("SideBarList") as Repeater;

            SideBarList.DataSource = Wizard1.WizardSteps;
            SideBarList.DataBind();

        }

        public string GetClassForWizardStep(object wizardStep)
        {
            WizardStep step = wizardStep as WizardStep;

            if (step == null)
            {
                return "";
            }

            int stepIndex = Wizard1.WizardSteps.IndexOf(step);

            if (stepIndex < Wizard1.ActiveStepIndex)
            {
                return "stepCompleted";
            }
            else if (stepIndex > Wizard1.ActiveStepIndex)
            {
                return "stepNotCompleted";
            }
            else
            {
                return "stepCurrent";
            }
        }

        public DataSet dsStaff = new DataSet();
        
        public void selectWorkLGEA()
        {
            if (rbtLGEA.Checked == true)
            {
                //MessageBox.Show(publicClass.connLGEA.State.ToString());
                if (dsStaff.Tables.Contains("lgea"))
                {
                    dsStaff.Tables.Remove("lgea");
                }
                publicClass.connectToDB();
                publicClass.daStaff = new SqlDataAdapter("SELECT LGAName FROM tblWorkLGEA ORDER BY LGAName", publicClass.conn);
                publicClass.daStaff.Fill(dsStaff, "lgea");
                publicClass.conn.Close();

                ddlWorkLGEA.DataTextField = "LGAName";
                ddlWorkLGEA.DataValueField = "LGAName";
                ddlWorkLGEA.DataSource = dsStaff.Tables["lgea"];
                ddlWorkLGEA.DataBind();

            }
            else
            {
                //Select Makurdi LGEA
            }
        }

        public void selectWorkStation()
        {
            if (rbtLGEA.Checked == true)
            {
                //MessageBox.Show(publicClass.connLGEA.State.ToString());
                if (dsStaff.Tables.Contains("schools"))
                {
                    dsStaff.Tables.Remove("schools");
                }

                publicClass.connectToDB();
                publicClass.daStaff = new SqlDataAdapter("SELECT Schools FROM tblschools WHERE LGEA='" + ddlWorkLGEA.Text + "'ORDER BY Schools", publicClass.conn);
                publicClass.daStaff.Fill(dsStaff, "schools");
                publicClass.conn.Close();

                ddlWorkStation.DataTextField = "schools";
                //cboWorkLGEA.ValueMember = "LGEA";
                ddlWorkStation.DataSource =dsStaff.Tables["schools"];
                ddlWorkStation.DataBind();
                publicClass.conn.Close();
            }

        }

        public void selectLGAOrigin()
        {
            DataSet dsOrigin = new DataSet();
            if (dsOrigin.Tables.Contains("lga"))
            {
                dsOrigin.Tables.Remove("lga");
            }
            publicClass.connectToDB();
            publicClass.daStaff = new SqlDataAdapter("Select * From tblLGA Where StateCode='" + ddlSOO.Text + "' ORDER BY LGAName", publicClass.conn);
            publicClass.daStaff.Fill(dsOrigin, "lga");
            //string df = dsOrigin.Tables["lga"].Rows[0][0].ToString();
            ddlLGA.DataTextField = "LGAName";
            ddlLGA.DataValueField = "LGAName";
            ddlLGA.DataSource = dsOrigin.Tables["lga"];
            ddlLGA.DataBind();
            dsOrigin.Clear();
        }
        public void selectBank()
        {
            DataSet dsBank = new DataSet();
            if (dsBank.Tables.Contains("bank"))
            {
                dsBank.Tables.Remove("bank");
            }
            publicClass.connectToDB();
            publicClass.daStaff = new SqlDataAdapter("Select Bank From tblBanks ORDER BY Bank", publicClass.conn);
            publicClass.daStaff.Fill(dsBank, "bank");
            //string df = dsOrigin.Tables["lga"].Rows[0][0].ToString();
            ddlBankName.DataTextField = "bank";
            ddlBankName.DataValueField = "bank";
            ddlBankName.DataSource = dsBank.Tables["bank"];
            ddlBankName.DataBind();
            dsBank.Clear();
        }
        protected void Page_Load(object sender, EventArgs e)
        {          
            Wizard1.PreRender += new EventHandler(Wizard1_PreRender);

            //try
            //{
                if (!(IsPostBack))
                {
                    selectBank();
                    DataSet dsOrigin = new DataSet();
                    publicClass.connectToDB();
                    if (ddlNationality.Text == "Nigeria")
                    {
                        if(dsOrigin.Tables.Contains("states"))
                        {
                            dsOrigin.Tables.Remove("states");
                        }
                        publicClass.daStaff = new SqlDataAdapter("Select * From tblStates ORDER BY StateName", publicClass.conn);
                        publicClass.daStaff.Fill(dsOrigin, "states");

                        ddlSOO.DataTextField = "StateName";
                        //ddlSOO.DataValueField = "StateCode";
                        ddlSOO.DataSource = dsOrigin.Tables["states"];
                        ddlSOO.DataBind();

                        if (dsOrigin.Tables.Contains("lga"))
                        {
                            dsOrigin.Tables.Remove("lga");
                        }

                        publicClass.daStaff = new SqlDataAdapter("Select * From tblLGA Where StateName ='" + ddlSOO.Text + "' ORDER BY LGAName", publicClass.conn);
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
            //}
            //catch (Exception ex)
            //{
            //    //Label1.Text = ex.Message;
            //}
        }

        protected void ddlNationality_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSOO_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectLGAOrigin();
        }

        protected void ddlReligion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            string sex = string.Empty;
            string DOB = string.Empty;
            string DOA = string.Empty;
            string DOLP = string.Empty;
            if (e.NextStepIndex == 5)
            {
                if(rbtMale.Checked==true)
                {
                    sex = "M";
                }
                else
                {
                    sex = "F";
                }

                lblFisrtname.Text = txtFirstname.Text;
                lblMiddlename.Text = txtMiddlename.Text;
                lblSurname.Text = txtSurname.Text;
                lblSex.Text = sex;
                lblMarritalStatus.Text = ddlMaritalStatus.Text;
                lblDOB.Text = txtDateofBirth.Text.ToString();
                lblHometown.Text = txtHometown.Text;
                lblNationality.Text = ddlNationality.Text;
                lblSOO.Text = ddlSOO.Text;
                lblLGA.Text = ddlLGA.Text;
                lblReligion.Text = ddlReligion.Text;

                lblBank.Text = ddlBankName.SelectedItem.Text;
                lblBankAccount.Text = txtAccountNumber.Text;


                Stream fs = fuPassport.PostedFile.InputStream;
                BinaryReader br = new System.IO.BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                Image1.ImageUrl = "data:image/png;base64," + base64String;
                Image1.Visible = true;
            }
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            int noExist;
            string sex = "M";
            //DateTime dateofBirth, dateofAdmission;
            string DOB, DOA, GradeLevel;
            Boolean fileOK = false;
            var pix = string.Empty;



            if (rbtMale.Checked == true)
            {
                sex = "M";
            }
            else { sex = "F"; }

            //GradeLevel = "CONPSS " + cboGrade.Text + "/" + cboSteps.Text;


            //string PostingDate = dtpLastPromotion.Value.ToShortDateString();
            //DateTime dob = DateTime.Parse(lblDOB.Text);
            //DateTime doa = dtpDOA.Value;
            //DateTime ageDate = dob.AddYears(18);

            //int age = Staff.Age(dob, doa); //Calculate age           
            //if (age < 18)
            //{
            //    MessageBox.Show("Age less than 18 years as at employment, please check 'date of birth' and 'date of appointment'", "Age", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            ////dateofBirth = DateTime.Parse();
            //DOB = dtpDOB.Value.ToShortDateString();
            //DOA = doa.ToShortDateString();

            //if (rbtLGEA.Checked == true)
            //{
            //    publicClass.DB = "0";


            //    if (publicClass.dsStaff.Tables.Contains("reg"))
            //    {
            //        publicClass.dsStaff.Tables.Remove("reg");
            //    }

            //    publicClass.connecttoLGEADB();
            //    string No = txtStaffNo.Text;
            //    publicClass.daStaffReg = new SQLiteDataAdapter("Select staffNo FROM tblStaffRegistration WHERE StaffNo ='" + No + "'", publicClass.connLGEA);
            //    publicClass.daStaffReg.Fill(publicClass.dsStaff, "reg");
            //    publicClass.connLGEA.Close();

            //    noExist = publicClass.dsStaff.Tables["reg"].Rows.Count;


            //    if (noExist == 0)
            //    {

            //        //try
            //        //{
            //        Staff newStaff = new Staff();

            //        var pass = File.ReadAllBytes(Application.StartupPath + "\\logo0004.png");

            //        string[] Retirement = Staff.Retire(dtpDOB.Value, dtpDOA.Value);

            //        string strRetireDate = Retirement[0];
            //        string strRetireReason = Retirement[0];

            //        newStaff.staffNo = txtStaffNo.Text;
            //        newStaff.FirstName = txtFirstName.Text;
            //        newStaff.MiddleName = txtMiddleName.Text;
            //        newStaff.SurName = txtLastName.Text;
            //        newStaff.Sex = sex;
            //        newStaff.MarritalStatus = cboMarritalStatus.Text;
            //        newStaff.DateofBirth = DOB;
            //        newStaff.HomeTown = txtHomeTown.Text;
            //        newStaff.Nationality = cboNationality.Text;
            //        newStaff.Stateoforigin = cboSOO.Text;
            //        newStaff.LGA = cboLGA.Text;
            //        newStaff.Religion = cboReligion.Text;
            //        newStaff.ResidentialAddress = txtContactAddress.Text;
            //        newStaff.PermanentAddress = txtPermanentAddress.Text;
            //        newStaff.PhoneNo = txtPhoneNo.Text;
            //        newStaff.Email = txtEmail.Text;
            //        newStaff.Qualification = cboQualification.Text;
            //        newStaff.Speciaty = txtSpeciaty.Text;
            //        newStaff.DateofAppointment = DOA;
            //        newStaff.DateofLastPromotion = DOA;
            //        newStaff.GradeLevelSteps = GradeLevel;
            //        newStaff.WorkType = cboWorkType.Text;
            //        newStaff.WorkStation = cboWorkStation.Text;
            //        newStaff.WorkLGEA = cboWorkLGEA.Text;
            //        newStaff.PostedDate = PostingDate;
            //        newStaff.Rank = txtRank.Text;
            //        newStaff.Pix = pass;
            //        newStaff.Bank = cboBank.Text;
            //        newStaff.AccNo = txtAccountNo.Text;
            //        newStaff.KFirstName = txtGFirstName.Text;
            //        newStaff.kSurname = txtGLastName.Text;
            //        newStaff.kContactAddress = txtGContactAddress.Text;
            //        newStaff.kPhoneNo = txtGPhoneNo.Text;
            //        newStaff.RetirementDate = strRetireDate;
            //        newStaff.RetirementReason = strRetireReason;
            //        newStaff.status = "0";
            //        newStaff.Approval = "0";
            //        newStaff.Category = "LGEA";

            //        string success = Staff.Register(newStaff);

            //        if (success == "1")
            //        {
            //            StreamWriter swReport = File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\DB\\Report.txt");
            //            swReport.WriteLine(string.Empty);
            //            swReport.WriteLine(publicClass.ActiveUser + " registered new staff with staff number " + txtStaffNo.Text + " on " + DateTime.Now);
            //            swReport.Close();

            //            clearText();
            //        }


            //        //     
            //        //catch (Exception ex)
            //        //{
            //        //   MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        //}

            //    }
            //    else
            //    {
            //        MessageBox.Show("Record already exist", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }


            //}
            //else
            //{
            //    if (rbtHqtrs.Checked == true)
            //    {
            //        //Save to SUBEBDataMgtDB-Hqtrs



            //    }
            //}
        }

        protected void ddlWorkLGEA_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectWorkStation();
        }
    }
}