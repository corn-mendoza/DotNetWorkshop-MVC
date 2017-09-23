using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pivotal.Helper;
using System;

namespace DotNetWorkshopSample.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base(ConnectionString, throwIfV1Schema: false)
        {
        }

        public static string ConnectionString
        {
            get
            {
                try
                {
                    CFEnvironmentVariables _env = new CFEnvironmentVariables();
                    var _connect = _env.getConnectionStringForDbService("user-provided", "DefaultConnection");
                    if (!string.IsNullOrEmpty(_connect))
                    {
                        Console.WriteLine($"Using bound service connection string for data: {_connect}");
                        return _connect;
                    }
                }
                catch { }

                var _s = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                Console.WriteLine($"Using web.config connection string for data: {_s}");

                return _s;
            }
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}