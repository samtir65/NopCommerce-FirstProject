using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nop.Plugin.Misc.Projects.Domain;

namespace Nop.Plugin.Misc.Projects.Services
{
    public interface IProjectService
    {
         Project GetProjectById(int id);
        List<Project> GetAllProject();
        void InsertToDB(Project project);
        void InsertToDB(IEnumerable<Project> projectList);
        void Delete(int id);
        void Delete(Project project);
        void EditProject(Project project);
        IEnumerable<Project>PublishProject();
        bool UnPublishProject(int id);





    }
}
