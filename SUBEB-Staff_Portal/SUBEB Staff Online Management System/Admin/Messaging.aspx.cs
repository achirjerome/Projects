using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SUBEB_Staff_Online_Management_System.Admin
{
    public partial class Messaging : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string conStrHqtrs = ConfigurationManager.ConnectionStrings["HqtrsConnection"].ConnectionString;
        SqlConnection connHtqrs;
        SqlConnection conn;
        DataSet dsMesaage = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            lblMsg.Text = string.Empty;
            if(dsMesaage.Tables.Contains("msg"))
            {
                dsMesaage.Tables.Remove("msg");
            }
            if (rbtLGEA.Checked == true)
            {
                conn = new SqlConnection(conStr);
                conn.Open();
                publicClass.daStaff = new SqlDataAdapter("Select Surname + ' ' + Firstname AS Name, PhoneNo from tblstaffRegistration WHERE staffNo='" + txtStaffNo.Text + "'", conn);
                publicClass.daStaff.Fill(dsMesaage, "msg");
                conn.Close();

                if (dsMesaage.Tables["msg"].Rows.Count ==1)
                {
                    string phonNo = dsMesaage.Tables["msg"].Rows[0]["PhoneNo"].ToString();
                    lblName.Text= dsMesaage.Tables["msg"].Rows[0]["Name"].ToString();
                    lblPhoneNo.Text = phonNo;
                }
                else
                {
                    lblMsg.Text = "No record found";
                }
            }
            else
            {
                connHtqrs = new SqlConnection(conStrHqtrs);
                connHtqrs.Open();
                publicClass.daStaff = new SqlDataAdapter("Select Surname + ' ' + Firstname AS Name, PhoneNo from tblstaffRegistration WHERE staffNo='" + txtStaffNo.Text + "'", connHtqrs);
                publicClass.daStaff.Fill(dsMesaage, "msg");
                connHtqrs.Close();

                if (dsMesaage.Tables["msg"].Rows.Count == 1)
                {
                    string phonNo =  dsMesaage.Tables["msg"].Rows[0]["PhoneNo"].ToString();
                    lblName.Text = dsMesaage.Tables["msg"].Rows[0]["Name"].ToString();
                    lblPhoneNo.Text = phonNo;
                }
                else
                {
                    lblMsg.Text = "No record found";
                }
            }
            
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = string.Empty;
                if (lblPhoneNo.Text != string.Empty && txtMsg.Text != string.Empty)
                {
                    sendText newText = new sendText();
                    newText.sendSMS(lblPhoneNo.Text, txtMsg.Text);
                    lblMsg.Text = "Message sent successfully";
                }
            }
            catch(Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
    }
}