using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Nop.Plugin.Misc.Projects.Data;
using Nop.Plugin.Misc.Projects.Domain;

namespace Nop.Plugin.Misc.Projects.Services
{
    public class ProjectService : IProjectService
    {
        private ProjectObjectContex _context;
        public ProjectService(ProjectObjectContex context)
        {
            _context = context;

        }
        public void Delete(int id)
        {
            var project = GetProjectById(id);
            Delete(project);
            _context.SaveChanges();
           
           
        }

        public void Delete(Project project)
        {
            _context.Entry(project).State = EntityState.Deleted;
        }

        public void EditProject(Project project)
        {
           
            _context.projects.Update(project);
            _context.SaveChanges();
        }

        public List<Project> GetAllProject()
        {
            return _context.projects.ToList();
               
        }

        public Project GetProjectById(int id)
        {
            return _context.projects.Find(id);
        }

        public void InsertToDB(Project project)
        {
            _context.projects.Add(project);
            _context.SaveChanges();
        }

       
        public void InsertToDB(IEnumerable<Project> projectList)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> PublishProject()
        {
          return  _context.projects.Where(p=>p.Published==true).ToList();
        }

        public bool UnPublishProject(int id)
        {
            return _context.projects.Any(p => p.Published == false && p.Id==id);
        }

        
    }
}
