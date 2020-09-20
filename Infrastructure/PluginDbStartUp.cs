using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.Misc.Projects.Data;
using Nop.Web.Framework.Infrastructure.Extensions;

namespace Nop.Plugin.Misc.Projects.Infrastructure
{
    public class PluginDbStartUp : INopStartup
    {
        public int Order => 2;

        public void Configure(IApplicationBuilder application)
        {

        }
            

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectObjectContex>(optionsBuilder=>
            {
                optionsBuilder.UseSqlServerWithLazyLoading(services);


            });
        }

    }
}
