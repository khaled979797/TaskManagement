using TaskManagement.Data.Models;
using TaskManagement.Service.Context;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Service.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
