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
    }
}
