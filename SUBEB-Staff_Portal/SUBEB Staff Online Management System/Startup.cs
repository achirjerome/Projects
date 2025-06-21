using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SUBEB_Staff_Online_Management_System.Models;
using System.Data;
using System.Data.SqlClient;


[assembly: OwinStartupAttribute(typeof(SUBEB_Staff_Online_Management_System.Startup))]
namespace SUBEB_Staff_Online_Management_System
{
    public partial class Startup {
       
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            //createRolesandUsers();
        }
        DataSet dsReg = new DataSet();

        //    private void createRolesandUsers()
        //    {
        //        ApplicationDbContext context = new ApplicationDbContext();

        //        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        //        var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


        //        // In Startup iam creating first Admin Role and creating a default Admin User     
        //        if (!roleManager.RoleExists("Admin"))
        //        {

        //            // first we create Admin rool    
        //            var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //            role.Name = "Admin";
        //            roleManager.Create(role);

        //            //Here we create a Admin super user who will maintain the website                   

        //            var user = new ApplicationUser();
        //            user.UserName = "Admin";
        //            user.Email = "admin@benuesubeb@gov.ng";

        //            string userPWD = "Admin.12345";

        //            var chkUser = UserManager.Create(user, userPWD);

        //            //Add default User to Role Admin    
        //            if (chkUser.Succeeded)
        //            {
        //                var result1 = UserManager.AddToRole(user.Id, "Admin");

        //            }
        //        }
        //        // creating Staff Role    
        //        if (!roleManager.RoleExists("Staff"))
        //        {

        //            // first we create Admin role    
        //            var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //            role.Name = "Staff";
        //            roleManager.Create(role);

        //            //var user = new ApplicationUser();
        //            //user.UserName = "Admin";
        //            //user.Email = "admin@benuesubeb@gov.ng";

        //            //string userPWD = "Admin.12345";

        //            //var chkUser = UserManager.Create(user, userPWD);

        //            ////Add default User to Role Admin    
        //            //if (chkUser.Succeeded)
        //            //{
        //            //    var result1 = UserManager.AddToRole(user.Id, "Admin");

        //            //}



        //        }
        //        // creating Chairman Role    
        //        if (!roleManager.RoleExists("Chairman"))
        //        {

        //            // first we create Chairman role    
        //            var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //            role.Name = "Chairman";
        //            roleManager.Create(role);

        //            var user = new ApplicationUser();
        //            user.UserName = "702";
        //            user.Email = "utse@benuesubeb@gov.ng";

        //            string userPWD = "UTSE.12345";

        //            var chkUser = UserManager.Create(user, userPWD);

        //            //Add default User to Role Admin    
        //            if (chkUser.Succeeded)
        //            {
        //                var result1 = UserManager.AddToRole(user.Id, "Chairman");

        //            }
        //        }

        //        // creating Staff Role    
        //        if (!roleManager.RoleExists("ES"))
        //        {

        //            // first we create ES role    
        //            var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //            role.Name = "ES";
        //            roleManager.Create(role);


        //        }

        //    }
    }
}
