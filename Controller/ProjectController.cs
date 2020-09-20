using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Misc.Projects.Domain;
using Nop.Plugin.Misc.Projects.Services;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Misc.Projects.Controller
{
    public class ProjectController : BasePluginController
    {
        #region Fields
        private IProjectService _projectservice;
        #endregion
        #region Ctor

        public ProjectController(IProjectService projectService)
        {
            _projectservice = projectService;

        }
        #endregion

        #region Methods
        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        public IActionResult Index()
        {
            var model = _projectservice.GetAllProject();
            return View("~/Plugins/Misc.Projects/Views/Index.cshtml", model);
        }
        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        public IActionResult EditProject(int id)
        {
            var model = _projectservice.GetProjectById(id);
            return View("~/Plugins/Misc.Projects/Views/Edit.cshtml", model);
        }
        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        [HttpPost]
        public IActionResult EditProjectByid(Project project)
        {
            if (!ModelState.IsValid)
            {
                return  View("~/Plugins/Misc.Projects/Views/Edit.cshtml");

            }
           var prj = _projectservice.GetProjectById(project.Id);
            prj.Name = project.Name;
            prj.ShortDescription = project.ShortDescription;
            prj.FullDescription = project.FullDescription;
            prj.Published = project.Published;
            
            _projectservice.EditProject(prj);
           
            return RedirectToAction("Index");
        }
        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _projectservice.Delete(id);
            return RedirectToAction("Index");
        }
        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]

        public IActionResult Create()
        {
            return View("~/Plugins/Misc.Projects/Views/Create.cshtml");
        }
        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        [HttpPost]
        public IActionResult Create(Project project)
        {
            if (string.IsNullOrWhiteSpace(project.Name))
                ModelState.AddModelError("Name", "Name is required");
           
            if (string.IsNullOrWhiteSpace(project.ShortDescription))
                ModelState.AddModelError("ShortDescription", "ShortDescription is required");
           
            if (string.IsNullOrWhiteSpace(project.FullDescription))
                ModelState.AddModelError("FullDescription", "FullDescription is required");
            if (ModelState.IsValid)
            {
                _projectservice.InsertToDB(project);
                return View("~/Plugins/Misc.Projects/Views/SuccessMessage.cshtml", project);
                
            }
          
            return View("~/Plugins/Misc.Projects/Views/Create.cshtml", project);

            
        }

       

        public IActionResult PublishedProjects()
        {
            var model = _projectservice.PublishProject();


            return View("~/Plugins/Misc.Projects/Views/Allprojects.cshtml", model);


        }
        public IActionResult ProjectsDetails(int id)
        {


            if (_projectservice.UnPublishProject(id))
            {
                return NotFound();
            }


            var model = _projectservice.GetProjectById(id);



            return View("~/Plugins/Misc.Projects/Views/Details.cshtml", model);
        }
       
       


        #endregion
    }
}
