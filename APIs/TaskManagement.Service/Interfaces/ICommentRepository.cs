using TaskManagement.Data.Models;

namespace TaskManagement.Service.Interfaces
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<Comment> AddComment(Comment comment);
        Task<string> EditComment(Comment comment);
        Task<string> DeleteComment(int id);
        Task<List<Comment>> GetAllComments(int assignmentId);
        Task<Comment> GetCommentById(int id);
    }
}
