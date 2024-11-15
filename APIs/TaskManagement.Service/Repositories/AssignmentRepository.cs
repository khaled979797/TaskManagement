﻿using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Models;
using TaskManagement.Service.Context;
using TaskManagement.Service.Interfaces;

namespace TaskManagement.Service.Repositories
{
    public class AssignmentRepository : GenericRepository<Assignment>, IAssignmentRepository
    {

        public AssignmentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Assignment> AddAssignment(Assignment assignment)
        {
            await BeginTransactionAsync();
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == assignment.UserId);
                if (user is null) return null!;
                var project = await context.Projects!.FirstOrDefaultAsync(x => x.Id == assignment.ProjectId);
                if (project is null) return null!;

                var newAssignment = await AddAsync(assignment);
                if (newAssignment is null) return null!;
                await CommitAsync();
                return newAssignment;
            }
            catch
            {
                await RollBackAsync();
                return null!;
            }
        }

        public async Task<string> DeleteAssignmentById(int id)
        {
            var assignment = await GetByIdAsync(id);
            if (assignment is null) return "NotFound";

            await BeginTransactionAsync();
            try
            {
                await DeleteAsync(assignment);
                await CommitAsync();
                return "Success";
            }
            catch
            {
                await RollBackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAssignment(Assignment assignment)
        {
            await BeginTransactionAsync();
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == assignment.UserId);
                if (user is null) return "UserNotFound";
                var project = await context.Projects!.FirstOrDefaultAsync(x => x.Id == assignment.ProjectId);
                if (project is null) return "ProjectNotFound";

                var checkAssignmentExist = await GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == assignment.Id);
                if (checkAssignmentExist is null) return "NotFound";

                await UpdateAsync(assignment);
                await CommitAsync();
                return "Success";
            }
            catch
            {
                await RollBackAsync();
                return "Failed";
            }
        }

        public async Task<List<Assignment>> GetAllAssignments()
        {
            return await GetTableNoTracking().Include(x => x.User).Include(x => x.Project)
                .Include(x => x.Comments)!.ThenInclude(x => x.User)
                .Include(x => x.Attachments)!.ThenInclude(x => x.User).ToListAsync();
        }

        public async Task<Assignment> GetAssignmentById(int id)
        {
            return await GetTableNoTracking().Include(x => x.User).Include(x => x.Project)
                .Include(x => x.Comments)!.ThenInclude(x => x.User)
                .Include(x => x.Attachments)!.ThenInclude(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id) ?? null!;
        }

        public async Task<bool> IsTitleExist(string title)
        {
            return await GetTableNoTracking().FirstOrDefaultAsync(x => x.Title == title) != null;
        }

        public async Task<bool> IsTitleExistExcludeSelf(string title, int id)
        {
            return await GetTableNoTracking().FirstOrDefaultAsync(x => x.Title == title && x.Id != id) != null;
        }
    }
}
