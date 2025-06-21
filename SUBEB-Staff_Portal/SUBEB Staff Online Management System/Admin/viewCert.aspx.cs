using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;

namespace SUBEB_Staff_Online_Management_System.Admin
{
    public partial class viewCert : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnViewCert_Click(object sender, EventArgs e)
        {
            DataSet dsregistered = new DataSet();
            //try
            //{
                
                //DataSet1 dsregistered = new DataSet1();
                //int ghj = dsregistered.Tables[0].Rows.Count;

                if (dsregistered.Tables.Contains("reg"))
                {
                    dsregistered.Tables.Remove("reg");
                }
                if (rbtLGEA.Checked == true)
                {
                conn = new SqlConnection(conStr);
                conn.Open();
                    //publicClass.daStudents = new OleDbDataAdapter("SELECT        tblStaffRegistration.StaffNo, tblStaffRegistration.FirstName, tblStaffRegistration.MiddleName, tblStaffRegistration.SurName, tblStaffRegistration.Sex, tblStaffRegistration.MarritalStatus, tblStaffRegistration.NoofChildren, tblStaffRegistration.DateOfBirth, tblStaffRegistration.HomeTown, tblStaffRegistration.Nationality, tblStaffRegistration.StateofOrigin, tblStaffRegistration.LGA, tblStaffRegistration.Religion, tblStaffRegistration.ContactAddress, tblStaffRegistration.PermanentAddress, tblStaffRegistration.PhoneNo, tblStaffRegistration.email, tblStaffRegistration.Qualification, tblStaffRegistration.Speciaty, tblStaffRegistration.DateofAppointment, tblStaffRegistration.JobTitle, tblStaffRegistration.GradeLevelSteps, tblStaffRegistration.BloodGroup, tblStaffRegistration.Pix, tblNextOfKin.kinCode, tblNextOfKin.FirstName AS KinFirstName, tblNextOfKin.MiddleName AS KinMidName, tblNextOfKin.SurName AS KinSurName,tblNextOfKin.HomeTown AS KinHomeTown, tblNextOfKin.LGA AS KinLGA, tblNextOfKin.StateofOrigin AS KinStateofOrigin,tblNextOfKin.Nationality AS KinNationality,   tblNextOfKin.Relationship, tblNextOfKin.ContactAddress AS KinResidence, tblNextOfKin.PhoneNo AS KinPhoneNo, tblCurrentLevel.PromotionCode, tblCurrentLevel.DateofPromotion, tblCurrentLevel.GradeLevelStep, tblCurrentLevel.Rank, tblPosting.fromDate AS DatePosted, tblPosting.toDate, tblWorkStations.SchoolName FROM (((tblStaffRegistration INNER JOIN tblNextOfKin ON tblStaffRegistration.StaffNo = tblNextOfKin.StaffNo) INNER JOIN tblCurrentLevel ON tblNextOfKin.StaffNo = tblCurrentLevel.StaffNo) INNER JOIN tblPosting ON tblCurrentLevel.StaffNo = tblPosting.StaffNo) INNER JOIN tblWorkstations ON tblPosting.WorkStation=tblWorkStations.SchoolCode", publicClass.conn);
                    publicClass.daStaff = new SqlDataAdapter("SELECT tblStaffRegistration.StaffNo, tblStaffRegistration.FirstName, tblStaffRegistration.MiddleName, tblStaffRegistration.SurName, tblStaffRegistration.Sex, tblStaffRegistration.MarritalStatus, tblStaffRegistration.NoofChildren, tblStaffRegistration.DateOfBirth, tblStaffRegistration.HomeTown, tblStaffRegistration.Nationality, tblStaffRegistration.StateofOrigin, tblStaffRegistration.LGA, tblStaffRegistration.Religion, tblStaffRegistration.ContactAddress, tblStaffRegistration.PermanentAddress, tblStaffRegistration.PhoneNo, tblStaffRegistration.email, tblStaffRegistration.Qualification,tblStaffRegistration.Speciaty, tblStaffRegistration.DateofAppointment, tblStaffRegistration.JobTitle, tblStaffRegistration.GradeLevelSteps, tblStaffRegistration.BloodGroup, tblStaffRegistration.Pix, tblNextOfKin.kinCode, tblNextOfKin.FirstName AS KinFirstName, tblNextOfKin.MiddleName AS KinMidName, tblNextOfKin.SurName AS KinSurName,tblNextOfKin.HomeTown AS KinHomeTown, tblNextOfKin.LGA AS KinLGA, tblNextOfKin.StateofOrigin AS KinStateofOrigin,tblNextOfKin.Nationality AS KinNationality,   tblNextOfKin.Relationship, tblNextOfKin.ContactAddress AS KinResidence, tblNextOfKin.PhoneNo AS KinPhoneNo, tblCurrentLevel.PromotionCode, tblCurrentLevel.DateofPromotion, tblCurrentLevel.GradeLevelStep, tblCurrentLevel.Rank, tblPosting.fromDate AS DatePosted, tblPosting.Workstation, tblPix.pix FROM (((tblStaffRegistration INNER JOIN tblNextOfKin ON tblStaffRegistration.StaffNo = tblNextOfKin.StaffNo) INNER JOIN tblCurrentLevel ON tblNextOfKin.StaffNo = tblCurrentLevel.StaffNo) INNER JOIN tblPosting ON tblCurrentLevel.StaffNo = tblPosting.StaffNo) INNER JOIN tblPix ON tblStaffRegistration.StaffNo=tblPix.StaffNo WHERE tblStaffRegistration.StaffNo='" + txtStaffNo.Text + "'", conn);
                    publicClass.daStaff.Fill(dsregistered, "reg");
                conn.Close();
                int fgh = dsregistered.Tables["reg"].Rows.Count;
                }
                else//Hqtrs
                {
                    //publicClass.connectToDB();
                    ////publicClass.daStudents = new OleDbDataAdapter("SELECT        tblStaffRegistration.StaffNo, tblStaffRegistration.FirstName, tblStaffRegistration.MiddleName, tblStaffRegistration.SurName, tblStaffRegistration.Sex, tblStaffRegistration.MarritalStatus, tblStaffRegistration.NoofChildren, tblStaffRegistration.DateOfBirth, tblStaffRegistration.HomeTown, tblStaffRegistration.Nationality, tblStaffRegistration.StateofOrigin, tblStaffRegistration.LGA, tblStaffRegistration.Religion, tblStaffRegistration.ContactAddress, tblStaffRegistration.PermanentAddress, tblStaffRegistration.PhoneNo, tblStaffRegistration.email, tblStaffRegistration.Qualification, tblStaffRegistration.Speciaty, tblStaffRegistration.DateofAppointment, tblStaffRegistration.JobTitle, tblStaffRegistration.GradeLevelSteps, tblStaffRegistration.BloodGroup, tblStaffRegistration.Pix, tblNextOfKin.kinCode, tblNextOfKin.FirstName AS KinFirstName, tblNextOfKin.MiddleName AS KinMidName, tblNextOfKin.SurName AS KinSurName,tblNextOfKin.HomeTown AS KinHomeTown, tblNextOfKin.LGA AS KinLGA, tblNextOfKin.StateofOrigin AS KinStateofOrigin,tblNextOfKin.Nationality AS KinNationality,   tblNextOfKin.Relationship, tblNextOfKin.ContactAddress AS KinResidence, tblNextOfKin.PhoneNo AS KinPhoneNo, tblCurrentLevel.PromotionCode, tblCurrentLevel.DateofPromotion, tblCurrentLevel.GradeLevelStep, tblCurrentLevel.Rank, tblPosting.fromDate AS DatePosted, tblPosting.toDate, tblWorkStations.SchoolName FROM (((tblStaffRegistration INNER JOIN tblNextOfKin ON tblStaffRegistration.StaffNo = tblNextOfKin.StaffNo) INNER JOIN tblCurrentLevel ON tblNextOfKin.StaffNo = tblCurrentLevel.StaffNo) INNER JOIN tblPosting ON tblCurrentLevel.StaffNo = tblPosting.StaffNo) INNER JOIN tblWorkstations ON tblPosting.WorkStation=tblWorkStations.SchoolCode", publicClass.conn);
                    //publicClass.daStaff = new SqlDataAdapter("SELECT tblStaffRegistration.StaffNo, tblStaffRegistration.FirstName, tblStaffRegistration.MiddleName, tblStaffRegistration.SurName, tblStaffRegistration.Sex, tblStaffRegistration.MarritalStatus, tblStaffRegistration.NoofChildren, tblStaffRegistration.DateOfBirth, tblStaffRegistration.HomeTown, tblStaffRegistration.Nationality, tblStaffRegistration.StateofOrigin, tblStaffRegistration.LGA, tblStaffRegistration.Religion, tblStaffRegistration.ContactAddress, tblStaffRegistration.PermanentAddress, tblStaffRegistration.PhoneNo, tblStaffRegistration.email, tblStaffRegistration.Qualification,tblStaffRegistration.Speciaty, tblStaffRegistration.DateofAppointment, tblStaffRegistration.JobTitle, tblStaffRegistration.GradeLevelSteps, tblStaffRegistration.BloodGroup, tblStaffRegistration.Pix, tblNextOfKin.kinCode, tblNextOfKin.FirstName AS KinFirstName, tblNextOfKin.MiddleName AS KinMidName, tblNextOfKin.SurName AS KinSurName,tblNextOfKin.HomeTown AS KinHomeTown, tblNextOfKin.LGA AS KinLGA, tblNextOfKin.StateofOrigin AS KinStateofOrigin,tblNextOfKin.Nationality AS KinNationality,   tblNextOfKin.Relationship, tblNextOfKin.ContactAddress AS KinResidence, tblNextOfKin.PhoneNo AS KinPhoneNo, tblCurrentLevel.PromotionCode, tblCurrentLevel.DateofPromotion, tblCurrentLevel.GradeLevelStep, tblCurrentLevel.Rank, tblPosting.fromDate AS DatePosted, tblPosting.Workstation, tblPix.pix FROM (((tblStaffRegistration INNER JOIN tblNextOfKin ON tblStaffRegistration.StaffNo = tblNextOfKin.StaffNo) INNER JOIN tblCurrentLevel ON tblNextOfKin.StaffNo = tblCurrentLevel.StaffNo) INNER JOIN tblPosting ON tblCurrentLevel.StaffNo = tblPosting.StaffNo) INNER JOIN tblPix ON tblStaffRegistration.StaffNo=tblPix.StaffNo WHERE tblStaffRegistration.StaffNo='" + txtStaffNo.Text + "'", publicClass.conn);
                    //publicClass.daStaff.Fill(dsregistered, "reg");
                }

            //MessageBox.Show(dsregistered.Tables["reg"].Rows.Count.ToString());
            //if (dsregistered.Tables["reg"].Rows.Count > 0)
            //{

            //}
            //int sdf = dsregistered.Tables["reg"].Rows.Count;
            //====================================================
            ReportDocument dfgg = new ReportDocument();
            dfgg.Load(Server.MapPath("~/crptCertificate.rpt"));
            
                    ////crptCertificate report = new crptCertificate();
                    dfgg.SetDataSource(dsregistered.Tables["reg"]);
                    ////report.DataSourceConnections[0].SetConnection("JeromePC", "SUBEBStaffMgtDB", "sa", "Admin1$");
                    CrystalReportViewer1.ReportSource = dfgg;
                    //=============================================
                //}
                //else
                //{
                //    crptCertificate report = new crptCertificate();
                //    report.SetDataSource(dsregistered);
                //}
            //}
            //catch(Exception ex)
            //{

            //}   
          
        }
    }
}