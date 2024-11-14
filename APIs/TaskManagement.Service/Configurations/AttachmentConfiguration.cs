using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Data.Models;

namespace TaskManagement.Service.Configurations
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.HasOne(x => x.Assignment).WithMany(x => x.Attachments).HasForeignKey(x => x.AssignmentId);
        }
    }
}
