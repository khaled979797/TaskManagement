using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Models;
using TaskManagement.Service.Context;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Service.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context) { }

        public async Task<Comment> AddComment(Comment comment)
        {
            await BeginTransactionAsync();
            try
            {
                var user = await context.Users.FindAsync(comment.UserId);
                if (user is null) return null!;
                var assignment = await context.Assignments!.FindAsync(comment.AssignmentId);
                if (assignment is null) return null!;

                var newComment = await AddAsync(comment);
                if (newComment is null) return null!;
                await CommitAsync();
                return newComment;
            }
            catch
            {
                await RollBackAsync();
                return null!;
            }
        }

        public async Task<string> DeleteComment(int id)
        {
            await BeginTransactionAsync();
            try
            {
                var comment = await GetByIdAsync(id);
                if (comment is null) return "NotFound";

                await DeleteAsync(comment);
                await CommitAsync();
                return "Success";
            }
            catch
            {
                await RollBackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditComment(Comment comment)
        {
            await BeginTransactionAsync();
            try
            {
                var user = await context.Users.FindAsync(comment.UserId);
                if (user is null) return "UserNotFound";
                var assignment = await context.Assignments!.FindAsync(comment.AssignmentId);
                if (assignment is null) return "AssignmentNotFound";

                var checkCommentExist = await GetTableNoTracking().AnyAsync(x => x.Id == comment.Id);
                if (!checkCommentExist) return "NotFound";

                await UpdateAsync(comment);
                await CommitAsync();
                return "Success";
            }
            catch
            {
                await RollBackAsync();
                return "Failed";
            }
        }

        public async Task<List<Comment>> GetAllComments(int assignmentId)
        {
            var comments = await GetTableNoTracking().Where(x => x.AssignmentId == assignmentId)
                .Include(x => x.User).OrderBy(x => x.TimeStamp).ToListAsync();
            return comments.Count() > 0 ? comments : null!;
        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await GetTableNoTracking().Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id) ?? null!;
        }
    }
}
