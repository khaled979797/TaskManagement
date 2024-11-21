using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Models;
using TaskManagement.Service.Context;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Service.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context) { }

        public async Task<List<Project>> GetAllProjects()
        {
            var projects = await GetTableNoTracking().ToListAsync();
            return projects.Count() > 0 ? projects : null!;
        }

        public async Task<Project> GetProjectById(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<string> DeleteProjectById(int id)
        {
            await BeginTransactionAsync();
            try
            {
                var project = await GetByIdAsync(id);
                if (project is null) return "NotFound";
                await DeleteAsync(project);
                await CommitAsync();
                return "Success";
            }
            catch
            {
                await RollBackAsync();
                return "Failed";
            }
        }

        public async Task<bool> IsNameExist(string name)
        {
            return await GetTableNoTracking().FirstOrDefaultAsync(x => x.Name == name) != null;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            return await GetTableNoTracking().FirstOrDefaultAsync(x => x.Name == name && x.Id != id) != null;
        }
    }
}
