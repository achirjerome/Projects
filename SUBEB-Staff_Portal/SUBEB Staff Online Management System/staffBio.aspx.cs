using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SUBEB_Staff_Online_Management_System
{
    public partial class staffBio : System.Web.UI.Page
    {
        DataSet dsregistered = new DataSet();
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (dsregistered.Tables.Contains("reg"))
            {
                dsregistered.Tables.Remove("reg");
            }
            string staffNo = string.Empty;
            if (publicClass.dbLGEA == true)
            {
                conn = new SqlConnection(conStr);
                staffNo = Request.QueryString["id"];
                conn.Open();
                //publicClass.daStudents = new OleDbDataAdapter("SELECT        tblStaffRegistration.StaffNo, tblStaffRegistration.FirstName, tblStaffRegistration.MiddleName, tblStaffRegistration.SurName, tblStaffRegistration.Sex, tblStaffRegistration.MarritalStatus, tblStaffRegistration.NoofChildren, tblStaffRegistration.DateOfBirth, tblStaffRegistration.HomeTown, tblStaffRegistration.Nationality, tblStaffRegistration.StateofOrigin, tblStaffRegistration.LGA, tblStaffRegistration.Religion, tblStaffRegistration.ContactAddress, tblStaffRegistration.PermanentAddress, tblStaffRegistration.PhoneNo, tblStaffRegistration.email, tblStaffRegistration.Qualification, tblStaffRegistration.Speciaty, tblStaffRegistration.DateofAppointment, tblStaffRegistration.JobTitle, tblStaffRegistration.GradeLevelSteps, tblStaffRegistration.BloodGroup, tblStaffRegistration.Pix, tblNextOfKin.kinCode, tblNextOfKin.FirstName AS KinFirstName, tblNextOfKin.MiddleName AS KinMidName, tblNextOfKin.SurName AS KinSurName,tblNextOfKin.HomeTown AS KinHomeTown, tblNextOfKin.LGA AS KinLGA, tblNextOfKin.StateofOrigin AS KinStateofOrigin,tblNextOfKin.Nationality AS KinNationality,   tblNextOfKin.Relationship, tblNextOfKin.ContactAddress AS KinResidence, tblNextOfKin.PhoneNo AS KinPhoneNo, tblCurrentLevel.PromotionCode, tblCurrentLevel.DateofPromotion, tblCurrentLevel.GradeLevelStep, tblCurrentLevel.Rank, tblPosting.fromDate AS DatePosted, tblPosting.toDate, tblWorkStations.SchoolName FROM (((tblStaffRegistration INNER JOIN tblNextOfKin ON tblStaffRegistration.StaffNo = tblNextOfKin.StaffNo) INNER JOIN tblCurrentLevel ON tblNextOfKin.StaffNo = tblCurrentLevel.StaffNo) INNER JOIN tblPosting ON tblCurrentLevel.StaffNo = tblPosting.StaffNo) INNER JOIN tblWorkstations ON tblPosting.WorkStation=tblWorkStations.SchoolCode", publicClass.conn);
                publicClass.daStaff = new SqlDataAdapter("SELECT tblStaffRegistration.StaffNo, tblStaffRegistration.FirstName, tblStaffRegistration.MiddleName, tblStaffRegistration.SurName, tblStaffRegistration.Sex, tblStaffRegistration.MarritalStatus, tblStaffRegistration.NoofChildren, tblStaffRegistration.DateOfBirth, tblStaffRegistration.HomeTown, tblStaffRegistration.Nationality, tblStaffRegistration.StateofOrigin, tblStaffRegistration.LGA, tblStaffRegistration.Religion, tblStaffRegistration.ContactAddress, tblStaffRegistration.PermanentAddress, tblStaffRegistration.PhoneNo, tblStaffRegistration.email, tblStaffRegistration.Qualification,tblStaffRegistration.Speciaty, tblStaffRegistration.DateofAppointment, tblStaffRegistration.JobTitle, tblStaffRegistration.BloodGroup, tblStaffRegistration.Pix, tblNextOfKin.kinCode, tblNextOfKin.FirstName AS KinFirstName, tblNextOfKin.MiddleName AS KinMidName, tblNextOfKin.SurName AS KinSurName,tblNextOfKin.HomeTown AS KinHomeTown, tblNextOfKin.LGA AS KinLGA, tblNextOfKin.StateofOrigin AS KinStateofOrigin,tblNextOfKin.Nationality AS KinNationality,   tblNextOfKin.Relationship, tblNextOfKin.ContactAddress AS KinResidence, tblNextOfKin.PhoneNo AS KinPhoneNo, tblCurrentLevel.PromotionCode, tblCurrentLevel.DateofPromotion, tblCurrentLevel.GradeLevelStep, tblCurrentLevel.Rank, tblPosting.fromDate AS DatePosted, tblPosting.Workstation, tblPix.pix FROM (((tblStaffRegistration INNER JOIN tblNextOfKin ON tblStaffRegistration.StaffNo = tblNextOfKin.StaffNo) INNER JOIN tblCurrentLevel ON tblNextOfKin.StaffNo = tblCurrentLevel.StaffNo) INNER JOIN tblPosting ON tblCurrentLevel.StaffNo = tblPosting.StaffNo) INNER JOIN tblPix ON tblStaffRegistration.StaffNo=tblPix.StaffNo WHERE tblStaffRegistration.StaffNo='" + staffNo + "'", conn);
                publicClass.daStaff.Fill(dsregistered, "reg");
                conn.Close();
            }
            else
            {
                //Hqtrs
                connHtqrs = new SqlConnection(conStrHqtrs);
                staffNo = Request.QueryString["id"];
                connHtqrs.Open();
                //publicClass.daStudents = new OleDbDataAdapter("SELECT        tblStaffRegistration.StaffNo, tblStaffRegistration.FirstName, tblStaffRegistration.MiddleName, tblStaffRegistration.SurName, tblStaffRegistration.Sex, tblStaffRegistration.MarritalStatus, tblStaffRegistration.NoofChildren, tblStaffRegistration.DateOfBirth, tblStaffRegistration.HomeTown, tblStaffRegistration.Nationality, tblStaffRegistration.StateofOrigin, tblStaffRegistration.LGA, tblStaffRegistration.Religion, tblStaffRegistration.ContactAddress, tblStaffRegistration.PermanentAddress, tblStaffRegistration.PhoneNo, tblStaffRegistration.email, tblStaffRegistration.Qualification, tblStaffRegistration.Speciaty, tblStaffRegistration.DateofAppointment, tblStaffRegistration.JobTitle, tblStaffRegistration.GradeLevelSteps, tblStaffRegistration.BloodGroup, tblStaffRegistration.Pix, tblNextOfKin.kinCode, tblNextOfKin.FirstName AS KinFirstName, tblNextOfKin.MiddleName AS KinMidName, tblNextOfKin.SurName AS KinSurName,tblNextOfKin.HomeTown AS KinHomeTown, tblNextOfKin.LGA AS KinLGA, tblNextOfKin.StateofOrigin AS KinStateofOrigin,tblNextOfKin.Nationality AS KinNationality,   tblNextOfKin.Relationship, tblNextOfKin.ContactAddress AS KinResidence, tblNextOfKin.PhoneNo AS KinPhoneNo, tblCurrentLevel.PromotionCode, tblCurrentLevel.DateofPromotion, tblCurrentLevel.GradeLevelStep, tblCurrentLevel.Rank, tblPosting.fromDate AS DatePosted, tblPosting.toDate, tblWorkStations.SchoolName FROM (((tblStaffRegistration INNER JOIN tblNextOfKin ON tblStaffRegistration.StaffNo = tblNextOfKin.StaffNo) INNER JOIN tblCurrentLevel ON tblNextOfKin.StaffNo = tblCurrentLevel.StaffNo) INNER JOIN tblPosting ON tblCurrentLevel.StaffNo = tblPosting.StaffNo) INNER JOIN tblWorkstations ON tblPosting.WorkStation=tblWorkStations.SchoolCode", publicClass.conn);
                publicClass.daStaff = new SqlDataAdapter("SELECT tblStaffRegistration.StaffNo, tblStaffRegistration.FirstName, tblStaffRegistration.MiddleName, tblStaffRegistration.SurName, tblStaffRegistration.Sex, tblStaffRegistration.MarritalStatus, tblStaffRegistration.NoofChildren, tblStaffRegistration.DateOfBirth, tblStaffRegistration.HomeTown, tblStaffRegistration.Nationality, tblStaffRegistration.StateofOrigin, tblStaffRegistration.LGA, tblStaffRegistration.Religion, tblStaffRegistration.ContactAddress, tblStaffRegistration.PermanentAddress, tblStaffRegistration.PhoneNo, tblStaffRegistration.email, tblStaffRegistration.Qualification,tblStaffRegistration.Speciaty, tblStaffRegistration.DateofAppointment, tblStaffRegistration.JobTitle, tblStaffRegistration.BloodGroup, tblStaffRegistration.Pix, tblNextOfKin.kinCode, tblNextOfKin.FirstName AS KinFirstName, tblNextOfKin.MiddleName AS KinMidName, tblNextOfKin.SurName AS KinSurName,tblNextOfKin.HomeTown AS KinHomeTown, tblNextOfKin.LGA AS KinLGA, tblNextOfKin.StateofOrigin AS KinStateofOrigin,tblNextOfKin.Nationality AS KinNationality,   tblNextOfKin.Relationship, tblNextOfKin.ContactAddress AS KinResidence, tblNextOfKin.PhoneNo AS KinPhoneNo, tblCurrentLevel.PromotionCode, tblCurrentLevel.DateofPromotion, tblCurrentLevel.GradeLevelStep, tblCurrentLevel.Rank, tblPosting.fromDate AS DatePosted, tblPosting.Workstation, tblPix.pix FROM (((tblStaffRegistration INNER JOIN tblNextOfKin ON tblStaffRegistration.StaffNo = tblNextOfKin.StaffNo) INNER JOIN tblCurrentLevel ON tblNextOfKin.StaffNo = tblCurrentLevel.StaffNo) INNER JOIN tblPosting ON tblCurrentLevel.StaffNo = tblPosting.StaffNo) INNER JOIN tblPix ON tblStaffRegistration.StaffNo=tblPix.StaffNo WHERE tblStaffRegistration.StaffNo='" + staffNo + "'", connHtqrs);
                publicClass.daStaff.Fill(dsregistered, "reg");
                connHtqrs.Close();
            }
            //string dgfg = dsregistered.Tables["reg"].Columns[25].ColumnName;
            FormView1.DataSource = dsregistered.Tables["reg"];
            FormView1.DataBind();
            Image1.ImageUrl = "~/staffPix.ashx?id=" + staffNo;
        }
    }
}