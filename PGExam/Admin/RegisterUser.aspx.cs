using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using DesignTemplate1.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DesignTemplate1.Admin
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection conn;
        SqlDataAdapter daReg;
        DataSet dsStates = new DataSet();
        DataSet dsReg = new DataSet();
        SqlCommand cmdSave = new SqlCommand();

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (dsReg.Tables.Contains("dept"))
            //{
            //    dsReg.Tables.Remove("dept");
            //}

            //conn = new SqlConnection(conStr);
            //conn.Open();
            //daReg = new SqlDataAdapter("SELECT department FROM tblDepartment ORDER By department", conn);
            //daReg.Fill(dsReg, "dept");
            //conn.Close();
            //ddlDepartment.DataTextField = "department";
            //ddlDepartment.DataSource = dsReg.Tables["dept"];
            //ddlDepartment.DataBind();
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {            
            SqlTransaction transac;
            conn = new SqlConnection(conStr);
            conn.Open();
            transac = conn.BeginTransaction();
             
            users new_user = new users();
            new_user.staffNo = txtStaffNo.Text;
            
            try
            {
                new_user.Department = Session["dept"].ToString();

                var userRole = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
                var userman = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                var user = new ApplicationUser() { UserName = txtStaffNo.Text, Email = txtEmail.Text };
                IdentityResult result = manager.Create(user, txtpassword.Text);

                if (result.Succeeded)
                {
                    if (!userRole.RoleExists("PGDEO"))
                    {
                        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                        role.Name = "PGDEO";
                        userRole.Create(role);
                    }


                    var findUser = userman.FindByEmail(txtEmail.Text);
                    if (!userman.IsInRole(findUser.Id, "PGDEO"))
                    {
                        var userResult = userman.AddToRole(findUser.Id, "PGDEO");
                    }
                                        
                    //IdentityHelper.RedirectToReturnUrl("~/Account/Login.aspx", Response);
                    
                }
                else
                {
                    //MsgBox(result.Errors.FirstOrDefault(), this.Page, this);
                    throw new Exception(result.Errors.FirstOrDefault());
                }

                cmdSave.CommandType = CommandType.Text;
                cmdSave.Transaction = transac;
                cmdSave.Connection = conn;
                cmdSave.CommandText = "INSERT INTO tblUsers VALUES(@staffno, @dept)";
                cmdSave.Parameters.AddWithValue("@staffno", new_user.staffNo);
                cmdSave.Parameters.AddWithValue("@dept", new_user.Department);

                int success=cmdSave.ExecuteNonQuery();
                cmdSave.Parameters.Clear();
                
                transac.Commit();

                if(success==1)
                {
                    MsgBox("User registered successfully", this.Page, this);
                    txtStaffNo.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtpassword.Text = string.Empty;
                    txtConfirmEmail.Text = string.Empty;
                }
                
            }
            catch (Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
                transac.Rollback();
            }
            conn.Close();
        }
    }
}