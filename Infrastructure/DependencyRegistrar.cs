using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Core;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Plugin.Misc.Projects.Domain;
using Nop.Plugin.Misc.Projects.Services;


namespace Nop.Plugin.Misc.Projects.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            //builder.RegisterType<ProjectService>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ProjectService>().As<IProjectService>();
            builder.RegisterType<EfRepository<Project>>().As<IRepository<Project>>().
                WithParameter(ResolvedParameter.ForNamed<IDbContext>("nop_object_context_project")).
                InstancePerLifetimeScope();
        }
        public int Order => 1;
    }
}
