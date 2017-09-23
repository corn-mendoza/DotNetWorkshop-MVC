using Pivotal.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DotNetWorkshopSample.Models
{
    public class AttendeeContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public AttendeeContext() : base(ConnectionString)
        {

        }

        public static string ConnectionString
        {
            get {
                try
                {
                    CFEnvironmentVariables _env = new CFEnvironmentVariables();
                    var _connect = _env.getConnectionStringForDbService("user-provided", "AttendeeContext");
                    if (!string.IsNullOrEmpty(_connect))
                    {
                        Console.WriteLine($"Using bound service connection string for data: {_connect}");
                        return _connect;
                    }
                }
                catch { }

                var _s = System.Configuration.ConfigurationManager.ConnectionStrings["AttendeeContext"].ConnectionString;
                Console.WriteLine($"Using web.config connection string for data: {_s}");

                return _s;
            }
        }

        public System.Data.Entity.DbSet<DotNetWorkshopSample.Models.AttendeeModel> AttendeeModels { get; set; }
    }
}
