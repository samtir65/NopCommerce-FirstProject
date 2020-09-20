using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;

namespace Nop.Plugin.Misc.Projects.Infrastructure
{
    public partial class RouteProvider : IRouteProvider
    {
        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="routeBuilder">Route builder</param>
        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            //PublishedProjects
            routeBuilder.MapRoute("Plugin.Misc.Projects.PublishedProjects", "Plugins/MiscProjects/PublishedProjects",
                 new { controller = "Project", action ="PublishedProjects"});

            //ProjectsDetails
            //routeBuilder.MapRoute("Plugin.Misc.Projects.ProjectsDetails", "Plugins/MiscProjects/ProjectsDetails",
            //     new { controller = "Project", action = "ProjectsDetails"});


        }

        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        public int Priority =>3;
    }
}