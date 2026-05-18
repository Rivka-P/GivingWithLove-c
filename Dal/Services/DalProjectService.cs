using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalProjectService : DalProjectInterface
    {
        private DbManager db;

        public DalProjectService(DbManager dbm)
        {
            db = dbm;
        }

        public async Task CreateAsync(Project item)
        {
            db.Projects.Add(item);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Project item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            var project = await db.Projects
                .FirstOrDefaultAsync(x => x.ProjectCode == item.ProjectCode);

            if (project == null)
                throw new Exception("לא נמצא הפריט למחיקה");

            db.Projects.Remove(project);
            await db.SaveChangesAsync();
        }

        public async Task<Project> ReadAsync(int id)
        {
            var project = await db.Projects
                .FirstOrDefaultAsync(v => v.ProjectCode == id)
                ?? throw new ObjectNotFoundException();

            return project;
        }

        public async Task<List<Project>> ReadAsync(Func<Project, bool> func)
        {
            // EF Core לא תומך ב־Func מסונכרנת בבסיס נתונים, לכן נטען קודם ל־List
            var allProjects = await db.Projects.ToListAsync();
            return allProjects.Where(func).ToList();
        }

        public async Task<List<Project>> ReadAllAsync()
        {
            return await db.Projects.ToListAsync();
        }

        public async Task UpdateAsync(Project item)
        {
            var project = await db.Projects
                .FirstOrDefaultAsync(v => v.ProjectCode == item.ProjectCode);

            if (project == null)
                throw new Exception("Project not found");

            // עדכון שדות
            project.ProjectName = item.ProjectName;
            project.ProjectManagerCode = item.ProjectManagerCode;
            project.DomainCode = item.DomainCode;

            await db.SaveChangesAsync();
        }
    }
}