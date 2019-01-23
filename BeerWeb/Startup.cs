using BeerWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeerWeb.Startup))]
namespace BeerWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();

        }

        // In this method we will create default User roles and Admin user for login   
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin role  
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Create product Manager role
                role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "ProductManager";
                roleManager.Create(role);



                var user = new ApplicationUser();
                user.UserName = "stefan.holmberg@nackademin.se";
                user.Email = "stefan.holmberg@nackademin.se";
                string userPWD = "!1Bananskal";
                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded) UserManager.AddToRole(user.Id, "Admin");

                user = new ApplicationUser();
                user.UserName = "dennis.nordstrom@nackademin.se";
                user.Email = "dennis.nordstrom@nackademin.se";
                userPWD = "!1Bananskal";
                chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded) UserManager.AddToRole(user.Id, "ProductManager");

            }
        }
    }
}
