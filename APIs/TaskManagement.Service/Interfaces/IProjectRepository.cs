using TaskManagement.Data.Models;

namespace TaskManagement.Service.Interfaces
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<List<Project>> GetAllProjects();
        Task<Project> GetProjectById(int id);
        Task<Project> GetProjectByName(string name);
        Task<string> DeleteProjectById(int id);
        Task<string> DeleteProjectByName(string name);
        Task<bool> IsNameExist(string name);
        Task<bool> IsNameExistExcludeSelf(string name, int id);
    }
}
