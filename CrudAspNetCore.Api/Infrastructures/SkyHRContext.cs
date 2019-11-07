using CrudAspNetCore.Api.Models;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAspNetCore.Api.Infrastructures
{
    public class SkyHRContext : DbContext
    {
        public SkyHRContext(DbContextOptions<SkyHRContext> options)
          : base(options)
        {
            //if (host.IsDevelopment()) return;

            var conn = (SqlConnection)Database.GetDbConnection();
            conn.AccessToken = (new AzureServiceTokenProvider())
                .GetAccessTokenAsync("https://database.windows.net/").Result;
            Database.EnsureCreated();
        }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);
        //     // Customize the ASP.NET Identity model and override the defaults if needed.
        //     // For example, you can rename the ASP.NET Identity table names and more.
        //     // Add your customizations after calling base.OnModelCreating(builder);
        // }
        public DbSet<Employee> Employees { get; set; }
    }
}
