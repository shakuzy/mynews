using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mynewsreally.Areas.Identity.Data;
using mynewsreally.Data;

[assembly: HostingStartup(typeof(mynewsreally.Areas.Identity.IdentityHostingStartup))]
namespace mynewsreally.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<mynewsreallyContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("mynewsreallyContextConnection")));

                services.AddDefaultIdentity<mynewsreallyUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<mynewsreallyContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders(); 

                    
            });
        }
    }
}