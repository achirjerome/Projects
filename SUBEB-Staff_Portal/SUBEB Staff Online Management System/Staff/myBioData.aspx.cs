using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SUBEB_Staff_Online_Management_System.Staff
{
    public partial class myBioData : System.Web.UI.Page
    {
        DataSet dstaffRecord = new DataSet();
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string StaffNo =HttpContext.Current.User.Identity.Name;
            conn = new SqlConnection(conStr);
            conn.Open();
            publicClass.daStaff = new SqlDataAdapter("SELECT tblStaffRegistration.StaffNo, tblStaffRegistration.SurName, tblStaffRegistration.MiddleName, tblStaffRegistration.FirstName, tblStaffRegistration.Sex, tblStaffRegistration.MarritalStatus, tblStaffRegistration.NoofChildren, tblStaffRegistration.DateofBirth, tblStaffRegistration.HomeTown, tblStaffRegistration.LGA, tblStaffRegistration.StateofOrigin, tblStaffRegistration.Nationality, tblStaffRegistration.Religion, tblStaffRegistration.ContactAddress, tblStaffRegistration.PermanentAddress, tblStaffRegistration.PhoneNo, tblStaffRegistration.Email, tblStaffRegistration.Qualification, tblStaffRegistration.Speciaty, tblStaffRegistration.DateofAppointment, tblStaffRegistration.JobTitle, tblNextOfKin.FirstName AS KinFirstName,  tblNextOfKin.MiddleName AS KinMiddleName,  tblNextOfKin.SurName AS KinSurName,  tblNextOfKin.Relationship,  tblNextOfKin.ContactAddress AS KinContact,  tblNextOfKin.PhoneNo AS KinPhoneNo,  tblPosting.WorkStation AS WorkStation, tblCurrentLevel.DateofPromotion, tblCurrentLevel.GradeLevelStep AS CurrentLevel, tblCurrentLevel.Rank FROM tblStaffRegistration INNER JOIN tblNextOfKin ON tblStaffRegistration.StaffNo = tblNextOfKin.StaffNo INNER JOIN tblPosting ON tblStaffRegistration.StaffNo = tblPosting.StaffNo INNER JOIN tblCurrentLevel ON tblStaffRegistration.StaffNo = tblCurrentLevel.StaffNo WHERE tblStaffRegistration.StaffNo='" + StaffNo + "'", conn);
            publicClass.daStaff.Fill(dstaffRecord, "record");
                        

            if (dstaffRecord.Tables["record"].Rows.Count > 0)
            {
                Image2.ImageUrl = "~/staffPix.ashx?id=" + StaffNo; 
                //DetailsView1.DataSource = dstaffRecord.Tables["record"];
                //DetailsView1.DataBind();
                lblPSN.Text = dstaffRecord.Tables["record"].Rows[0]["StaffNo"].ToString();
                lblName.Text = dstaffRecord.Tables["record"].Rows[0]["SurName"].ToString() + " " + dstaffRecord.Tables["record"].Rows[0]["FirstName"].ToString() + " " + dstaffRecord.Tables["record"].Rows[0]["MiddleName"].ToString();
                lblSex.Text= dstaffRecord.Tables["record"].Rows[0]["Sex"].ToString();
                lblMaritalStatus.Text= dstaffRecord.Tables["record"].Rows[0]["MarritalStatus"].ToString();
                lblNoofChildren.Text= dstaffRecord.Tables["record"].Rows[0]["NoofChildren"].ToString();
                lblDateofBirth.Text= dstaffRecord.Tables["record"].Rows[0]["DateofBirth"].ToString();
                lblHomeTown.Text= dstaffRecord.Tables["record"].Rows[0]["HomeTown"].ToString();
                lblLGA.Text= dstaffRecord.Tables["record"].Rows[0]["LGA"].ToString();
                lblStateofOrigin.Text= dstaffRecord.Tables["record"].Rows[0]["StateofOrigin"].ToString();
                lblNationality.Text=dstaffRecord.Tables["record"].Rows[0]["Nationality"].ToString();
                lblReligion.Text= dstaffRecord.Tables["record"].Rows[0]["Religion"].ToString();
                lblContactAddress.Text= dstaffRecord.Tables["record"].Rows[0]["ContactAddress"].ToString();
                lblPermanentAddress.Text= dstaffRecord.Tables["record"].Rows[0]["PermanentAddress"].ToString();
                lblPhoneNo.Text= dstaffRecord.Tables["record"].Rows[0]["PhoneNo"].ToString();
                lblEmail.Text= dstaffRecord.Tables["record"].Rows[0]["Email"].ToString();
                lblQualification.Text= dstaffRecord.Tables["record"].Rows[0]["Qualification"].ToString();
                lblFieldofStudy.Text= dstaffRecord.Tables["record"].Rows[0]["speciaty"].ToString();
                lblDateofAppointment.Text= dstaffRecord.Tables["record"].Rows[0]["DateofAppointment"].ToString();
                lblJobType.Text= dstaffRecord.Tables["record"].Rows[0]["JobTitle"].ToString();
                lblWorkStation.Text= dstaffRecord.Tables["record"].Rows[0]["WorkStation"].ToString();
                lblDateofLastPromotion.Text= dstaffRecord.Tables["record"].Rows[0]["DateofPromotion"].ToString();
                lblGradeLevel.Text= dstaffRecord.Tables["record"].Rows[0]["CurrentLevel"].ToString();
                lblRank.Text= dstaffRecord.Tables["record"].Rows[0]["Rank"].ToString();
                lblKinName.Text= dstaffRecord.Tables["record"].Rows[0]["kinSurName"].ToString() + " " + dstaffRecord.Tables["record"].Rows[0]["kinFirstName"].ToString() + " " + dstaffRecord.Tables["record"].Rows[0]["kinMiddleName"].ToString();
                lblRelationship.Text= dstaffRecord.Tables["record"].Rows[0]["Relationship"].ToString();
                lblKinContactAddress.Text= dstaffRecord.Tables["record"].Rows[0]["kinContact"].ToString();
                lblKinPhoneNo.Text= dstaffRecord.Tables["record"].Rows[0]["kinPhoneNo"].ToString();

                publicClass.dbLGEA = true;
            }
            else
            {
                connHtqrs = new SqlConnection(conStrHqtrs);
                connHtqrs.Open();
                publicClass.daStaff = new SqlDataAdapter("SELECT tblStaffRegistration.StaffNo, tblStaffRegistration.SurName, tblStaffRegistration.MiddleName, tblStaffRegistration.FirstName, tblStaffRegistration.Sex, tblStaffRegistration.MarritalStatus, tblStaffRegistration.NoofChildren, tblStaffRegistration.DateofBirth, tblStaffRegistration.HomeTown, tblStaffRegistration.LGA, tblStaffRegistration.StateofOrigin, tblStaffRegistration.Nationality, tblStaffRegistration.Religion, tblStaffRegistration.ContactAddress, tblStaffRegistration.PermanentAddress, tblStaffRegistration.PhoneNo, tblStaffRegistration.Email, tblStaffRegistration.Qualification, tblStaffRegistration.Speciaty, tblStaffRegistration.DateofAppointment, tblStaffRegistration.JobTitle, tblNextOfKin.FirstName AS KinFirstName,  tblNextOfKin.MiddleName AS KinMiddleName,  tblNextOfKin.SurName AS KinSurName,  tblNextOfKin.Relationship,  tblNextOfKin.ContactAddress AS KinContact,  tblNextOfKin.PhoneNo AS KinPhoneNo,  tblPosting.WorkStation AS WorkStation, tblCurrentLevel.DateofPromotion, tblCurrentLevel.GradeLevelStep AS CurrentLevel, tblCurrentLevel.Rank FROM tblStaffRegistration INNER JOIN tblNextOfKin ON tblStaffRegistration.StaffNo = tblNextOfKin.StaffNo INNER JOIN tblPosting ON tblStaffRegistration.StaffNo = tblPosting.StaffNo INNER JOIN tblCurrentLevel ON tblStaffRegistration.StaffNo = tblCurrentLevel.StaffNo WHERE tblStaffRegistration.StaffNo='" + StaffNo + "'", connHtqrs);
                publicClass.daStaff.Fill(dstaffRecord, "record");

                if (dstaffRecord.Tables["record"].Rows.Count > 0)
                {
                    Image2.ImageUrl = "~/staffPix.ashx?id=" + StaffNo;
                    //DetailsView1.DataSource = dstaffRecord.Tables["record"];
                    //DetailsView1.DataBind();
                    lblPSN.Text = dstaffRecord.Tables["record"].Rows[0]["StaffNo"].ToString();
                    lblName.Text = dstaffRecord.Tables["record"].Rows[0]["SurName"].ToString() + " " + dstaffRecord.Tables["record"].Rows[0]["FirstName"].ToString() + " " + dstaffRecord.Tables["record"].Rows[0]["MiddleName"].ToString();
                    lblSex.Text = dstaffRecord.Tables["record"].Rows[0]["Sex"].ToString();
                    lblMaritalStatus.Text = dstaffRecord.Tables["record"].Rows[0]["MarritalStatus"].ToString();
                    lblNoofChildren.Text = dstaffRecord.Tables["record"].Rows[0]["NoofChildren"].ToString();
                    lblDateofBirth.Text = dstaffRecord.Tables["record"].Rows[0]["DateofBirth"].ToString();
                    lblHomeTown.Text = dstaffRecord.Tables["record"].Rows[0]["HomeTown"].ToString();
                    lblLGA.Text = dstaffRecord.Tables["record"].Rows[0]["LGA"].ToString();
                    lblStateofOrigin.Text = dstaffRecord.Tables["record"].Rows[0]["StateofOrigin"].ToString();
                    lblNationality.Text = dstaffRecord.Tables["record"].Rows[0]["Nationality"].ToString();
                    lblReligion.Text = dstaffRecord.Tables["record"].Rows[0]["Religion"].ToString();
                    lblContactAddress.Text = dstaffRecord.Tables["record"].Rows[0]["ContactAddress"].ToString();
                    lblPermanentAddress.Text = dstaffRecord.Tables["record"].Rows[0]["PermanentAddress"].ToString();
                    lblPhoneNo.Text = dstaffRecord.Tables["record"].Rows[0]["PhoneNo"].ToString();
                    lblEmail.Text = dstaffRecord.Tables["record"].Rows[0]["Email"].ToString();
                    lblQualification.Text = dstaffRecord.Tables["record"].Rows[0]["Qualification"].ToString();
                    lblFieldofStudy.Text = dstaffRecord.Tables["record"].Rows[0]["speciaty"].ToString();
                    lblDateofAppointment.Text = dstaffRecord.Tables["record"].Rows[0]["DateofAppointment"].ToString();
                    lblJobType.Text = dstaffRecord.Tables["record"].Rows[0]["JobTitle"].ToString();
                    lblWorkStation.Text = dstaffRecord.Tables["record"].Rows[0]["WorkStation"].ToString();
                    lblDateofLastPromotion.Text = dstaffRecord.Tables["record"].Rows[0]["DateofPromotion"].ToString();
                    lblGradeLevel.Text = dstaffRecord.Tables["record"].Rows[0]["CurrentLevel"].ToString();
                    lblRank.Text = dstaffRecord.Tables["record"].Rows[0]["Rank"].ToString();
                    lblKinName.Text = dstaffRecord.Tables["record"].Rows[0]["kinSurName"].ToString() + " " + dstaffRecord.Tables["record"].Rows[0]["kinFirstName"].ToString() + " " + dstaffRecord.Tables["record"].Rows[0]["kinMiddleName"].ToString();
                    lblRelationship.Text = dstaffRecord.Tables["record"].Rows[0]["Relationship"].ToString();
                    lblKinContactAddress.Text = dstaffRecord.Tables["record"].Rows[0]["kinContact"].ToString();
                    lblKinPhoneNo.Text = dstaffRecord.Tables["record"].Rows[0]["kinPhoneNo"].ToString();

                    publicClass.dbLGEA = false;
                }
            }
        }
    }
}