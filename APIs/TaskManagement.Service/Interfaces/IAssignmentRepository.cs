using TaskManagement.Data.Models;

namespace TaskManagement.Service.Interfaces
{
    public interface IAssignmentRepository : IGenericRepository<Assignment>
    {
        Task<Assignment> AddAssignment(Assignment assignment);
        Task<List<Assignment>> GetAllAssignments();
        Task<List<Assignment>> GetAllAssignmentsByUser(int id);
        Task<Assignment> GetAssignmentById(int id);
        Task<string> EditAssignment(Assignment assignment);
        Task<string> DeleteAssignmentById(int id);
        Task<Assignment> MarkAssignmentCompleted(int id);
        Task<Assignment> MarkAssignmentUncompleted(int id);
        Task<bool> IsTitleExist(string title);
        Task<bool> IsTitleExistExcludeSelf(string title, int id);
    }
}
