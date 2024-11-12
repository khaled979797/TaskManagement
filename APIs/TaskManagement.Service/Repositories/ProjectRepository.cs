using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Models;
using TaskManagement.Service.Context;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Service.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<Project>> GetAllProjects()
        {
            return await context.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectById(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<Project> GetProjectByName(string name)
        {
            return await GetTableNoTracking().Where(x => x.Name == name).FirstOrDefaultAsync();
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

        public async Task<string> DeleteProjectByName(string name)
        {
            await BeginTransactionAsync();
            try
            {
                var project = await context.Projects.FirstOrDefaultAsync(x => x.Name == name);
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
            return await GetTableNoTracking().Where(x => x.Name == name).FirstOrDefaultAsync() != null;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            return await GetTableNoTracking().Where(x => x.Name == name && x.Id != id).FirstOrDefaultAsync() != null;
        }
    }
}
