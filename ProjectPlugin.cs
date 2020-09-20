using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core;
using Nop.Plugin.Misc.Projects.Data;
using Nop.Services.Plugins;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Misc.Projects
{

    public class ProjectPlugin : BasePlugin, IAdminMenuPlugin
    {
        private ProjectObjectContex _objectContex;
        private IWebHelper _webHelper;
        public ProjectPlugin(ProjectObjectContex objectContex, IWebHelper webHelper)
        {
            _objectContex = objectContex;
            _webHelper = webHelper;
        }
        public override void Install()
        {
            _objectContex.Install();
            base.Install();
        }

        public override void Uninstall()
        {
            _objectContex.Uninstall();
            base.Uninstall();
        }
        public void ManageSiteMap(SiteMapNode rootNode)
        {
            rootNode.ChildNodes.Add(new SiteMapNode
            {
                Title = "Project",
                Visible = true,
                IconClass = "list of project",
                ChildNodes = new List<SiteMapNode>
                 { new SiteMapNode { Url = $"{_webHelper.GetStoreLocation()}Admin/Project/Index", Title="List of projects", Visible=true, }
                  , new SiteMapNode { Title="Create New project", Url=$"{_webHelper.GetStoreLocation()}Admin/Project/Create", Visible=true, }
                    }
            
            });
        }
    }
}
