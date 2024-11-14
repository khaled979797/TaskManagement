using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Data.Models;

namespace TaskManagement.Service.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(x => x.Assignment).WithMany(x => x.Comments).HasForeignKey(x => x.AssignmentId);
        }
    }
}
