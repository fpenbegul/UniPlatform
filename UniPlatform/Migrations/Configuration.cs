namespace UniPlatform.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UniPlatform.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<UniPlatform.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!roleManager.RoleExists("admin"))
            {
                roleManager.Create(new IdentityRole() { Name = "admin" });
            }
            if (!roleManager.RoleExists("user"))
            {
                roleManager.Create(new IdentityRole() { Name = "user" });
            }
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var adminUser = userManager.FindByName("admin");

            if (adminUser == null)
            {
                adminUser = new ApplicationUser()
                {
                    UserName = "admin@a.com",
                    Email = "admin@a.com"
                };
                userManager.Create(adminUser, "Ankara1.");
            }
            if (!userManager.IsInRole(adminUser.Id, "admin"))
            {
                userManager.AddToRole(adminUser.Id, "admin");
            }


        }
    }
}
